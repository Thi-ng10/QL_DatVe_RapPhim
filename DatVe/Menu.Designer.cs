namespace DatVe
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Phim = new Button();
            btn_Phong = new Button();
            btn_Ghe = new Button();
            btn_SuatChieu = new Button();
            btn_DatVe = new Button();
            btn_HoaDon = new Button();
            btn_BaoCao = new Button();
            SuspendLayout();
            // 
            // btn_Phim
            // 
            btn_Phim.Location = new Point(75, 30);
            btn_Phim.Name = "btn_Phim";
            btn_Phim.Size = new Size(130, 29);
            btn_Phim.TabIndex = 0;
            btn_Phim.Text = "Phim";
            btn_Phim.UseVisualStyleBackColor = true;
            btn_Phim.Click += btn_Phim_Click;
            // 
            // btn_Phong
            // 
            btn_Phong.Location = new Point(75, 84);
            btn_Phong.Name = "btn_Phong";
            btn_Phong.Size = new Size(130, 29);
            btn_Phong.TabIndex = 1;
            btn_Phong.Text = "Phòng chiếu";
            btn_Phong.UseVisualStyleBackColor = true;
            btn_Phong.Click += btn_Phong_Click;
            // 
            // btn_Ghe
            // 
            btn_Ghe.Location = new Point(75, 143);
            btn_Ghe.Name = "btn_Ghe";
            btn_Ghe.Size = new Size(130, 29);
            btn_Ghe.TabIndex = 2;
            btn_Ghe.Text = "Ghế";
            btn_Ghe.UseVisualStyleBackColor = true;
            btn_Ghe.Click += btn_Ghe_Click;
            // 
            // btn_SuatChieu
            // 
            btn_SuatChieu.Location = new Point(75, 201);
            btn_SuatChieu.Name = "btn_SuatChieu";
            btn_SuatChieu.Size = new Size(130, 29);
            btn_SuatChieu.TabIndex = 3;
            btn_SuatChieu.Text = "Suất chiếu";
            btn_SuatChieu.UseVisualStyleBackColor = true;
            btn_SuatChieu.Click += btn_SuatChieu_Click;
            // 
            // btn_DatVe
            // 
            btn_DatVe.Location = new Point(297, 30);
            btn_DatVe.Name = "btn_DatVe";
            btn_DatVe.Size = new Size(132, 29);
            btn_DatVe.TabIndex = 4;
            btn_DatVe.Text = "Đặt vé";
            btn_DatVe.UseVisualStyleBackColor = true;
            btn_DatVe.Click += btn_DatVe_Click;
            // 
            // btn_HoaDon
            // 
            btn_HoaDon.Location = new Point(297, 84);
            btn_HoaDon.Name = "btn_HoaDon";
            btn_HoaDon.Size = new Size(132, 29);
            btn_HoaDon.TabIndex = 5;
            btn_HoaDon.Text = "Hóa đơn";
            btn_HoaDon.UseVisualStyleBackColor = true;
            btn_HoaDon.Click += btn_HoaDon_Click;
            // 
            // btn_BaoCao
            // 
            btn_BaoCao.Location = new Point(297, 143);
            btn_BaoCao.Name = "btn_BaoCao";
            btn_BaoCao.Size = new Size(132, 29);
            btn_BaoCao.TabIndex = 6;
            btn_BaoCao.Text = "Báo cáo";
            btn_BaoCao.UseVisualStyleBackColor = true;
            btn_BaoCao.Click += btn_BaoCao_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_BaoCao);
            Controls.Add(btn_HoaDon);
            Controls.Add(btn_DatVe);
            Controls.Add(btn_SuatChieu);
            Controls.Add(btn_Ghe);
            Controls.Add(btn_Phong);
            Controls.Add(btn_Phim);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Phim;
        private Button btn_Phong;
        private Button btn_Ghe;
        private Button btn_SuatChieu;
        private Button btn_DatVe;
        private Button btn_HoaDon;
        private Button btn_BaoCao;
    }
}
