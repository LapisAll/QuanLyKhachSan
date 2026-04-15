using System.Windows.Forms;

namespace GUI
{
    partial class FrmBookingForm
    {
        private System.ComponentModel.IContainer components = null;
        public ComboBox cbbGuest;
        public ComboBox cbbRoom;

        public DateTimePicker dtCheckIn;
        public DateTimePicker dtCheckOut;
        public DateTimePicker dtTimeIn;
        public DateTimePicker dtTimeOut;

        public NumericUpDown numAdults;
        public NumericUpDown numChildren;
        public TextBox txtNotes;
        public Button btnSave;
        public Button btnCancel;

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
            this.cbbGuest = new System.Windows.Forms.ComboBox();
            this.cbbRoom = new System.Windows.Forms.ComboBox();
            this.dtCheckIn = new System.Windows.Forms.DateTimePicker();
            this.dtCheckOut = new System.Windows.Forms.DateTimePicker();

            // BƯỚC 2: Khởi tạo (new) ngay lập tức trước khi gán tọa độ
            this.dtTimeIn = new System.Windows.Forms.DateTimePicker();
            this.dtTimeOut = new System.Windows.Forms.DateTimePicker();

            this.numAdults = new System.Windows.Forms.NumericUpDown();
            this.numChildren = new System.Windows.Forms.NumericUpDown();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            System.Windows.Forms.Label lblGuest = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblRoom = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblIn = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblOut = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblAdult = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblChild = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numAdults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChildren)).BeginInit();
            this.SuspendLayout();

            // lblGuest
            lblGuest.Text = "Khách hàng:";
            lblGuest.Location = new System.Drawing.Point(20, 20);
            lblGuest.AutoSize = true;

            // cbbGuest
            this.cbbGuest.Location = new System.Drawing.Point(130, 20);
            this.cbbGuest.Size = new System.Drawing.Size(250, 21);
            this.cbbGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblRoom
            lblRoom.Text = "Phòng:";
            lblRoom.Location = new System.Drawing.Point(20, 60);
            lblRoom.AutoSize = true;

            // cbbRoom
            this.cbbRoom.Location = new System.Drawing.Point(130, 60);
            this.cbbRoom.Size = new System.Drawing.Size(250, 21);
            this.cbbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // BƯỚC 3: Cấu hình Ngày và Giờ Check-in
            lblIn.Text = "Ngày Check-in:";
            lblIn.Location = new System.Drawing.Point(20, 100);
            lblIn.AutoSize = true;
            // Chọn ngày
            this.dtCheckIn.Location = new System.Drawing.Point(130, 100);
            this.dtCheckIn.Size = new System.Drawing.Size(120, 21);
            this.dtCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // Chọn giờ
            this.dtTimeIn.Location = new System.Drawing.Point(260, 100);
            this.dtTimeIn.Size = new System.Drawing.Size(120, 21);
            this.dtTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimeIn.ShowUpDown = true;

            // BƯỚC 4: Cấu hình Ngày và Giờ Check-out
            lblOut.Text = "Ngày Check-out:";
            lblOut.Location = new System.Drawing.Point(20, 140);
            lblOut.AutoSize = true;
            // Chọn ngày
            this.dtCheckOut.Location = new System.Drawing.Point(130, 140);
            this.dtCheckOut.Size = new System.Drawing.Size(120, 21);
            this.dtCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // Chọn giờ
            this.dtTimeOut.Location = new System.Drawing.Point(260, 140);
            this.dtTimeOut.Size = new System.Drawing.Size(120, 21);
            this.dtTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimeOut.ShowUpDown = true;

            // numAdults
            lblAdult.Text = "Người lớn:";
            lblAdult.Location = new System.Drawing.Point(20, 180);
            lblAdult.AutoSize = true;
            this.numAdults.Location = new System.Drawing.Point(130, 180);
            this.numAdults.Value = 1;

            // numChildren
            lblChild.Text = "Trẻ em:";
            lblChild.Location = new System.Drawing.Point(220, 180);
            lblChild.AutoSize = true;
            this.numChildren.Location = new System.Drawing.Point(280, 180);

            // btnSave
            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(130, 230);
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // btnCancel
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Location = new System.Drawing.Point(230, 230);
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // FrmBookingForm
            this.ClientSize = new System.Drawing.Size(420, 300);
            this.Controls.Add(lblGuest);
            this.Controls.Add(this.cbbGuest);
            this.Controls.Add(lblRoom);
            this.Controls.Add(this.cbbRoom);

            this.Controls.Add(lblIn);
            this.Controls.Add(this.dtCheckIn);
            this.Controls.Add(this.dtTimeIn); // Đã thêm vào form

            this.Controls.Add(lblOut);
            this.Controls.Add(this.dtCheckOut);
            this.Controls.Add(this.dtTimeOut); // Đã thêm vào form

            this.Controls.Add(lblAdult);
            this.Controls.Add(this.numAdults);
            this.Controls.Add(lblChild);
            this.Controls.Add(this.numChildren);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmBookingForm";
            this.Text = "Đặt Phòng Mới";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.numAdults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChildren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}