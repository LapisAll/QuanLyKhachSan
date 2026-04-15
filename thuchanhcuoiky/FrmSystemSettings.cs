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
    public partial class FrmSystemSettings : Form
    {
        // Khởi tạo BUS để tương tác với cơ sở dữ liệu nhân viên
        private NhanVienBUS nvBUS = new NhanVienBUS();

        public FrmSystemSettings()
        {
            InitializeComponent();

            // Đăng ký sự kiện Click cho các nút bấm
            btnCreateAdmin.Click += BtnCreateAdmin_Click;
            btnSaveGeneral.Click += BtnSaveGeneral_Click;
        }

        // CHỨC NĂNG: TẠO TÀI KHOẢN ADMIN MỚI
        private void BtnCreateAdmin_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtAdminUser.Text) || string.IsNullOrWhiteSpace(txtAdminPass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Đóng gói dữ liệu vào DTO (Ép quyền là Admin)
            NhanVienDTO newAdmin = new NhanVienDTO
            {
                TenDangNhap = txtAdminUser.Text.Trim(),
                MatKhau = txtAdminPass.Text, // Mật khẩu quản trị
                Role = "Admin",             // ĐỊNH DANH QUYỀN CAO NHẤT
                Email = "admin@hotel.com",  // Giá trị mặc định hoặc bổ sung ô nhập
                SoDienThoai = "0000000000"
            };

            // 3. Gọi BUS để thực hiện đăng ký
            if (nvBUS.DangKy(newAdmin))
            {
                MessageBox.Show($"Đã tạo thành công tài khoản Quản trị viên: {newAdmin.TenDangNhap}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa trống ô nhập sau khi tạo xong
                txtAdminUser.Clear();
                txtAdminPass.Clear();
            }
            else
            {
                MessageBox.Show("Lỗi: Tên đăng nhập đã tồn tại hoặc không hợp lệ!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CHỨC NĂNG: LƯU THÔNG TIN KHÁCH SẠN
        private void BtnSaveGeneral_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHotelName.Text))
            {
                MessageBox.Show("Tên khách sạn không được để trống!");
                return;
            }

            // Ở đây bạn có thể gọi một hàm lưu vào bảng 'Setting' trong Database
            // Tạm thời hiển thị thông báo thành công
            MessageBox.Show("Đã lưu cấu hình tên khách sạn: " + txtHotelName.Text, "Thành công");
        }
    }
}
