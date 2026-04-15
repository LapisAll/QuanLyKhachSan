using System.Windows.Forms;
namespace GUI
{
    partial class FrmCheckOut
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.ComboBox cbbBookings;
        public System.Windows.Forms.Label lblBookingInfo;
        public System.Windows.Forms.Label lblTotalCost;
        public System.Windows.Forms.TextBox txtServiceCost;
        public System.Windows.Forms.Button btnCheckOut;
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
            this.cbbBookings = new System.Windows.Forms.ComboBox();
            this.lblBookingInfo = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.txtServiceCost = new System.Windows.Forms.TextBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Label for booking selection
            System.Windows.Forms.Label lblBooking = new System.Windows.Forms.Label();
            lblBooking.Text = "Chọn Đơn Đặt Phòng:";
            lblBooking.Location = new System.Drawing.Point(20, 20);
            lblBooking.AutoSize = true;
            lblBooking.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Controls.Add(lblBooking);

            // cbbBookings
            this.cbbBookings.FormattingEnabled = true;
            this.cbbBookings.Location = new System.Drawing.Point(20, 50);
            this.cbbBookings.Size = new System.Drawing.Size(440, 21);
            this.cbbBookings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBookings.SelectedIndexChanged += new System.EventHandler(this.CbbBookings_SelectedIndexChanged);
            this.Controls.Add(this.cbbBookings);

            // lblBookingInfo
            this.lblBookingInfo.Location = new System.Drawing.Point(20, 90);
            this.lblBookingInfo.Size = new System.Drawing.Size(440, 100);
            this.lblBookingInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblBookingInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBookingInfo.Text = "Chọn đơn đặt phòng để xem chi tiết";
            this.Controls.Add(this.lblBookingInfo);

            // Label for service cost
            System.Windows.Forms.Label lblService = new System.Windows.Forms.Label();
            lblService.Text = "Tiền Dịch Vụ Bổ Sung (VNĐ):";
            lblService.Location = new System.Drawing.Point(20, 210);
            lblService.AutoSize = true;
            lblService.Font = new System.Drawing.Font("Arial", 10F);
            this.Controls.Add(lblService);

            // txtServiceCost
            this.txtServiceCost.Location = new System.Drawing.Point(20, 240);
            this.txtServiceCost.Size = new System.Drawing.Size(440, 20);
            this.txtServiceCost.Text = "0";
            this.Controls.Add(this.txtServiceCost);

            // lblTotalCost
            this.lblTotalCost.Location = new System.Drawing.Point(20, 280);
            this.lblTotalCost.Size = new System.Drawing.Size(440, 40);
            this.lblTotalCost.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalCost.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTotalCost.ForeColor = System.Drawing.Color.White;
            this.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalCost.Text = "Tổng tiền phòng: 0 VNĐ";
            this.Controls.Add(this.lblTotalCost);

            // btnCheckOut
            this.btnCheckOut.Text = "✅ Check-Out";
            this.btnCheckOut.Location = new System.Drawing.Point(140, 340);
            this.btnCheckOut.Size = new System.Drawing.Size(120, 45);
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.Click += new System.EventHandler(this.BtnCheckOut_Click);
            this.Controls.Add(this.btnCheckOut);

            // btnCancel
            this.btnCancel.Text = "❌ Hủy";
            this.btnCancel.Location = new System.Drawing.Point(290, 340);
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.Controls.Add(this.btnCancel);

            // FrmCheckOut
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 410);
            this.Name = "FrmCheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check-Out";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}