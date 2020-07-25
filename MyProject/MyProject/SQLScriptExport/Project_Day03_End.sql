USE [MyProjectMay2020]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/25/2020 5:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 7/25/2020 5:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaCtDh] [int] IDENTITY(1,1) NOT NULL,
	[MaDonHang] [bigint] NOT NULL,
	[MaHangHoa] [uniqueidentifier] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[MaCtDh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 7/25/2020 5:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaHoaDon] [bigint] IDENTITY(1,1) NOT NULL,
	[NgayDat] [datetime2](7) NOT NULL,
	[NgayGiao] [datetime2](7) NULL,
	[TrangThaiDatHang] [int] NOT NULL,
	[PhuongThucThanhToan] [int] NOT NULL,
	[MaKH] [nvarchar](450) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 7/25/2020 5:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[Id] [uniqueidentifier] NOT NULL,
	[MaHH] [nvarchar](10) NULL,
	[TenHH] [nvarchar](100) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
	[MoTa] [nvarchar](200) NULL,
	[Hinh] [nvarchar](150) NULL,
	[ChiTiet] [nvarchar](max) NULL,
	[GiamGia] [tinyint] NOT NULL,
	[MaLoai] [int] NULL,
 CONSTRAINT [PK_HangHoa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hinhs]    Script Date: 7/25/2020 5:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hinhs](
	[Id] [uniqueidentifier] NOT NULL,
	[Url] [nvarchar](max) NULL,
	[LoaiHinh] [int] NOT NULL,
	[MaLoai] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Hinhs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/25/2020 5:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nvarchar](450) NOT NULL,
	[TenKhachHang] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[DienThoai] [nvarchar](max) NULL,
	[MatKhau] [nvarchar](max) NULL,
	[RandomKey] [nvarchar](max) NULL,
	[TrangThai] [bit] NOT NULL,
	[VaiTro] [int] NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loai]    Script Date: 7/25/2020 5:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NOT NULL,
	[MaLoaiCha] [int] NULL,
 CONSTRAINT [PK_Loai] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200718080714_Init_DB', N'3.1.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200725065816_Add_Customer_Order', N'3.1.6')
INSERT [dbo].[HangHoa] ([Id], [MaHH], [TenHH], [SoLuong], [DonGia], [MoTa], [Hinh], [ChiTiet], [GiamGia], [MaLoai]) VALUES (N'9e6549b0-9da9-4654-9392-39780749f5df', N'KS003', N'Đồng hồ Nữ Korlex', 12, 1590000, N'Bảo hành chính hãng 12 tháng.
1 đổi 1 trong 1 tháng với sản phẩm lỗi. Xem chi tiết
Bảo hành pin trọn đời', N'korlex-ks003-02-nu-1-3-600x600.jpg', NULL, 2, 10)
INSERT [dbo].[HangHoa] ([Id], [MaHH], [TenHH], [SoLuong], [DonGia], [MoTa], [Hinh], [ChiTiet], [GiamGia], [MaLoai]) VALUES (N'dd67033a-9794-4430-9659-5b5f89bc71d7', N'20R30025VA', N'Laptop Lenovo ThinkPad L13', 23, 24990000, N'ntel Core i7-10510U 1.80 GHz up to 4.90 GHz, 8MB
RAM: 8GB DDR4 2666MHz
Ổ đĩa cứng: 256GB SSD', N'570x470_Lenovo-ThinkPad-L13-2 (1).jpg', N'Hệ điều hành	
Free Dos
Bộ vi xử lý	
Intel Core i7-10510U  1.80 GHz up to  4.90 GHz, 8MB
Bộ nhớ Ram	
8GB DDR4 2666MHz
Ổ đĩa cứng	
256GB SSD
Màn hình	
13.3"FHD IPS
Đồ họa	
Intel UHD Graphics 620
Camera	
720p HD Camera with ThinkShutter privacy cover
Âm thanh	
Dolby Audio Premium
Cổng giao tiếp	
2 x USB 3.1 Gen 1 2 x USB-C microSD card reader
Cổng xuất hình	
1 x HDMI 1.4
Pin (Battery)	
4 Cell Li-Ion Polymer Internal Battery, 46Wh
Phụ kiện kèm theo	
Full box
Bluetooth	
BT5.0
Wifi	
Intel WiFi 6 AX201
Kích thước	
311.5mm x 219mm x 17.6mm
Khối lượng	
1.38kg
Bảo mật	
Fingerprint
Bảo hành	
36 tháng
Hãng sản xuất	
Lenovo', 0, 4)
INSERT [dbo].[HangHoa] ([Id], [MaHH], [TenHH], [SoLuong], [DonGia], [MoTa], [Hinh], [ChiTiet], [GiamGia], [MaLoai]) VALUES (N'58b97d6b-8b4c-4e55-96b2-677ef7f6e347', N'DT-OP-001', N'OPPO A92', 11, 6490000, NULL, N'oppo-a92-tim.png', NULL, 0, 2)
INSERT [dbo].[HangHoa] ([Id], [MaHH], [TenHH], [SoLuong], [DonGia], [MoTa], [Hinh], [ChiTiet], [GiamGia], [MaLoai]) VALUES (N'e7c3b43b-8bb8-4bbe-a0d0-9fec52dc1f29', N'DT-001', N'iPhone 11 128GB', 0, 22999000, N'Màn hình:	IPS LCD, 6.1", Liquid Retina
Hệ điều hành:	iOS 13
Camera sau:	Chính 12 MP & Phụ 12 MP
Camera trước:	12 MP
CPU:	Apple A13 Bionic 6 nhân
RAM:	4 GB
Bộ nhớ trong:	128 GB', N'iphone-11-128gb-green-400x460.png', N'Được xem là phiên bản iPhone "giá rẻ" trong bộ 3 iPhone mới ra mắt nhưng iPhone 11 128GB vẫn sở hữu cho mình rất nhiều ưu điểm mà hiếm có một chiếc smartphone nào khác sở hữu.
Nâng cấp mạnh mẽ về cụm camera
Năm nay với iPhone 11 thì Apple đã nâng cấp khá nhiều về camera nếu so sánh với chiếc iPhone Xr 128GB năm ngoái.

Điện thoại iPhone 11 128GB | Cụm camera kép phía sau

Chúng ta đã có bộ đôi camera kép thay vì camera đơn như trên thế hệ cũ và với một camera góc siêu rộng thì bạn cũng có nhiều hơn những lựa chọn khi chụp hình.

Điện thoại iPhone 11 128GB | Giao diện chụp ảnh

Trước đây để lấy được hết kiến trúc của một tòa nhà, để ghi lại hết sự hùng vĩ của một ngọn núi thì không còn cách nào khác là bạn phải di chuyển ra khá xa để chụp.

Điện thoại iPhone 11 128GB | Ảnh chụp góc siêu rộng

Ảnh chụp chế độ góc siêu rộng

Nhưng với góc siêu rộng trên iPhone 11 thì có thể cho bạn những bức ảnh với hiệu ứng góc rộng rất ấn tượng và thích mắt.

Điện thoại iPhone 11 128GB | Ảnh chụp chế độ chân dung

Ảnh camera chế độ chân dung

Bên cạnh đó là tính năng Deep Fusion được quảng cáo là cơ chế chụp hình mới, đem lại hình ảnh với độ chi tiết cao, dải tần nhạy sáng rộng và rất ít bị nhiễu.

Điện thoại iPhone 11 128GB | Ảnh chụp đủ sáng

Một bức ảnh chụp đủ sáng trên iPhone 11

Cụ thể, khi người dùng bấm nút chụp, thiết bị sẽ thực hiện tổng cộng 9 bức hình cùng lúc, gồm một tấm chính và tám tấm phụ, sau đó chọn ra các điểm ảnh tốt nhất để đưa vào tấm ảnh cuối cùng nhằm cải thiện chi tiết và khử nhiễu.

Điện thoại iPhone 11 128GB | Ảnh chụp chế độ bình thường

Quả bóng qua ống kính chế độ bình thường của iPhone 11

Và điều được người dùng mong chờ nhất chính là tính năng chụp đêm cũng xuất hiện trên chiếc iPhone mới này với tên gọi Night Mode.

Điện thoại iPhone 11 128GB | Ảnh chụp chế độ Night Mode

Ảnh chụp với chế độ Night Mode

Xem thêm: Đánh giá chi tiết iPhone 11: Hóa ''bão tố'' hay thành ''bom xịt''?

Night Mode sẽ tự động kích hoạt khi bạn chụp ảnh trong điều kiện thiếu sáng và chất lượng ảnh cho ra là rất ấn tượng khi so sánh với những chiếc iPhone đời cũ.', 0, 2)
INSERT [dbo].[HangHoa] ([Id], [MaHH], [TenHH], [SoLuong], [DonGia], [MoTa], [Hinh], [ChiTiet], [GiamGia], [MaLoai]) VALUES (N'72fc39c0-395e-4874-9a35-c69e7d85f316', N'70216827', N'Laptop Dell Latitude 5410', 11, 22990000, N'CPU: Intel Core i5-10310U 1.70 GHz,6 MB
RAM: 1x8GB, DDR4 Non-ECC
256GB M2 PCIe NVMe SSD
VGA: Intel UHD Graphics 620, 14" ', N'570x470_Untitled-3.jpg', N'Hệ điều hành	
Free Dos
Bộ vi xử lý	
Intel Core i5-10310U 1.70 GHz,6 MB
Bộ nhớ Ram	
1x8GB, DDR4 Non-ECC (2 DIMM slot, 2667 MHz, Max 32 GB)
Ổ đĩa cứng	
256GB M2 PCIe NVMe SSD
Màn hình	
14" FHD WVA (1920 x 1080) Anti-Glare Non-Touch
Đồ họa	
Intel UHD Graphics 620
Lan	
10/100/1000 Mbps
Camera	
1280 x 720 at 30 fps, Integrated Widescreen HD Webcam with Dual Digital Microphone
Âm thanh	
Realtek ALC3204
Cổng giao tiếp	
(2) USB 3.1 Type-A ports; (1) USB 3.1 Type-A port with PowerShare; (1) USB 3.1 Gen2 Type-C™ port with DisplayPort AltMode/Thunderbolt™3; (1) Universal Audio Jack
Cổng xuất hình	
(1) HDMI 1.4b 
Keyboard + Mouse	
Dual Pointing Backlit US English Keyboard 
Pin (Battery)	
4 Cell 68Whr 
Phụ kiện kèm theo	
Full box
Bluetooth	
Bluetooth 5.0
Wifi	
802.11ax
Kích thước	
20.26 (H) x 323.05 (W) x 216 mm (D)
Khối lượng	
~1.47 kg
Bảo hành	
12 tháng
Hãng sản xuất	
Dell', 0, 4)
INSERT [dbo].[HangHoa] ([Id], [MaHH], [TenHH], [SoLuong], [DonGia], [MoTa], [Hinh], [ChiTiet], [GiamGia], [MaLoai]) VALUES (N'd0f982bb-64fd-4820-8ce5-c9245ed158a3', N'LM-TF001.G', N'Đồng hồ Nam Larmes LM-TF001.GLG3G.121.3GG - Grimlock', 13, 3760000, N'Bộ sản phẩm gồm: Hộp
Bảo hành chính hãng 12 tháng.
1 đổi 1 trong 1 tháng với sản phẩm lỗi. Xem chi tiết
Bảo hành pin trọn đời', N'larmes-lm-tf001-glg3g-121-3gg-nam.jpg', NULL, 0, 10)
INSERT [dbo].[HangHoa] ([Id], [MaHH], [TenHH], [SoLuong], [DonGia], [MoTa], [Hinh], [ChiTiet], [GiamGia], [MaLoai]) VALUES (N'84259234-8f58-4621-8017-d641fe4dbcf9', N'BQ015T', N'Laptop ASUS S533JQ', 111, 19990000, N'CPU: Intel Core i5-1035G1 1.0GHz up to 3.6GHz 6MB
RAM: 8GB onboard DDR4/ 2666MHz
Ổ đĩa cứng: 512GB SSD PCIe (M.2 2280)', N'570x470_ASUS-S533FA-BQ026T--13.png', N'Hệ điều hành	
Win 10 bản quyền
Bộ vi xử lý	
Intel Core i5-1035G1 1.0GHz up to 3.6GHz 6MB
Bộ nhớ Ram	
8GB onboard DDR4/ 2666MHz
Ổ đĩa cứng	
512GB SSD PCIe (M.2 2280)
Màn hình	
15.6" FHD
Đồ họa	
NVIDIA GEFORCE  MX350 2GB GDDR5 
Khe cắm mở rộng	
1 x MicroSD card reader
Camera	
HD Camera
Other Supports	
Finger Print
Cổng giao tiếp	
1 x USB 3.2 Gen 1 Type-C, 1 x USB 3.2 Gen 1 Type-A,2 x USB 2.0,1 x HDMI
Keyboard + Mouse	
Keyboard Laptop + Touchpad
Pin (Battery)	
3-cells
Phụ kiện kèm theo	
Full box
Bluetooth	
Bluetooth V5.0
Wifi	
Wi-Fi 6
Kích thước	
Height:  1.61cm (0.63 inches) Width:  35.98cm (14.17 inches) Depth:  23.38cm (9.2 inches)
Khối lượng	
1.8kg
Bảo hành	
24 tháng (Pin 12 tháng)
Hãng sản xuất	
ASUS', 0, 4)
SET IDENTITY_INSERT [dbo].[Loai] ON 

INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (1, N'Điện máy - Điện máy', NULL)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (2, N'Điện thoại', 9)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (3, N'Máy tính bảng', 9)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (4, N'Laptop', 9)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (5, N'Điện lạnh', 1)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (6, N'Máy ảnh', NULL)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (7, N'Máy cơ', 6)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (8, N'Máy kỹ thuật số', 6)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (9, N'Điện máy', 1)
INSERT [dbo].[Loai] ([MaLoai], [TenLoai], [MaLoaiCha]) VALUES (10, N'Đồng hồ', NULL)
SET IDENTITY_INSERT [dbo].[Loai] OFF
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang_MaDonHang] FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaHoaDon])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang_MaDonHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_HangHoa_MaHangHoa] FOREIGN KEY([MaHangHoa])
REFERENCES [dbo].[HangHoa] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_HangHoa_MaHangHoa]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang_MaKH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang_MaKH]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_Loai_MaLoai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_Loai_MaLoai]
GO
ALTER TABLE [dbo].[Loai]  WITH CHECK ADD  CONSTRAINT [FK_Loai_Loai_MaLoaiCha] FOREIGN KEY([MaLoaiCha])
REFERENCES [dbo].[Loai] ([MaLoai])
GO
ALTER TABLE [dbo].[Loai] CHECK CONSTRAINT [FK_Loai_Loai_MaLoaiCha]
GO
