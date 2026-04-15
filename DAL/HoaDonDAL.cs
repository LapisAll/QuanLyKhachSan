using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class HoaDonDAL
    {
        public static List<HoaDonDTO> GetAllInvoices()
        {
            List<HoaDonDTO> invoices = new List<HoaDonDTO>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // 1. Cập nhật SELECT để lấy thêm các cột mới
                string query = "SELECT MaHoaDon, MaDatPhong, NgayTao, SoTienPhong, SoTienDichVu, TongTien, TrangThaiTT, TenKhachHang, SoCMND, SoDienThoai, NgayCheckIn, NgayCheckOut FROM HoaDon";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            invoices.Add(new HoaDonDTO
                            {
                                MaHoaDon = (int)reader["MaHoaDon"],
                                MaDatPhong = (int)reader["MaDatPhong"],
                                NgayTao = (DateTime)reader["NgayTao"],
                                SoTienPhong = (decimal)reader["SoTienPhong"],
                                SoTienDichVu = (decimal)reader["SoTienDichVu"],
                                TongTien = (decimal)reader["TongTien"],
                                TrangThaiTT = (string)reader["TrangThaiTT"],
                                // Đọc thêm dữ liệu mới (xử lý tránh lỗi nếu DB có dòng cũ bị NULL)
                                TenKhachHang = reader["TenKhachHang"]?.ToString() ?? "",
                                SoCMND = reader["SoCMND"]?.ToString() ?? "",
                                SoDienThoai = reader["SoDienThoai"]?.ToString() ?? "",
                                NgayCheckIn = reader["NgayCheckIn"] != DBNull.Value ? (DateTime)reader["NgayCheckIn"] : DateTime.Now,
                                NgayCheckOut = reader["NgayCheckOut"] != DBNull.Value ? (DateTime)reader["NgayCheckOut"] : DateTime.Now
                            });
                        }
                    }
                }
            }
            return invoices;
        }

        public static HoaDonDTO GetInvoiceById(int maHoaDon)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // 2. Cập nhật SELECT BY ID
                string query = "SELECT MaHoaDon, MaDatPhong, NgayTao, SoTienPhong, SoTienDichVu, TongTien, TrangThaiTT, TenKhachHang, SoCMND, SoDienThoai, NgayCheckIn, NgayCheckOut FROM HoaDon WHERE MaHoaDon = @MaHoaDon";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new HoaDonDTO
                            {
                                MaHoaDon = (int)reader["MaHoaDon"],
                                MaDatPhong = (int)reader["MaDatPhong"],
                                NgayTao = (DateTime)reader["NgayTao"],
                                SoTienPhong = (decimal)reader["SoTienPhong"],
                                SoTienDichVu = (decimal)reader["SoTienDichVu"],
                                TongTien = (decimal)reader["TongTien"],
                                TrangThaiTT = (string)reader["TrangThaiTT"],
                                TenKhachHang = reader["TenKhachHang"]?.ToString() ?? "",
                                SoCMND = reader["SoCMND"]?.ToString() ?? "",
                                SoDienThoai = reader["SoDienThoai"]?.ToString() ?? "",
                                NgayCheckIn = reader["NgayCheckIn"] != DBNull.Value ? (DateTime)reader["NgayCheckIn"] : DateTime.Now,
                                NgayCheckOut = reader["NgayCheckOut"] != DBNull.Value ? (DateTime)reader["NgayCheckOut"] : DateTime.Now
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool AddInvoice(HoaDonDTO hoaDon)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // 3. Cập nhật INSERT đầy đủ 11 cột
                string query = @"INSERT INTO HoaDon (MaDatPhong, NgayTao, SoTienPhong, SoTienDichVu, TongTien, TrangThaiTT, 
                                                    TenKhachHang, SoCMND, SoDienThoai, NgayCheckIn, NgayCheckOut) 
                                 VALUES (@MaDatPhong, @NgayTao, @SoTienPhong, @SoTienDichVu, @TongTien, @TrangThaiTT, 
                                         @TenKhachHang, @SoCMND, @SoDienThoai, @NgayCheckIn, @NgayCheckOut)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatPhong", hoaDon.MaDatPhong);
                    cmd.Parameters.AddWithValue("@NgayTao", hoaDon.NgayTao);
                    cmd.Parameters.AddWithValue("@SoTienPhong", hoaDon.SoTienPhong);
                    cmd.Parameters.AddWithValue("@SoTienDichVu", hoaDon.SoTienDichVu);
                    cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                    cmd.Parameters.AddWithValue("@TrangThaiTT", hoaDon.TrangThaiTT);

                    // THÊM CÁC THAM SỐ MỚI
                    cmd.Parameters.AddWithValue("@TenKhachHang", hoaDon.TenKhachHang ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoCMND", hoaDon.SoCMND ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai", hoaDon.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayCheckIn", hoaDon.NgayCheckIn);
                    cmd.Parameters.AddWithValue("@NgayCheckOut", hoaDon.NgayCheckOut);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}