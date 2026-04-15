using System.Windows.Forms;
namespace GUI
{
    partial class FrmGuestForm
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.TextBox txtTen;
        public System.Windows.Forms.TextBox txtCMND;
        public System.Windows.Forms.TextBox txtPhone;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtAddress;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnCancel;

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
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Labels
            System.Windows.Forms.Label lblTen = new System.Windows.Forms.Label();
            lblTen.Text = "Tên Khách Hàng:";
            lblTen.Location = new System.Drawing.Point(20, 20);
            lblTen.AutoSize = true;
            lblTen.Font = new System.Drawing.Font("Arial", 10F);
            this.Controls.Add(lblTen);

            System.Windows.Forms.Label lblCMND = new System.Windows.Forms.Label();
            lblCMND.Text = "Số CMND/CCCD:";
            lblCMND.Location = new System.Drawing.Point(20, 60);
            lblCMND.AutoSize = true;
            lblCMND.Font = new System.Drawing.Font("Arial", 10F);
            this.Controls.Add(lblCMND);

            System.Windows.Forms.Label lblPhone = new System.Windows.Forms.Label();
            lblPhone.Text = "Điện Thoại:";
            lblPhone.Location = new System.Drawing.Point(20, 100);
            lblPhone.AutoSize = true;
            lblPhone.Font = new System.Drawing.Font("Arial", 10F);
            this.Controls.Add(lblPhone);

            System.Windows.Forms.Label lblEmail = new System.Windows.Forms.Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new System.Drawing.Point(20, 140);
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Arial", 10F);
            this.Controls.Add(lblEmail);

            System.Windows.Forms.Label lblAddress = new System.Windows.Forms.Label();
            lblAddress.Text = "Địa Chỉ:";
            lblAddress.Location = new System.Drawing.Point(20, 180);
            lblAddress.AutoSize = true;
            lblAddress.Font = new System.Drawing.Font("Arial", 10F);
            this.Controls.Add(lblAddress);

            // TextBoxes
            this.txtTen.Location = new System.Drawing.Point(130, 20);
            this.txtTen.Size = new System.Drawing.Size(250, 20);

            this.txtCMND.Location = new System.Drawing.Point(130, 60);
            this.txtCMND.Size = new System.Drawing.Size(250, 20);

            this.txtPhone.Location = new System.Drawing.Point(130, 100);
            this.txtPhone.Size = new System.Drawing.Size(250, 20);

            this.txtEmail.Location = new System.Drawing.Point(130, 140);
            this.txtEmail.Size = new System.Drawing.Size(250, 20);

            this.txtAddress.Location = new System.Drawing.Point(130, 180);
            this.txtAddress.Size = new System.Drawing.Size(250, 20);

            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAddress);

            // Buttons
            this.btnSave.Text = "💾 Lưu";
            this.btnSave.Location = new System.Drawing.Point(130, 240);
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.Location = new System.Drawing.Point(280, 240);
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 310);
            this.Name = "FrmGuestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Khách Hàng";
            this.ResumeLayout(false);
        }
    }
}