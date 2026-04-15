using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace thuchanhcuoiky
{
    public partial class FrmRegister : Form
    {
        // Khởi tạo lớp nghiệp vụ
        private NhanVienBUS nvBUS = new NhanVienBUS();

        public FrmRegister()
        {
            InitializeComponent();
            // Gán sự kiện
            this.btnCreatePass.Click += btnCreatePass_Click;
            this.btnRegister.Click += btnRegister_Click;
            this.linkLabel1.Click += (s, e) => this.Close(); // Quay lại đăng nhập
        }

        // 1. Chức năng tạo mật khẩu ngẫu nhiên
        private void btnCreatePass_Click(object sender, EventArgs e)
        {
            // Gọi hàm sinh mật khẩu từ BLL
            string randomPass = nvBUS.TaoMatKhauNgauNhien();
            txtPassword.Text = randomPass;

            // Hiện mật khẩu để admin có thể chép lại gửi cho nhân viên
            txtPassword.UseSystemPasswordChar = false;
            MessageBox.Show("Mật khẩu mới đã được tạo: " + randomPass, "Thông báo");
        }

        // 2. Chức năng Đăng ký
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng sơ bộ
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng và tạo mật khẩu!");
                return;
            }

            // Đóng gói dữ liệu
            NhanVienDTO nv = new NhanVienDTO
            {
                TenDangNhap = txtUser.Text.Trim(),
                MatKhau = txtPassword.Text, // Mật khẩu đã tạo
                Email = txtEmail.Text.Trim(),
                SoDienThoai = txtPhoneNumber.Text.Trim()
            };

            // Gọi BLL xử lý
            if (nvBUS.DangKy(nv))
            {
                MessageBox.Show("Đăng ký tài khoản nhân viên thành công!", "Thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Tên đăng nhập có thể đã tồn tại.", "Lỗi");
            }
        }
    }
}
