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
    public class DbConnection
    {
        protected string ConnectionString = @"Data Source=DESKTOP-BDGU3CT;Initial Catalog=HotelManagementDB02;Integrated Security=True";
    }
    public class NhanVienDAL : DbConnection 
    {
        public NhanVienDTO GetNhanVienByUsername(string username)
        {
            NhanVienDTO nv = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    // Thêm cột Role vào câu lệnh SELECT
                    string sql = "SELECT Username, MatKhau, Email, SDT, Role FROM NhanVien WHERE Username = @user";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", username);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        nv = new NhanVienDTO
                        {
                            TenDangNhap = rdr["Username"].ToString(),
                            MatKhau = rdr["MatKhau"].ToString(),
                            Email = rdr["Email"].ToString(),
                            SoDienThoai = rdr["SDT"].ToString(),
                            Role = rdr["Role"].ToString() // Giả sử DTO đã có thuộc tính Role
                        };
                    }
                }
            }
            catch (Exception) { }
            return nv;
        }

        public bool UpdatePassword(string username, string newPass)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string sql = "UPDATE NhanVien SET MatKhau = @pass WHERE Username = @user";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@pass", newPass);
                    cmd.Parameters.AddWithValue("@user", username);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0; 
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool InsertNhanVien(NhanVienDTO nv)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    // Thêm cột Role vào câu lệnh INSERT
                    string sql = "INSERT INTO NhanVien (Username, MatKhau, Email, SDT, Role) VALUES (@user, @pass, @email, @sdt, @role)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@user", nv.TenDangNhap);
                    cmd.Parameters.AddWithValue("@pass", nv.MatKhau);
                    cmd.Parameters.AddWithValue("@email", nv.Email);
                    cmd.Parameters.AddWithValue("@sdt", nv.SoDienThoai);
                    cmd.Parameters.AddWithValue("@role", nv.Role ?? "Employee"); // Nếu null thì mặc định là nhân viên

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }
        public List<NhanVienDTO> GetAllNhanVien()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    // Lấy thêm cột Role
                    string sql = "SELECT Username, Email, SDT, Role, MatKhau FROM NhanVien";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        list.Add(new NhanVienDTO
                        {
                            TenDangNhap = rdr["Username"].ToString(),
                            Email = rdr["Email"].ToString(),
                            SoDienThoai = rdr["SDT"].ToString(),
                            Role = rdr["Role"].ToString(),
                            MatKhau = rdr["MatKhau"].ToString()
                        });
                    }
                }
            }
            catch (Exception) { }
            return list;
        }
    }
}
