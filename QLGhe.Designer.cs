namespace DatVe
{
    partial class QLGhe
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
            txt_Hang = new TextBox();
            label4 = new Label();
            cbo_Phong = new ComboBox();
            txt_So = new TextBox();
            label5 = new Label();
            label6 = new Label();
            cbo_TrangThai = new ComboBox();
            groupBox1 = new GroupBox();
            dgv_DSGhe = new DataGridView();
            btn_Them = new Button();
            btn_DatLai = new Button();
            btn_Xoa = new Button();
            btn_Sua = new Button();
            btn_TimKiem = new Button();
            txtTimKiem = new TextBox();
            cbo_Loai = new ComboBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_DSGhe).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(321, 0);
            label1.Name = "label1";
            label1.Size = new Size(221, 45);
            label1.TabIndex = 1;
            label1.Text = "QUẢN LÝ GHẾ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 2;
            label2.Text = "Phòng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 128);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 3;
            label3.Text = "Hàng:";
            // 
            // txt_Hang
            // 
            txt_Hang.Location = new Point(135, 128);
            txt_Hang.Name = "txt_Hang";
            txt_Hang.Size = new Size(151, 27);
            txt_Hang.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(437, 77);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 5;
            label4.Text = "Loại:";
            // 
            // cbo_Phong
            // 
            cbo_Phong.FormattingEnabled = true;
            cbo_Phong.Location = new Point(135, 73);
            cbo_Phong.Name = "cbo_Phong";
            cbo_Phong.Size = new Size(151, 28);
            cbo_Phong.TabIndex = 7;
            cbo_Phong.SelectedIndexChanged += cbo_Phong_SelectedIndexChanged;
            // 
            // txt_So
            // 
            txt_So.Location = new Point(135, 182);
            txt_So.Name = "txt_So";
            txt_So.Size = new Size(151, 27);
            txt_So.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 182);
            label5.Name = "label5";
            label5.Size = new Size(29, 20);
            label5.TabIndex = 8;
            label5.Text = "Số:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(437, 131);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 10;
            label6.Text = "Trạng thái:";
            // 
            // cbo_TrangThai
            // 
            cbo_TrangThai.FormattingEnabled = true;
            cbo_TrangThai.Location = new Point(574, 125);
            cbo_TrangThai.Name = "cbo_TrangThai";
            cbo_TrangThai.Size = new Size(151, 28);
            cbo_TrangThai.TabIndex = 12;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_DSGhe);
            groupBox1.Location = new Point(12, 302);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(824, 237);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách ghế:";
            // 
            // dgv_DSGhe
            // 
            dgv_DSGhe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_DSGhe.Location = new Point(33, 37);
            dgv_DSGhe.Name = "dgv_DSGhe";
            dgv_DSGhe.RowHeadersWidth = 51;
            dgv_DSGhe.Size = new Size(761, 200);
            dgv_DSGhe.TabIndex = 0;
            dgv_DSGhe.CellClick += dgv_DSGhe_CellClick;
            // 
            // btn_Them
            // 
            btn_Them.Location = new Point(13, 232);
            btn_Them.Name = "btn_Them";
            btn_Them.Size = new Size(94, 29);
            btn_Them.TabIndex = 14;
            btn_Them.Text = "Thêm";
            btn_Them.UseVisualStyleBackColor = true;
            btn_Them.Click += btn_Them_Click;
            // 
            // btn_DatLai
            // 
            btn_DatLai.Location = new Point(383, 232);
            btn_DatLai.Name = "btn_DatLai";
            btn_DatLai.Size = new Size(94, 29);
            btn_DatLai.TabIndex = 15;
            btn_DatLai.Text = "Đặt lại";
            btn_DatLai.UseVisualStyleBackColor = true;
            btn_DatLai.Click += btn_DatLai_Click;
            // 
            // btn_Xoa
            // 
            btn_Xoa.Location = new Point(263, 232);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(94, 29);
            btn_Xoa.TabIndex = 16;
            btn_Xoa.Text = "Xóa";
            btn_Xoa.UseVisualStyleBackColor = true;
            btn_Xoa.Click += btn_Xoa_Click;
            // 
            // btn_Sua
            // 
            btn_Sua.Location = new Point(135, 232);
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Size = new Size(94, 29);
            btn_Sua.TabIndex = 17;
            btn_Sua.Text = "Sửa";
            btn_Sua.UseVisualStyleBackColor = true;
            btn_Sua.Click += btn_Sua_Click;
            // 
            // btn_TimKiem
            // 
            btn_TimKiem.Location = new Point(507, 232);
            btn_TimKiem.Name = "btn_TimKiem";
            btn_TimKiem.Size = new Size(94, 29);
            btn_TimKiem.TabIndex = 18;
            btn_TimKiem.Text = "Tìm kiếm";
            btn_TimKiem.UseVisualStyleBackColor = true;
            btn_TimKiem.Click += btn_TimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(633, 232);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(173, 27);
            txtTimKiem.TabIndex = 19;
            // 
            // cbo_Loai
            // 
            cbo_Loai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_Loai.FormattingEnabled = true;
            cbo_Loai.Location = new Point(574, 69);
            cbo_Loai.Name = "cbo_Loai";
            cbo_Loai.Size = new Size(151, 28);
            cbo_Loai.TabIndex = 20;
            // 
            // QLGhe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 587);
            Controls.Add(cbo_Loai);
            Controls.Add(txtTimKiem);
            Controls.Add(btn_TimKiem);
            Controls.Add(btn_Sua);
            Controls.Add(btn_Xoa);
            Controls.Add(btn_DatLai);
            Controls.Add(btn_Them);
            Controls.Add(groupBox1);
            Controls.Add(cbo_TrangThai);
            Controls.Add(label6);
            Controls.Add(txt_So);
            Controls.Add(label5);
            Controls.Add(cbo_Phong);
            Controls.Add(label4);
            Controls.Add(txt_Hang);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "QLGhe";
            Text = "QLGhe";
            Load += QLGhe_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_DSGhe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txt_Hang;
        private Label label4;
        private ComboBox cbo_Phong;
        private TextBox txt_So;
        private Label label5;
        private Label label6;
        private ComboBox cbo_TrangThai;
        private GroupBox groupBox1;
        private DataGridView dgv_DSGhe;
        private Button btn_Them;
        private Button btn_DatLai;
        private Button btn_Xoa;
        private Button btn_Sua;
        private Button btn_TimKiem;
        private TextBox txtTimKiem;
        private ComboBox cbo_Loai;
    }
}