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

namespace thuchanhcuoiky
{
    public partial class FrmChangePass : Form
    {
        // Khởi tạo đối tượng BLL
        private NhanVienBUS nvBus = new NhanVienBUS();

        public FrmChangePass()
        {
            InitializeComponent();
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            // 2. Chạy logic thông qua BLL
            try
            {
                string username = "admin";

                // Gọi hàm xử lý từ tầng BLL
                string ketQua = nvBus.DoiMatKhau(username, oldPass, newPass, confirmPass);

                if (ketQua == "Thành công")
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ketQua, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
