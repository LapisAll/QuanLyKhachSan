using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DatPhongBUS
    {
        private PhongBUS phongBUS = new PhongBUS();
        private KhachHangBUS khachHangBUS = new KhachHangBUS();

        public List<DatPhongDTO> GetAllBookings() => DatPhongDAL.GetAllBookings();

        public DatPhongDTO GetBookingById(int maDatPhong) => DatPhongDAL.GetBookingById(maDatPhong);

        public bool CreateBooking(DatPhongDTO datPhong)
        {
            if (datPhong.NgayCheckOut <= datPhong.NgayCheckIn)
                throw new Exception("Ngày check-out phải sau ngày check-in!");

            if ((datPhong.NgayCheckOut - datPhong.NgayCheckIn).TotalHours < 1)
                throw new Exception("Thời gian lưu trú tối thiểu phải là 1 tiếng!");

            var room = phongBUS.GetRoomById(datPhong.MaPhong);
            if (room == null)
                throw new Exception("Phòng không tồn tại!");

            if (room.TrangThaiPhong != "Available")
                throw new Exception("Phòng không còn trống!");

            var guest = khachHangBUS.GetGuestById(datPhong.MaKhach);
            if (guest == null)
                throw new Exception("Khách hàng không tồn tại!");

            if (datPhong.SoNguoiLon <= 0)
                throw new Exception("Số người lớn phải lớn hơn 0!");

            if (DatPhongDAL.AddBooking(datPhong))
            {
                phongBUS.ChangeRoomStatus(datPhong.MaPhong, "Occupied");
                return true;
            }

            return false;
        }

        public bool UpdateBooking(DatPhongDTO datPhong)
        {
            if (datPhong.NgayCheckOut <= datPhong.NgayCheckIn)
                throw new Exception("Ngày check-out phải sau ngày check-in!");

            // Nên thêm kiểm tra 1 tiếng ở đây nếu bạn muốn đồng bộ
            if ((datPhong.NgayCheckOut - datPhong.NgayCheckIn).TotalHours < 1)
                throw new Exception("Thời gian lưu trú tối thiểu phải là 1 tiếng!");

            return DatPhongDAL.UpdateBooking(datPhong);
        }

        public bool CheckOut(int maDatPhong)
        {
            var booking = GetBookingById(maDatPhong);
            if (booking != null)
            {
                booking.TrangThai = "Checked-Out";
                phongBUS.ChangeRoomStatus(booking.MaPhong, "Dirty");
                return DatPhongDAL.UpdateBooking(booking);
            }
            return false;
        }
        public bool DeleteBooking(int maDatPhong)
        {
            // Gọi trực tiếp hàm static từ lớp DatPhongDAL
            return DAL.DatPhongDAL.DeleteBooking(maDatPhong);
        }
        public List<DatPhongDTO> GetActiveBookings()
            => DatPhongDAL.GetAllBookings().Where(d => d.TrangThai == "Confirmed" || d.TrangThai == "Checked-In").ToList();
    }
}

