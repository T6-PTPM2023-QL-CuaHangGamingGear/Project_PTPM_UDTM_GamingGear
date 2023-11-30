--------------------------------------------------------------------------------------------------------------------
CREATE DATABASE QL_GAMING_GEAR
GO
USE QL_GAMING_GEAR
GO
SET DATEFORMAT DMY
GO
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE NhaSanXuat
(
	MaNSX CHAR(5) NOT NULL UNIQUE,
	TenNSX NVARCHAR(30) NOT NULL,
	DiaChi NVARCHAR(30) NOT NULL,
)
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE LoaiSanPham
(
	MaLSP CHAR(5) NOT NULL UNIQUE,
	TenLSP NVARCHAR(30) NOT NULL
)
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE SanPham
(
	MaSP CHAR(5) NOT NULL UNIQUE,
	TenSP NVARCHAR(50) NOT NULL,
	MaLSP CHAR(5) NOT NULL,
	MaNSX CHAR(5) NOT NULL UNIQUE,
	DonGia INT NOT NULL,
	SoLuong INT NOT NULL,
	HinhAnh CHAR(100) NOT NULL,
	ThongTin NVARCHAR(200) NOT NULL
)
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE KhachHang
(
	MaKH CHAR(5) NOT NULL UNIQUE,
	TenKH NVARCHAR(50) NOT NULL,
	SDT CHAR(10) NOT NULL UNIQUE,
	Email VARCHAR(50),
	NgaySinh SMALLDATETIME,
	MatKhau VARCHAR(20),
	DiaChi NVARCHAR(30) NOT NULL,
	TinhTrang NVARCHAR(10)
)
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE NhanVien
(
	MaNV CHAR(5) NOT NULL UNIQUE,
	TenNV NVARCHAR(50) NOT NULL,
	GioiTinh NVARCHAR(3),
	SDT CHAR(10) NOT NULL UNIQUE,
	NgaySinh SMALLDATETIME,
	MatKhau VARCHAR(20),
	ChucVu NVARCHAR(20),
	TinhTrang NVARCHAR(10)
)
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE GioHang
(
	MaGioHang CHAR(5) NOT NULL UNIQUE,
	MaKH CHAR(5) NOT NULL UNIQUE,
	MaSP CHAR(5) NOT NULL UNIQUE,
	TenSP NVARCHAR(50) NOT NULL UNIQUE,
	DonGia INT NOT NULL,
	SoLuong INT NOT NULL
)
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE DonHang
(
	MaDonHang CHAR(5) NOT NULL UNIQUE,
	MaGioHang CHAR(5) NOT NULL UNIQUE,
	NgayDatHang DATETIME,
)
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE HoaDon
(
	MaHD CHAR(5) NOT NULL UNIQUE,
	NgayLap DATETIME,
	MaNV CHAR(5) NOT NULL,
	MaKH CHAR(5) NOT NULL,
	TongGiaTri FLOAT,
)
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE ChiTietHoaDon
(
	MaHD CHAR(5) NOT NULL UNIQUE,
	MaSP CHAR(5) NOT NULL UNIQUE,
	TenSP NVARCHAR(50) NOT NULL UNIQUE,
	DonGia INT NOT NULL,
	SoLuong INT NOT NULL
)
--------------------------------------------------------------------------------------------------------------------
CREATE TABLE DanhGia
(
	MaDG CHAR(5) NOT NULL UNIQUE,
	MaSP CHAR(5) NOT NULL,
	MaKH CHAR(5) NOT NULL,
	SaoDanhGia INT NOT NULL,
	BinhLuan NVARCHAR(50) NOT NULL
)
--------------------------------------------------------------------------------------------------------------------
--Khoa chinh
ALTER TABLE NhaSanXuat ADD CONSTRAINT PK_NhaSanXuat PRIMARY KEY(MaNSX)
ALTER TABLE LoaiSanPham ADD CONSTRAINT PK_LoaiSanPham PRIMARY KEY(MaLSP)
ALTER TABLE SanPham ADD CONSTRAINT PK_SanPham PRIMARY KEY(MaSP)
ALTER TABLE KhachHang ADD CONSTRAINT PK_KhachHang PRIMARY KEY(MaKH)
ALTER TABLE NhanVien ADD CONSTRAINT PK_NhanVien PRIMARY KEY(MaNV)
ALTER TABLE GioHang ADD CONSTRAINT PK_GioHang PRIMARY KEY(MaKH)
ALTER TABLE DonHang ADD CONSTRAINT PK_DonHang PRIMARY KEY(MaDonHang)
ALTER TABLE HoaDon ADD CONSTRAINT PK_HoaDon PRIMARY KEY(MaHD)
ALTER TABLE ChiTietHoaDon ADD CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY(MaHD)
ALTER TABLE DanhGia ADD CONSTRAINT PK_DanhGia PRIMARY KEY(MaDG)
--------------------------------------------------------------------------------------------------------------------
--Khoa ngoai
ALTER TABLE SanPham ADD CONSTRAINT FK_SanPham_NhaSanXuat FOREIGN KEY(MaNSX) REFERENCES NhaSanXuat(MaNSX)
ALTER TABLE SanPham ADD CONSTRAINT FK_SanPham_LoaiSanPham FOREIGN KEY(MaLSP) REFERENCES LoaiSanPham(MaLSP)
ALTER TABLE GioHang ADD CONSTRAINT FK_GioHang_SanPham FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP)
ALTER TABLE GioHang ADD CONSTRAINT FK_GioHang_KhachHang FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH)
ALTER TABLE DonHang ADD CONSTRAINT FK_DonHang_GioHang FOREIGN KEY(MaGioHang) REFERENCES GioHang(MaGioHang)
ALTER TABLE HoaDon ADD CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH)
ALTER TABLE HoaDon ADD CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
ALTER TABLE ChiTietHoaDon ADD CONSTRAINT FK_ChiTietHoaDon_SanPham FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP)
ALTER TABLE ChiTietHoaDon ADD CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY(MaHD) REFERENCES HoaDon(MaHD)
ALTER TABLE DanhGia ADD CONSTRAINT FK_DanhGia_SanPham FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP)
ALTER TABLE DanhGia ADD CONSTRAINT FK_DanhGia_KhachHang FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH)
--------------------------------------------------------------------------------------------------------------------
GO
--------------------------------------------------------------------------------------------------------------------
--TRIGGER
--Tạo MaNSX tự tăng
CREATE TRIGGER InsertMaNSX
ON NhaSanXuat
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaxMaNSX INT;

    SELECT @MaxMaNSX = COALESCE(MAX(CAST(SUBSTRING(MaNSX, 4, 2) AS INT)), 0)
    FROM NhaSanXuat;

    INSERT INTO NhaSanXuat (MaNSX, TenNSX, DiaChi)
    SELECT 'NSX' + RIGHT('00' + CAST(@MaxMaNSX + ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(2)), 2),
           TenNSX,
           DiaChi
    FROM inserted;
END;

GO
--------------------------------------------------------------------------------------------------------------------
--Tạo MaLSP tự tăng
CREATE TRIGGER InsertMaLSP
ON LoaiSanPham
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NewMaLSP CHAR(5);
    DECLARE @MaxMaLSP INT;

    SELECT @MaxMaLSP = COALESCE(MAX(CAST(SUBSTRING(MaLSP, 4, 2) AS INT)), 0) 
    FROM LoaiSanPham;

    SET @NewMaLSP = 'LSP' + RIGHT('00' + CAST(@MaxMaLSP + 1 AS VARCHAR(2)), 2);

    INSERT INTO LoaiSanPham (MaLSP, TenLSP)
    SELECT @NewMaLSP, TenLSP
    FROM inserted;
END;

GO
--------------------------------------------------------------------------------------------------------------------
--Tạo MaSP tự tăng
CREATE TRIGGER InsertMaSP
ON SanPham
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NewMaSP CHAR(5);
    DECLARE @MaxMaSP INT;

    SELECT @MaxMaSP = COALESCE(MAX(CAST(SUBSTRING(MaSP, 3, 3) AS INT)), 0)
    FROM SanPham;

    SET @NewMaSP = 'SP' + RIGHT('000' + CAST(@MaxMaSP + 1 AS VARCHAR(3)), 3);

    INSERT INTO SanPham (MaSP, TenSP, MaLSP, MaNSX, DonGia, SoLuong, HinhAnh, ThongTin)
    SELECT @NewMaSP, TenSP, MaLSP, MaNSX, DonGia, SoLuong, HinhAnh, ThongTin
    FROM inserted;
END;

GO
--------------------------------------------------------------------------------------------------------------------
--Tạo MaNV tự tăng
CREATE TRIGGER InsertMaNV
ON NhanVien
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NewMaNV CHAR(5);
    DECLARE @MaxMaNV INT;

    SELECT @MaxMaNV = COALESCE(MAX(CAST(SUBSTRING(MaNV, 3, 3) AS INT)), 0)
    FROM NhanVien;

    SET @NewMaNV = 'NV' + RIGHT('000' + CAST(@MaxMaNV + 1 AS VARCHAR(3)), 3);

    INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, SDT, NgaySinh, MatKhau, ChucVu, TinhTrang)
    SELECT @NewMaNV, TenNV, GioiTinh, SDT, NgaySinh, MatKhau, ChucVu, TinhTrang
    FROM inserted;
END;

GO
--------------------------------------------------------------------------------------------------------------------
--Tạo MaKH tự tăng
CREATE TRIGGER InsertMaKH
ON KhachHang
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NewMaKH CHAR(5);
    DECLARE @MaxMaKH INT;

    SELECT @MaxMaKH = COALESCE(MAX(CAST(SUBSTRING(MaKH, 3, 3) AS INT)), 0)
    FROM KhachHang;

    SET @NewMaKH = 'KH' + RIGHT('000' + CAST(@MaxMaKH + 1 AS VARCHAR(3)), 3);

    INSERT INTO KhachHang (MaKH, TenKH, SDT, Email, NgaySinh, MatKhau, DiaChi, TinhTrang)
    SELECT @NewMaKH, TenKH, SDT, Email, NgaySinh, MatKhau, DiaChi, TinhTrang
    FROM inserted;
END;

GO
--------------------------------------------------------------------------------------------------------------------
--Tạo MaGioHang tự tăng
CREATE TRIGGER InsertMaGH
ON GioHang
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NewMaGH CHAR(5);
    DECLARE @MaxMaGH INT;

    SELECT @MaxMaGH = COALESCE(MAX(CAST(SUBSTRING(MaGioHang, 3, 3) AS INT)), 0)
    FROM GioHang;

    SET @NewMaGH = 'GH' + RIGHT('000' + CAST(@MaxMaGH + 1 AS VARCHAR(3)), 3);

    INSERT INTO GioHang (MaGioHang, MaKH, MaSP, TenSP, DonGia, SoLuong)
    SELECT @NewMaGH, MaKH, MaSP, TenSP, DonGia, SoLuong
    FROM inserted;
END;

GO
--------------------------------------------------------------------------------------------------------------------
--Tạo MaHD tự tăng
CREATE TRIGGER InsertMaHD
ON HoaDon
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NewMaHD CHAR(5);
    DECLARE @MaxMaHD INT;

    SELECT @MaxMaHD = COALESCE(MAX(CAST(SUBSTRING(MaHD, 3, 3) AS INT)), 0)
    FROM HoaDon;

    SET @NewMaHD = 'HD' + RIGHT('000' + CAST(@MaxMaHD + 1 AS VARCHAR(3)), 3);

    INSERT INTO HoaDon (MaHD, NgayLap, MaNV, MaKH, TongGiaTri)
    SELECT @NewMaHD, NgayLap, MaNV, MaKH, TongGiaTri
    FROM inserted;
END;

GO
--------------------------------------------------------------------------------------------------------------------
--Tạo MaDonHang tự tăng
CREATE TRIGGER InsertMaDonHang
ON DonHang
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NewMaDonHang CHAR(5);
    DECLARE @MaxMaDonHang INT;

    SELECT @MaxMaDonHang = COALESCE(MAX(CAST(SUBSTRING(MaDonHang, 3, 3) AS INT)), 0)
    FROM DonHang;

    SET @NewMaDonHang = 'DH' + RIGHT('000' + CAST(@MaxMaDonHang + 1 AS VARCHAR(3)), 3);

    INSERT INTO DonHang (MaDonHang, MaGioHang, NgayDatHang)
    SELECT @NewMaDonHang, MaGioHang, NgayDatHang
    FROM inserted;
END;

GO
--------------------------------------------------------------------------------------------------------------------
--Tạo MaDG tự tăng
CREATE TRIGGER InsertMaDG
ON DanhGia
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NewMaDG CHAR(5);
    DECLARE @MaxMaDG INT;

    SELECT @MaxMaDG = COALESCE(MAX(CAST(SUBSTRING(MaDG, 3, 3) AS INT)), 0)
    FROM DanhGia;

    SET @NewMaDG = 'DG' + RIGHT('000' + CAST(@MaxMaDG + 1 AS VARCHAR(3)), 3);

    INSERT INTO DanhGia (MaDG, MaSP, MaKH, SaoDanhGia, BinhLuan)
    SELECT @NewMaDG, MaSP, MaKH, SaoDanhGia, BinhLuan
    FROM inserted;
END;

GO
--------------------------------------------------------------------------------------------------------------------
--DataOnly
INSERT INTO NhanVien (TenNV, GioiTinh, SDT, NgaySinh, MatKhau, ChucVu, TinhTrang)
VALUES ('Truong Canh Truong', 'Nam', '2001200696', '2002-04-14 00:00:00', 'truong', 'NV Kho', 'Con lam')

INSERT INTO NhanVien (TenNV, GioiTinh, SDT, NgaySinh, MatKhau, ChucVu, TinhTrang)
VALUES ('Vu Ngoc Hoang Cung', 'Nam', '2001206991', '2002-04-14 00:00:00', 'cung', 'NV BanHang', 'Con lam')

INSERT INTO NhanVien (TenNV, GioiTinh, SDT, NgaySinh, MatKhau, ChucVu, TinhTrang)
VALUES('Vo Nguyen Thanh Nhan', 'Nam', '2001190706', '2002-04-14 00:00:00', 'nhan', 'NV ThongKe', 'Con lam')



INSERT INTO KhachHang(TenKH, SDT, Email, NgaySinh, MatKhau, DiaChi, TinhTrang)
VALUES ('Han Ky An', '2025550193', 'johndoe@internxt.com', '1977-05-19 00:00:00', 'kyan','Tan Phu','Khach hang tiem nang')

INSERT INTO KhachHang (TenKH, SDT, Email, NgaySinh, MatKhau, DiaChi, TinhTrang)
VALUES ('Nguyen Thi Nga', '2025550167', 'jane@beaconmessenger.com', '1985-06-22 00:00:00', 'nga','Binh Chanh', 'Khach hang mua theo dip')

INSERT INTO KhachHang (TenKH, SDT, Email, NgaySinh, MatKhau, DiaChi, TinhTrang)
VALUES('Pham Van Huy', '2025550127', 'johndoe012@internxt.com', '1992-12-13 00:00:00', 'huy', 'Long An', 'Khach hang cu')