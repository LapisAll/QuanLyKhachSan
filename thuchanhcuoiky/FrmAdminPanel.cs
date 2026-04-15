using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thuchanhcuoiky
{
    public partial class FrmAdminPanel : Form
    {
        public FrmAdminPanel()
        {
            InitializeComponent();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            new FrmEditRoom().ShowDialog();
            // Khởi tạo Form Quản lý phòng
            using (FrmEditRoom frm = new FrmEditRoom())
            {
                // Hiển thị ở giữa màn hình cha
                frm.StartPosition = FormStartPosition.CenterParent;

                // Nếu sau khi đóng Form mà có thay đổi thành công (DialogResult.OK)
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Có thể load lại dữ liệu ở Dashboard nếu cần
                    MessageBox.Show("Dữ liệu phòng đã được cập nhật!", "Thông báo");
                }
            }
        }

        private void btnSystemSettings_Click(object sender, EventArgs e)
        {
            using (FrmSystemSettings frm = new FrmSystemSettings())
            {
                // Hiển thị dạng Dialog để Admin tập trung xử lý cài đặt
                frm.ShowDialog();
            }
        }
    }
}
