namespace DatVe
{
    partial class QLPhim
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
            groupBox1 = new GroupBox();
            dgvPhim = new DataGridView();
            groupBox2 = new GroupBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtMoTa = new TextBox();
            cbTT = new ComboBox();
            dtpNgayKhoiChieu = new DateTimePicker();
            txtDienVien = new TextBox();
            txtGHTuoi = new TextBox();
            txtDaoDien = new TextBox();
            txtTenPhim = new TextBox();
            txtTheLoai = new TextBox();
            txtThoiLuong = new TextBox();
            txtMaPhim = new TextBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLamMoi = new Button();
            txtTKPhim = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhim).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvPhim);
            groupBox1.Location = new Point(24, 377);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(994, 265);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh Sách Phim ";
            // 
            // dgvPhim
            // 
            dgvPhim.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhim.Location = new Point(20, 26);
            dgvPhim.Name = "dgvPhim";
            dgvPhim.ReadOnly = true;
            dgvPhim.RowHeadersWidth = 51;
            dgvPhim.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhim.Size = new Size(950, 222);
            dgvPhim.TabIndex = 0;
            dgvPhim.CellContentClick += dgvPhim_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtMoTa);
            groupBox2.Controls.Add(cbTT);
            groupBox2.Controls.Add(dtpNgayKhoiChieu);
            groupBox2.Controls.Add(txtDienVien);
            groupBox2.Controls.Add(txtGHTuoi);
            groupBox2.Controls.Add(txtDaoDien);
            groupBox2.Controls.Add(txtTenPhim);
            groupBox2.Controls.Add(txtTheLoai);
            groupBox2.Controls.Add(txtThoiLuong);
            groupBox2.Controls.Add(txtMaPhim);
            groupBox2.Location = new Point(24, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(994, 271);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông Tin Phim";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(688, 224);
            label10.Name = "label10";
            label10.Size = new Size(81, 20);
            label10.TabIndex = 19;
            label10.Text = "Trạng Thái:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(688, 33);
            label9.Name = "label9";
            label9.Size = new Size(51, 20);
            label9.TabIndex = 18;
            label9.Text = "Mô tả:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(328, 226);
            label8.Name = "label8";
            label8.Size = new Size(122, 20);
            label8.TabIndex = 17;
            label8.Text = "Ngày Khởi Chiếu:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(328, 33);
            label7.Name = "label7";
            label7.Size = new Size(75, 20);
            label7.TabIndex = 16;
            label7.Text = "Đạo Diễn:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(328, 100);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 15;
            label6.Text = "Diễn Viên:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(328, 159);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 14;
            label5.Text = "Giới Hạn Tuổi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 222);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 13;
            label4.Text = "Thời Lượng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 159);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 12;
            label3.Text = "Thể Loại:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 92);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 11;
            label2.Text = "Tên Phim:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 33);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 10;
            label1.Text = "Mã Phim:";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(688, 56);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(273, 127);
            txtMoTa.TabIndex = 9;
            // 
            // cbTT
            // 
            cbTT.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTT.FormattingEnabled = true;
            cbTT.Items.AddRange(new object[] { "Sắp chiếu", "Đang chiếu", "Ngừng chiếu" });
            cbTT.Location = new Point(775, 220);
            cbTT.Name = "cbTT";
            cbTT.Size = new Size(186, 28);
            cbTT.TabIndex = 8;
            // 
            // dtpNgayKhoiChieu
            // 
            dtpNgayKhoiChieu.CustomFormat = "dd/MM/yy";
            dtpNgayKhoiChieu.Format = DateTimePickerFormat.Custom;
            dtpNgayKhoiChieu.Location = new Point(458, 221);
            dtpNgayKhoiChieu.Name = "dtpNgayKhoiChieu";
            dtpNgayKhoiChieu.Size = new Size(199, 27);
            dtpNgayKhoiChieu.TabIndex = 7;
            // 
            // txtDienVien
            // 
            txtDienVien.Location = new Point(458, 93);
            txtDienVien.Name = "txtDienVien";
            txtDienVien.Size = new Size(199, 27);
            txtDienVien.TabIndex = 6;
            // 
            // txtGHTuoi
            // 
            txtGHTuoi.Location = new Point(458, 156);
            txtGHTuoi.Name = "txtGHTuoi";
            txtGHTuoi.Size = new Size(199, 27);
            txtGHTuoi.TabIndex = 5;
            // 
            // txtDaoDien
            // 
            txtDaoDien.Location = new Point(458, 30);
            txtDaoDien.Name = "txtDaoDien";
            txtDaoDien.Size = new Size(199, 27);
            txtDaoDien.TabIndex = 4;
            // 
            // txtTenPhim
            // 
            txtTenPhim.Location = new Point(112, 93);
            txtTenPhim.Name = "txtTenPhim";
            txtTenPhim.Size = new Size(187, 27);
            txtTenPhim.TabIndex = 3;
            // 
            // txtTheLoai
            // 
            txtTheLoai.Location = new Point(112, 156);
            txtTheLoai.Name = "txtTheLoai";
            txtTheLoai.Size = new Size(187, 27);
            txtTheLoai.TabIndex = 2;
            // 
            // txtThoiLuong
            // 
            txtThoiLuong.Location = new Point(112, 221);
            txtThoiLuong.Name = "txtThoiLuong";
            txtThoiLuong.Size = new Size(187, 27);
            txtThoiLuong.TabIndex = 1;
            // 
            // txtMaPhim
            // 
            txtMaPhim.Location = new Point(112, 30);
            txtMaPhim.Name = "txtMaPhim";
            txtMaPhim.Size = new Size(187, 27);
            txtMaPhim.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(24, 319);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(352, 319);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(186, 319);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(514, 319);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTKPhim
            // 
            txtTKPhim.Location = new Point(712, 321);
            txtTKPhim.Name = "txtTKPhim";
            txtTKPhim.Size = new Size(199, 27);
            txtTKPhim.TabIndex = 7;
            txtTKPhim.Text = "Tìm Kiếm Phim. . .";
            txtTKPhim.TextChanged += txtTKPhim_TextChanged;
            // 
            // QLPhim
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 666);
            Controls.Add(txtTKPhim);
            Controls.Add(btnLamMoi);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "QLPhim";
            Text = "QLPhim";
            Load += QLPhim_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhim).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtTenPhim;
        private TextBox txtTheLoai;
        private TextBox txtThoiLuong;
        private TextBox txtMaPhim;
        private ComboBox cbTT;
        private DateTimePicker dtpNgayKhoiChieu;
        private TextBox txtDienVien;
        private TextBox txtGHTuoi;
        private TextBox txtDaoDien;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtMoTa;
        private DataGridView dgvPhim;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLamMoi;
        private TextBox txtTKPhim;
    }
}