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
using GUI;

namespace thuchanhcuoiky
{
    public partial class FrmLogin : Form
    {
        NhanVienBUS bus = new NhanVienBUS();

        public FrmLogin()
        {
            InitializeComponent();

            // Gỡ bỏ mọi sự kiện cũ trước khi gán mới để tránh bị lặp 2 lần
            this.btnLogin.Click -= btnLogin_Click;
            this.btnLogin.Click += btnLogin_Click;

            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Gọi BUS kiểm tra
            if (bus.KiemTraDangNhap(txtUsername.Text, txtPassword.Text))
            {
                // 1. Gán kết quả OK
                // Trong Winforms, khi Form được mở bằng ShowDialog(), 
                // việc gán DialogResult sẽ TỰ ĐỘNG đóng Form đó lại.
                this.DialogResult = DialogResult.OK;

                // KHÔNG gọi this.Close() ở đây nữa để tránh xung đột luồng
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
    
}
