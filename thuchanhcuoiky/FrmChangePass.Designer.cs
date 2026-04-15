namespace thuchanhcuoiky
{
    partial class FrmChangePass
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOldPass = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(400, 10);

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Size = new System.Drawing.Size(400, 40);
            this.lblTitle.Text = "ĐỔI MẬT KHẨU";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblOldPass
            this.lblOldPass.Text = "Mật khẩu hiện tại:";
            this.lblOldPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOldPass.Location = new System.Drawing.Point(50, 85);
            this.lblOldPass.Size = new System.Drawing.Size(150, 20);

            // txtOldPass
            this.txtOldPass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtOldPass.Location = new System.Drawing.Point(50, 108);
            this.txtOldPass.Size = new System.Drawing.Size(300, 29);
            this.txtOldPass.UseSystemPasswordChar = true;

            // lblNewPass
            this.lblNewPass.Text = "Mật khẩu mới:";
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewPass.Location = new System.Drawing.Point(50, 150);
            this.lblNewPass.Size = new System.Drawing.Size(150, 20);

            // txtNewPass
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNewPass.Location = new System.Drawing.Point(50, 173);
            this.txtNewPass.Size = new System.Drawing.Size(300, 29);
            this.txtNewPass.UseSystemPasswordChar = true;

            // lblConfirmPass
            this.lblConfirmPass.Text = "Xác nhận mật khẩu mới:";
            this.lblConfirmPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmPass.Location = new System.Drawing.Point(50, 215);
            this.lblConfirmPass.Size = new System.Drawing.Size(200, 20);

            // txtConfirmPass
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtConfirmPass.Location = new System.Drawing.Point(50, 238);
            this.txtConfirmPass.Size = new System.Drawing.Size(300, 29);
            this.txtConfirmPass.UseSystemPasswordChar = true;

            // btnUpdate (Màu xanh lá đồng bộ với nút đăng nhập)
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(50, 295);
            this.btnUpdate.Size = new System.Drawing.Size(140, 40);
            this.btnUpdate.Text = "CẬP NHẬT";
            this.btnUpdate.UseVisualStyleBackColor = false;

            // btnCancel (Màu xám/đỏ nhẹ cho nút hủy)
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(210, 295);
            this.btnCancel.Size = new System.Drawing.Size(140, 40);
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;

            // FrmChangePass
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 370);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblOldPass);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
    }
}