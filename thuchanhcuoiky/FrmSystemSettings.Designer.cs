namespace thuchanhcuoiky
{
    partial class FrmSystemSettings
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

        private void InitializeComponent()
        {
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tabAdminAccount = new System.Windows.Forms.TabPage();
            this.lblAdminTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateAdmin = new System.Windows.Forms.Button();
            this.txtAdminPass = new System.Windows.Forms.TextBox();
            this.txtAdminUser = new System.Windows.Forms.TextBox();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHotelName = new System.Windows.Forms.TextBox();
            this.btnSaveGeneral = new System.Windows.Forms.Button();
            this.tcSettings.SuspendLayout();
            this.tabAdminAccount.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tabAdminAccount);
            this.tcSettings.Controls.Add(this.tabGeneral);
            this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettings.Location = new System.Drawing.Point(10, 10);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(530, 430);
            this.tcSettings.TabIndex = 0;
            // 
            // tabAdminAccount
            // 
            this.tabAdminAccount.BackColor = System.Drawing.Color.White;
            this.tabAdminAccount.Controls.Add(this.lblAdminTitle);
            this.tabAdminAccount.Controls.Add(this.label2);
            this.tabAdminAccount.Controls.Add(this.label1);
            this.tabAdminAccount.Controls.Add(this.btnCreateAdmin);
            this.tabAdminAccount.Controls.Add(this.txtAdminPass);
            this.tabAdminAccount.Controls.Add(this.txtAdminUser);
            this.tabAdminAccount.Location = new System.Drawing.Point(4, 25);
            this.tabAdminAccount.Name = "tabAdminAccount";
            this.tabAdminAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdminAccount.Size = new System.Drawing.Size(522, 401);
            this.tabAdminAccount.TabIndex = 0;
            this.tabAdminAccount.Text = "Cấp quyền Admin";
            // 
            // lblAdminTitle
            // 
            this.lblAdminTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAdminTitle.Location = new System.Drawing.Point(30, 30);
            this.lblAdminTitle.Name = "lblAdminTitle";
            this.lblAdminTitle.Size = new System.Drawing.Size(400, 30);
            this.lblAdminTitle.TabIndex = 0;
            this.lblAdminTitle.Text = "TẠO TÀI KHOẢN QUẢN TRỊ VIÊN";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(35, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu quản trị:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(35, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên đăng nhập Admin:";
            // 
            // btnCreateAdmin
            // 
            this.btnCreateAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnCreateAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAdmin.ForeColor = System.Drawing.Color.White;
            this.btnCreateAdmin.Location = new System.Drawing.Point(35, 230);
            this.btnCreateAdmin.Name = "btnCreateAdmin";
            this.btnCreateAdmin.Size = new System.Drawing.Size(350, 45);
            this.btnCreateAdmin.TabIndex = 5;
            this.btnCreateAdmin.Text = "🚀 XÁC NHẬN TẠO ADMIN";
            this.btnCreateAdmin.UseVisualStyleBackColor = false;

            // 
            // txtAdminPass
            // 
            this.txtAdminPass.Location = new System.Drawing.Point(35, 175);
            this.txtAdminPass.Name = "txtAdminPass";
            this.txtAdminPass.Size = new System.Drawing.Size(350, 22);
            this.txtAdminPass.TabIndex = 4;
            this.txtAdminPass.UseSystemPasswordChar = true;
            // 
            // txtAdminUser
            // 
            this.txtAdminUser.Location = new System.Drawing.Point(35, 105);
            this.txtAdminUser.Name = "txtAdminUser";
            this.txtAdminUser.Size = new System.Drawing.Size(350, 22);
            this.txtAdminUser.TabIndex = 2;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.txtHotelName);
            this.tabGeneral.Controls.Add(this.btnSaveGeneral);
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(522, 401);
            this.tabGeneral.TabIndex = 1;
            this.tabGeneral.Text = "Thông tin khách sạn";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(30, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên khách sạn (In hóa đơn):";
            // 
            // txtHotelName
            // 
            this.txtHotelName.Location = new System.Drawing.Point(30, 55);
            this.txtHotelName.Name = "txtHotelName";
            this.txtHotelName.Size = new System.Drawing.Size(350, 22);
            this.txtHotelName.TabIndex = 1;
            // 
            // btnSaveGeneral
            // 
            this.btnSaveGeneral.Location = new System.Drawing.Point(30, 100);
            this.btnSaveGeneral.Name = "btnSaveGeneral";
            this.btnSaveGeneral.Size = new System.Drawing.Size(120, 30);
            this.btnSaveGeneral.TabIndex = 2;
            this.btnSaveGeneral.Text = "Lưu cấu hình";
            // 
            // FrmSystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.tcSettings);
            this.Name = "FrmSystemSettings";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu Hình Hệ Thống & Phân Quyền";
            this.tcSettings.ResumeLayout(false);
            this.tabAdminAccount.ResumeLayout(false);
            this.tabAdminAccount.PerformLayout();
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcSettings;
        private System.Windows.Forms.TabPage tabAdminAccount;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Button btnCreateAdmin;
        private System.Windows.Forms.TextBox txtAdminPass;
        private System.Windows.Forms.TextBox txtAdminUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAdminTitle;
        private System.Windows.Forms.TextBox txtHotelName;
        private System.Windows.Forms.Button btnSaveGeneral;
        private System.Windows.Forms.Label label3;
    }
}