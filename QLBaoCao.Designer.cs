namespace DatVe
{
    partial class QLBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLBaoCao));
            tab1 = new TabControl();
            tabPage2 = new TabPage();
            label2 = new Label();
            chckTatCa = new CheckBox();
            dtpThang = new DateTimePicker();
            lblTongDoanhThu = new Label();
            dgvVeDaBan = new DataGridView();
            lblTongVe = new Label();
            tabPage1 = new TabPage();
            dgvLSKH = new DataGridView();
            lblTTKH = new Label();
            btnTraCuu = new Button();
            txtSDT = new TextBox();
            label1 = new Label();
            tabPage3 = new TabPage();
            TatCaSC = new CheckBox();
            dtpThangSC = new DateTimePicker();
            label3 = new Label();
            dgvSC = new DataGridView();
            lblSCHot = new Label();
            tab1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVeDaBan).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLSKH).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSC).BeginInit();
            SuspendLayout();
            // 
            // tab1
            // 
            tab1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tab1.Controls.Add(tabPage2);
            tab1.Controls.Add(tabPage1);
            tab1.Controls.Add(tabPage3);
            tab1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tab1.Location = new Point(0, 0);
            tab1.Name = "tab1";
            tab1.SelectedIndex = 0;
            tab1.Size = new Size(1301, 635);
            tab1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackgroundImage = (Image)resources.GetObject("tabPage2.BackgroundImage");
            tabPage2.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(chckTatCa);
            tabPage2.Controls.Add(dtpThang);
            tabPage2.Controls.Add(lblTongDoanhThu);
            tabPage2.Controls.Add(dgvVeDaBan);
            tabPage2.Controls.Add(lblTongVe);
            tabPage2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage2.ImeMode = ImeMode.NoControl;
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1293, 597);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "1. Danh sách vé đã bán";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 22);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 6;
            label2.Text = "Tháng:";
            // 
            // chckTatCa
            // 
            chckTatCa.AutoSize = true;
            chckTatCa.Location = new Point(456, 20);
            chckTatCa.Name = "chckTatCa";
            chckTatCa.Size = new Size(86, 29);
            chckTatCa.TabIndex = 5;
            chckTatCa.Text = "Tất cả";
            chckTatCa.UseVisualStyleBackColor = true;
            // 
            // dtpThang
            // 
            dtpThang.CustomFormat = "MM/yyyy";
            dtpThang.Format = DateTimePickerFormat.Custom;
            dtpThang.Location = new Point(188, 18);
            dtpThang.Name = "dtpThang";
            dtpThang.ShowUpDown = true;
            dtpThang.Size = new Size(250, 31);
            dtpThang.TabIndex = 4;
            dtpThang.ValueChanged += dtpThang_ValueChanged;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.AutoSize = true;
            lblTongDoanhThu.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongDoanhThu.ForeColor = Color.DarkGreen;
            lblTongDoanhThu.Location = new Point(696, 82);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(186, 31);
            lblTongDoanhThu.TabIndex = 3;
            lblTongDoanhThu.Text = "Tổng doanh thu";
            // 
            // dgvVeDaBan
            // 
            dgvVeDaBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVeDaBan.BackgroundColor = SystemColors.ButtonHighlight;
            dgvVeDaBan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVeDaBan.Location = new Point(6, 136);
            dgvVeDaBan.Name = "dgvVeDaBan";
            dgvVeDaBan.ReadOnly = true;
            dgvVeDaBan.RowHeadersWidth = 51;
            dgvVeDaBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVeDaBan.Size = new Size(1279, 453);
            dgvVeDaBan.TabIndex = 2;
            // 
            // lblTongVe
            // 
            lblTongVe.AutoSize = true;
            lblTongVe.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongVe.Location = new Point(696, 22);
            lblTongVe.Name = "lblTongVe";
            lblTongVe.Size = new Size(129, 31);
            lblTongVe.TabIndex = 1;
            lblTongVe.Text = "Tổng số vé";
            // 
            // tabPage1
            // 
            tabPage1.BackgroundImage = (Image)resources.GetObject("tabPage1.BackgroundImage");
            tabPage1.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage1.Controls.Add(dgvLSKH);
            tabPage1.Controls.Add(lblTTKH);
            tabPage1.Controls.Add(btnTraCuu);
            tabPage1.Controls.Add(txtSDT);
            tabPage1.Controls.Add(label1);
            tabPage1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1293, 597);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "2. Lịch sử đặt vé";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLSKH
            // 
            dgvLSKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLSKH.BackgroundColor = SystemColors.ButtonHighlight;
            dgvLSKH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLSKH.Location = new Point(6, 109);
            dgvLSKH.Name = "dgvLSKH";
            dgvLSKH.RowHeadersWidth = 51;
            dgvLSKH.Size = new Size(1142, 412);
            dgvLSKH.TabIndex = 4;
            // 
            // lblTTKH
            // 
            lblTTKH.AutoSize = true;
            lblTTKH.Location = new Point(609, 27);
            lblTTKH.Name = "lblTTKH";
            lblTTKH.Size = new Size(118, 25);
            lblTTKH.TabIndex = 3;
            lblTTKH.Text = "Khách hàng:";
            // 
            // btnTraCuu
            // 
            btnTraCuu.Location = new Point(438, 17);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.Size = new Size(113, 39);
            btnTraCuu.TabIndex = 2;
            btnTraCuu.Text = "Tra cứu";
            btnTraCuu.UseVisualStyleBackColor = true;
            btnTraCuu.Click += btnTraCuu_Click;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(186, 21);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(194, 31);
            txtSDT.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 24);
            label1.Name = "label1";
            label1.Size = new Size(160, 25);
            label1.TabIndex = 0;
            label1.Text = "Số điện thoại KH:";
            // 
            // tabPage3
            // 
            tabPage3.BackgroundImage = (Image)resources.GetObject("tabPage3.BackgroundImage");
            tabPage3.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage3.Controls.Add(TatCaSC);
            tabPage3.Controls.Add(dtpThangSC);
            tabPage3.Controls.Add(label3);
            tabPage3.Controls.Add(dgvSC);
            tabPage3.Controls.Add(lblSCHot);
            tabPage3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1293, 597);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "3. Suất chiếu đông nhất";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // TatCaSC
            // 
            TatCaSC.AutoSize = true;
            TatCaSC.Location = new Point(578, 16);
            TatCaSC.Name = "TatCaSC";
            TatCaSC.Size = new Size(86, 29);
            TatCaSC.TabIndex = 5;
            TatCaSC.Text = "Tất cả";
            TatCaSC.UseVisualStyleBackColor = true;
            TatCaSC.CheckedChanged += chkTatCaSC_CheckedChanged;
            // 
            // dtpThangSC
            // 
            dtpThangSC.CustomFormat = "MM/yyyy";
            dtpThangSC.Format = DateTimePickerFormat.Custom;
            dtpThangSC.Location = new Point(312, 16);
            dtpThangSC.Name = "dtpThangSC";
            dtpThangSC.ShowUpDown = true;
            dtpThangSC.Size = new Size(250, 31);
            dtpThangSC.TabIndex = 4;
            dtpThangSC.ValueChanged += dtpThangSC_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(240, 20);
            label3.Name = "label3";
            label3.Size = new Size(76, 25);
            label3.TabIndex = 3;
            label3.Text = "Tháng: ";
            // 
            // dgvSC
            // 
            dgvSC.AllowUserToAddRows = false;
            dgvSC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvSC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSC.BackgroundColor = SystemColors.ButtonHighlight;
            dgvSC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSC.Location = new Point(8, 141);
            dgvSC.Name = "dgvSC";
            dgvSC.RowHeadersWidth = 51;
            dgvSC.Size = new Size(1277, 438);
            dgvSC.TabIndex = 2;
            // 
            // lblSCHot
            // 
            lblSCHot.AutoSize = true;
            lblSCHot.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSCHot.ForeColor = Color.DarkRed;
            lblSCHot.Location = new Point(240, 77);
            lblSCHot.Name = "lblSCHot";
            lblSCHot.Size = new Size(68, 28);
            lblSCHot.TabIndex = 1;
            lblSCHot.Text = "-------";
            // 
            // QLBaoCao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1301, 635);
            Controls.Add(tab1);
            Name = "QLBaoCao";
            Text = "Quản Lý Báo Cáo";
            Load += QLBaoCao_Load;
            tab1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVeDaBan).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLSKH).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSC).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tab1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabPage tabPage3;
        private Label lblTongDoanhThu;
        private DataGridView dgvVeDaBan;
        private Label lblTongVe;
        private DataGridView dgvLSKH;
        private Label lblTTKH;
        private Button btnTraCuu;
        private TextBox txtSDT;
        private Label label1;
        private Label lblSCHot;
        private DataGridView dgvSC;
        private DateTimePicker dtpThang;
        private CheckBox chckTatCa;
        private Label label2;
        private CheckBox TatCaSC;
        private DateTimePicker dtpThangSC;
        private Label label3;
    }
}