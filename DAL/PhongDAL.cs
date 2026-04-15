using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhongDAL
    {
        // 1. GetAllRooms - Đã xóa 'static'
        public List<PhongDTO> GetAllRooms()
        {
            List<PhongDTO> rooms = new List<PhongDTO>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaPhong, TenPhong, LoaiPhong, GiaPhong, TrangThaiPhong, SoGiuong, DienTich FROM Phong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(new PhongDTO
                            {
                                MaPhong = (int)reader["MaPhong"],
                                TenPhong = (string)reader["TenPhong"],
                                LoaiPhong = (string)reader["LoaiPhong"],
                                GiaPhong = (decimal)reader["GiaPhong"],
                                TrangThaiPhong = (string)reader["TrangThaiPhong"],
                                SoGiuong = (int)reader["SoGiuong"],
                                DienTich = (int)reader["DienTich"]
                            });
                        }
                    }
                }
            }
            return rooms;
        }

        // 2. GetRoomById - Đã xóa 'static'
        public PhongDTO GetRoomById(int maPhong)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaPhong, TenPhong, LoaiPhong, GiaPhong, TrangThaiPhong, SoGiuong, DienTich FROM Phong WHERE MaPhong = @MaPhong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhong", maPhong);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PhongDTO
                            {
                                MaPhong = (int)reader["MaPhong"],
                                TenPhong = (string)reader["TenPhong"],
                                LoaiPhong = (string)reader["LoaiPhong"],
                                GiaPhong = (decimal)reader["GiaPhong"],
                                TrangThaiPhong = (string)reader["TrangThaiPhong"],
                                SoGiuong = (int)reader["SoGiuong"],
                                DienTich = (int)reader["DienTich"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        // 3. UpdateRoom - Đã xóa 'static'
        public bool UpdateRoom(PhongDTO phong)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Phong SET TenPhong = @TenPhong, LoaiPhong = @LoaiPhong, GiaPhong = @GiaPhong, TrangThaiPhong = @TrangThaiPhong, SoGiuong = @SoGiuong, DienTich = @DienTich WHERE MaPhong = @MaPhong";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhong", phong.MaPhong);
                    cmd.Parameters.AddWithValue("@TenPhong", phong.TenPhong);
                    cmd.Parameters.AddWithValue("@LoaiPhong", phong.LoaiPhong);
                    cmd.Parameters.AddWithValue("@GiaPhong", phong.GiaPhong);
                    cmd.Parameters.AddWithValue("@TrangThaiPhong", phong.TrangThaiPhong);
                    cmd.Parameters.AddWithValue("@SoGiuong", phong.SoGiuong);
                    cmd.Parameters.AddWithValue("@DienTich", phong.DienTich);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 4. InsertRoom (Dùng cho chức năng thêm mới trong BUS) - Đã xóa 'static'
        public bool InsertRoom(PhongDTO phong)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Phong (TenPhong, LoaiPhong, GiaPhong, TrangThaiPhong, SoGiuong, DienTich) VALUES (@TenPhong, @LoaiPhong, @GiaPhong, @TrangThaiPhong, @SoGiuong, @DienTich)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenPhong", phong.TenPhong);
                    cmd.Parameters.AddWithValue("@LoaiPhong", phong.LoaiPhong);
                    cmd.Parameters.AddWithValue("@GiaPhong", phong.GiaPhong);
                    cmd.Parameters.AddWithValue("@TrangThaiPhong", phong.TrangThaiPhong);
                    cmd.Parameters.AddWithValue("@SoGiuong", phong.SoGiuong);
                    cmd.Parameters.AddWithValue("@DienTich", phong.DienTich);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 5. AddRoom (Giữ lại để tương thích ngược nếu cần)
        public bool AddRoom(PhongDTO phong) => InsertRoom(phong);
    }
}