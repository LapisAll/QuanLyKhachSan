using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Windows.Forms;

namespace BLL
{
    public class NhanVienBUS
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public string TaoMatKhauNgauNhien()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string DoiMatKhau(string username, string oldPass, string newPass, string confirmPass)
        {
            if (string.IsNullOrWhiteSpace(oldPass) || string.IsNullOrWhiteSpace(newPass))
                return "Mật khẩu không được để trống!";

            if (newPass != confirmPass)
                return "Xác nhận mật khẩu mới không khớp!";

            if (newPass.Length < 6)
                return "Mật khẩu mới phải có ít nhất 6 ký tự!";

            // SỬA LỖI TẠI ĐÂY: Lấy đối tượng DTO thay vì string
            NhanVienDTO nv = dal.GetNhanVienByUsername(username);

            if (nv == null || nv.MatKhau.Trim() != oldPass.Trim())
                return "Mật khẩu cũ không chính xác!";

            if (dal.UpdatePassword(username, newPass))
            {
                return "Thành công";
            }

            return "Lỗi hệ thống, vui lòng thử lại sau!";
        }

        public bool DangKy(NhanVienDTO nv)
        {
            if (string.IsNullOrEmpty(nv.TenDangNhap) || nv.TenDangNhap.Length < 3)
                return false;

            if (string.IsNullOrEmpty(nv.MatKhau))
                return false;

            // SỬA LỖI TẠI ĐÂY: Kiểm tra xem tài khoản đã tồn tại chưa
            NhanVienDTO existingUser = dal.GetNhanVienByUsername(nv.TenDangNhap);
            if (existingUser != null)
            {
                return false; // Tài khoản đã tồn tại
            }

            return dal.InsertNhanVien(nv);
        }

        public bool KiemTraDangNhap(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return false;

            // SỬA LỖI TẠI ĐÂY: Lấy đối tượng và gán vào Session để phân quyền
            NhanVienDTO nv = dal.GetNhanVienByUsername(user.Trim());

            if (nv != null && nv.MatKhau.Trim() == pass.Trim())
            {
                // LƯU VÀO SESSION (Đảm bảo lớp Session đã thêm thuộc tính Role)
                DTO.Session.Username = nv.TenDangNhap;
                DTO.Session.Role = nv.Role;

                return true;
            }
            return false;
        }

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            return dal.GetAllNhanVien();
        }
    }
}