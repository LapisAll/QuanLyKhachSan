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
using ClosedXML.Excel;
using System.IO;


namespace GUI
{
    public partial class FrmCheckOut : Form
    {
        private DatPhongBUS datPhongBUS;
        private PhongBUS phongBUS;
        private HoaDonBUS hoaDonBUS;
        private KhachHangBUS khachHangBUS = new KhachHangBUS();

        public FrmCheckOut(DatPhongBUS datPhongBUS, PhongBUS phongBUS, HoaDonBUS hoaDonBUS)
        {
            this.datPhongBUS = datPhongBUS;
            this.phongBUS = phongBUS;
            this.hoaDonBUS = hoaDonBUS;
            InitializeComponent();
            LoadActiveBookings();
        }

        private void LoadActiveBookings()
        {
            var activeBookings = datPhongBUS.GetActiveBookings();

            foreach (var booking in activeBookings)
            {
                var room = phongBUS.GetRoomById(booking.MaPhong);
                if (room != null)
                {
                    string displayText = $"Mã {booking.MaDatPhong} - Phòng {room.TenPhong} - Check-in: {booking.NgayCheckIn:dd/MM/yyyy}";
                    cbbBookings.Items.Add(new BookingItem { Text = displayText, Value = booking.MaDatPhong });
                }
            }

            if (cbbBookings.Items.Count > 0)
                cbbBookings.SelectedIndex = 0;
            else
                MessageBox.Show("Không có đơn đặt phòng nào đang hoạt động!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbbBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBookings.SelectedIndex == -1) return;

            int maDatPhong = ((BookingItem)cbbBookings.SelectedItem).Value;
            var booking = datPhongBUS.GetBookingById(maDatPhong);

            if (booking != null)
            {
                var room = phongBUS.GetRoomById(booking.MaPhong);

                // Display booking details
                lblBookingInfo.Text = $"Phòng: {room.TenPhong}\n" +
                                     $"Check-in: {booking.NgayCheckIn:dd/MM/yyyy}\n" +
                                     $"Check-out dự kiến: {booking.NgayCheckOut:dd/MM/yyyy}\n" +
                                     $"Số đêm: {(booking.NgayCheckOut - booking.NgayCheckIn).TotalDays}";

                // Calculate total cost
                decimal totalRoomCost = (decimal)(booking.NgayCheckOut - booking.NgayCheckIn).TotalDays * room.GiaPhong;

                lblTotalCost.Text = $"Tổng tiền phòng: {totalRoomCost:N0} VNĐ";
                lblTotalCost.Tag = totalRoomCost;
            }
        }

        private void BtnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra lựa chọn
                if (cbbBookings.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn đơn đặt phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dynamic selectedItem = cbbBookings.SelectedItem;
                int maDatPhong = (int)selectedItem.Value;

                // 2. Lấy thông tin đơn đặt
                var booking = datPhongBUS.GetBookingById(maDatPhong);
                if (booking == null)
                {
                    MessageBox.Show("Đơn đặt phòng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Lấy thông tin khách hàng (Quan trọng để in hóa đơn)
                var khachHang = khachHangBUS.GetGuestById(booking.MaKhach);
                if (khachHang == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. Lấy thông tin phòng
                var room = phongBUS.GetRoomById(booking.MaPhong);

                // 5. Tính toán tiền bạc
                double totalHours = (DateTime.Now - booking.NgayCheckIn).TotalHours; // Tính tới thời điểm hiện tại
                if (totalHours < 1) totalHours = 1;

                decimal giaMoiGio = room.GiaPhong / 24;
                decimal totalRoomCost = Math.Round((decimal)totalHours * giaMoiGio, 0);
                decimal additionalServiceCost = string.IsNullOrWhiteSpace(txtServiceCost.Text) ? 0 : decimal.Parse(txtServiceCost.Text);

                // 6. Tạo đối tượng Hóa đơn DTO
                var hoaDon = new HoaDonDTO
                {
                    MaDatPhong = maDatPhong,
                    NgayTao = DateTime.Now,
                    SoTienPhong = totalRoomCost,
                    SoTienDichVu = additionalServiceCost,
                    TongTien = totalRoomCost + additionalServiceCost,
                    TrangThaiTT = "Paid",
                    TenKhachHang = khachHang.TenKhach,
                    SoCMND = khachHang.SoCMND,
                    SoDienThoai = khachHang.SoDienThoai,
                    NgayCheckIn = booking.NgayCheckIn,
                    NgayCheckOut = DateTime.Now // Lưu thời điểm trả phòng thực tế
                };

             
                hoaDonBUS.CreateInvoice(hoaDon);
                phongBUS.ChangeRoomStatus(booking.MaPhong, "Available");
                datPhongBUS.CheckOut(maDatPhong);
                try { khachHangBUS.DeleteGuest(booking.MaKhach); } catch { }
                string receiptMsg = $"Thanh toán thành công cho khách: {khachHang.TenKhach}\n" +
                                    $"Tổng tiền: {hoaDon.TongTien:N0} VNĐ\n\n" +
                                    $"Bạn có muốn xuất hóa đơn ra file Excel không?";

                DialogResult dr = MessageBox.Show(receiptMsg, "Hoàn tất thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    ExcelHelper.ExportInvoice(hoaDon);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
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


    public class BookingItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString() => Text;
    }
}
