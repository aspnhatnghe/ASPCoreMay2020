USE [MyProjectMay2020]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/19/2020 11:22:45 AM ******/
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
/****** Object:  Table [dbo].[HangHoa]    Script Date: 7/19/2020 11:22:45 AM ******/
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
/****** Object:  Table [dbo].[Hinhs]    Script Date: 7/19/2020 11:22:45 AM ******/
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
/****** Object:  Table [dbo].[Loai]    Script Date: 7/19/2020 11:22:45 AM ******/
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
INSERT [dbo].[HangHoa] ([Id], [MaHH], [TenHH], [SoLuong], [DonGia], [MoTa], [Hinh], [ChiTiet], [GiamGia], [MaLoai]) VALUES (N'58b97d6b-8b4c-4e55-96b2-677ef7f6e347', N'DT-OP-001', N'OPPO A92', 11, 6490000, NULL, N'oppo-a92-tim.png', NULL, 0, NULL)
INSERT [dbo].[HangHoa] ([Id], [MaHH], [TenHH], [SoLuong], [DonGia], [MoTa], [Hinh], [ChiTiet], [GiamGia], [MaLoai]) VALUES (N'e7c3b43b-8bb8-4bbe-a0d0-9fec52dc1f29', N'DT-001', N'iPhone 11 128GB', 1, 22999000, N'Màn hình:	IPS LCD, 6.1", Liquid Retina
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

Night Mode sẽ tự động kích hoạt khi bạn chụp ảnh trong điều kiện thiếu sáng và chất lượng ảnh cho ra là rất ấn tượng khi so sánh với những chiếc iPhone đời cũ.', 0, NULL)
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
SET IDENTITY_INSERT [dbo].[Loai] OFF
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
