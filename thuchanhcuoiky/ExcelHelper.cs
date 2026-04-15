using ClosedXML.Excel;
using DTO;
using System;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public static class ExcelHelper
    {
        public static void ExportInvoice(HoaDonDTO hoadon)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("HoaDon");

                // Tính toán thời gian ở
                double hours = (hoadon.NgayCheckOut - hoadon.NgayCheckIn).TotalHours;
                if (hours < 1) hours = 1;

                // --- Giao diện hóa đơn ---
                worksheet.Cell("A1").Value = "HÓA ĐƠN THANH TOÁN (SAO KÊ)";
                worksheet.Cell("A1").Style.Font.Bold = true;
                worksheet.Cell("A1").Style.Font.FontSize = 16;
                worksheet.Range("A1:D1").Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                worksheet.Cell("A3").Value = "Mã HĐ:"; worksheet.Cell("B3").Value = hoadon.MaHoaDon;
                worksheet.Cell("A4").Value = "Khách Hàng:"; worksheet.Cell("B4").Value = hoadon.TenKhachHang;
                worksheet.Cell("A5").Value = "Ngày Lập:"; worksheet.Cell("B5").Value = hoadon.NgayTao.ToString("dd/MM/yyyy HH:mm");

                worksheet.Range("A7:D7").Style.Fill.BackgroundColor = XLColor.LightGray;
                worksheet.Cell("A7").Value = "Nội dung"; worksheet.Cell("D7").Value = "Thành tiền";

                worksheet.Cell("A8").Value = "Tiền thuê phòng";
                worksheet.Cell("B8").Value = $"{Math.Round(hours, 1)} giờ";
                worksheet.Cell("D8").Value = hoadon.SoTienPhong;

                worksheet.Cell("A9").Value = "Tiền dịch vụ";
                worksheet.Cell("D9").Value = hoadon.SoTienDichVu;

                worksheet.Cell("C11").Value = "TỔNG CỘNG:";
                worksheet.Cell("D11").Value = hoadon.TongTien;
                worksheet.Cell("D11").Style.Font.Bold = true;
                worksheet.Cell("D11").Style.Font.FontColor = XLColor.Red;

                worksheet.Columns().AdjustToContents();

                using (SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook|*.xlsx",
                    FileName = $"HD_{hoadon.MaHoaDon}_{hoadon.TenKhachHang}.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất file thành công!", "Thông báo");
                    }
                }
            }
        }
    }
}