using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public static class MockDatabase
    {
        public static List<PhongDTO> DanhSachPhong { get; set; } = new List<PhongDTO>();
        public static List<KhachHangDTO> DanhSachKhachHang { get; set; } = new List<KhachHangDTO>();
        public static List<DatPhongDTO> DanhSachDatPhong { get; set; } = new List<DatPhongDTO>();
        public static List<HoaDonDTO> DanhSachHoaDon { get; set; } = new List<HoaDonDTO>();
        public static List<DTO.NhanVienDTO> DanhSachTaiKhoan { get; set; } = new List<DTO.NhanVienDTO>();

        public static void InitializeData()
        {
            // Sample rooms
            DanhSachPhong = new List<PhongDTO>
            {
                new PhongDTO { MaPhong = 101, TenPhong = "Phòng 101", LoaiPhong = "Đơn", GiaPhong = 500000, TrangThaiPhong = "Available", SoGiuong = 1, DienTich = 20 },
                new PhongDTO { MaPhong = 102, TenPhong = "Phòng 102", LoaiPhong = "Đôi", GiaPhong = 800000, TrangThaiPhong = "Available", SoGiuong = 2, DienTich = 30 },
                new PhongDTO { MaPhong = 103, TenPhong = "Phòng 103", LoaiPhong = "VIP", GiaPhong = 1500000, TrangThaiPhong = "Occupied", SoGiuong = 2, DienTich = 50 },
                new PhongDTO { MaPhong = 201, TenPhong = "Phòng 201", LoaiPhong = "Đơn", GiaPhong = 500000, TrangThaiPhong = "Dirty", SoGiuong = 1, DienTich = 20 },
                new PhongDTO { MaPhong = 202, TenPhong = "Phòng 202", LoaiPhong = "Đôi", GiaPhong = 800000, TrangThaiPhong = "Available", SoGiuong = 2, DienTich = 30 },
                new PhongDTO { MaPhong = 203, TenPhong = "Phòng 203", LoaiPhong = "VIP", GiaPhong = 1500000, TrangThaiPhong = "Available", SoGiuong = 2, DienTich = 50 }
            };

            // Sample guests
            DanhSachKhachHang = new List<KhachHangDTO>
            {
                new KhachHangDTO { MaKhach = 1, TenKhach = "Nguyễn Văn A", SoCMND = "001122334455", SoDienThoai = "0987654321", Email = "a@example.com", DiaChi = "Hà Nội" },
                new KhachHangDTO { MaKhach = 2, TenKhach = "Trần Thị B", SoCMND = "001122334456", SoDienThoai = "0912345678", Email = "b@example.com", DiaChi = "TP HCM" }
            };
        }

        // ROOM OPERATIONS
        public static List<PhongDTO> GetAllRooms() => DanhSachPhong;

        public static PhongDTO GetRoomById(int maPhong) => DanhSachPhong.FirstOrDefault(p => p.MaPhong == maPhong);

        public static bool UpdateRoom(PhongDTO phong)
        {
            var room = GetRoomById(phong.MaPhong);
            if (room != null)
            {
                room.TrangThaiPhong = phong.TrangThaiPhong;
                room.GiaPhong = phong.GiaPhong;
                room.LoaiPhong = phong.LoaiPhong;
                return true;
            }
            return false;
        }

        public static bool AddRoom(PhongDTO phong)
        {
            if (GetRoomById(phong.MaPhong) == null)
            {
                DanhSachPhong.Add(phong);
                return true;
            }
            return false;
        }

        // GUEST OPERATIONS
        public static List<KhachHangDTO> GetAllGuests() => DanhSachKhachHang;

        public static KhachHangDTO GetGuestById(int maKhach) => DanhSachKhachHang.FirstOrDefault(k => k.MaKhach == maKhach);

        public static bool AddGuest(KhachHangDTO khach)
        {
            if (DanhSachKhachHang.FirstOrDefault(k => k.SoCMND == khach.SoCMND) == null)
            {
                khach.MaKhach = DanhSachKhachHang.Count > 0 ? DanhSachKhachHang.Max(k => k.MaKhach) + 1 : 1;
                DanhSachKhachHang.Add(khach);
                return true;
            }
            return false;
        }

        public static bool UpdateGuest(KhachHangDTO khach)
        {
            var guest = GetGuestById(khach.MaKhach);
            if (guest != null)
            {
                guest.TenKhach = khach.TenKhach;
                guest.SoDienThoai = khach.SoDienThoai;
                guest.Email = khach.Email;
                guest.DiaChi = khach.DiaChi;
                return true;
            }
            return false;
        }

        // BOOKING OPERATIONS
        public static List<DatPhongDTO> GetAllBookings() => DanhSachDatPhong;

        public static DatPhongDTO GetBookingById(int maDatPhong) => DanhSachDatPhong.FirstOrDefault(d => d.MaDatPhong == maDatPhong);

        public static bool AddBooking(DatPhongDTO datPhong)
        {
            datPhong.MaDatPhong = DanhSachDatPhong.Count > 0 ? DanhSachDatPhong.Max(d => d.MaDatPhong) + 1 : 1;
            DanhSachDatPhong.Add(datPhong);
            return true;
        }

        public static bool UpdateBooking(DatPhongDTO datPhong)
        {
            var booking = GetBookingById(datPhong.MaDatPhong);
            if (booking != null)
            {
                booking.TrangThai = datPhong.TrangThai;
                booking.NgayCheckIn = datPhong.NgayCheckIn;
                booking.NgayCheckOut = datPhong.NgayCheckOut;
                return true;
            }
            return false;
        }

        // INVOICE OPERATIONS
        public static List<HoaDonDTO> GetAllInvoices() => DanhSachHoaDon;

        public static HoaDonDTO GetInvoiceById(int maHoaDon) => DanhSachHoaDon.FirstOrDefault(h => h.MaHoaDon == maHoaDon);

        public static bool AddInvoice(HoaDonDTO hoaDon)
        {
            hoaDon.MaHoaDon = DanhSachHoaDon.Count > 0 ? DanhSachHoaDon.Max(h => h.MaHoaDon) + 1 : 1;
            DanhSachHoaDon.Add(hoaDon);
            return true;
        }

        public static bool LuuTaiKhoan(DTO.NhanVienDTO nv)
        {
            if (DanhSachTaiKhoan.Any(x => x.TenDangNhap == nv.TenDangNhap)) return false;
            DanhSachTaiKhoan.Add(nv);
            return true;
        }
    }
}
