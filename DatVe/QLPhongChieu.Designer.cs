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
            txt_MaPhong = new TextBox();
            txt_TenPhong = new TextBox();
            txt_SoGhe = new TextBox();
            txt_LoaiPhong = new TextBox();
            cbo_TrangThaiPhong = new ComboBox();
            dgv_DSPhong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_DSPhong).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(230, 20);
            label1.Name = "label1";
            label1.Size = new Size(170, 20);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ PHÒNG CHIẾU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 71);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 1;
            label2.Text = "Mã phòng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 117);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 2;
            label3.Text = "Tên phòng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 169);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 3;
            label4.Text = "Số ghế:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(363, 71);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 4;
            label5.Text = "Loại phòng:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(363, 117);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 5;
            label6.Text = "Trạng thái:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(55, 216);
            label7.Name = "label7";
            label7.Size = new Size(127, 20);
            label7.TabIndex = 6;
            label7.Text = "Danh sách phòng:";
            // 
            // txt_MaPhong
            // 
            txt_MaPhong.Location = new Point(163, 71);
            txt_MaPhong.Name = "txt_MaPhong";
            txt_MaPhong.Size = new Size(147, 27);
            txt_MaPhong.TabIndex = 7;
            // 
            // txt_TenPhong
            // 
            txt_TenPhong.Location = new Point(163, 119);
            txt_TenPhong.Name = "txt_TenPhong";
            txt_TenPhong.Size = new Size(147, 27);
            txt_TenPhong.TabIndex = 8;
            // 
            // txt_SoGhe
            // 
            txt_SoGhe.Location = new Point(163, 169);
            txt_SoGhe.Name = "txt_SoGhe";
            txt_SoGhe.Size = new Size(147, 27);
            txt_SoGhe.TabIndex = 9;
            // 
            // txt_LoaiPhong
            // 
            txt_LoaiPhong.Location = new Point(480, 71);
            txt_LoaiPhong.Name = "txt_LoaiPhong";
            txt_LoaiPhong.Size = new Size(151, 27);
            txt_LoaiPhong.TabIndex = 10;
            // 
            // cbo_TrangThaiPhong
            // 
            cbo_TrangThaiPhong.FormattingEnabled = true;
            cbo_TrangThaiPhong.Location = new Point(480, 118);
            cbo_TrangThaiPhong.Name = "cbo_TrangThaiPhong";
            cbo_TrangThaiPhong.Size = new Size(151, 28);
            cbo_TrangThaiPhong.TabIndex = 11;
            // 
            // dgv_DSPhong
            // 
            dgv_DSPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_DSPhong.Location = new Point(55, 274);
            dgv_DSPhong.Name = "dgv_DSPhong";
            dgv_DSPhong.RowHeadersWidth = 51;
            dgv_DSPhong.Size = new Size(576, 188);
            dgv_DSPhong.TabIndex = 12;
            // 
            // QLPhongChieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 555);
            Controls.Add(dgv_DSPhong);
            Controls.Add(cbo_TrangThaiPhong);
            Controls.Add(txt_LoaiPhong);
            Controls.Add(txt_SoGhe);
            Controls.Add(txt_TenPhong);
            Controls.Add(txt_MaPhong);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "QLPhongChieu";
            Text = "QLPhongChieu";
            ((System.ComponentModel.ISupportInitialize)dgv_DSPhong).EndInit();
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
        private TextBox txt_MaPhong;
        private TextBox txt_TenPhong;
        private TextBox txt_SoGhe;
        private TextBox txt_LoaiPhong;
        private ComboBox cbo_TrangThaiPhong;
        private DataGridView dgv_DSPhong;
    }
}