using DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace DAL
{
    public class KhachHangDAL
    {
        public static List<KhachHangDTO> GetAllGuests()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // Câu lệnh SQL lấy danh sách khách hàng chưa bị xóa (IsDeleted = 0)
                string query = "SELECT MaKhach, TenKhach, SoCMND, SoDienThoai FROM KhachHang WHERE IsDeleted = 0 OR IsDeleted IS NULL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new KhachHangDTO
                            {
                                MaKhach = (int)reader["MaKhach"],
                                // Dùng .ToString() để tránh lỗi văng app nếu dữ liệu trong SQL vô tình bị NULL
                                TenKhach = reader["TenKhach"] != DBNull.Value ? reader["TenKhach"].ToString() : "",
                                SoCMND = reader["SoCMND"] != DBNull.Value ? reader["SoCMND"].ToString() : "",
                                SoDienThoai = reader["SoDienThoai"] != DBNull.Value ? reader["SoDienThoai"].ToString() : ""
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static KhachHangDTO GetGuestById(int maKhach)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaKhach, TenKhach, SoCMND, SoDienThoai, Email, DiaChi FROM KhachHang WHERE MaKhach = @MaKhach";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhach", maKhach);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhachHangDTO
                            {
                                MaKhach = (int)reader["MaKhach"],
                                TenKhach = (string)reader["TenKhach"],
                                SoCMND = (string)reader["SoCMND"],
                                SoDienThoai = (string)reader["SoDienThoai"],
                                Email = reader["Email"] != System.DBNull.Value ? (string)reader["Email"] : "",
                                DiaChi = reader["DiaChi"] != System.DBNull.Value ? (string)reader["DiaChi"] : ""
                            };
                        }
                    }
                }
            }

            return null;
        }

        public static bool AddGuest(KhachHangDTO khach)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO KhachHang (TenKhach, SoCMND, SoDienThoai, Email, DiaChi) VALUES (@TenKhach, @SoCMND, @SoDienThoai, @Email, @DiaChi)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenKhach", khach.TenKhach);
                    cmd.Parameters.AddWithValue("@SoCMND", khach.SoCMND);
                    cmd.Parameters.AddWithValue("@SoDienThoai", khach.SoDienThoai);
                    cmd.Parameters.AddWithValue("@Email", khach.Email ?? "");
                    cmd.Parameters.AddWithValue("@DiaChi", khach.DiaChi ?? "");

                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (SqlException ex) when (ex.Number == 2627) // Duplicate key
                    {
                        throw new System.Exception("Số CMND đã tồn tại!");
                    }
                }
            }
        }

        public static bool UpdateGuest(KhachHangDTO khach)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE KhachHang SET TenKhach = @TenKhach, SoDienThoai = @SoDienThoai, Email = @Email, DiaChi = @DiaChi WHERE MaKhach = @MaKhach";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhach", khach.MaKhach);
                    cmd.Parameters.AddWithValue("@TenKhach", khach.TenKhach);
                    cmd.Parameters.AddWithValue("@SoDienThoai", khach.SoDienThoai);
                    cmd.Parameters.AddWithValue("@Email", khach.Email ?? "");
                    cmd.Parameters.AddWithValue("@DiaChi", khach.DiaChi ?? "");

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public static bool DeleteGuest(int maKhach)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();       
                string query = "UPDATE KhachHang SET IsDeleted = 1 WHERE MaKhach = @MaKhach";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhach", maKhach);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}