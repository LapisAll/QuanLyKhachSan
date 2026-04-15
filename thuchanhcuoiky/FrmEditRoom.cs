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
    public partial class FrmEditRoom : Form
    {
        // Khởi tạo lớp xử lý nghiệp vụ Phòng
        private PhongBUS pBUS = new PhongBUS();

        public FrmEditRoom()
        {
            InitializeComponent();

            // Đăng ký các sự kiện quan trọng
            this.Load += FrmEditRoom_Load;
            dgvRooms.CellClick += DgvRooms_CellClick;
            btnSave.Click += BtnSave_Click;
            btnAddNew.Click += BtnAddNew_Click;
        }

        private void FrmEditRoom_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
            SetupComboBoxes();
        }

        // 1. Load danh sách phòng từ Database vào bảng bên trái
        private void LoadDataGrid()
        {
            try
            {
                dgvRooms.DataSource = pBUS.GetAllRooms();

                // Việt hóa tiêu đề cột
                if (dgvRooms.Columns["MaPhong"] != null)
                {
                    dgvRooms.Columns["MaPhong"].HeaderText = "Mã Phòng";
                    dgvRooms.Columns["TenPhong"].HeaderText = "Tên Phòng";
                    dgvRooms.Columns["LoaiPhong"].HeaderText = "Loại";
                    dgvRooms.Columns["GiaPhong"].HeaderText = "Giá (VNĐ)";
                    dgvRooms.Columns["TrangThaiPhong"].HeaderText = "Trạng Thái";

                    // Định dạng tiền tệ cho cột Giá
                    dgvRooms.Columns["GiaPhong"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void SetupComboBoxes()
        {
            // Nếu designer chưa có sẵn Items, ta thêm ở đây
            if (cboType.Items.Count == 0)
                cboType.Items.AddRange(new object[] { "Single", "Double", "VIP", "Suite" });

            if (cboStatus.Items.Count == 0)
                cboStatus.Items.AddRange(new object[] { "Available", "Occupied", "Dirty" });

            cboType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
        }

        // 2. Sự kiện Click chọn dòng -> Đổ dữ liệu sang các ô nhập liệu bên phải
        private void DgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];

                txtRoomId.Text = row.Cells["MaPhong"].Value.ToString();
                txtRoomName.Text = row.Cells["TenPhong"].Value.ToString();
                cboType.Text = row.Cells["LoaiPhong"].Value.ToString();
                txtPrice.Text = row.Cells["GiaPhong"].Value.ToString();
                cboStatus.Text = row.Cells["TrangThaiPhong"].Value.ToString();

                // KHÓA Mã phòng (Primary Key) khi đang sửa
                txtRoomId.ReadOnly = true;
                btnSave.Text = "💾 CẬP NHẬT";
            }
        }

        // 3. Nút THÊM MỚI (Làm trống các ô để nhập phòng mới)
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            txtRoomId.ReadOnly = false; // Mở khóa để nhập mã mới
            txtRoomId.Clear();
            txtRoomName.Clear();
            txtPrice.Clear();
            cboType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            btnSave.Text = "💾 LƯU PHÒNG MỚI";
            txtRoomId.Focus();
        }

        // 4. Nút LƯU / CẬP NHẬT
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra rỗng cơ bản
            if (string.IsNullOrWhiteSpace(txtRoomId.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra định dạng số cho Mã Phòng
            if (!int.TryParse(txtRoomId.Text.Trim(), out int maPhong))
            {
                MessageBox.Show("Mã phòng phải là số nguyên!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoomId.Focus();
                return;
            }

            // 3. Kiểm tra định dạng số cho Giá Phòng
            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal giaPhong))
            {
                MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }

            // 4. Đóng gói dữ liệu vào DTO
            PhongDTO room = new PhongDTO
            {
                MaPhong = maPhong,
                TenPhong = txtRoomName.Text.Trim(),
                LoaiPhong = cboType.Text,
                GiaPhong = giaPhong,
                TrangThaiPhong = cboStatus.Text
            };

            // 5. Thực hiện Lưu hoặc Cập nhật
            if (txtRoomId.ReadOnly == false) // Chế độ THÊM MỚI
            {
                if (pBUS.InsertRoom(room))
                {
                    MessageBox.Show("Thêm phòng mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    BtnAddNew_Click(null, null); // Reset form sau khi thêm thành công
                }
                else
                {
                    MessageBox.Show("Thất bại! Mã phòng này đã tồn tại trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Chế độ CẬP NHẬT
            {
                if (pBUS.UpdateRoom(room))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
