namespace GUI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnRoomStatus = new System.Windows.Forms.Button();
            this.btnAdminPanels = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.btnGuestMgmt = new System.Windows.Forms.Button();
            this.btnRoomMgmt = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.pnlSidebar.Controls.Add(this.btnRoomStatus);
            this.pnlSidebar.Controls.Add(this.btnAdminPanels);
            this.pnlSidebar.Controls.Add(this.btnChangePass);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnExit);
            this.pnlSidebar.Controls.Add(this.btnInvoice);
            this.pnlSidebar.Controls.Add(this.btnCheckOut);
            this.pnlSidebar.Controls.Add(this.btnBooking);
            this.pnlSidebar.Controls.Add(this.btnGuestMgmt);
            this.pnlSidebar.Controls.Add(this.btnRoomMgmt);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(195, 650);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnRoomStatus
            // 
            this.btnRoomStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoomStatus.FlatAppearance.BorderSize = 0;
            this.btnRoomStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoomStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRoomStatus.ForeColor = System.Drawing.Color.White;
            this.btnRoomStatus.Location = new System.Drawing.Point(0, 359);
            this.btnRoomStatus.Margin = new System.Windows.Forms.Padding(2);
            this.btnRoomStatus.Name = "btnRoomStatus";
            this.btnRoomStatus.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRoomStatus.Size = new System.Drawing.Size(195, 49);
            this.btnRoomStatus.TabIndex = 13;
            this.btnRoomStatus.Text = "🛏️  Tình trạng phòng";
            this.btnRoomStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomStatus.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnAdminPanels
            // 
            this.btnAdminPanels.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAdminPanels.FlatAppearance.BorderSize = 0;
            this.btnAdminPanels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminPanels.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdminPanels.ForeColor = System.Drawing.Color.White;
            this.btnAdminPanels.Location = new System.Drawing.Point(0, 454);
            this.btnAdminPanels.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdminPanels.Name = "btnAdminPanels";
            this.btnAdminPanels.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAdminPanels.Size = new System.Drawing.Size(195, 49);
            this.btnAdminPanels.TabIndex = 12;
            this.btnAdminPanels.Text = "Quản trị hệ thống";
            this.btnAdminPanels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminPanels.Click += new System.EventHandler(this.btnAdminPanels_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChangePass.FlatAppearance.BorderSize = 0;
            this.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePass.ForeColor = System.Drawing.Color.White;
            this.btnChangePass.Location = new System.Drawing.Point(0, 503);
            this.btnChangePass.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnChangePass.Size = new System.Drawing.Size(195, 49);
            this.btnChangePass.TabIndex = 10;
            this.btnChangePass.Text = "Đổi mật khẩu";
            this.btnChangePass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePass.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 552);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(195, 49);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(0, 601);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(195, 49);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInvoice.FlatAppearance.BorderSize = 0;
            this.btnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInvoice.ForeColor = System.Drawing.Color.White;
            this.btnInvoice.Location = new System.Drawing.Point(0, 310);
            this.btnInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnInvoice.Size = new System.Drawing.Size(195, 49);
            this.btnInvoice.TabIndex = 6;
            this.btnInvoice.Text = "💰  Hóa Đơn";
            this.btnInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(0, 261);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCheckOut.Size = new System.Drawing.Size(195, 49);
            this.btnCheckOut.TabIndex = 5;
            this.btnCheckOut.Text = "🚪  Check-Out";
            this.btnCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckOut.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBooking.FlatAppearance.BorderSize = 0;
            this.btnBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBooking.ForeColor = System.Drawing.Color.White;
            this.btnBooking.Location = new System.Drawing.Point(0, 212);
            this.btnBooking.Margin = new System.Windows.Forms.Padding(2);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnBooking.Size = new System.Drawing.Size(195, 49);
            this.btnBooking.TabIndex = 4;
            this.btnBooking.Text = "📋  Đặt Phòng";
            this.btnBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooking.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnGuestMgmt
            // 
            this.btnGuestMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGuestMgmt.FlatAppearance.BorderSize = 0;
            this.btnGuestMgmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuestMgmt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuestMgmt.ForeColor = System.Drawing.Color.White;
            this.btnGuestMgmt.Location = new System.Drawing.Point(0, 163);
            this.btnGuestMgmt.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuestMgmt.Name = "btnGuestMgmt";
            this.btnGuestMgmt.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnGuestMgmt.Size = new System.Drawing.Size(195, 49);
            this.btnGuestMgmt.TabIndex = 3;
            this.btnGuestMgmt.Text = "👥  Quản Lý Khách";
            this.btnGuestMgmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuestMgmt.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnRoomMgmt
            // 
            this.btnRoomMgmt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoomMgmt.FlatAppearance.BorderSize = 0;
            this.btnRoomMgmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoomMgmt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRoomMgmt.ForeColor = System.Drawing.Color.White;
            this.btnRoomMgmt.Location = new System.Drawing.Point(0, 114);
            this.btnRoomMgmt.Margin = new System.Windows.Forms.Padding(2);
            this.btnRoomMgmt.Name = "btnRoomMgmt";
            this.btnRoomMgmt.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRoomMgmt.Size = new System.Drawing.Size(195, 49);
            this.btnRoomMgmt.TabIndex = 2;
            this.btnRoomMgmt.Text = "🛏️  Quản Lý Phòng";
            this.btnRoomMgmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomMgmt.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 65);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(195, 49);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "📊  Bảng Điều Khiển";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(195, 65);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(195, 65);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "LUXURY HOTEL";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblCurrentUser);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(195, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(855, 65);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblCurrentUser.Location = new System.Drawing.Point(600, 20);
            this.lblCurrentUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(240, 24);
            this.lblCurrentUser.TabIndex = 1;
            this.lblCurrentUser.Text = "Xin chào, Admin";
            this.lblCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblPageTitle.Location = new System.Drawing.Point(15, 18);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(126, 30);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Dashboard";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(195, 65);
            this.pnlMainContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.pnlMainContent.Size = new System.Drawing.Size(855, 585);
            this.pnlMainContent.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Khách Sạn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnRoomMgmt;
        private System.Windows.Forms.Button btnGuestMgmt;
        private System.Windows.Forms.Button btnBooking;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnAdminPanels;
        private System.Windows.Forms.Button btnRoomStatus;
    }
}