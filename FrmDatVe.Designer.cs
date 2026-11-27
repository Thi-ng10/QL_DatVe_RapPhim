#nullable disable
namespace DatVe
{
    partial class FrmDatVe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lb_Phim = new System.Windows.Forms.Label();
            this.cb_Phim = new System.Windows.Forms.ComboBox();
            this.lb_SuatChieu = new System.Windows.Forms.Label();
            this.dgv_SuatChieu = new System.Windows.Forms.DataGridView();
            this.lb_SoDo = new System.Windows.Forms.Label();
            this.pn_SoDoGhe = new System.Windows.Forms.Panel();
            this.lb_CT_Trong = new System.Windows.Forms.Label();
            this.lb_CT_CuaToi = new System.Windows.Forms.Label();
            this.lb_CT_NguoiKhac = new System.Windows.Forms.Label();
            this.lb_CT_DaBan = new System.Windows.Forms.Label();
            this.lb_CT_Hong = new System.Windows.Forms.Label();
            this.lb_GheChon = new System.Windows.Forms.Label();
            this.lst_GheChon = new System.Windows.Forms.ListBox();
            this.lb_TongTien = new System.Windows.Forms.Label();
            this.lb_SDT = new System.Windows.Forms.Label();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.btn_TimKhach = new System.Windows.Forms.Button();
            this.lb_TenKhach = new System.Windows.Forms.Label();
            this.txt_TenKhach = new System.Windows.Forms.TextBox();
            this.lb_Loai = new System.Windows.Forms.Label();
            this.cb_LoaiKhach = new System.Windows.Forms.ComboBox();
            this.lb_PT = new System.Windows.Forms.Label();
            this.cb_PhuongThuc = new System.Windows.Forms.ComboBox();
            this.lb_GhiChu = new System.Windows.Forms.Label();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_ThanhToan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SuatChieu)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Phim
            // 
            this.lb_Phim.Location = new System.Drawing.Point(20, 18);
            this.lb_Phim.Name = "lb_Phim";
            this.lb_Phim.TabIndex = 0;
            this.lb_Phim.Text = "Phim:";
            this.lb_Phim.AutoSize = true;
            this.lb_Phim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            // 
            // cb_Phim
            // 
            this.cb_Phim.Location = new System.Drawing.Point(75, 14);
            this.cb_Phim.Name = "cb_Phim";
            this.cb_Phim.Size = new System.Drawing.Size(345, 23);
            this.cb_Phim.TabIndex = 1;
            this.cb_Phim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Phim.FormattingEnabled = true;
            // 
            // lb_SuatChieu
            // 
            this.lb_SuatChieu.Location = new System.Drawing.Point(20, 52);
            this.lb_SuatChieu.Name = "lb_SuatChieu";
            this.lb_SuatChieu.TabIndex = 2;
            this.lb_SuatChieu.Text = "Suất chiếu";
            this.lb_SuatChieu.AutoSize = true;
            this.lb_SuatChieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            // 
            // dgv_SuatChieu
            // 
            this.dgv_SuatChieu.Location = new System.Drawing.Point(20, 75);
            this.dgv_SuatChieu.Name = "dgv_SuatChieu";
            this.dgv_SuatChieu.Size = new System.Drawing.Size(400, 310);
            this.dgv_SuatChieu.TabIndex = 3;
            this.dgv_SuatChieu.AllowUserToAddRows = false;
            this.dgv_SuatChieu.AllowUserToDeleteRows = false;
            this.dgv_SuatChieu.ReadOnly = true;
            this.dgv_SuatChieu.MultiSelect = false;
            this.dgv_SuatChieu.RowHeadersVisible = false;
            this.dgv_SuatChieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SuatChieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_SuatChieu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_SuatChieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // 
            // lb_SoDo
            // 
            this.lb_SoDo.Location = new System.Drawing.Point(440, 52);
            this.lb_SoDo.Name = "lb_SoDo";
            this.lb_SoDo.TabIndex = 4;
            this.lb_SoDo.Text = "Sơ đồ ghế (bấm vào ghế để giữ, bấm lại để bỏ giữ)";
            this.lb_SoDo.AutoSize = true;
            this.lb_SoDo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            // 
            // pn_SoDoGhe
            // 
            this.pn_SoDoGhe.Location = new System.Drawing.Point(440, 75);
            this.pn_SoDoGhe.Name = "pn_SoDoGhe";
            this.pn_SoDoGhe.Size = new System.Drawing.Size(690, 310);
            this.pn_SoDoGhe.TabIndex = 5;
            this.pn_SoDoGhe.AutoScroll = true;
            this.pn_SoDoGhe.BackColor = System.Drawing.Color.White;
            this.pn_SoDoGhe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lb_CT_Trong
            // 
            this.lb_CT_Trong.Location = new System.Drawing.Point(440, 392);
            this.lb_CT_Trong.Name = "lb_CT_Trong";
            this.lb_CT_Trong.Size = new System.Drawing.Size(115, 24);
            this.lb_CT_Trong.TabIndex = 6;
            this.lb_CT_Trong.Text = "Trống";
            this.lb_CT_Trong.AutoSize = false;
            this.lb_CT_Trong.BackColor = System.Drawing.Color.LightGreen;
            this.lb_CT_Trong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_CT_Trong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lb_CT_CuaToi
            // 
            this.lb_CT_CuaToi.Location = new System.Drawing.Point(561, 392);
            this.lb_CT_CuaToi.Name = "lb_CT_CuaToi";
            this.lb_CT_CuaToi.Size = new System.Drawing.Size(115, 24);
            this.lb_CT_CuaToi.TabIndex = 7;
            this.lb_CT_CuaToi.Text = "Của mình";
            this.lb_CT_CuaToi.AutoSize = false;
            this.lb_CT_CuaToi.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lb_CT_CuaToi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_CT_CuaToi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lb_CT_NguoiKhac
            // 
            this.lb_CT_NguoiKhac.Location = new System.Drawing.Point(682, 392);
            this.lb_CT_NguoiKhac.Name = "lb_CT_NguoiKhac";
            this.lb_CT_NguoiKhac.Size = new System.Drawing.Size(115, 24);
            this.lb_CT_NguoiKhac.TabIndex = 8;
            this.lb_CT_NguoiKhac.Text = "Người khác giữ";
            this.lb_CT_NguoiKhac.AutoSize = false;
            this.lb_CT_NguoiKhac.BackColor = System.Drawing.Color.Orange;
            this.lb_CT_NguoiKhac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_CT_NguoiKhac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lb_CT_DaBan
            // 
            this.lb_CT_DaBan.Location = new System.Drawing.Point(803, 392);
            this.lb_CT_DaBan.Name = "lb_CT_DaBan";
            this.lb_CT_DaBan.Size = new System.Drawing.Size(115, 24);
            this.lb_CT_DaBan.TabIndex = 9;
            this.lb_CT_DaBan.Text = "Đã bán";
            this.lb_CT_DaBan.AutoSize = false;
            this.lb_CT_DaBan.BackColor = System.Drawing.Color.IndianRed;
            this.lb_CT_DaBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_CT_DaBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lb_CT_Hong
            // 
            this.lb_CT_Hong.Location = new System.Drawing.Point(924, 392);
            this.lb_CT_Hong.Name = "lb_CT_Hong";
            this.lb_CT_Hong.Size = new System.Drawing.Size(115, 24);
            this.lb_CT_Hong.TabIndex = 10;
            this.lb_CT_Hong.Text = "Ghế hỏng";
            this.lb_CT_Hong.AutoSize = false;
            this.lb_CT_Hong.BackColor = System.Drawing.Color.DimGray;
            this.lb_CT_Hong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_CT_Hong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_CT_Hong.ForeColor = System.Drawing.Color.White;
            // 
            // lb_GheChon
            // 
            this.lb_GheChon.Location = new System.Drawing.Point(20, 395);
            this.lb_GheChon.Name = "lb_GheChon";
            this.lb_GheChon.TabIndex = 11;
            this.lb_GheChon.Text = "Ghế đã chọn";
            this.lb_GheChon.AutoSize = true;
            this.lb_GheChon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            // 
            // lst_GheChon
            // 
            this.lst_GheChon.Location = new System.Drawing.Point(20, 418);
            this.lst_GheChon.Name = "lst_GheChon";
            this.lst_GheChon.Size = new System.Drawing.Size(400, 154);
            this.lst_GheChon.TabIndex = 12;
            this.lst_GheChon.FormattingEnabled = true;
            this.lst_GheChon.ItemHeight = 15;
            // 
            // lb_TongTien
            // 
            this.lb_TongTien.Location = new System.Drawing.Point(20, 584);
            this.lb_TongTien.Name = "lb_TongTien";
            this.lb_TongTien.Size = new System.Drawing.Size(400, 34);
            this.lb_TongTien.TabIndex = 13;
            this.lb_TongTien.Text = "Tổng tiền: 0đ";
            this.lb_TongTien.AutoSize = false;
            this.lb_TongTien.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_TongTien.ForeColor = System.Drawing.Color.Red;
            this.lb_TongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_SDT
            // 
            this.lb_SDT.Location = new System.Drawing.Point(440, 435);
            this.lb_SDT.Name = "lb_SDT";
            this.lb_SDT.TabIndex = 14;
            this.lb_SDT.Text = "Số điện thoại:";
            this.lb_SDT.AutoSize = true;
            // 
            // txt_SDT
            // 
            this.txt_SDT.Location = new System.Drawing.Point(540, 431);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(170, 23);
            this.txt_SDT.TabIndex = 15;
            this.txt_SDT.MaxLength = 15;
            // 
            // btn_TimKhach
            // 
            this.btn_TimKhach.Location = new System.Drawing.Point(720, 429);
            this.btn_TimKhach.Name = "btn_TimKhach";
            this.btn_TimKhach.Size = new System.Drawing.Size(100, 28);
            this.btn_TimKhach.TabIndex = 16;
            this.btn_TimKhach.Text = "Tìm khách";
            this.btn_TimKhach.UseVisualStyleBackColor = true;
            // 
            // lb_TenKhach
            // 
            this.lb_TenKhach.Location = new System.Drawing.Point(440, 477);
            this.lb_TenKhach.Name = "lb_TenKhach";
            this.lb_TenKhach.TabIndex = 17;
            this.lb_TenKhach.Text = "Tên khách:";
            this.lb_TenKhach.AutoSize = true;
            // 
            // txt_TenKhach
            // 
            this.txt_TenKhach.Location = new System.Drawing.Point(540, 473);
            this.txt_TenKhach.Name = "txt_TenKhach";
            this.txt_TenKhach.Size = new System.Drawing.Size(280, 23);
            this.txt_TenKhach.TabIndex = 18;
            this.txt_TenKhach.MaxLength = 100;
            // 
            // lb_Loai
            // 
            this.lb_Loai.Location = new System.Drawing.Point(840, 435);
            this.lb_Loai.Name = "lb_Loai";
            this.lb_Loai.TabIndex = 19;
            this.lb_Loai.Text = "Loại khách:";
            this.lb_Loai.AutoSize = true;
            // 
            // cb_LoaiKhach
            // 
            this.cb_LoaiKhach.Location = new System.Drawing.Point(925, 431);
            this.cb_LoaiKhach.Name = "cb_LoaiKhach";
            this.cb_LoaiKhach.Size = new System.Drawing.Size(205, 23);
            this.cb_LoaiKhach.TabIndex = 20;
            this.cb_LoaiKhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_LoaiKhach.FormattingEnabled = true;
            // 
            // lb_PT
            // 
            this.lb_PT.Location = new System.Drawing.Point(840, 477);
            this.lb_PT.Name = "lb_PT";
            this.lb_PT.TabIndex = 21;
            this.lb_PT.Text = "Thanh toán:";
            this.lb_PT.AutoSize = true;
            // 
            // cb_PhuongThuc
            // 
            this.cb_PhuongThuc.Location = new System.Drawing.Point(925, 473);
            this.cb_PhuongThuc.Name = "cb_PhuongThuc";
            this.cb_PhuongThuc.Size = new System.Drawing.Size(205, 23);
            this.cb_PhuongThuc.TabIndex = 22;
            this.cb_PhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PhuongThuc.FormattingEnabled = true;
            // 
            // lb_GhiChu
            // 
            this.lb_GhiChu.Location = new System.Drawing.Point(440, 525);
            this.lb_GhiChu.Name = "lb_GhiChu";
            this.lb_GhiChu.TabIndex = 23;
            this.lb_GhiChu.Text = "Ghế được giữ tối đa 5 phút. Hết hạn giữ phải chọn lại ghế.";
            this.lb_GhiChu.AutoSize = true;
            this.lb_GhiChu.ForeColor = System.Drawing.Color.DimGray;
            // 
            // btn_Huy
            // 
            this.btn_Huy.Location = new System.Drawing.Point(800, 584);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(140, 44);
            this.btn_Huy.TabIndex = 24;
            this.btn_Huy.Text = "Hủy giữ ghế";
            this.btn_Huy.UseVisualStyleBackColor = true;
            // 
            // btn_ThanhToan
            // 
            this.btn_ThanhToan.Location = new System.Drawing.Point(960, 584);
            this.btn_ThanhToan.Name = "btn_ThanhToan";
            this.btn_ThanhToan.Size = new System.Drawing.Size(170, 44);
            this.btn_ThanhToan.TabIndex = 25;
            this.btn_ThanhToan.Text = "Thanh toán";
            this.btn_ThanhToan.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_ThanhToan.ForeColor = System.Drawing.Color.White;
            this.btn_ThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_ThanhToan.UseVisualStyleBackColor = false;
            // 
            // FrmDatVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 645);
            this.Controls.Add(this.lb_Phim);
            this.Controls.Add(this.cb_Phim);
            this.Controls.Add(this.lb_SuatChieu);
            this.Controls.Add(this.dgv_SuatChieu);
            this.Controls.Add(this.lb_SoDo);
            this.Controls.Add(this.pn_SoDoGhe);
            this.Controls.Add(this.lb_CT_Trong);
            this.Controls.Add(this.lb_CT_CuaToi);
            this.Controls.Add(this.lb_CT_NguoiKhac);
            this.Controls.Add(this.lb_CT_DaBan);
            this.Controls.Add(this.lb_CT_Hong);
            this.Controls.Add(this.lb_GheChon);
            this.Controls.Add(this.lst_GheChon);
            this.Controls.Add(this.lb_TongTien);
            this.Controls.Add(this.lb_SDT);
            this.Controls.Add(this.txt_SDT);
            this.Controls.Add(this.btn_TimKhach);
            this.Controls.Add(this.lb_TenKhach);
            this.Controls.Add(this.txt_TenKhach);
            this.Controls.Add(this.lb_Loai);
            this.Controls.Add(this.cb_LoaiKhach);
            this.Controls.Add(this.lb_PT);
            this.Controls.Add(this.cb_PhuongThuc);
            this.Controls.Add(this.lb_GhiChu);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_ThanhToan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDatVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt vé";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SuatChieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lb_Phim;
        private System.Windows.Forms.ComboBox cb_Phim;
        private System.Windows.Forms.Label lb_SuatChieu;
        private System.Windows.Forms.DataGridView dgv_SuatChieu;
        private System.Windows.Forms.Label lb_SoDo;
        private System.Windows.Forms.Panel pn_SoDoGhe;
        private System.Windows.Forms.Label lb_CT_Trong;
        private System.Windows.Forms.Label lb_CT_CuaToi;
        private System.Windows.Forms.Label lb_CT_NguoiKhac;
        private System.Windows.Forms.Label lb_CT_DaBan;
        private System.Windows.Forms.Label lb_CT_Hong;
        private System.Windows.Forms.Label lb_GheChon;
        private System.Windows.Forms.ListBox lst_GheChon;
        private System.Windows.Forms.Label lb_TongTien;
        private System.Windows.Forms.Label lb_SDT;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.Button btn_TimKhach;
        private System.Windows.Forms.Label lb_TenKhach;
        private System.Windows.Forms.TextBox txt_TenKhach;
        private System.Windows.Forms.Label lb_Loai;
        private System.Windows.Forms.ComboBox cb_LoaiKhach;
        private System.Windows.Forms.Label lb_PT;
        private System.Windows.Forms.ComboBox cb_PhuongThuc;
        private System.Windows.Forms.Label lb_GhiChu;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_ThanhToan;
    }
}
