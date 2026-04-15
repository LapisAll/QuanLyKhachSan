using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PhongBUS
    {
        // 1. Khai báo biến dal để kết nối với tầng DAL (Sửa lỗi CS0103)
        private PhongDAL dal = new PhongDAL();

        // 2. Sử dụng biến dal để gọi các hàm từ tầng DAL
        public List<PhongDTO> GetAllRooms() => dal.GetAllRooms();

        public PhongDTO GetRoomById(int maPhong) => dal.GetRoomById(maPhong);

        // 3. Chỉ giữ lại 1 hàm UpdateRoom duy nhất (Sửa lỗi CS0111 và CS0121)
        public bool UpdateRoom(PhongDTO phong)
        {
            if (phong.MaPhong <= 0) return false;
            return dal.UpdateRoom(phong);
        }

        // 4. Hàm thêm phòng (Sử dụng hàm InsertRoom từ DAL)
        public bool InsertRoom(PhongDTO p)
        {
            if (string.IsNullOrWhiteSpace(p.TenPhong) || p.GiaPhong < 0)
                return false;

            return dal.InsertRoom(p);
        }

        // 5. Các hàm lọc dữ liệu
        public List<PhongDTO> GetAvailableRooms()
            => dal.GetAllRooms().Where(p => p.TrangThaiPhong == "Available").ToList();

        public bool ChangeRoomStatus(int maPhong, string newStatus)
        {
            var room = GetRoomById(maPhong);
            if (room != null)
            {
                room.TrangThaiPhong = newStatus;
                return dal.UpdateRoom(room);
            }
            return false;
        }
    }
}