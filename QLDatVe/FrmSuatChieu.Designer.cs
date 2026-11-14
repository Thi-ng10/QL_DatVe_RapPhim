namespace QLDatVe
{
    partial class FrmSuatChieu
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btn_Them = new Button();
            btn_Sua = new Button();
            btn_Xoa = new Button();
            btn_TimKiem = new Button();
            btn_LamMoi = new Button();
            groupBox1 = new GroupBox();
            dgv_SuatChieu = new DataGridView();
            cbo_Phim = new ComboBox();
            cbo_PhongChieu = new ComboBox();
            dtp_NgayChieu = new DateTimePicker();
            dtp_GioBD = new DateTimePicker();
            txt_GiaCoBan = new TextBox();
            txt_GioKT = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_SuatChieu).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(282, 9);
            label1.Name = "label1";
            label1.Size = new Size(225, 30);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ SUẤT CHIẾU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Turquoise;
            label2.Location = new Point(74, 62);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 1;
            label2.Text = "Phim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Turquoise;
            label3.Location = new Point(72, 113);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 2;
            label3.Text = "Ngày chiếu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Turquoise;
            label4.Location = new Point(72, 168);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 3;
            label4.Text = "Giá cơ bản:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Turquoise;
            label5.Location = new Point(433, 62);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 4;
            label5.Text = "Phòng chiếu:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Turquoise;
            label6.Location = new Point(433, 115);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 5;
            label6.Text = "Giờ bắt đầu:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Turquoise;
            label7.Location = new Point(434, 168);
            label7.Name = "label7";
            label7.Size = new Size(98, 20);
            label7.TabIndex = 6;
            label7.Text = "Giờ kết thúc:";
            // 
            // btn_Them
            // 
            btn_Them.BackColor = SystemColors.ButtonHighlight;
            btn_Them.Location = new Point(88, 223);
            btn_Them.Name = "btn_Them";
            btn_Them.Size = new Size(75, 23);
            btn_Them.TabIndex = 7;
            btn_Them.Text = "Thêm";
            btn_Them.UseVisualStyleBackColor = false;
            btn_Them.Click += btn_Them_Click;
            // 
            // btn_Sua
            // 
            btn_Sua.BackColor = SystemColors.ButtonHighlight;
            btn_Sua.Location = new Point(224, 223);
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Size = new Size(75, 23);
            btn_Sua.TabIndex = 8;
            btn_Sua.Text = "Sửa";
            btn_Sua.UseVisualStyleBackColor = false;
            // 
            // btn_Xoa
            // 
            btn_Xoa.BackColor = SystemColors.ButtonHighlight;
            btn_Xoa.Location = new Point(349, 223);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(75, 23);
            btn_Xoa.TabIndex = 9;
            btn_Xoa.Text = "Xoá";
            btn_Xoa.UseVisualStyleBackColor = false;
            // 
            // btn_TimKiem
            // 
            btn_TimKiem.BackColor = SystemColors.ButtonHighlight;
            btn_TimKiem.Location = new Point(475, 223);
            btn_TimKiem.Name = "btn_TimKiem";
            btn_TimKiem.Size = new Size(75, 23);
            btn_TimKiem.TabIndex = 10;
            btn_TimKiem.Text = "Tìm kiếm";
            btn_TimKiem.UseVisualStyleBackColor = false;
            btn_TimKiem.Click += btn_TimKiem_Click;
            // 
            // btn_LamMoi
            // 
            btn_LamMoi.BackColor = SystemColors.ButtonHighlight;
            btn_LamMoi.Location = new Point(594, 223);
            btn_LamMoi.Name = "btn_LamMoi";
            btn_LamMoi.Size = new Size(75, 23);
            btn_LamMoi.TabIndex = 11;
            btn_LamMoi.Text = "Làm mới";
            btn_LamMoi.UseVisualStyleBackColor = false;
            btn_LamMoi.Click += btn_LamMoi_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(dgv_SuatChieu);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(38, 264);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(713, 174);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách suất chiếu";
            // 
            // dgv_SuatChieu
            // 
            dgv_SuatChieu.BackgroundColor = SystemColors.ButtonHighlight;
            dgv_SuatChieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_SuatChieu.Location = new Point(17, 18);
            dgv_SuatChieu.Name = "dgv_SuatChieu";
            dgv_SuatChieu.Size = new Size(674, 150);
            dgv_SuatChieu.TabIndex = 0;
            // 
            // cbo_Phim
            // 
            cbo_Phim.FormattingEnabled = true;
            cbo_Phim.Location = new Point(158, 59);
            cbo_Phim.Name = "cbo_Phim";
            cbo_Phim.Size = new Size(202, 23);
            cbo_Phim.TabIndex = 13;
            // 
            // cbo_PhongChieu
            // 
            cbo_PhongChieu.FormattingEnabled = true;
            cbo_PhongChieu.Location = new Point(538, 59);
            cbo_PhongChieu.Name = "cbo_PhongChieu";
            cbo_PhongChieu.Size = new Size(121, 23);
            cbo_PhongChieu.TabIndex = 14;
            // 
            // dtp_NgayChieu
            // 
            dtp_NgayChieu.Location = new Point(160, 113);
            dtp_NgayChieu.Name = "dtp_NgayChieu";
            dtp_NgayChieu.Size = new Size(200, 23);
            dtp_NgayChieu.TabIndex = 15;
            // 
            // dtp_GioBD
            // 
            dtp_GioBD.CustomFormat = "HH:mm";
            dtp_GioBD.Format = DateTimePickerFormat.Custom;
            dtp_GioBD.Location = new Point(538, 110);
            dtp_GioBD.Name = "dtp_GioBD";
            dtp_GioBD.ShowUpDown = true;
            dtp_GioBD.Size = new Size(121, 23);
            dtp_GioBD.TabIndex = 16;
            dtp_GioBD.ValueChanged += dtp_GioBD_ValueChanged;
            // 
            // txt_GiaCoBan
            // 
            txt_GiaCoBan.Location = new Point(158, 165);
            txt_GiaCoBan.Name = "txt_GiaCoBan";
            txt_GiaCoBan.Size = new Size(100, 23);
            txt_GiaCoBan.TabIndex = 18;
            // 
            // txt_GioKT
            // 
            txt_GioKT.Location = new Point(538, 165);
            txt_GioKT.Name = "txt_GioKT";
            txt_GioKT.ReadOnly = true;
            txt_GioKT.Size = new Size(100, 23);
            txt_GioKT.TabIndex = 19;
            // 
            // FrmSuatChieu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.images;
            ClientSize = new Size(800, 450);
            Controls.Add(txt_GioKT);
            Controls.Add(txt_GiaCoBan);
            Controls.Add(dtp_GioBD);
            Controls.Add(dtp_NgayChieu);
            Controls.Add(cbo_PhongChieu);
            Controls.Add(cbo_Phim);
            Controls.Add(groupBox1);
            Controls.Add(btn_LamMoi);
            Controls.Add(btn_TimKiem);
            Controls.Add(btn_Xoa);
            Controls.Add(btn_Sua);
            Controls.Add(btn_Them);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmSuatChieu";
            Text = "FrmSuatChieu";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_SuatChieu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btn_Them;
        private Button btn_Sua;
        private Button btn_Xoa;
        private Button btn_TimKiem;
        private Button btn_LamMoi;
        private GroupBox groupBox1;
        private DataGridView dgv_SuatChieu;
        private ComboBox cbo_Phim;
        private ComboBox cbo_PhongChieu;
        private DateTimePicker dtp_NgayChieu;
        private DateTimePicker dtp_GioBD;
        private TextBox txt_GiaCoBan;
        private TextBox txt_GioKT;
    }
}