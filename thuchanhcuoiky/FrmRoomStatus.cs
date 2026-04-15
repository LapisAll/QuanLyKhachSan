using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmRoomStatus : Form
    {
        private PhongBUS phongBUS;

        public FrmRoomStatus(PhongBUS phongBUS)
        {
            this.phongBUS = phongBUS;
            InitializeComponent();
            SetupUI();
            LoadRoomsData();
        }

        private void SetupUI()
        {
            // Title
            Label lblTitle = new Label
            {
                Text = "🧹 Quản Lý Trạng Thái Phòng",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Left = 20,
                Top = 20,
                AutoSize = true,
                ForeColor = Color.FromArgb(41, 128, 185)
            };
            this.Controls.Add(lblTitle);

            // Status info labels
            Label lblInfo = new Label
            {
                Text = "🟢 Trống = Available | 🔴 Đã Đặt = Occupied | 🟡 Cần Vệ Sinh = Dirty",
                Font = new Font("Arial", 10),
                Left = 20,
                Top = 50,
                Width = 500,
                Height = 25,
                ForeColor = Color.FromArgb(127, 140, 141)
            };
            this.Controls.Add(lblInfo);

            // Add columns to DataGridView
            dgvRooms.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "MaPhong", HeaderText = "Mã Phòng", DataPropertyName = "MaPhong", Width = 80 },
                new DataGridViewTextBoxColumn { HeaderText = "Tên Phòng", DataPropertyName = "TenPhong" },
                new DataGridViewTextBoxColumn { HeaderText = "Loại Phòng", DataPropertyName = "LoaiPhong" },
                new DataGridViewTextBoxColumn { HeaderText = "Giá (VNĐ)", DataPropertyName = "GiaPhong", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } },
                new DataGridViewTextBoxColumn { HeaderText = "Trạng Thái Hiện Tại", DataPropertyName = "TrangThaiPhong" },
                new DataGridViewTextBoxColumn { HeaderText = "Số Giường", DataPropertyName = "SoGiuong", Width = 80 },
                new DataGridViewTextBoxColumn { HeaderText = "Diện Tích (m²)", DataPropertyName = "DienTich", Width = 100 }
            );

            dgvRooms.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvRooms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dgvRooms.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvRooms.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                    int maPhong = (int)row.Cells["MaPhong"].Value;
                    ShowStatusChangeForm(maPhong);
                    LoadRoomsData();
                }
            };

            // Instruction label
            Label lblInstruction = new Label
            {
                Text = "💡 Double-click trên một phòng để thay đổi trạng thái",
                Font = new Font("Arial", 10, FontStyle.Italic),
                Left = 20,
                Top = 460,
                Width = 500,
                Height = 25,
                ForeColor = Color.FromArgb(127, 140, 141)
            };
            this.Controls.Add(lblInstruction);

            // Status change buttons panel
            Label lblQuickAction = new Label
            {
                Text = "Hoặc chọn phòng và nhấn nút dưới đây:",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Left = 20,
                Top = 490,
                AutoSize = true
            };
            this.Controls.Add(lblQuickAction);

            // Wire up button events
            btnDirty.Click += (s, e) => MarkRoomStatus("Dirty", "🟡 Cần Vệ Sinh");
            btnAvailable.Click += (s, e) => MarkRoomStatus("Available", "🟢 Sẵn Sàng Phục Vụ");
            btnClose.Click += (s, e) => this.Close();
        }

        private void LoadRoomsData()
        {
            dgvRooms.Rows.Clear();
            var rooms = phongBUS.GetAllRooms();
            foreach (var room in rooms)
            {
                dgvRooms.Rows.Add(
                    room.MaPhong,
                    room.TenPhong,
                    room.LoaiPhong,
                    room.GiaPhong,
                    GetStatusText(room.TrangThaiPhong),
                    room.SoGiuong,
                    room.DienTich
                );
            }
        }

        private void MarkRoomStatus(string statusValue, string displayName)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phòng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhong = (int)dgvRooms.SelectedRows[0].Cells["MaPhong"].Value;
            try
            {
                phongBUS.ChangeRoomStatus(maPhong, statusValue);
                MessageBox.Show($"Đã cập nhật trạng thái phòng thành '{displayName}'", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRoomsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowStatusChangeForm(int maPhong)
        {
            var room = phongBUS.GetRoomById(maPhong);
            if (room == null) return;

            Form frmStatus = new Form
            {
                Text = $"Thay Đổi Trạng Thái - {room.TenPhong}",
                Width = 400,
                Height = 300,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White
            };

            // Current status label
            Label lblCurrent = new Label
            {
                Text = $"Trạng thái hiện tại: {GetStatusText(room.TrangThaiPhong)}",
                Font = new Font("Arial", 11, FontStyle.Bold),
                Left = 20,
                Top = 20,
                Width = 350,
                Height = 25
            };
            frmStatus.Controls.Add(lblCurrent);

            // Status selection
            Label lblNew = new Label
            {
                Text = "Chọn trạng thái mới:",
                Font = new Font("Arial", 11),
                Left = 20,
                Top = 60,
                Width = 200,
                Height = 20
            };
            frmStatus.Controls.Add(lblNew);

            ComboBox cbbStatus = new ComboBox
            {
                Left = 20,
                Top = 85,
                Width = 350,
                Height = 25,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cbbStatus.Items.Add("Available (🟢 Trống)");
            cbbStatus.Items.Add("Occupied (🔴 Đã Đặt)");
            cbbStatus.Items.Add("Dirty (🟡 Cần Vệ Sinh)");
            cbbStatus.SelectedIndex = 0;

            frmStatus.Controls.Add(cbbStatus);

            // Info label
            Label lblInfo = new Label
            {
                Text = "• Available: Phòng sẵn sàng cho khách\n" +
                       "• Occupied: Khách đang ở trong phòng\n" +
                       "• Dirty: Phòng cần được vệ sinh",
                Font = new Font("Arial", 9),
                Left = 20,
                Top = 120,
                Width = 350,
                Height = 80,
                ForeColor = Color.FromArgb(127, 140, 141)
            };
            frmStatus.Controls.Add(lblInfo);

            // OK button
            Button btnOK = new Button
            {
                Text = "✅ Cập Nhật",
                Width = 150,
                Height = 35,
                Left = 80,
                Top = 215,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Arial", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            btnOK.Click += (s, e) =>
            {
                try
                {
                    string newStatus = "Available"; // default value

                    // Traditional switch statement instead of switch expression
                    switch (cbbStatus.SelectedIndex)
                    {
                        case 0:
                            newStatus = "Available";
                            break;
                        case 1:
                            newStatus = "Occupied";
                            break;
                        case 2:
                            newStatus = "Dirty";
                            break;
                        default:
                            newStatus = "Available";
                            break;
                    }

                    phongBUS.ChangeRoomStatus(maPhong, newStatus);
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmStatus.Close();
                    LoadRoomsData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            frmStatus.Controls.Add(btnOK);

            // Cancel button
            Button btnCancel = new Button
            {
                Text = "❌ Hủy",
                Width = 150,
                Height = 35,
                Left = 250,
                Top = 215,
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                Font = new Font("Arial", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            btnCancel.Click += (s, e) => frmStatus.Close();
            frmStatus.Controls.Add(btnCancel);

            frmStatus.ShowDialog();
        }

        private string GetStatusText(string status)
        {
            // Traditional switch statement instead of switch expression
            switch (status)
            {
                case "Available":
                    return "🟢 Trống";
                case "Occupied":
                    return "🔴 Đã Đặt";
                case "Dirty":
                    return "🟡 Cần Vệ Sinh";
                default:
                    return "❓ Không Xác Định";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}