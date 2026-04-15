using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{

    public partial class FrmBookingForm : Form
    {
        private DatPhongBUS datPhongBUS;
        private PhongBUS phongBUS;
        private KhachHangBUS khachHangBUS;

        public FrmBookingForm(DatPhongBUS datPhongBUS, PhongBUS phongBUS, KhachHangBUS khachHangBUS)
        {
            this.datPhongBUS = datPhongBUS;
            this.phongBUS = phongBUS;
            this.khachHangBUS = khachHangBUS;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var guests = khachHangBUS.GetAllGuests();
            foreach (var guest in guests)
            {
                cbbGuest.Items.Add(new ComboBoxItem { Text = guest.TenKhach, Value = guest.MaKhach });
            }

            var rooms = phongBUS.GetAvailableRooms();
            foreach (var room in rooms)
            {
                cbbRoom.Items.Add(new ComboBoxItem { Text = room.TenPhong, Value = room.MaPhong });
            }

            if (cbbGuest.Items.Count > 0) cbbGuest.SelectedIndex = 0;
            if (cbbRoom.Items.Count > 0) cbbRoom.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra chọn khách và phòng (Giữ nguyên)
                if (cbbGuest.SelectedIndex == -1 || cbbRoom.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ khách hàng và phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Ghép Ngày và Giờ từ các DateTimePicker
                DateTime checkIn = dtCheckIn.Value.Date + dtTimeIn.Value.TimeOfDay;
                DateTime checkOut = dtCheckOut.Value.Date + dtTimeOut.Value.TimeOfDay;

                // 3. KIỂM TRA RÀNG BUỘC: Tối thiểu 1 tiếng
                TimeSpan duration = checkOut - checkIn;

                if (duration.TotalHours < 1)
                {
                    MessageBox.Show("Hệ thống chỉ chấp nhận đặt phòng tối thiểu từ 1 tiếng trở lên!",
                                    "Lỗi thời gian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. Nếu hợp lệ thì tiến hành lưu
                int maKhach = ((ComboBoxItem)cbbGuest.SelectedItem).Value;
                int maPhong = ((ComboBoxItem)cbbRoom.SelectedItem).Value;

                var datPhong = new DatPhongDTO
                {
                    MaKhach = maKhach,
                    MaPhong = maPhong,
                    NgayCheckIn = checkIn,
                    NgayCheckOut = checkOut,
                    SoNguoiLon = (int)numAdults.Value,
                    SoTreEm = (int)numChildren.Value,
                    GhiChu = txtNotes.Text ?? "",
                    TrangThai = "Confirmed"
                };

                datPhongBUS.CreateBooking(datPhong);

                // Cập nhật trạng thái phòng sang Occupied (Đã đặt)
                phongBUS.ChangeRoomStatus(maPhong, "Occupied");

                MessageBox.Show("Đặt phòng thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString() => Text;
    }
}
