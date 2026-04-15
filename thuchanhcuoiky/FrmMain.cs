using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using thuchanhcuoiky;
using GUI;

namespace GUI
{
    public partial class FrmMain : Form
    {
        private PhongBUS phongBUS = new PhongBUS();
        private KhachHangBUS khachHangBUS = new KhachHangBUS();
        private DatPhongBUS datPhongBUS = new DatPhongBUS();
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 1. Thực hiện phân quyền trước khi hiển thị
            PhanQuyen();

            // 2. Mặc định load Dashboard
            HighlightButton(btnDashboard);
            LoadDashboard();

            // Khử răng cưa/giật lag cho Panel
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, pnlMainContent, new object[] { true });
        }

        #region Navigation Logic (Xử lý điều hướng)

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            // 1. Hiệu ứng highlight nút
            HighlightButton(btn);

            // 2. Cập nhật tiêu đề trang (Cắt icon emoji nếu có)
            if (btn.Text.Length > 3)
                lblPageTitle.Text = btn.Text.Substring(3).Trim();
            else
                lblPageTitle.Text = btn.Text;

            string choice = btn.Text;

            // 3. XỬ LÝ ĐIỀU HƯỚNG
            // Kiểm tra Tình trạng phòng
            if (choice.Contains("Tình trạng phòng"))
            {
                using (GUI.FrmRoomStatus frm = new GUI.FrmRoomStatus(this.phongBUS))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
                HighlightButton(btnDashboard);
                LoadDashboard();
            }
           
            {
                // Các chức năng nạp vào Panel chính
                pnlMainContent.Controls.Clear();

                if (choice.Contains("Bảng Điều Khiển")) LoadDashboard();
                else if (choice.Contains("Quản Lý Phòng")) LoadRoomManagement();
                else if (choice.Contains("Quản Lý Khách")) LoadGuestManagement();
                else if (choice.Contains("Đặt Phòng")) LoadBooking();
                else if (choice.Contains("Check-Out")) OpenCheckOutForm();
                else if (choice.Contains("Hóa Đơn")) LoadInvoices();
                else if (choice.Contains("Quản trị hệ thống")) LoadAdminPanel();
                else if (choice.Contains("Đổi mật khẩu")) OpenChangePassword();
            }
        }

        private void LoadAdminPanel()
        {
            pnlMainContent.Controls.Clear();

            // Tạo FlowLayoutPanel để các nút tự sắp xếp đẹp mắt
            FlowLayoutPanel flpAdminMenu = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30),
                BackColor = Color.Transparent
            };

            // 1. Nút Quản lý/Chỉnh sửa phòng (Giá, loại phòng)
            Button btnEditRoom = CreateAdminCard("🏠 QUẢN LÝ PHÒNG", "Chỉnh sửa giá và loại phòng", Color.FromArgb(52, 152, 219));
            btnEditRoom.Click += (s, e) => {
                using (FrmEditRoom frm = new FrmEditRoom())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            };

            // 2. Nút Cài đặt hệ thống (Thêm Admin, Thông tin khách sạn)
            Button btnSysSettings = CreateAdminCard("⚙️ HỆ THỐNG", "Thêm Admin & Cấu hình chung", Color.FromArgb(155, 89, 182));
            btnSysSettings.Click += (s, e) => {
                using (FrmSystemSettings frm = new FrmSystemSettings())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            };

            // 3. Nút Quản lý nhân viên (Danh sách nhân viên hiện có)
            Button btnUserMgmt = CreateAdminCard("👥 NHÂN VIÊN", "Xem danh sách tài khoản", Color.FromArgb(46, 204, 113));
            btnUserMgmt.Click += (s, e) => LoadEmployeeManagement();

            flpAdminMenu.Controls.Add(btnEditRoom);
            flpAdminMenu.Controls.Add(btnSysSettings);
            flpAdminMenu.Controls.Add(btnUserMgmt);

            pnlMainContent.Controls.Add(flpAdminMenu);
        }

        // Hàm hỗ trợ tạo nút bấm kiểu Card cho đẹp
        private Button CreateAdminCard(string title, string description, Color themeColor)
        {
            Button btn = new Button
            {
                Text = title + "\n\n" + description,
                Size = new Size(280, 160),
                Margin = new Padding(15),
                BackColor = themeColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void HighlightButton(Button selectedBtn)
        {
            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(31, 41, 55); // Màu gốc
                }
            }
            selectedBtn.BackColor = Color.FromArgb(59, 130, 246); // Màu xanh highlight
        }

        #endregion

        #region Dashboard & Room Map (Bảng điều khiển & Sơ đồ phòng)

        private void LoadDashboard()
        {
            pnlMainContent.Controls.Clear();

            // 1. Lấy số liệu thống kê
            int totalRooms = phongBUS.GetAllRooms().Count;
            int availableRooms = phongBUS.GetAvailableRooms().Count;
            int totalGuests = khachHangBUS.GetAllGuests().Count;
            int activeBookings = datPhongBUS.GetActiveBookings().Count;

            // 2. Vẽ các Card thống kê (Tọa độ X, Y tương đối trong pnlMainContent)
            AddStatisticCard("TỔNG SỐ PHÒNG", totalRooms.ToString(), 20, 20, Color.FromArgb(16, 185, 129));
            AddStatisticCard("PHÒNG CÒN TRỐNG", availableRooms.ToString(), 320, 20, Color.FromArgb(59, 130, 246));
            AddStatisticCard("KHÁCH ĐANG Ở", activeBookings.ToString(), 620, 20, Color.FromArgb(245, 158, 11));
            AddStatisticCard("KHÁCH HÀNG", totalGuests.ToString(), 920, 20, Color.FromArgb(139, 92, 246));

            // 3. Tiêu đề sơ đồ phòng
            Label lblMap = new Label
            {
                Text = "Sơ Đồ Phòng Trực Tuyến",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location = new Point(20, 160),
                AutoSize = true
            };
            pnlMainContent.Controls.Add(lblMap);

            // 4. Panel chứa danh sách phòng (FlowLayout)
            FlowLayoutPanel flowRoomMap = new FlowLayoutPanel
            {
                Location = new Point(20, 200),
                Size = new Size(pnlMainContent.Width - 40, pnlMainContent.Height - 220),
                AutoScroll = true,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            var rooms = phongBUS.GetAllRooms();
            foreach (var room in rooms)
            {
                Panel cardRoom = new Panel { Width = 130, Height = 130, Margin = new Padding(10), BackColor = Color.White };

                // Đổi màu theo trạng thái (Xanh: Trống, Đỏ: Có khách, Vàng: Bẩn)
                Color statusColor = room.TrangThaiPhong == "Available" ? Color.FromArgb(34, 197, 94) :
                                   room.TrangThaiPhong == "Occupied" ? Color.FromArgb(239, 68, 68) : Color.FromArgb(234, 179, 8);

                Panel pnlStatus = new Panel { Dock = DockStyle.Top, Height = 5, BackColor = statusColor };
                Label lblName = new Label { Text = room.TenPhong, Dock = DockStyle.Top, TextAlign = ContentAlignment.BottomCenter, Height = 40, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
                Label lblType = new Label { Text = room.LoaiPhong, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, Height = 30, ForeColor = Color.Gray };
                Label lblSttText = new Label { Text = room.TrangThaiPhong, Dock = DockStyle.Bottom, TextAlign = ContentAlignment.MiddleCenter, Height = 30, ForeColor = statusColor, Font = new Font("Segoe UI", 8, FontStyle.Bold) };

                cardRoom.Controls.Add(lblSttText);
                cardRoom.Controls.Add(lblType);
                cardRoom.Controls.Add(lblName);
                cardRoom.Controls.Add(pnlStatus);

                cardRoom.Cursor = Cursors.Hand;
                cardRoom.Click += (s, e) => {
                    // 1. Lưu mã phòng vào Tag của Panel chính để hàm LoadBooking có thể đọc được
                    pnlMainContent.Tag = room.MaPhong;

                    // 2. Gọi hàm điều hướng sang trang Đặt Phòng
                    // Giả sử nút sidebar Đặt phòng của bạn tên là btnBooking
                    MenuButton_Click(this.btnBooking, EventArgs.Empty);
                };

                flowRoomMap.Controls.Add(cardRoom);
            }
            pnlMainContent.Controls.Add(flowRoomMap);
        }

        private void AddStatisticCard(string title, string value, int x, int y, Color themeColor)
        {
            Panel card = new Panel
            {
                Size = new Size(280, 120),
                Location = new Point(x, y),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Trang trí một đường kẻ bên trái card
            Panel line = new Panel { Dock = DockStyle.Left, Width = 5, BackColor = themeColor };
            Label lblT = new Label { Text = title, ForeColor = Color.Gray, Font = new Font("Segoe UI", 9, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
            Label lblV = new Label { Text = value, ForeColor = Color.FromArgb(31, 41, 55), Font = new Font("Segoe UI", 24, FontStyle.Bold), Location = new Point(20, 45), AutoSize = true };

            card.Controls.Add(lblV);
            card.Controls.Add(lblT);
            card.Controls.Add(line);
            pnlMainContent.Controls.Add(card);
        }

        #endregion

        #region Management Data Grids (Quản lý các bảng dữ liệu)

        private void LoadRoomManagement()
        {
            pnlMainContent.Controls.Clear();

            // Gọi đúng tên hàm CreateSearchControl
            var searchComp = CreateSearchControl("Nhập tên phòng...", (s, e) => {
                var grid = pnlMainContent.Controls.Find("dgvRoomMgmt", true).FirstOrDefault() as DataGridView;
                var txtInput = pnlMainContent.Tag as TextBox;

                if (grid != null && txtInput != null)
                {
                    grid.Rows.Clear();
                    string key = txtInput.Text.ToLower();
                    if (key == "nhập tên phòng...") key = "";

                    var filtered = phongBUS.GetAllRooms().Where(r =>
                        r.TenPhong.ToLower().Contains(key) || r.MaPhong.ToString().Contains(key));

                    foreach (var r in filtered)
                        grid.Rows.Add(r.MaPhong, r.TenPhong, r.LoaiPhong, r.GiaPhong.ToString("N0"), r.TrangThaiPhong);
                }
            });

            pnlMainContent.Tag = searchComp.TextBox; // Lưu để Lambda dùng lại
            pnlMainContent.Controls.Add(searchComp.Panel);

            DataGridView dgv = CreateGrid();
            dgv.Name = "dgvRoomMgmt";
            dgv.Top = 60; dgv.Height -= 60;
            dgv.Columns.Add("Ma", "Mã");
            dgv.Columns.Add("Ten", "Tên Phòng");
            dgv.Columns.Add("Loai", "Loại");
            dgv.Columns.Add("Gia", "Giá Niêm Yết");
            dgv.Columns.Add("TT", "Trạng Thái");

            foreach (var r in phongBUS.GetAllRooms())
                dgv.Rows.Add(r.MaPhong, r.TenPhong, r.LoaiPhong, r.GiaPhong.ToString("N0"), r.TrangThaiPhong);

            pnlMainContent.Controls.Add(dgv);
        }

        private void LoadGuestManagement()
        {
            pnlMainContent.Controls.Clear();

            // 1. Tạo Component Tìm kiếm
            var searchComp = CreateSearchControl("Nhập tên hoặc CCCD...", (s, e) => {
                // --- FIX LỖI Lambda ---
                // Dùng 'gridKhach' để tránh trùng tên (CS0136)
                var gridKhach = pnlMainContent.Controls.Find("dgvGuestMgmt", true).FirstOrDefault() as DataGridView;

                // Lấy keyword từ Tag (Fix CS1628)
                var txt = pnlMainContent.Tag as TextBox;
                string key = (txt != null) ? txt.Text.ToLower() : "";
                if (key == "nhập tên hoặc cccd...") key = "";

                if (gridKhach != null)
                {
                    gridKhach.Rows.Clear();
                    var filtered = khachHangBUS.GetAllGuests().Where(g =>
                        g.TenKhach.ToLower().Contains(key) || g.SoCMND.Contains(key));
                    foreach (var g in filtered)
                        gridKhach.Rows.Add(g.MaKhach, g.TenKhach, g.SoCMND, g.SoDienThoai);
                }
            });

            pnlMainContent.Tag = searchComp.TextBox;
            pnlMainContent.Controls.Add(searchComp.Panel);

            // 2. Thêm nút "Thêm khách" vào Panel tìm kiếm (Dịch nút Add)
            Button btnAdd = new Button { Text = "➕ Thêm Khách", Location = new Point(450, 12), Size = new Size(130, 32), BackColor = Color.FromArgb(16, 185, 129), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnAdd.Click += (s, e) => { if (new FrmGuestForm(khachHangBUS).ShowDialog() == DialogResult.OK) LoadGuestManagement(); };
            searchComp.Panel.Controls.Add(btnAdd);

            // 3. Tạo Grid
            DataGridView dgv = CreateGrid();
            dgv.Name = "dgvGuestMgmt";
            dgv.Top = 60; dgv.Height -= 60;
            dgv.Columns.Add("Ma", "ID");
            dgv.Columns.Add("Ten", "Họ Tên");
            dgv.Columns.Add("CMND", "Số CCCD");
            dgv.Columns.Add("SDT", "SĐT");

            foreach (var g in khachHangBUS.GetAllGuests())
                dgv.Rows.Add(g.MaKhach, g.TenKhach, g.SoCMND, g.SoDienThoai);

            pnlMainContent.Controls.Add(dgv);
        }

        private void LoadBooking()
        {
            pnlMainContent.Controls.Clear();

            // 1. Tích hợp thanh tìm kiếm (Tìm theo Tên khách hoặc Mã phòng)
            var searchComp = CreateSearchControl("Nhập tên khách hoặc mã phòng...", (s, e) => {
                var grid = pnlMainContent.Controls.Find("dgvBookingMgmt", true).FirstOrDefault() as DataGridView;
                var txtInput = pnlMainContent.Tag as TextBox;

                if (grid != null && txtInput != null)
                {
                    grid.Rows.Clear();
                    string key = txtInput.Text.ToLower();
                    if (key == "nhập tên khách hoặc mã phòng...") key = "";

                    var allBookings = datPhongBUS.GetAllBookings();
                    var allGuests = khachHangBUS.GetAllGuests();

                    // TỐI ƯU: Lọc bỏ những đơn đặt không tìm thấy khách (N/A) ngay từ khâu Search
                    var filtered = allBookings.Where(b => {
                        var guest = allGuests.FirstOrDefault(g => g.MaKhach == b.MaKhach);
                        if (guest == null) return false; // Không khớp thì bỏ qua đơn này

                        string guestName = guest.TenKhach.ToLower();
                        return guestName.Contains(key) || b.MaPhong.ToString().Contains(key);
                    });

                    foreach (var b in filtered)
                    {
                        var guest = allGuests.FirstOrDefault(g => g.MaKhach == b.MaKhach);
                        // Vì đã lọc ở trên nên chắc chắn guest != null
                        grid.Rows.Add(b.MaDatPhong, guest.TenKhach, b.MaPhong, b.NgayCheckIn.ToString("dd/MM/yyyy HH:mm"));
                    }
                }
            });

            pnlMainContent.Tag = searchComp.TextBox;
            pnlMainContent.Controls.Add(searchComp.Panel);

            // 2. Nút thêm đặt phòng mới
            Button btnAdd = new Button
            {
                Text = "📝 Đặt Phòng Ngay",
                Location = new Point(450, 12),
                Size = new Size(160, 32),
                BackColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += (s, e) => { if (new FrmBookingForm(datPhongBUS, phongBUS, khachHangBUS).ShowDialog() == DialogResult.OK) LoadBooking(); };
            searchComp.Panel.Controls.Add(btnAdd);

            // 3. Tạo Grid hiển thị
            DataGridView dgv = CreateGrid();
            dgv.Name = "dgvBookingMgmt";
            dgv.Top = 60; dgv.Height -= 60;
            dgv.Columns.Add("Ma", "Mã Đặt");
            dgv.Columns.Add("Khach", "Tên Khách Hàng");
            dgv.Columns.Add("Phong", "Mã Phòng");
            dgv.Columns.Add("CheckIn", "Ngày Đến");

            // 4. Đổ dữ liệu ban đầu
            var bookings = datPhongBUS.GetAllBookings();
            var guests = khachHangBUS.GetAllGuests();

            foreach (var b in bookings)
            {
                var guest = guests.FirstOrDefault(g => g.MaKhach == b.MaKhach);

                // PHƯƠNG ÁN TỐI ƯU: Chỉ thêm vào Grid nếu khách hàng TỒN TẠI
                // Điều này sẽ xóa bỏ hoàn toàn các dòng "Không xác định" sau khi Checkout
                if (guest != null)
                {
                    dgv.Rows.Add(b.MaDatPhong, guest.TenKhach, b.MaPhong, b.NgayCheckIn.ToString("dd/MM/yyyy HH:mm"));
                }
                else
                {
                    // Tùy chọn: Có thể gọi datPhongBUS.DeleteBooking(b.MaDatPhong) để dọn rác ngầm
                }
            }

            pnlMainContent.Controls.Add(dgv);

            if (pnlMainContent.Tag != null && pnlMainContent.Tag is int selectedMaPhong)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["Phong"].Value != null && (int)row.Cells["Phong"].Value == selectedMaPhong)
                    {
                        dgv.ClearSelection();
                        row.Selected = true; 

                        dgv.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
                pnlMainContent.Tag = null;
            }
        }

        private void LoadInvoices()
        {
            pnlMainContent.Controls.Clear();

            // 1. Panel tìm kiếm (Giữ nguyên logic cũ của bạn)
            var searchComp = CreateSearchControl("Nhập tên khách hàng...", (s, e) => {
                var grid = pnlMainContent.Controls.Find("dgvInvoiceMgmt", true).FirstOrDefault() as DataGridView;
                var txt = pnlMainContent.Tag as TextBox;
                if (grid != null && txt != null)
                {
                    grid.Rows.Clear();
                    string key = txt.Text.ToLower();
                    if (key == "nhập tên khách hàng...") key = "";
                    var filtered = hoaDonBUS.GetAllInvoices().Where(i => i.TenKhachHang.ToLower().Contains(key));
                    foreach (var i in filtered)
                        grid.Rows.Add(i.MaHoaDon, i.TenKhachHang, i.NgayTao.ToString("dd/MM/yyyy HH:mm"), i.TongTien.ToString("N0"));
                }
            });

            pnlMainContent.Tag = searchComp.TextBox;
            pnlMainContent.Controls.Add(searchComp.Panel);

            // --- MỚI: Thêm nút Xuất Excel cho dòng đang chọn ---
            Button btnReExport = new Button
            {
                Text = "📥 Xuất Excel (Dòng chọn)",
                Location = new Point(450, 12), // Đặt cạnh nút tìm kiếm
                Size = new Size(180, 32),
                BackColor = Color.FromArgb(34, 197, 94),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnReExport.Click += (s, e) => {
                var dgv = pnlMainContent.Controls.Find("dgvInvoiceMgmt", true).FirstOrDefault() as DataGridView;
                if (dgv?.SelectedRows.Count > 0)
                {
                    int maHD = (int)dgv.SelectedRows[0].Cells["Ma"].Value;
                    var hd = hoaDonBUS.GetInvoiceById(maHD); // Lấy lại đầy đủ thông tin từ DB
                    if (hd != null)
                    {
                        ExcelHelper.ExportInvoice(hd); // Gọi Class tiện ích đã tạo ở Bước 1
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn trong danh sách!");
                }
            };
            searchComp.Panel.Controls.Add(btnReExport);

            // 2. Tạo Grid (Giữ nguyên)
            DataGridView dgvMain = CreateGrid();
            dgvMain.Name = "dgvInvoiceMgmt";
            dgvMain.Top = 60; dgvMain.Height -= 60;
            dgvMain.Columns.Add("Ma", "Số HĐ");
            dgvMain.Columns.Add("Khach", "Khách Hàng");
            dgvMain.Columns.Add("Ngay", "Ngày Lập");
            dgvMain.Columns.Add("Tong", "Thành Tiền");

            foreach (var i in hoaDonBUS.GetAllInvoices())
                dgvMain.Rows.Add(i.MaHoaDon, i.TenKhachHang, i.NgayTao.ToString("dd/MM/yyyy HH:mm"), i.TongTien.ToString("N0"));

            pnlMainContent.Controls.Add(dgvMain);
        }

        #endregion

        #region Helpers (Hàm bổ trợ)
        // Nằm trong #region Helpers
        private SearchComponent CreateSearchControl(string hint, EventHandler searchAction)
        {
            // 1. Panel chứa ô tìm kiếm và nút bấm
            Panel pnl = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(20, 10, 20, 10) };

            // 2. Ô TextBox nhập từ khóa
            TextBox txt = new TextBox { Width = 300, Font = new Font("Segoe UI", 11), Location = new Point(20, 15) };

            // Mẹo giả lập Placeholder (Lỗi 'PlaceholderText' biến mất)
            txt.Text = hint;
            txt.ForeColor = Color.Gray;
            txt.Enter += (s, e) => { if (txt.Text == hint) { txt.Text = ""; txt.ForeColor = Color.Black; } };
            txt.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = hint; txt.ForeColor = Color.Gray; } };

            // 3. Nút Tìm kiếm
            Button btn = new Button
            {
                Text = "🔍 Tìm kiếm",
                Location = new Point(330, 12),
                Size = new Size(100, 32),
                BackColor = Color.FromArgb(107, 114, 128),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderSize = 0;

            // Gán sự kiện click và phím Enter
            btn.Click += searchAction;
            txt.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) searchAction(s, e); };

            // 4. Lắp ráp và trả về Component
            pnl.Controls.Add(txt);
            pnl.Controls.Add(btn);
            return new SearchComponent { Panel = pnl, TextBox = txt };
        }
        private DataGridView CreateGrid()
        {
            DataGridView dgv = new DataGridView
            {
                // 1. Sửa lỗi viết đúng thuộc tính Location
                Location = new Point(20, 20),
                Width = pnlMainContent.Width - 40,
                Height = pnlMainContent.Height - 40,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,

                // --- PHẦN CỐ ĐỊNH ---
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                AllowUserToOrderColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,

                // --- CÁC THIẾT LẬP KHÁC ---
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            // 2. Thiết kế tiêu đề (Header)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 244, 246);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;
            dgv.EnableHeadersVisualStyles = false;

            // 3. Tăng trải nghiệm người dùng (Dòng xen kẽ màu)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // --- ĐÂY LÀ ĐOẠN SỬA LỖI CS1061 ---
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246); // Màu nền khi chọn dòng
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;                // Màu chữ khi chọn dòng

            return dgv;
        }

        private void OpenCheckOutForm()
        {
            using (var f = new FrmCheckOut(datPhongBUS, phongBUS, hoaDonBUS))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadDashboard();
            }
        }

        #endregion


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát hẳn chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Gỡ sự kiện FormClosing để không bị hỏi lại lần nữa
                this.FormClosing -= FrmMain_FormClosing;

                // THOÁT HẲN: Không quay về Program.cs để chạy vòng lặp nữa
                Application.Exit();
            }
        }

        // 2. Hàm xử lý sự kiện đóng Form
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát hệ thống không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2 
            );


            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void OpenChangePassword()
        {
            using (FrmChangePass frm = new FrmChangePass())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            HighlightButton(btnDashboard);
            LoadDashboard();
        }
        private void LoadEmployeeManagement()
        {
            pnlMainContent.Controls.Clear();

            // 1. Tạo nút bấm để mở Form đăng ký (Pop-up)
            Button btnAddNew = new Button
            {
                Text = "➕ Thêm Nhân Viên Mới",
                Location = new Point(20, 20),
                Size = new Size(200, 45),
                BackColor = Color.FromArgb(79, 70, 229),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnAddNew.FlatAppearance.BorderSize = 0;

            btnAddNew.Click += (s, e) =>
            {
                // Mở Form đăng ký riêng biệt
                using (thuchanhcuoiky.FrmRegister frm = new thuchanhcuoiky.FrmRegister())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadEmployeeManagement(); // Tự động load lại bảng sau khi đăng ký thành công
                    }
                }
            };
            pnlMainContent.Controls.Add(btnAddNew);

            // 2. Hiển thị danh sách nhân viên hiện có (DataGridView)
            DataGridView dgv = CreateGrid();
            dgv.Top = 80;
            dgv.Height -= 80;

            dgv.Columns.Add("User", "Tên Đăng Nhập");
            dgv.Columns.Add("Email", "Email");
            dgv.Columns.Add("SDT", "Số Điện Thoại");
            dgv.Columns.Add("Pass", "Mật Khẩu");

            // Khai báo BUS để lấy dữ liệu
            NhanVienBUS nvBUS = new NhanVienBUS();
            var list = nvBUS.LayDanhSachNhanVien();

            if (list != null)
            {
                foreach (var nv in list)
                {
                    dgv.Rows.Add(nv.TenDangNhap, nv.Email, nv.SoDienThoai, nv.MatKhau);
                }
            }

            pnlMainContent.Controls.Add(dgv);
        }
        private void PhanQuyen()
        {
            string userRole = DTO.Session.Role;
            string userName = DTO.Session.Username;

            if (userRole == "Admin")
            {
                btnAdminPanels.Visible = true;
                lblCurrentUser.Text = "👑 Quản lý: " + userName;
            }
            else
            {
                btnAdminPanels.Visible = false;
                lblCurrentUser.Text = "👤 Nhân viên: " + userName;
            }
        }
        private void btnRoomStatus_Click(object sender, EventArgs e)
        {
            // Truyền đối tượng phongBUS vào Constructor của FrmRoomStatus
            using (GUI.FrmRoomStatus frm = new GUI.FrmRoomStatus(this.phongBUS))
            {
                frm.ShowDialog(); 
                LoadDashboard();   
            }
        }


        private void btnAdminPanels_Click(object sender, EventArgs e)
        {
            MenuButton_Click(sender, e);
        }
        private void OpenAssignGuestForm(int maPhong, string tenPhong)
        {
            // 1. Tìm thông tin đơn đặt phòng (Booking) mới nhất của phòng này
            var currentBooking = datPhongBUS.GetAllBookings()
                                .Where(b => b.MaPhong == maPhong)
                                .OrderByDescending(b => b.NgayCheckIn)
                                .FirstOrDefault();

            // 2. TẠO FORM XÁC NHẬN NHANH
            Form frmAction = new Form
            {
                Text = "Xử lý đặt phòng: " + tenPhong,
                Size = new Size(400, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.White
            };

            Label lblInfo = new Label
            {
                Text = currentBooking != null ? $"Khách hàng: {currentBooking.MaKhach}\nNgày hẹn: {currentBooking.NgayCheckIn:dd/MM/yyyy}" : "Phòng chưa có thông tin đặt trước.",
                Location = new Point(20, 20),
                Size = new Size(350, 60),
                Font = new Font("Segoe UI", 10)
            };

            // NÚT 1: NHẬN PHÒNG (Chuyển sang Occupied)
            Button btnCheckIn = new Button
            {
                Text = "📥 NHẬN PHÒNG",
                Location = new Point(20, 100),
                Size = new Size(160, 50),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // NÚT 2: HỦY ĐẶT TRƯỚC (Chuyển về Available)
            Button btnCancel = new Button
            {
                Text = "❌ HỦY ĐẶT CHỖ",
                Location = new Point(200, 100),
                Size = new Size(160, 50),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // XỬ LÝ SỰ KIỆN NHẬN PHÒNG
            btnCheckIn.Click += (s, e) => {
                if (currentBooking != null && currentBooking.NgayCheckIn.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("Chưa đến ngày hẹn, không thể nhận phòng!", "Thông báo");
                    return;
                }

                if (phongBUS.ChangeRoomStatus(maPhong, "Occupied"))
                {
                    MessageBox.Show("Khách đã nhận phòng thành công!", "Thông báo");
                    frmAction.Close();
                    RefreshData(); // Hàm tự viết để load lại Grid và Dashboard
                }
            };

            // XỬ LÝ SỰ KIỆN HỦY ĐẶT TRƯỚC
            btnCancel.Click += (s, e) => {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn hủy đơn đặt phòng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    // 1. Trả trạng thái phòng về trống
                    phongBUS.ChangeRoomStatus(maPhong, "Available");
                    // 2. (Tùy chọn) Xóa hoặc cập nhật trạng thái đơn trong bảng DatPhong
                    datPhongBUS.DeleteBooking(currentBooking.MaDatPhong);

                    MessageBox.Show("Đã hủy đặt trước. Phòng hiện tại đã trống.", "Thông báo");
                    frmAction.Close();
                    RefreshData();
                }
            };

            frmAction.Controls.AddRange(new Control[] { lblInfo, btnCheckIn, btnCancel });
            frmAction.ShowDialog();
        }
        private void ProcessWalkIn(int maPhong, string tenPhong)
        {
            DialogResult dr = MessageBox.Show($"Phòng {tenPhong} đang trống. Bạn có muốn làm thủ tục nhận phòng ngay cho khách vãng lai không?",
                                              "Nhận phòng trực tiếp", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                // Mở Form Đặt phòng nhưng truyền sẵn MaPhong và mặc định Ngày là Hôm nay
                using (FrmBookingForm frm = new FrmBookingForm(datPhongBUS, phongBUS, khachHangBUS))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi lưu đơn đặt, tự động chuyển trạng thái phòng luôn
                        phongBUS.ChangeRoomStatus(maPhong, "Occupied");
                        LoadRoomManagement();
                        LoadDashboard();
                    }
                }
            }
        }
        private void RefreshData()
        {
            LoadRoomManagement(); // Cập nhật danh sách bảng
            LoadDashboard();      // Cập nhật lại sơ đồ phòng (đổi màu xanh/đỏ)
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 1. Xóa dữ liệu phiên làm việc hiện tại
                DTO.Session.Username = null;
                DTO.Session.Role = null;
                this.FormClosing -= FrmMain_FormClosing;

                this.Close(); // Đóng FrmMain, luồng xử lý sẽ quay về vòng lặp ở Program.cs
            }
        }
        public class SearchComponent
        {
            public Panel Panel { get; set; }
            public TextBox TextBox { get; set; }
        }
    }
}