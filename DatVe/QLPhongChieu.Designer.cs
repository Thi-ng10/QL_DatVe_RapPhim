namespace DatVe
{
    partial class QLPhongChieu
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
            label8 = new Label();
            label9 = new Label();
            txt_MaPhong = new TextBox();
            txt_TenPhong = new TextBox();
            txt_SoGhe = new TextBox();
            cbo_TrangThai = new ComboBox();
            dtp_NgayKiemTra = new DateTimePicker();
            dtp_GioBatDau = new DateTimePicker();
            dtp_GioKetThuc = new DateTimePicker();
            btn_Them = new Button();
            btn_Sua = new Button();
            btn_Xoa = new Button();
            btn_DatLai = new Button();
            btn_KiemTra = new Button();
            dgv_DSPhong = new DataGridView();
            groupBox1 = new GroupBox();
            cbo_LoaiPhong = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv_DSPhong).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(386, 9);
            label1.Name = "label1";
            label1.Size = new Size(344, 41);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ PHÒNG CHIẾU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 83);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 1;
            label2.Text = "Mã phòng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 128);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 2;
            label3.Text = "Tên phòng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 175);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 3;
            label4.Text = "Số ghế:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(412, 83);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 4;
            label5.Text = "Loại phòng:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(412, 128);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 5;
            label6.Text = "Trạng thái:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(412, 175);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 6;
            label7.Text = "Ngày kiểm tra:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(788, 83);
            label8.Name = "label8";
            label8.Size = new Size(90, 20);
            label8.TabIndex = 7;
            label8.Text = "Giờ bắt đầu:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(788, 128);
            label9.Name = "label9";
            label9.Size = new Size(91, 20);
            label9.TabIndex = 8;
            label9.Text = "Giờ kết thúc:";
            // 
            // txt_MaPhong
            // 
            txt_MaPhong.Location = new Point(128, 83);
            txt_MaPhong.Name = "txt_MaPhong";
            txt_MaPhong.Size = new Size(197, 27);
            txt_MaPhong.TabIndex = 11;
            // 
            // txt_TenPhong
            // 
            txt_TenPhong.Location = new Point(128, 128);
            txt_TenPhong.Name = "txt_TenPhong";
            txt_TenPhong.Size = new Size(197, 27);
            txt_TenPhong.TabIndex = 12;
            // 
            // txt_SoGhe
            // 
            txt_SoGhe.Location = new Point(128, 168);
            txt_SoGhe.Name = "txt_SoGhe";
            txt_SoGhe.Size = new Size(197, 27);
            txt_SoGhe.TabIndex = 13;
            // 
            // cbo_TrangThai
            // 
            cbo_TrangThai.FormattingEnabled = true;
            cbo_TrangThai.Location = new Point(523, 127);
            cbo_TrangThai.Name = "cbo_TrangThai";
            cbo_TrangThai.Size = new Size(197, 28);
            cbo_TrangThai.TabIndex = 15;
            cbo_TrangThai.SelectedIndexChanged += cbo_TrangThai_SelectedIndexChanged;
            // 
            // dtp_NgayKiemTra
            // 
            dtp_NgayKiemTra.Format = DateTimePickerFormat.Short;
            dtp_NgayKiemTra.Location = new Point(523, 170);
            dtp_NgayKiemTra.Name = "dtp_NgayKiemTra";
            dtp_NgayKiemTra.Size = new Size(197, 27);
            dtp_NgayKiemTra.TabIndex = 16;
            // 
            // dtp_GioBatDau
            // 
            dtp_GioBatDau.CustomFormat = "";
            dtp_GioBatDau.Format = DateTimePickerFormat.Time;
            dtp_GioBatDau.Location = new Point(896, 83);
            dtp_GioBatDau.Name = "dtp_GioBatDau";
            dtp_GioBatDau.ShowUpDown = true;
            dtp_GioBatDau.Size = new Size(191, 27);
            dtp_GioBatDau.TabIndex = 17;
            // 
            // dtp_GioKetThuc
            // 
            dtp_GioKetThuc.CustomFormat = "HH:mm";
            dtp_GioKetThuc.Format = DateTimePickerFormat.Time;
            dtp_GioKetThuc.Location = new Point(896, 128);
            dtp_GioKetThuc.Name = "dtp_GioKetThuc";
            dtp_GioKetThuc.ShowUpDown = true;
            dtp_GioKetThuc.Size = new Size(191, 27);
            dtp_GioKetThuc.TabIndex = 18;
            // 
            // btn_Them
            // 
            btn_Them.Location = new Point(33, 229);
            btn_Them.Name = "btn_Them";
            btn_Them.Size = new Size(94, 29);
            btn_Them.TabIndex = 19;
            btn_Them.Text = "Thêm";
            btn_Them.UseVisualStyleBackColor = true;
            btn_Them.Click += btn_Them_Click;
            // 
            // btn_Sua
            // 
            btn_Sua.Location = new Point(153, 229);
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Size = new Size(94, 29);
            btn_Sua.TabIndex = 20;
            btn_Sua.Text = "Sửa";
            btn_Sua.UseVisualStyleBackColor = true;
            btn_Sua.Click += btn_Sua_Click;
            // 
            // btn_Xoa
            // 
            btn_Xoa.Location = new Point(279, 229);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(94, 29);
            btn_Xoa.TabIndex = 21;
            btn_Xoa.Text = "Xóa";
            btn_Xoa.UseVisualStyleBackColor = true;
            btn_Xoa.Click += btn_Xoa_Click;
            // 
            // btn_DatLai
            // 
            btn_DatLai.Location = new Point(405, 229);
            btn_DatLai.Name = "btn_DatLai";
            btn_DatLai.Size = new Size(94, 29);
            btn_DatLai.TabIndex = 22;
            btn_DatLai.Text = "Đặt lại";
            btn_DatLai.UseVisualStyleBackColor = true;
            btn_DatLai.Click += btn_DatLai_Click;
            // 
            // btn_KiemTra
            // 
            btn_KiemTra.Location = new Point(788, 229);
            btn_KiemTra.Name = "btn_KiemTra";
            btn_KiemTra.Size = new Size(94, 29);
            btn_KiemTra.TabIndex = 23;
            btn_KiemTra.Text = "Kiểm tra";
            btn_KiemTra.UseVisualStyleBackColor = true;
            btn_KiemTra.Click += btn_KiemTra_Click;
            // 
            // dgv_DSPhong
            // 
            dgv_DSPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_DSPhong.Location = new Point(50, 41);
            dgv_DSPhong.Name = "dgv_DSPhong";
            dgv_DSPhong.RowHeadersWidth = 51;
            dgv_DSPhong.Size = new Size(957, 236);
            dgv_DSPhong.TabIndex = 24;
            dgv_DSPhong.CellClick += dgv_DSPhong_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_DSPhong);
            groupBox1.Location = new Point(33, 289);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1054, 325);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách phòng:";
            // 
            // cbo_LoaiPhong
            // 
            cbo_LoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_LoaiPhong.FormattingEnabled = true;
            cbo_LoaiPhong.Location = new Point(524, 80);
            cbo_LoaiPhong.Name = "cbo_LoaiPhong";
            cbo_LoaiPhong.Size = new Size(197, 28);
            cbo_LoaiPhong.TabIndex = 26;
            // 
            // QLPhongChieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 651);
            Controls.Add(cbo_LoaiPhong);
            Controls.Add(groupBox1);
            Controls.Add(btn_KiemTra);
            Controls.Add(btn_DatLai);
            Controls.Add(btn_Xoa);
            Controls.Add(btn_Sua);
            Controls.Add(btn_Them);
            Controls.Add(dtp_GioKetThuc);
            Controls.Add(dtp_GioBatDau);
            Controls.Add(dtp_NgayKiemTra);
            Controls.Add(cbo_TrangThai);
            Controls.Add(txt_SoGhe);
            Controls.Add(txt_TenPhong);
            Controls.Add(txt_MaPhong);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "QLPhongChieu";
            Text = "QLPhongChieu";
            Load += QLPhongChieu_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_DSPhong).EndInit();
            groupBox1.ResumeLayout(false);
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
        private Label label8;
        private Label label9;
        private TextBox txt_MaPhong;
        private TextBox txt_TenPhong;
        private TextBox txt_SoGhe;
        private ComboBox cbo_TrangThai;
        private DateTimePicker dtp_NgayKiemTra;
        private DateTimePicker dtp_GioBatDau;
        private DateTimePicker dtp_GioKetThuc;
        private Button btn_Them;
        private Button btn_Sua;
        private Button btn_Xoa;
        private Button btn_DatLai;
        private Button btn_KiemTra;
        private DataGridView dgv_DSPhong;
        private GroupBox groupBox1;
        private ComboBox cbo_LoaiPhong;
    }
}