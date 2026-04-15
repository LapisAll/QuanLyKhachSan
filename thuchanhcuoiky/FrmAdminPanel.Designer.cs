
namespace thuchanhcuoiky
{
    partial class FrmAdminPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnManageRooms = new System.Windows.Forms.Button();
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.btnSystemSettings = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpMenu
            // 
            this.flpMenu.Controls.Add(this.btnManageRooms);
            this.flpMenu.Controls.Add(this.btnManageEmployees);
            this.flpMenu.Controls.Add(this.btnSystemSettings);
            this.flpMenu.Location = new System.Drawing.Point(50, 100);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(900, 500);
            this.flpMenu.TabIndex = 0;
            // 
            // btnManageRooms
            // 
            this.btnManageRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnManageRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageRooms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageRooms.ForeColor = System.Drawing.Color.White;
            this.btnManageRooms.Location = new System.Drawing.Point(20, 20);
            this.btnManageRooms.Margin = new System.Windows.Forms.Padding(20);
            this.btnManageRooms.Name = "btnManageRooms";
            this.btnManageRooms.Size = new System.Drawing.Size(250, 150);
            this.btnManageRooms.TabIndex = 0;
            this.btnManageRooms.Text = "🏠 QUẢN LÝ PHÒNG";
            this.btnManageRooms.UseVisualStyleBackColor = false;
            this.btnManageRooms.Click += new System.EventHandler(this.btnManageRooms_Click);
            // 
            // btnManageEmployees
            // 
            this.btnManageEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnManageEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageEmployees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageEmployees.ForeColor = System.Drawing.Color.White;
            this.btnManageEmployees.Location = new System.Drawing.Point(310, 20);
            this.btnManageEmployees.Margin = new System.Windows.Forms.Padding(20);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(250, 150);
            this.btnManageEmployees.TabIndex = 1;
            this.btnManageEmployees.Text = "👥 TÀI KHOẢN NHÂN VIÊN";
            this.btnManageEmployees.UseVisualStyleBackColor = false;
            // 
            // btnSystemSettings
            // 
            this.btnSystemSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnSystemSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSystemSettings.ForeColor = System.Drawing.Color.White;
            this.btnSystemSettings.Location = new System.Drawing.Point(600, 20);
            this.btnSystemSettings.Margin = new System.Windows.Forms.Padding(20);
            this.btnSystemSettings.Name = "btnSystemSettings";
            this.btnSystemSettings.Size = new System.Drawing.Size(250, 150);
            this.btnSystemSettings.TabIndex = 2;
            this.btnSystemSettings.Text = "⚙️ HỆ THỐNG";
            this.btnSystemSettings.UseVisualStyleBackColor = false;
            this.btnSystemSettings.Click += new System.EventHandler(this.btnSystemSettings_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(50, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(419, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BẢNG QUẢN TRỊ ADMIN";
            // 
            // FrmAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.flpMenu);
            this.Name = "FrmAdminPanel";
            this.flpMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Button btnManageRooms;
        private System.Windows.Forms.Button btnManageEmployees;
        private System.Windows.Forms.Button btnSystemSettings;
        private System.Windows.Forms.Label lblTitle;
    }
}