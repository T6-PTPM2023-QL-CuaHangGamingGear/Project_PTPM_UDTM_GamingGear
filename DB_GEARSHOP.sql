CREATE DATABASE DB_GEARSHOP;
GO

USE DB_GEARSHOP;
GO

CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(50),
    CCCD NVARCHAR(13),
    DiaChi NVARCHAR(50),
    DienThoai NVARCHAR(11),
    ChucVu NVARCHAR(40),
    MatKhau NVARCHAR(10),
    GhiChu NVARCHAR(100)
);

CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(50),
    DiaChi NVARCHAR(50),
    DienThoai NVARCHAR(11),
    Email NVARCHAR(50),
    MatKhau NVARCHAR(10),
    GhiChu NVARCHAR(100)
);

CREATE TABLE NhaCungCap (
    MaNCC INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(50),
    DiaChi NVARCHAR(50),
    DienThoai NVARCHAR(11),
    GhiChu NVARCHAR(100)
);

CREATE TABLE PhieuNhap (
    MaPN INT IDENTITY(1,1) PRIMARY KEY,
    MaNCC INT,
    MaNV INT,
    NgayNhap DATE NOT NULL DEFAULT GETDATE(),
    TongTienPN MONEY DEFAULT 0,
    GhiChu NVARCHAR(100),
    CONSTRAINT FK_PhieuNhap_NhaCungCap FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
    CONSTRAINT FK_PhieuNhap_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE LoaiSP (
    MaLoaiSP INT IDENTITY(1,1) PRIMARY KEY,
    TenLoaiSP NVARCHAR(50) CONSTRAINT UNIQUE_TenLoaiSP UNIQUE (TenLoaiSP)
);

CREATE TABLE HangSX (
    MaHangSX INT IDENTITY(1,1) PRIMARY KEY,
    TenHangSX NVARCHAR(50) CONSTRAINT UNIQUE_TenHang UNIQUE (TenHangSX)

);

CREATE TABLE SanPham (
    MaSP INT IDENTITY(1,1) PRIMARY KEY,
    TenSP NVARCHAR(50),
    MaLoaiSP INT,
    MaHangSX INT,
    HinhAnh NVARCHAR(MAX),
    GiaSP MONEY DEFAULT 0,
    SoLuong INT,
    MoTa NVARCHAR(300),
    CONSTRAINT FK_SanPham_LoaiSP FOREIGN KEY (MaLoaiSP) REFERENCES LoaiSP(MaLoaiSP),
    CONSTRAINT FK_SanPham_HangSX FOREIGN KEY (MaHangSX) REFERENCES HangSX(MaHangSX)
);

CREATE TABLE ChiTietPhieuNhap (
    MaPN INT,
    MaSP INT,
    SoLuongSP INT,
    GiaNhapSP DECIMAL (18, 2) NOT NULL,
    TongTienNhapSP MONEY DEFAULT 0,
    GhiChu NVARCHAR(100),
    CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaPN, MaSP),
    CONSTRAINT FK_ChiTietPhieuNhap_PhieuNhap FOREIGN KEY (MaPN) REFERENCES PhieuNhap(MaPN),
    CONSTRAINT FK_ChiTietPhieuNhap_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

CREATE TABLE DonHang (
    MaDH INT IDENTITY(1,1) PRIMARY KEY,
    MaGiaoDich NVARCHAR(15),
    MaSP INT,
    SoLuongSP INT,
    GiaSP DECIMAL (18, 2),
    ThanhTien MONEY DEFAULT 0,
    MaKH INT,
    TenNVPT NVARCHAR(50) NOT NULL,
    GhiChu NVARCHAR(100),
    CONSTRAINT FK_DonHang_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    CONSTRAINT FK_DonHang_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

--Trigger--
--Tính thành tiền khi nhập liệu vào DonHang--
GO
CREATE TRIGGER ThanhTien_DH ON DonHang
FOR INSERT, UPDATE
AS
	UPDATE DonHang
	SET ThanhTien = (SELECT SoLuongSP * GiaSP)
GO

--Các hành động khi thêm sản phẩm vào ChiTietPhieuNhap--
CREATE TRIGGER Them_CTPN ON ChiTietPhieuNhap
AFTER INSERT
AS
	--Tính tổng tiền nhập của 1 sản phẩm--
	UPDATE ChiTietPhieuNhap
	SET TongTienNhapSP = (SELECT SoLuongSP * GiaNhapSP)

	--Cập nhật số lượng của bảng Sản Phẩm = 0 khi nó == null--
	UPDATE SanPham
	SET SoLuong = 0
	WHERE SoLuong IS NULL

	--Cập nhật lại tổng tiền phiếu nhập của bảng Phiếu Nhập =0 khi nó bằng null--
	UPDATE PhieuNhap
	SET TongTienPN = 0
	WHERE TongTienPN IS NULL

	--Cập nhật số lượng trong bảng Sản Phẩm bằng số lượng hiện tại + số lượng vừa nhập vào ChiTietPhieuNhap(SoLuongSP)
	UPDATE SanPham
	SET SoLuong = SoLuong + (SELECT SoLuongSP FROM inserted)
	WHERE SanPham.MaSP = (SELECT MaSP FROM inserted)

	--Cập nhật tổng tiền phiếu nhập bằng tổng tiền hiện tại + tiền vừa nhập vào ChiTietPhieuNhap--
	UPDATE PhieuNhap
	SET TongTienPN = TongTienPN + (SELECT SoLuongSP * GiaNhapSP FROM inserted)
	WHERE PhieuNhap.MaPN = (SELECT MaPN FROM inserted)
GO

--Các hành động khi xóa sản phẩm khỏi ChiTietPhieuNhap--
CREATE TRIGGER Xoa_CTPN ON ChiTietPhieuNhap
FOR DELETE
AS
	--Cập nhật số lượng của bảng Sản Phẩm = 0 khi nó == null--
	UPDATE SanPham
	SET SoLuong = 0
	WHERE SoLuong IS NULL

	--Cập nhật lại tổng tiền phiếu nhập của bảng Phiếu Nhập =0 khi nó bằng null--
	UPDATE PhieuNhap
	SET TongTienPN = 0
	WHERE TongTienPN IS NULL

	--Cập nhật số lượng trong bảng Sản Phẩm bằng số lượng hiện tại - số lượng vừa nhập vào ChiTietPhieuNhap(SoLuongSP)
	UPDATE SanPham 
	SET SoLuong = SoLuong - (SELECT SUM(SoLuongSP) FROM deleted)
	WHERE SanPham.MaSP = (SELECT MaSP FROM deleted)

	--Cập nhật tổng tiền phiếu nhập bằng tổng tiền hiện tại - tiền vừa nhập vào ChiTietPhieuNhap--
	UPDATE PhieuNhap
	SET TongTienPN = TongTienPN - (SELECT SoLuongSP * GiaNhapSP FROM deleted)
	WHERE PhieuNhap.MaPN = (SELECT MaPN FROM deleted)
GO

--Cập nhật số lượng mua của mỗi sản phẩm khi chọn giống nhau trong bảng DonHang--
CREATE TRIGGER CN_SLSP_DonHang ON DonHang
AFTER INSERT
AS
	/*Sau khi nhập 1 dòng dữ liệu nếu xuất hiện trên 1 dòng dữ liệu giống nhau*/
	/*Trigger sẽ Update soluongSP của DonHang có masp và magiaodich giống với masp và magiaodich vừa nhập*/
	IF(SELECT COUNT(*) FROM DonHang WHERE MaSP = (SELECT MaSP FROM inserted) and MaGiaoDich = (SELECT MaGiaoDich FROM inserted)) > 1
		UPDATE DonHang
		SET SoLuongSP = SoLuongSP + (SELECT SoLuongSP FROM inserted) --SoLuongPS ?--
		WHERE MaSP = (SELECT MaSP FROM inserted) AND MaGiaoDich = (SELECT MaGiaoDich FROM inserted)
	--Xóa những dòng đơn hàng trùng--
	DELETE FROM DonHang
	WHERE MaDH IN (SELECT TOP((SELECT COUNT(*) FROM DonHang WHERE MaSP = (SELECT MaSP FROM inserted) and MaGiaoDich = (SELECT MaGiaoDich FROM inserted)) - 1) MaDH
	FROM DonHang
	WHERE MaDH = (SELECT MaSP FROM inserted) AND MaGiaoDich = (SELECT MaGiaoDich FROM inserted) ORDER BY SoLuongSP) --SoLuongSP ?--
GO

--Show tất cả các trigger đã chạy trên database--
SELECT 
    name AS TriggerName,
    OBJECT_NAME(parent_id) AS TableName,
    create_date AS CreatedDate
FROM 
    sys.triggers;


--Procedure--

--PhieuNhap vs ChiTietPhieuNhap--

--Thủ tục khi thêm dữ liệu vào ChiTietPhieuNhap--
GO
CREATE PROC PRO_Them_CTPN @mapn int, @masp int, @slsp int, @gnsp money
AS
	INSERT INTO ChiTietPhieuNhap(MaPN, MaSP, SoLuongSP, GiaNhapSP)
	VALUES (@mapn, @masp, @slsp, @gnsp)
GO


--Thủ tục thêm phiếu nhập--
CREATE PROC PRO_Them_PN @mapn int, @mancc int, @manv int
AS
	INSERT INTO PhieuNhap(MaPN, MaNCC, MaNV)
	VALUES(@mapn, @mancc, @manv)
GO

--Thủ tục xóa phiếu nhập--
CREATE PROC PRO_Xoa_PN @mapn int
AS
	DELETE FROM ChiTietPhieuNhap WHERE MaPN = @mapn
	DELETE FROM PhieuNhap WHERE MaPN = @mapn
GO

--Thủ tục xóa chi tiết phiếu nhập--
CREATE PROC PRO_Xoa_CTPN @mapn int, @masp int
AS
	DELETE FROM ChiTietPhieuNhap WHERE MaPN = @mapn AND MaSP = @masp
GO

--SanPham--
--Thủ tục sửa sản phẩm--
CREATE PROC PRO_Sua_SP @masp int, @tensp nvarchar(50), @mlsp int, @mhsx int, @hinhanh nvarchar(max), @sl int, @gsp money
AS
	UPDATE SanPham
	SET TenSP = @tensp, MaLoaiSP = @mlsp, MaHangSX = @mhsx, SoLuong = @sl
	WHERE MaSP = @masp

	UPDATE DonHang
	SET GiaSP = @gsp
	WHERE masp = @masp
GO

--Thủ tục xóa sản phẩm--
CREATE PROC PRO_Xoa_SP @masp int
AS
	If (SELECT COUNT(*) FROM ChiTietPhieuNhap WHERE MaSP = @masp) > 0
		COMMIT TRAN
	Else
		DELETE FROM DonHang WHERE MaSP = @masp
		DELETE FROM SanPham WHERE MaSP = @masp
GO

--Show bill (chi tiết những sản phẩm đã chọn mua)--
CREATE PROC PRO_ShowBill @magiaodich nvarchar(15)
AS
	If (SELECT TOP(1) MaKH FROM DonHang WHERE MaGiaoDich LIKE @magiaodich) IS NULL
		SELECT DISTINCT MaDH, dh.MaSP, TenSP, SoLuongSP, dh.GiaSP, ThanhTien, 'tenkh' = NULL, TenNVPT
		FROM DonHang dh, KhachHang kh, SanPham sp
		WHERE sp.MaSP = dh.MaSP AND MaGiaoDich LIKE @magiaodich
	Else
		SELECT MaDH, dh.MaSP, TenSP, SoLuongSP, dh.GiaSP, ThanhTien,kh.TenKH, TenNVPT
		FROM DonHang dh, KhachHang kh, SanPham sp
		WHERE kh.MaKH = dh.MaKH AND sp.MaSP = dh.MaSP AND MaGiaoDich LIKE @magiaodich
GO


