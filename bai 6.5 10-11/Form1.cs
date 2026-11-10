using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private string strCon = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KaraokeDB;Integrated Security=True";

    private int currentMaPhong = -1;
    private string currentTenPhong = "";
    private decimal currentGiaTheoGio = 0;
    private string currentTrangThai = "";
    private int currentMaHD = -1;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        LoadSoDoPhong();
        LoadDanhSachDichVu();
        ResetGiaoDienChonPhong();
    }

    private void LoadSoDoPhong()
    {
        flpPhongHat.Controls.Clear();

        using (SqlConnection con = new SqlConnection(strCon))
        {
            con.Open();
            string sql = "SELECT MaPhong, TenPhong, LoaiPhong, GiaTheoGio, TrangThai FROM PhongHat";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Button btn = new Button();
                int maPhong = (int)reader["MaPhong"];
                string tenPhong = reader["TenPhong"].ToString();
                string trangThai = reader["TrangThai"].ToString();
                decimal gia = Convert.ToDecimal(reader["GiaTheoGio"]);

                btn.Width = 145;
                btn.Height = 100;
                btn.Text = tenPhong + "\n(" + reader["LoaiPhong"] + ")\n" + trangThai;
                btn.Tag = new { MaPhong = maPhong, TenPhong = tenPhong, Gia = gia, TrangThai = trangThai };

                if (trangThai == "Trống")
                {
                    btn.BackColor = Color.LightGreen;
                }
                else
                {
                    btn.BackColor = Color.Salmon;
                }

                btn.Click += BtnPhong_Click;
                flpPhongHat.Controls.Add(btn);
            }
        }
    }

    private void BtnPhong_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        dynamic data = btn.Tag;

        currentMaPhong = data.MaPhong;
        currentTenPhong = data.TenPhong;
        currentGiaTheoGio = data.Gia;
        currentTrangThai = data.TrangThai;

        lblThongTinPhong.Text = "Đang chọn: " + currentTenPhong + " | Giá: " + currentGiaTheoGio.ToString("N0") + " đ/h | Trạng thái: " + currentTrangThai;

        if (currentTrangThai == "Trống")
        {
            btnMoPhong.Enabled = true;
            btnThanhToan.Enabled = false;
            btnThemDV.Enabled = false;
            currentMaHD = -1;
            dgvChiTietDichVu.DataSource = null;
        }
        else
        {
            btnMoPhong.Enabled = false;
            btnThanhToan.Enabled = true;
            btnThemDV.Enabled = true;

            LayMaHDHienTai(currentMaPhong);
            LoadChiTietDichVu(currentMaHD);
        }
    }

    private void LayMaHDHienTai(int maPhong)
    {
        using (SqlConnection con = new SqlConnection(strCon))
        {
            con.Open();
            string sql = "SELECT TOP 1 MaHD FROM HoaDon WHERE MaPhong = @MaPhong AND TrangThai = 0 ORDER BY MaHD DESC";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaPhong", maPhong);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                currentMaHD = Convert.ToInt32(result);
            }
        }
    }

    private void btnMoPhong_Click(object sender, EventArgs e)
    {
        if (currentMaPhong == -1) return;

        using (SqlConnection con = new SqlConnection(strCon))
        {
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                string sqlInsertHD = @"INSERT INTO HoaDon (MaPhong, GioVao, TrangThai) 
                                       VALUES (@MaPhong, GETDATE(), 0);
                                       SELECT SCOPE_IDENTITY();";
                SqlCommand cmdHD = new SqlCommand(sqlInsertHD, con, trans);
                cmdHD.Parameters.AddWithValue("@MaPhong", currentMaPhong);
                currentMaHD = Convert.ToInt32(cmdHD.ExecuteScalar());

                string sqlUpdatePhong = "UPDATE PhongHat SET TrangThai = N'Đang hát' WHERE MaPhong = @MaPhong";
                SqlCommand cmdPhong = new SqlCommand(sqlUpdatePhong, con, trans);
                cmdPhong.Parameters.AddWithValue("@MaPhong", currentMaPhong);
                cmdPhong.ExecuteNonQuery();

                trans.Commit();
                MessageBox.Show("Mở phòng " + currentTenPhong + " thành công!", "Thông báo");

                LoadSoDoPhong();
                ResetGiaoDienChonPhong();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Lỗi khi mở phòng: " + ex.Message);
            }
        }
    }

    private void LoadDanhSachDichVu()
    {
        using (SqlConnection con = new SqlConnection(strCon))
        {
            string sql = "SELECT MaDV, TenDV, DonGia, TonKho FROM DichVu";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cboDichVu.DataSource = dt;
            cboDichVu.DisplayMember = "TenDV";
            cboDichVu.ValueMember = "MaDV";
        }
    }

    private void LoadChiTietDichVu(int maHD)
    {
        using (SqlConnection con = new SqlConnection(strCon))
        {
            string sql = @"SELECT dv.TenDV AS [Tên Dịch Vụ], 
                                  ct.SoLuong AS [Số Lượng], 
                                  ct.DonGia AS [Đơn Giá], 
                                  (ct.SoLuong * ct.DonGia) AS [Thành Tiền] 
                           FROM ChiTietDichVu ct 
                           JOIN DichVu dv ON ct.MaDV = dv.MaDV 
                           WHERE ct.MaHD = @MaHD";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaHD", maHD);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvChiTietDichVu.DataSource = dt;
        }
    }

    private void btnThemDV_Click(object sender, EventArgs e)
    {
        if (currentMaHD == -1)
        {
            MessageBox.Show("Vui lòng chọn phòng đang hát!");
            return;
        }

        int maDV = Convert.ToInt32(cboDichVu.SelectedValue);
        int soLuong = (int)nudSoLuong.Value;

        using (SqlConnection con = new SqlConnection(strCon))
        {
            con.Open();

            string sqlKiemTra = "SELECT DonGia, TonKho FROM DichVu WHERE MaDV = @MaDV";
            SqlCommand cmdCheck = new SqlCommand(sqlKiemTra, con);
            cmdCheck.Parameters.AddWithValue("@MaDV", maDV);

            decimal donGia = 0;
            int tonKho = 0;
            using (SqlDataReader rd = cmdCheck.ExecuteReader())
            {
                if (rd.Read())
                {
                    donGia = Convert.ToDecimal(rd["DonGia"]);
                    tonKho = Convert.ToInt32(rd["TonKho"]);
                }
            }

            if (tonKho < soLuong)
            {
                MessageBox.Show("Kho chỉ còn " + tonKho + " sản phẩm, không đủ để gọi!", "Cảnh báo");
                return;
            }

            string sqlUpsert = @"
                IF EXISTS (SELECT 1 FROM ChiTietDichVu WHERE MaHD = @MaHD AND MaDV = @MaDV)
                    UPDATE ChiTietDichVu 
                    SET SoLuong = SoLuong + @SoLuong 
                    WHERE MaHD = @MaHD AND MaDV = @MaDV
                ELSE
                    INSERT INTO ChiTietDichVu (MaHD, MaDV, SoLuong, DonGia) 
                    VALUES (@MaHD, @MaDV, @SoLuong, @DonGia)";

            SqlCommand cmdUpsert = new SqlCommand(sqlUpsert, con);
            cmdUpsert.Parameters.AddWithValue("@MaHD", currentMaHD);
            cmdUpsert.Parameters.AddWithValue("@MaDV", maDV);
            cmdUpsert.Parameters.AddWithValue("@SoLuong", soLuong);
            cmdUpsert.Parameters.AddWithValue("@DonGia", donGia);

            cmdUpsert.ExecuteNonQuery();

            LoadChiTietDichVu(currentMaHD);
        }
    }

    private void btnThanhToan_Click(object sender, EventArgs e)
    {
        if (currentMaHD == -1 || currentMaPhong == -1) return;

        using (SqlConnection con = new SqlConnection(strCon))
        {
            con.Open();

            string sqlGetGioVao = "SELECT GioVao FROM HoaDon WHERE MaHD = @MaHD";
            SqlCommand cmdGetGio = new SqlCommand(sqlGetGioVao, con);
            cmdGetGio.Parameters.AddWithValue("@MaHD", currentMaHD);
            DateTime gioVao = Convert.ToDateTime(cmdGetGio.ExecuteScalar());
            DateTime gioRa = DateTime.Now;

            TimeSpan thoiGianHat = gioRa - gioVao;
            double soGio = Math.Max(0.05, thoiGianHat.TotalHours);
            decimal tongTienPhong = Math.Round((decimal)soGio * currentGiaTheoGio, 0);

            string sqlGetTienDV = "SELECT ISNULL(SUM(SoLuong * DonGia), 0) FROM ChiTietDichVu WHERE MaHD = @MaHD";
            SqlCommand cmdGetDV = new SqlCommand(sqlGetTienDV, con);
            cmdGetDV.Parameters.AddWithValue("@MaHD", currentMaHD);
            decimal tongTienDV = Convert.ToDecimal(cmdGetDV.ExecuteScalar());

            decimal tongCong = tongTienPhong + tongTienDV;

            string thongBao = "Phòng: " + currentTenPhong + "\n" +
                              "Thời gian hát: " + thoiGianHat.Hours + " giờ " + thoiGianHat.Minutes + " phút\n" +
                              "Tiền phòng: " + tongTienPhong.ToString("N0") + " VNĐ\n" +
                              "Tiền dịch vụ: " + tongTienDV.ToString("N0") + " VNĐ\n" +
                              "-----------------------------------\n" +
                              "TỔNG CỘNG: " + tongCong.ToString("N0") + " VNĐ\n\n" +
                              "Bạn có muốn thanh toán và trả phòng không?";

            if (MessageBox.Show(thongBao, "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            SqlTransaction trans = con.BeginTransaction();
            try
            {
                string sqlUpdateHD = @"UPDATE HoaDon 
                                       SET GioRa = @GioRa, 
                                           TongTienPhong = @TienPhong, 
                                           TongTienDichVu = @TienDV, 
                                           TrangThai = 1 
                                       WHERE MaHD = @MaHD";
                SqlCommand cmdUpdateHD = new SqlCommand(sqlUpdateHD, con, trans);
                cmdUpdateHD.Parameters.AddWithValue("@GioRa", gioRa);
                cmdUpdateHD.Parameters.AddWithValue("@TienPhong", tongTienPhong);
                cmdUpdateHD.Parameters.AddWithValue("@TienDV", tongTienDV);
                cmdUpdateHD.Parameters.AddWithValue("@MaHD", currentMaHD);
                cmdUpdateHD.ExecuteNonQuery();

                string sqlTruKho = @"
                    UPDATE dv
                    SET dv.TonKho = dv.TonKho - ct.SoLuong
                    FROM DichVu dv
                    INNER JOIN ChiTietDichVu ct ON dv.MaDV = ct.MaDV
                    WHERE ct.MaHD = @MaHD";
                SqlCommand cmdTruKho = new SqlCommand(sqlTruKho, con, trans);
                cmdTruKho.Parameters.AddWithValue("@MaHD", currentMaHD);
                cmdTruKho.ExecuteNonQuery();

                string sqlUpdatePhong = "UPDATE PhongHat SET TrangThai = N'Trống' WHERE MaPhong = @MaPhong";
                SqlCommand cmdUpdatePhong = new SqlCommand(sqlUpdatePhong, con, trans);
                cmdUpdatePhong.Parameters.AddWithValue("@MaPhong", currentMaPhong);
                cmdUpdatePhong.ExecuteNonQuery();

                trans.Commit();
                MessageBox.Show("Thanh toán thành công!", "Thông báo");

                LoadSoDoPhong();
                ResetGiaoDienChonPhong();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Lỗi thanh toán (Đã rollback): " + ex.Message, "Lỗi");
            }
        }
    }

    private void ResetGiaoDienChonPhong()
    {
        currentMaPhong = -1;
        currentMaHD = -1;
        lblThongTinPhong.Text = "Chọn một phòng để thao tác...";
        btnMoPhong.Enabled = false;
        btnThanhToan.Enabled = false;
        btnThemDV.Enabled = false;
        dgvChiTietDichVu.DataSource = null;
    }
}