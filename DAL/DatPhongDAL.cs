using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DatPhongDAL
    {
        public static List<DatPhongDTO> GetAllBookings()
        {
            List<DatPhongDTO> bookings = new List<DatPhongDTO>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaDatPhong, MaKhach, MaPhong, NgayCheckIn, NgayCheckOut, SoNguoiLon, SoTreEm, GhiChu, TrangThai FROM DatPhong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(new DatPhongDTO
                            {
                                MaDatPhong = (int)reader["MaDatPhong"],
                                MaKhach = (int)reader["MaKhach"],
                                MaPhong = (int)reader["MaPhong"],
                                NgayCheckIn = (DateTime)reader["NgayCheckIn"],
                                NgayCheckOut = (DateTime)reader["NgayCheckOut"],
                                SoNguoiLon = (int)reader["SoNguoiLon"],
                                SoTreEm = (int)reader["SoTreEm"],
                                GhiChu = reader["GhiChu"] != System.DBNull.Value ? (string)reader["GhiChu"] : "",
                                TrangThai = (string)reader["TrangThai"]
                            });
                        }
                    }
                }
            }

            return bookings;
        }

        public static DatPhongDTO GetBookingById(int maDatPhong)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaDatPhong, MaKhach, MaPhong, NgayCheckIn, NgayCheckOut, SoNguoiLon, SoTreEm, GhiChu, TrangThai FROM DatPhong WHERE MaDatPhong = @MaDatPhong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DatPhongDTO
                            {
                                MaDatPhong = (int)reader["MaDatPhong"],
                                MaKhach = (int)reader["MaKhach"],
                                MaPhong = (int)reader["MaPhong"],
                                NgayCheckIn = (DateTime)reader["NgayCheckIn"],
                                NgayCheckOut = (DateTime)reader["NgayCheckOut"],
                                SoNguoiLon = (int)reader["SoNguoiLon"],
                                SoTreEm = (int)reader["SoTreEm"],
                                GhiChu = reader["GhiChu"] != System.DBNull.Value ? (string)reader["GhiChu"] : "",
                                TrangThai = (string)reader["TrangThai"]
                            };
                        }
                    }
                }
            }

            return null;
        }

        public static bool AddBooking(DatPhongDTO datPhong)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO DatPhong (MaKhach, MaPhong, NgayCheckIn, NgayCheckOut, SoNguoiLon, SoTreEm, GhiChu, TrangThai) VALUES (@MaKhach, @MaPhong, @NgayCheckIn, @NgayCheckOut, @SoNguoiLon, @SoTreEm, @GhiChu, @TrangThai)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhach", datPhong.MaKhach);
                    cmd.Parameters.AddWithValue("@MaPhong", datPhong.MaPhong);
                    cmd.Parameters.AddWithValue("@NgayCheckIn", datPhong.NgayCheckIn);
                    cmd.Parameters.AddWithValue("@NgayCheckOut", datPhong.NgayCheckOut);
                    cmd.Parameters.AddWithValue("@SoNguoiLon", datPhong.SoNguoiLon);
                    cmd.Parameters.AddWithValue("@SoTreEm", datPhong.SoTreEm);
                    cmd.Parameters.AddWithValue("@GhiChu", datPhong.GhiChu ?? "");
                    cmd.Parameters.AddWithValue("@TrangThai", datPhong.TrangThai);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateBooking(DatPhongDTO datPhong)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE DatPhong SET TrangThai = @TrangThai, NgayCheckIn = @NgayCheckIn, NgayCheckOut = @NgayCheckOut WHERE MaDatPhong = @MaDatPhong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatPhong", datPhong.MaDatPhong);
                    cmd.Parameters.AddWithValue("@TrangThai", datPhong.TrangThai);
                    cmd.Parameters.AddWithValue("@NgayCheckIn", datPhong.NgayCheckIn);
                    cmd.Parameters.AddWithValue("@NgayCheckOut", datPhong.NgayCheckOut);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public static bool DeleteBooking(int maDatPhong)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM DatPhong WHERE MaDatPhong = @MaDatPhong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
