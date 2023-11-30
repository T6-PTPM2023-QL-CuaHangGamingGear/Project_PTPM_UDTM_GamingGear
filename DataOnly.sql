USE [QL_GAMING_GEAR]
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [DiaChi]) VALUES (N'NSX01', N'SAMSUNG', N'Thái Nguyên')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [DiaChi]) VALUES (N'NSX02', N'LG', N'Hà Nội')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [DiaChi]) VALUES (N'NSX03', N'HyperX', N'TP.HCM')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [DiaChi]) VALUES (N'NSX04', N'Logitech', N'TP.HCM')
GO
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (N'LSP01', N'Bàn phím')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (N'LSP02', N'Tai nghe')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (N'LSP03', N'Chuột')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (N'LSP04', N'Màn hình')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MaLSP], [MaNSX], [DonGia], [SoLuong], [HinhAnh], [ThongTin]) 
	VALUES (N'SP001', N'HyperX Cloud Earbuds 2', N'LSP02', N'NSX03', 990000, 5, N'https://images.tokopedia.net/img/cache/700/VqbcmM/2023/5/25/8056864d-288f-483d-9906-cad7a06c0e87.jpg', N'Hãng sản xuất : HP HyperX Tình trạng : 100% Bảo hành : 24 tháng ')
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [Email], [NgaySinh], [MatKhau], [DiaChi], [TinhTrang]) VALUES (N'KH001', N'Lâm Gia Huy', N'0981235128', N'giahuylam@gmail.com', CAST(N'1986-12-12T00:00:00' AS SmallDateTime), N'123123', N'TP.HCM', N'Hoạt động')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [SDT], [NgaySinh], [MatKhau], [ChucVu], [TinhTrang]) VALUES (N'NV001', N'Vũ Ngọc Hoàng Cung', N'Nam', N'0869612313', CAST(N'2001-12-22T00:00:00' AS SmallDateTime), N'123123', N'Nhân viên', N'Đi làm')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [GioiTinh], [SDT], [NgaySinh], [MatKhau], [ChucVu], [TinhTrang]) VALUES (N'NV002', N'Chung Đặng Mạnh Đạt', N'Nam', N'0987654321', CAST(N'2002-06-18T00:00:00' AS SmallDateTime), N'123123', N'Nhân viên', N'Đi làm')
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongGiaTri]) VALUES (N'HD001', CAST(N'2023-09-11T00:00:00.000' AS DateTime), N'NV001', N'KH001', 990000)
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [TenSP], [DonGia], [SoLuong]) VALUES (N'HD001', N'SP001', N'HyperX Cloud Earbuds 2', 990000, 1)
GO
