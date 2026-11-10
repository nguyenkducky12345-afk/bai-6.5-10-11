using System.Windows.Forms;
using System.Drawing;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

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
        this.flpPhongHat = new System.Windows.Forms.FlowLayoutPanel();
        this.grpChucNang = new System.Windows.Forms.GroupBox();
        this.btnThanhToan = new System.Windows.Forms.Button();
        this.btnMoPhong = new System.Windows.Forms.Button();
        this.lblThongTinPhong = new System.Windows.Forms.Label();
        this.grpDichVu = new System.Windows.Forms.GroupBox();
        this.dgvChiTietDichVu = new System.Windows.Forms.DataGridView();
        this.btnThemDV = new System.Windows.Forms.Button();
        this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
        this.label2 = new System.Windows.Forms.Label();
        this.cboDichVu = new System.Windows.Forms.ComboBox();
        this.label1 = new System.Windows.Forms.Label();
        this.grpChucNang.SuspendLayout();
        this.grpDichVu.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDichVu)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
        this.SuspendLayout();
        // 
        // flpPhongHat
        // 
        this.flpPhongHat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)));
        this.flpPhongHat.AutoScroll = true;
        this.flpPhongHat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.flpPhongHat.Location = new System.Drawing.Point(12, 12);
        this.flpPhongHat.Name = "flpPhongHat";
        this.flpPhongHat.Padding = new System.Windows.Forms.Padding(8);
        this.flpPhongHat.Size = new System.Drawing.Size(340, 560);
        this.flpPhongHat.TabIndex = 0;
        // 
        // grpChucNang
        // 
        this.grpChucNang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpChucNang.Controls.Add(this.btnThanhToan);
        this.grpChucNang.Controls.Add(this.btnMoPhong);
        this.grpChucNang.Controls.Add(this.lblThongTinPhong);
        this.grpChucNang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.grpChucNang.Location = new System.Drawing.Point(365, 12);
        this.grpChucNang.Name = "grpChucNang";
        this.grpChucNang.Size = new System.Drawing.Size(567, 105);
        this.grpChucNang.TabIndex = 1;
        this.grpChucNang.TabStop = false;
        this.grpChucNang.Text = "Thông Tin Phòng";
        // 
        // btnThanhToan
        // 
        this.btnThanhToan.BackColor = System.Drawing.Color.LightCoral;
        this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnThanhToan.Location = new System.Drawing.Point(170, 56);
        this.btnThanhToan.Name = "btnThanhToan";
        this.btnThanhToan.Size = new System.Drawing.Size(140, 38);
        this.btnThanhToan.TabIndex = 2;
        this.btnThanhToan.Text = "Thanh Toán";
        this.btnThanhToan.UseVisualStyleBackColor = false;
        this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
        // 
        // btnMoPhong
        // 
        this.btnMoPhong.BackColor = System.Drawing.Color.LightGreen;
        this.btnMoPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnMoPhong.Location = new System.Drawing.Point(15, 56);
        this.btnMoPhong.Name = "btnMoPhong";
        this.btnMoPhong.Size = new System.Drawing.Size(140, 38);
        this.btnMoPhong.TabIndex = 1;
        this.btnMoPhong.Text = "Mở Phòng";
        this.btnMoPhong.UseVisualStyleBackColor = false;
        this.btnMoPhong.Click += new System.EventHandler(this.btnMoPhong_Click);
        // 
        // lblThongTinPhong
        // 
        this.lblThongTinPhong.AutoSize = true;
        this.lblThongTinPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblThongTinPhong.ForeColor = System.Drawing.Color.DarkBlue;
        this.lblThongTinPhong.Location = new System.Drawing.Point(15, 25);
        this.lblThongTinPhong.Name = "lblThongTinPhong";
        this.lblThongTinPhong.Size = new System.Drawing.Size(201, 19);
        this.lblThongTinPhong.TabIndex = 0;
        this.lblThongTinPhong.Text = "Chọn một phòng để thao tác...";
        // 
        // grpDichVu
        // 
        this.grpDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpDichVu.Controls.Add(this.dgvChiTietDichVu);
        this.grpDichVu.Controls.Add(this.btnThemDV);
        this.grpDichVu.Controls.Add(this.nudSoLuong);
        this.grpDichVu.Controls.Add(this.label2);
        this.grpDichVu.Controls.Add(this.cboDichVu);
        this.grpDichVu.Controls.Add(this.label1);
        this.grpDichVu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.grpDichVu.Location = new System.Drawing.Point(365, 125);
        this.grpDichVu.Name = "grpDichVu";
        this.grpDichVu.Size = new System.Drawing.Size(567, 447);
        this.grpDichVu.TabIndex = 2;
        this.grpDichVu.TabStop = false;
        this.grpDichVu.Text = "Gọi Dịch Vụ / Nước Uống";
        // 
        // dgvChiTietDichVu
        // 
        this.dgvChiTietDichVu.AllowUserToAddRows = false;
        this.dgvChiTietDichVu.AllowUserToDeleteRows = false;
        this.dgvChiTietDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.dgvChiTietDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvChiTietDichVu.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
        this.dgvChiTietDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvChiTietDichVu.Location = new System.Drawing.Point(15, 75);
        this.dgvChiTietDichVu.MultiSelect = false;
        this.dgvChiTietDichVu.Name = "dgvChiTietDichVu";
        this.dgvChiTietDichVu.ReadOnly = true;
        this.dgvChiTietDichVu.RowHeadersVisible = false;
        this.dgvChiTietDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvChiTietDichVu.Size = new System.Drawing.Size(537, 355);
        this.dgvChiTietDichVu.TabIndex = 5;
        // 
        // btnThemDV
        // 
        this.btnThemDV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnThemDV.Location = new System.Drawing.Point(423, 26);
        this.btnThemDV.Name = "btnThemDV";
        this.btnThemDV.Size = new System.Drawing.Size(129, 32);
        this.btnThemDV.TabIndex = 4;
        this.btnThemDV.Text = "+ Thêm dịch vụ";
        this.btnThemDV.UseVisualStyleBackColor = true;
        this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
        // 
        // nudSoLuong
        // 
        this.nudSoLuong.Location = new System.Drawing.Point(344, 30);
        this.nudSoLuong.Minimum = new decimal(new int[] {
        1,
        0,
        0,
        0});
        this.nudSoLuong.Name = "nudSoLuong";
        this.nudSoLuong.Size = new System.Drawing.Size(65, 24);
        this.nudSoLuong.TabIndex = 3;
        this.nudSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.nudSoLuong.Value = new decimal(new int[] {
        1,
        0,
        0,
        0});
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(275, 33);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(64, 17);
        this.label2.TabIndex = 2;
        this.label2.Text = "Số lượng:";
        // 
        // cboDichVu
        // 
        this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboDichVu.FormattingEnabled = true;
        this.cboDichVu.Location = new System.Drawing.Point(74, 30);
        this.cboDichVu.Name = "cboDichVu";
        this.cboDichVu.Size = new System.Drawing.Size(185, 25);
        this.cboDichVu.TabIndex = 1;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(15, 33);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(53, 17);
        this.label1.TabIndex = 0;
        this.label1.Text = "Dịch vụ:";
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(944, 584);
        this.Controls.Add(this.grpDichVu);
        this.Controls.Add(this.grpChucNang);
        this.Controls.Add(this.flpPhongHat);
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Hệ Thống Quản Lý Đặt Phòng & Dịch Vụ Karaoke";
        this.Load += new System.EventHandler(this.Form1_Load);
        this.grpChucNang.ResumeLayout(false);
        this.grpChucNang.PerformLayout();
        this.grpDichVu.ResumeLayout(false);
        this.grpDichVu.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDichVu)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel flpPhongHat;
    private System.Windows.Forms.GroupBox grpChucNang;
    private System.Windows.Forms.Button btnThanhToan;
    private System.Windows.Forms.Button btnMoPhong;
    private System.Windows.Forms.Label lblThongTinPhong;
    private System.Windows.Forms.GroupBox grpDichVu;
    private System.Windows.Forms.DataGridView dgvChiTietDichVu;
    private System.Windows.Forms.Button btnThemDV;
    private System.Windows.Forms.NumericUpDown nudSoLuong;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cboDichVu;
    private System.Windows.Forms.Label label1;
}