#nullable disable
namespace DatVe
{
    partial class FrmHoaDon
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
            this.lb_Tim = new System.Windows.Forms.Label();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.chk_LocNgay = new System.Windows.Forms.CheckBox();
            this.dtp_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.lb_Den = new System.Windows.Forms.Label();
            this.dtp_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.btn_TaiLai = new System.Windows.Forms.Button();
            this.lb_DanhSach = new System.Windows.Forms.Label();
            this.dgv_HoaDon = new System.Windows.Forms.DataGridView();
            this.lb_ThongTin = new System.Windows.Forms.Label();
            this.lb_HDMa = new System.Windows.Forms.Label();
            this.txt_HDMa = new System.Windows.Forms.TextBox();
            this.lb_Khach = new System.Windows.Forms.Label();
            this.txt_TenKhach = new System.Windows.Forms.TextBox();
            this.lb_SDT = new System.Windows.Forms.Label();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.lb_Ngay = new System.Windows.Forms.Label();
            this.txt_NgayLap = new System.Windows.Forms.TextBox();
            this.lb_Tong = new System.Windows.Forms.Label();
            this.txt_TongTien = new System.Windows.Forms.TextBox();
            this.lb_PT = new System.Windows.Forms.Label();
            this.cb_PhuongThuc = new System.Windows.Forms.ComboBox();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_In = new System.Windows.Forms.Button();
            this.lb_VeTrongHD = new System.Windows.Forms.Label();
            this.dgv_ChiTiet = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Tim
            // 
            this.lb_Tim.Location = new System.Drawing.Point(20, 19);
            this.lb_Tim.Name = "lb_Tim";
            this.lb_Tim.TabIndex = 0;
            this.lb_Tim.Text = "Tìm (mã HĐ hoặc SĐT):";
            this.lb_Tim.AutoSize = true;
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(170, 15);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(190, 23);
            this.txt_TimKiem.TabIndex = 1;
            // 
            // chk_LocNgay
            // 
            this.chk_LocNgay.Location = new System.Drawing.Point(380, 17);
            this.chk_LocNgay.Name = "chk_LocNgay";
            this.chk_LocNgay.TabIndex = 2;
            this.chk_LocNgay.Text = "Lọc theo ngày";
            this.chk_LocNgay.AutoSize = true;
            this.chk_LocNgay.UseVisualStyleBackColor = true;
            // 
            // dtp_TuNgay
            // 
            this.dtp_TuNgay.Location = new System.Drawing.Point(500, 15);
            this.dtp_TuNgay.Name = "dtp_TuNgay";
            this.dtp_TuNgay.Size = new System.Drawing.Size(125, 23);
            this.dtp_TuNgay.TabIndex = 3;
            this.dtp_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lb_Den
            // 
            this.lb_Den.Location = new System.Drawing.Point(633, 19);
            this.lb_Den.Name = "lb_Den";
            this.lb_Den.TabIndex = 4;
            this.lb_Den.Text = "đến";
            this.lb_Den.AutoSize = true;
            // 
            // dtp_DenNgay
            // 
            this.dtp_DenNgay.Location = new System.Drawing.Point(665, 15);
            this.dtp_DenNgay.Name = "dtp_DenNgay";
            this.dtp_DenNgay.Size = new System.Drawing.Size(125, 23);
            this.dtp_DenNgay.TabIndex = 5;
            this.dtp_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // btn_Tim
            // 
            this.btn_Tim.Location = new System.Drawing.Point(815, 12);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(100, 30);
            this.btn_Tim.TabIndex = 6;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            // 
            // btn_TaiLai
            // 
            this.btn_TaiLai.Location = new System.Drawing.Point(925, 12);
            this.btn_TaiLai.Name = "btn_TaiLai";
            this.btn_TaiLai.Size = new System.Drawing.Size(110, 30);
            this.btn_TaiLai.TabIndex = 7;
            this.btn_TaiLai.Text = "Tải lại";
            this.btn_TaiLai.UseVisualStyleBackColor = true;
            // 
            // lb_DanhSach
            // 
            this.lb_DanhSach.Location = new System.Drawing.Point(20, 55);
            this.lb_DanhSach.Name = "lb_DanhSach";
            this.lb_DanhSach.TabIndex = 8;
            this.lb_DanhSach.Text = "Danh sách hóa đơn";
            this.lb_DanhSach.AutoSize = true;
            this.lb_DanhSach.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            // 
            // dgv_HoaDon
            // 
            this.dgv_HoaDon.Location = new System.Drawing.Point(20, 78);
            this.dgv_HoaDon.Name = "dgv_HoaDon";
            this.dgv_HoaDon.Size = new System.Drawing.Size(1060, 225);
            this.dgv_HoaDon.TabIndex = 9;
            this.dgv_HoaDon.AllowUserToAddRows = false;
            this.dgv_HoaDon.AllowUserToDeleteRows = false;
            this.dgv_HoaDon.ReadOnly = true;
            this.dgv_HoaDon.MultiSelect = false;
            this.dgv_HoaDon.RowHeadersVisible = false;
            this.dgv_HoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_HoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_HoaDon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // 
            // lb_ThongTin
            // 
            this.lb_ThongTin.Location = new System.Drawing.Point(20, 315);
            this.lb_ThongTin.Name = "lb_ThongTin";
            this.lb_ThongTin.TabIndex = 10;
            this.lb_ThongTin.Text = "Thông tin hóa đơn đang chọn";
            this.lb_ThongTin.AutoSize = true;
            this.lb_ThongTin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            // 
            // lb_HDMa
            // 
            this.lb_HDMa.Location = new System.Drawing.Point(20, 352);
            this.lb_HDMa.Name = "lb_HDMa";
            this.lb_HDMa.TabIndex = 11;
            this.lb_HDMa.Text = "Mã hóa đơn:";
            this.lb_HDMa.AutoSize = true;
            // 
            // txt_HDMa
            // 
            this.txt_HDMa.Location = new System.Drawing.Point(110, 348);
            this.txt_HDMa.Name = "txt_HDMa";
            this.txt_HDMa.Size = new System.Drawing.Size(90, 23);
            this.txt_HDMa.TabIndex = 12;
            // 
            // lb_Khach
            // 
            this.lb_Khach.Location = new System.Drawing.Point(220, 352);
            this.lb_Khach.Name = "lb_Khach";
            this.lb_Khach.TabIndex = 13;
            this.lb_Khach.Text = "Khách hàng:";
            this.lb_Khach.AutoSize = true;
            // 
            // txt_TenKhach
            // 
            this.txt_TenKhach.Location = new System.Drawing.Point(305, 348);
            this.txt_TenKhach.Name = "txt_TenKhach";
            this.txt_TenKhach.Size = new System.Drawing.Size(210, 23);
            this.txt_TenKhach.TabIndex = 14;
            // 
            // lb_SDT
            // 
            this.lb_SDT.Location = new System.Drawing.Point(535, 352);
            this.lb_SDT.Name = "lb_SDT";
            this.lb_SDT.TabIndex = 15;
            this.lb_SDT.Text = "SĐT:";
            this.lb_SDT.AutoSize = true;
            // 
            // txt_SDT
            // 
            this.txt_SDT.Location = new System.Drawing.Point(575, 348);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(130, 23);
            this.txt_SDT.TabIndex = 16;
            // 
            // lb_Ngay
            // 
            this.lb_Ngay.Location = new System.Drawing.Point(725, 352);
            this.lb_Ngay.Name = "lb_Ngay";
            this.lb_Ngay.TabIndex = 17;
            this.lb_Ngay.Text = "Ngày lập:";
            this.lb_Ngay.AutoSize = true;
            // 
            // txt_NgayLap
            // 
            this.txt_NgayLap.Location = new System.Drawing.Point(790, 348);
            this.txt_NgayLap.Name = "txt_NgayLap";
            this.txt_NgayLap.Size = new System.Drawing.Size(150, 23);
            this.txt_NgayLap.TabIndex = 18;
            // 
            // lb_Tong
            // 
            this.lb_Tong.Location = new System.Drawing.Point(20, 392);
            this.lb_Tong.Name = "lb_Tong";
            this.lb_Tong.TabIndex = 19;
            this.lb_Tong.Text = "Tổng tiền:";
            this.lb_Tong.AutoSize = true;
            // 
            // txt_TongTien
            // 
            this.txt_TongTien.Location = new System.Drawing.Point(110, 388);
            this.txt_TongTien.Name = "txt_TongTien";
            this.txt_TongTien.Size = new System.Drawing.Size(130, 23);
            this.txt_TongTien.TabIndex = 20;
            // 
            // lb_PT
            // 
            this.lb_PT.Location = new System.Drawing.Point(260, 392);
            this.lb_PT.Name = "lb_PT";
            this.lb_PT.TabIndex = 21;
            this.lb_PT.Text = "Thanh toán:";
            this.lb_PT.AutoSize = true;
            // 
            // cb_PhuongThuc
            // 
            this.cb_PhuongThuc.Location = new System.Drawing.Point(340, 388);
            this.cb_PhuongThuc.Name = "cb_PhuongThuc";
            this.cb_PhuongThuc.Size = new System.Drawing.Size(160, 23);
            this.cb_PhuongThuc.TabIndex = 22;
            this.cb_PhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PhuongThuc.FormattingEnabled = true;
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(520, 385);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(170, 30);
            this.btn_Sua.TabIndex = 23;
            this.btn_Sua.Text = "Lưu phương thức";
            this.btn_Sua.UseVisualStyleBackColor = true;
            // 
            // btn_In
            // 
            this.btn_In.Location = new System.Drawing.Point(700, 385);
            this.btn_In.Name = "btn_In";
            this.btn_In.Size = new System.Drawing.Size(130, 30);
            this.btn_In.TabIndex = 24;
            this.btn_In.Text = "In hóa đơn";
            this.btn_In.UseVisualStyleBackColor = true;
            // 
            // lb_VeTrongHD
            // 
            this.lb_VeTrongHD.Location = new System.Drawing.Point(20, 432);
            this.lb_VeTrongHD.Name = "lb_VeTrongHD";
            this.lb_VeTrongHD.TabIndex = 25;
            this.lb_VeTrongHD.Text = "Các vé trong hóa đơn";
            this.lb_VeTrongHD.AutoSize = true;
            this.lb_VeTrongHD.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            // 
            // dgv_ChiTiet
            // 
            this.dgv_ChiTiet.Location = new System.Drawing.Point(20, 455);
            this.dgv_ChiTiet.Name = "dgv_ChiTiet";
            this.dgv_ChiTiet.Size = new System.Drawing.Size(1060, 195);
            this.dgv_ChiTiet.TabIndex = 26;
            this.dgv_ChiTiet.AllowUserToAddRows = false;
            this.dgv_ChiTiet.AllowUserToDeleteRows = false;
            this.dgv_ChiTiet.ReadOnly = true;
            this.dgv_ChiTiet.MultiSelect = false;
            this.dgv_ChiTiet.RowHeadersVisible = false;
            this.dgv_ChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ChiTiet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_ChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // 
            // FrmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 670);
            this.Controls.Add(this.lb_Tim);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.chk_LocNgay);
            this.Controls.Add(this.dtp_TuNgay);
            this.Controls.Add(this.lb_Den);
            this.Controls.Add(this.dtp_DenNgay);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.btn_TaiLai);
            this.Controls.Add(this.lb_DanhSach);
            this.Controls.Add(this.dgv_HoaDon);
            this.Controls.Add(this.lb_ThongTin);
            this.Controls.Add(this.lb_HDMa);
            this.Controls.Add(this.txt_HDMa);
            this.Controls.Add(this.lb_Khach);
            this.Controls.Add(this.txt_TenKhach);
            this.Controls.Add(this.lb_SDT);
            this.Controls.Add(this.txt_SDT);
            this.Controls.Add(this.lb_Ngay);
            this.Controls.Add(this.txt_NgayLap);
            this.Controls.Add(this.lb_Tong);
            this.Controls.Add(this.txt_TongTien);
            this.Controls.Add(this.lb_PT);
            this.Controls.Add(this.cb_PhuongThuc);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_In);
            this.Controls.Add(this.lb_VeTrongHD);
            this.Controls.Add(this.dgv_ChiTiet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hóa đơn";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lb_Tim;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.CheckBox chk_LocNgay;
        private System.Windows.Forms.DateTimePicker dtp_TuNgay;
        private System.Windows.Forms.Label lb_Den;
        private System.Windows.Forms.DateTimePicker dtp_DenNgay;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.Button btn_TaiLai;
        private System.Windows.Forms.Label lb_DanhSach;
        private System.Windows.Forms.DataGridView dgv_HoaDon;
        private System.Windows.Forms.Label lb_ThongTin;
        private System.Windows.Forms.Label lb_HDMa;
        private System.Windows.Forms.TextBox txt_HDMa;
        private System.Windows.Forms.Label lb_Khach;
        private System.Windows.Forms.TextBox txt_TenKhach;
        private System.Windows.Forms.Label lb_SDT;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.Label lb_Ngay;
        private System.Windows.Forms.TextBox txt_NgayLap;
        private System.Windows.Forms.Label lb_Tong;
        private System.Windows.Forms.TextBox txt_TongTien;
        private System.Windows.Forms.Label lb_PT;
        private System.Windows.Forms.ComboBox cb_PhuongThuc;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_In;
        private System.Windows.Forms.Label lb_VeTrongHD;
        private System.Windows.Forms.DataGridView dgv_ChiTiet;
    }
}