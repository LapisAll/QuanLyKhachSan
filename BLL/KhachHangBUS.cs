using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KhachHangBUS
    {
        public List<KhachHangDTO> GetAllGuests() => KhachHangDAL.GetAllGuests();

        public KhachHangDTO GetGuestById(int maKhach) => KhachHangDAL.GetGuestById(maKhach);

        public bool AddGuest(KhachHangDTO khach)
        {
            if (string.IsNullOrWhiteSpace(khach.TenKhach))
                throw new Exception("Tên khách hàng không được trống!");

            if (string.IsNullOrWhiteSpace(khach.SoCMND) || khach.SoCMND.Length < 9)
                throw new Exception("Số CMND phải có ít nhất 9 ký tự!");

            if (string.IsNullOrWhiteSpace(khach.SoDienThoai) || khach.SoDienThoai.Length < 10)
                throw new Exception("Số điện thoại phải có ít nhất 10 ký tự!");

            if (!IsValidEmail(khach.Email))
                throw new Exception("Email không hợp lệ!");

            return KhachHangDAL.AddGuest(khach);
        }

        public bool UpdateGuest(KhachHangDTO khach)
        {
            if (khach.MaKhach <= 0)
                throw new Exception("Mã khách hàng không hợp lệ!");

            if (string.IsNullOrWhiteSpace(khach.TenKhach))
                throw new Exception("Tên khách hàng không được trống!");

            return KhachHangDAL.UpdateGuest(khach);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteGuest(int maKhach)
        {
            return DAL.KhachHangDAL.DeleteGuest(maKhach);
        }
    }
}
