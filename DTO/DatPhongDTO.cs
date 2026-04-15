using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DatPhongDTO
    {
        public int MaDatPhong { get; set; }
        public int MaKhach { get; set; }
        public int MaPhong { get; set; }
        public DateTime NgayCheckIn { get; set; }
        public DateTime NgayCheckOut { get; set; }
        public int SoNguoiLon { get; set; }
        public int SoTreEm { get; set; }
        public string GhiChu { get; set; }
        public string TrangThai { get; set; } // Pending, Confirmed, Checked-In, Checked-Out
    }
}
