namespace DatVe
{
    partial class frmBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            label1 = new Label();
            label2 = new Label();
            cb_LoaiBaoCao = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            dtp_TuNgay = new DateTimePicker();
            dtp_DenNgay = new DateTimePicker();
            label5 = new Label();
            cb_Phim = new ComboBox();
            lbl_TongDoanhThu = new Label();
            btn_ThongKe = new Button();
            btn_LamMoi = new Button();
            groupBox1 = new GroupBox();
            dgv_BaoCao = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_BaoCao).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(36, 18);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(216, 25);
            label1.TabIndex = 0;
            label1.Text = "BÁO CÁO DOANH THU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(43, 63);
            label2.Name = "label2";
            label2.Size = new Size(86, 19);
            label2.TabIndex = 1;
            label2.Text = "Loại báo cáo";
            // 
            // cb_LoaiBaoCao
            // 
            cb_LoaiBaoCao.FormattingEnabled = true;
            cb_LoaiBaoCao.Location = new Point(43, 81);
            cb_LoaiBaoCao.Name = "cb_LoaiBaoCao";
            cb_LoaiBaoCao.Size = new Size(276, 23);
            cb_LoaiBaoCao.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(43, 114);
            label3.Name = "label3";
            label3.Size = new Size(58, 19);
            label3.TabIndex = 3;
            label3.Text = "Từ ngày";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(327, 114);
            label4.Name = "label4";
            label4.Size = new Size(68, 19);
            label4.TabIndex = 4;
            label4.Text = "Đến ngày";
            // 
            // dtp_TuNgay
            // 
            dtp_TuNgay.Format = DateTimePickerFormat.Short;
            dtp_TuNgay.Location = new Point(43, 136);
            dtp_TuNgay.Name = "dtp_TuNgay";
            dtp_TuNgay.Size = new Size(200, 23);
            dtp_TuNgay.TabIndex = 5;
            // 
            // dtp_DenNgay
            // 
            dtp_DenNgay.Format = DateTimePickerFormat.Short;
            dtp_DenNgay.Location = new Point(327, 136);
            dtp_DenNgay.Name = "dtp_DenNgay";
            dtp_DenNgay.Size = new Size(200, 23);
            dtp_DenNgay.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(43, 171);
            label5.Name = "label5";
            label5.Size = new Size(40, 19);
            label5.TabIndex = 7;
            label5.Text = "Phim";
            // 
            // cb_Phim
            // 
            cb_Phim.FormattingEnabled = true;
            cb_Phim.Location = new Point(43, 193);
            cb_Phim.Name = "cb_Phim";
            cb_Phim.Size = new Size(276, 23);
            cb_Phim.TabIndex = 8;
            // 
            // lbl_TongDoanhThu
            // 
            lbl_TongDoanhThu.AutoSize = true;
            lbl_TongDoanhThu.BackColor = Color.Transparent;
            lbl_TongDoanhThu.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_TongDoanhThu.Location = new Point(36, 267);
            lbl_TongDoanhThu.Name = "lbl_TongDoanhThu";
            lbl_TongDoanhThu.Size = new Size(147, 20);
            lbl_TongDoanhThu.TabIndex = 9;
            lbl_TongDoanhThu.Text = "TỔNG DOANH THU";
            // 
            // btn_ThongKe
            // 
            btn_ThongKe.BackColor = SystemColors.HighlightText;
            btn_ThongKe.Location = new Point(115, 232);
            btn_ThongKe.Name = "btn_ThongKe";
            btn_ThongKe.Size = new Size(128, 23);
            btn_ThongKe.TabIndex = 10;
            btn_ThongKe.Text = "Thống kê";
            btn_ThongKe.UseVisualStyleBackColor = false;
            btn_ThongKe.Click += btn_ThongKe_Click;
            // 
            // btn_LamMoi
            // 
            btn_LamMoi.BackColor = SystemColors.ControlLightLight;
            btn_LamMoi.Location = new Point(371, 232);
            btn_LamMoi.Name = "btn_LamMoi";
            btn_LamMoi.Size = new Size(129, 23);
            btn_LamMoi.TabIndex = 11;
            btn_LamMoi.Text = "Làm mới";
            btn_LamMoi.UseVisualStyleBackColor = false;
            btn_LamMoi.Click += btn_LamMoi_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(dgv_BaoCao);
            groupBox1.Location = new Point(36, 320);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(749, 185);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chi tiết báo cáo";
            // 
            // dgv_BaoCao
            // 
            dgv_BaoCao.BackgroundColor = SystemColors.ControlLightLight;
            dgv_BaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_BaoCao.Location = new Point(15, 22);
            dgv_BaoCao.Name = "dgv_BaoCao";
            dgv_BaoCao.Size = new Size(715, 150);
            dgv_BaoCao.TabIndex = 0;
            // 
            // frmBaoCao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 506);
            Controls.Add(groupBox1);
            Controls.Add(btn_LamMoi);
            Controls.Add(btn_ThongKe);
            Controls.Add(lbl_TongDoanhThu);
            Controls.Add(cb_Phim);
            Controls.Add(label5);
            Controls.Add(dtp_DenNgay);
            Controls.Add(dtp_TuNgay);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cb_LoaiBaoCao);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmBaoCao";
            Text = "frmBaoCao";
            Load += frmBaoCao_Load_1;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_BaoCao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cb_LoaiBaoCao;
        private Label label3;
        private Label label4;
        private DateTimePicker dtp_TuNgay;
        private DateTimePicker dtp_DenNgay;
        private Label label5;
        private ComboBox cb_Phim;
        private Label lbl_TongDoanhThu;
        private Button btn_ThongKe;
        private Button btn_LamMoi;
        private GroupBox groupBox1;
        private DataGridView dgv_BaoCao;
    }
}