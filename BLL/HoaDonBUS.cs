using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class HoaDonBUS
    {
        private DatPhongBUS datPhongBUS = new DatPhongBUS();

        public List<HoaDonDTO> GetAllInvoices() => HoaDonDAL.GetAllInvoices();

        public HoaDonDTO GetInvoiceById(int maHD)
        {
            return HoaDonDAL.GetInvoiceById(maHD);
        }

        public bool CreateInvoice(HoaDonDTO hoaDon)
        {
            if (hoaDon.MaDatPhong <= 0)
                throw new Exception("Mã đặt phòng không hợp lệ!");

            if (hoaDon.SoTienPhong < 0 || hoaDon.SoTienDichVu < 0)
                throw new Exception("Số tiền không được âm!");

            hoaDon.TongTien = hoaDon.SoTienPhong + hoaDon.SoTienDichVu;

            return HoaDonDAL.AddInvoice(hoaDon);
        }

        public decimal CalculateTotalCost(int maDatPhong, decimal giaDayPhong)
        {
            var booking = datPhongBUS.GetBookingById(maDatPhong);
            if (booking != null)
            {
                int nights = (int)(booking.NgayCheckOut - booking.NgayCheckIn).TotalDays;
                return giaDayPhong * nights;
            }
            return 0;
        }
    }
}
