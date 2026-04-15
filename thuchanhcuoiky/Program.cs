using DAL;
using System;
using System.Windows.Forms;
using GUI;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Kiểm tra kết nối trước
            TestDatabaseConnection();

            // 2. VÒNG LẶP ĐIỀU HƯỚNG CHÍNH
            // Vòng lặp này giúp khi bạn Close() FrmMain, nó sẽ tự động hiện lại FrmLogin
            while (true)
            {
                // Khởi tạo Login từ namespace thuchanhcuoiky
                using (thuchanhcuoiky.FrmLogin login = new thuchanhcuoiky.FrmLogin())
                {
                    // Chờ người dùng đăng nhập
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        // Nếu đăng nhập thành công (DialogResult = OK), mở Form Main
                        // Sử dụng Application.Run để FrmMain làm chủ tiến trình hiện tại
                        Application.Run(new FrmMain());

                        // Sau khi FrmMain bị đóng (this.Close() khi Logout), 
                        // luồng xử lý sẽ quay lại đầu vòng lặp while để hiện Login.
                        // Nếu muốn thoát hẳn khi nhấn X ở FrmMain mà không phải Logout, 
                        // bạn cần xử lý thêm ở bước 2 bên dưới.
                    }
                    else
                    {
                        // Nếu người dùng nhấn X hoặc Cancel ở màn hình Login -> Thoát hẳn App
                        break;
                    }
                }
            }
        }

        private static void TestDatabaseConnection()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối CSDL: {ex.Message}\n\nVui lòng kiểm tra lại chuỗi kết nối.",
                                "Kết nối thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0); // Thoát ứng dụng ngay nếu không có DB
            }
        }
    }
}