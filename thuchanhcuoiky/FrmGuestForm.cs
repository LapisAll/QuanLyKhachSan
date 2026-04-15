using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmGuestForm : Form
    {
        private KhachHangBUS khachHangBUS;

        public FrmGuestForm(KhachHangBUS khachHangBUS)
        {
            this.khachHangBUS = khachHangBUS;
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTen.Text))
                {
                    MessageBox.Show("Tên khách hàng không được trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Khởi tạo DTO chuẩn C# 7.3
                KhachHangDTO khach = new KhachHangDTO();
                khach.TenKhach = txtTen.Text;
                khach.SoCMND = txtCMND.Text;
                khach.SoDienThoai = txtPhone.Text;
                khach.Email = txtEmail.Text;
                khach.DiaChi = txtAddress.Text;

                if (khachHangBUS.AddGuest(khach))
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Số CMND đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}