CREATE TABLE PhongHat (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(50) NOT NULL,
    LoaiPhong NVARCHAR(30),
    GiaTheoGio DECIMAL(18,2),
    TrangThai NVARCHAR(20) DEFAULT N'Trống' -- 'Trống' hoặc 'Đang hát'
);

CREATE TABLE DichVu (
    MaDV INT IDENTITY(1,1) PRIMARY KEY,
    TenDV NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2),
    TonKho INT DEFAULT 0
);

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong INT FOREIGN KEY REFERENCES PhongHat(MaPhong),
    GioVao DATETIME NOT NULL,
    GioRa DATETIME NULL,
    TongTienPhong DECIMAL(18,2) DEFAULT 0,
    TongTienDichVu DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán
);

CREATE TABLE ChiTietDichVu (
    MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV),
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2),
    PRIMARY KEY (MaHD, MaDV)
);

-- Thêm dữ liệu mẫu
INSERT INTO PhongHat (TenPhong, LoaiPhong, GiaTheoGio, TrangThai) VALUES
(N'Phòng Thường 101', N'Thường', 80000, N'Trống'),
(N'Phòng Thường 102', N'Thường', 80000, N'Trống'),
(N'Phòng VIP 201', N'VIP', 150000, N'Trống'),
(N'Phòng VIP 202', N'VIP', 150000, N'Trống');

INSERT INTO DichVu (TenDV, DonGia, TonKho) VALUES
(N'Bia Heineken', 25000, 100),
(N'Nước ngọt lon', 15000, 50),
(N'Trái cây dĩa', 80000, 20),
(N'Khăn lạnh', 5000, 200);