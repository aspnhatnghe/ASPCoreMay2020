USE [MyProjectMay2020]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/19/2020 8:20:55 AM ******/
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
/****** Object:  Table [dbo].[HangHoa]    Script Date: 7/19/2020 8:20:56 AM ******/
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
/****** Object:  Table [dbo].[Hinhs]    Script Date: 7/19/2020 8:20:56 AM ******/
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
/****** Object:  Table [dbo].[Loai]    Script Date: 7/19/2020 8:20:56 AM ******/
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
