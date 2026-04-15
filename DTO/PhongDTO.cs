using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongDTO
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string LoaiPhong { get; set; }
        public decimal GiaPhong { get; set; }
        public string TrangThaiPhong { get; set; } // Available, Occupied, Dirty
        public int SoGiuong { get; set; }
        public int DienTich { get; set; }
    }
}
