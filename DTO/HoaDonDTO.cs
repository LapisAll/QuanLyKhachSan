using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public int MaHoaDon { get; set; }
        public int MaDatPhong { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal SoTienPhong { get; set; }
        public decimal SoTienDichVu { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThaiTT { get; set; } // Unpaid, Paid
        public string TenKhachHang { get; set; }
        public string SoCMND { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayCheckIn { get; set; }
        public DateTime NgayCheckOut { get; set; }
    }
}
