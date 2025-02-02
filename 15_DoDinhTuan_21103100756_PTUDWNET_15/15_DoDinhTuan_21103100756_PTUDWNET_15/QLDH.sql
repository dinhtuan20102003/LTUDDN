USE [QLDH]
GO
/****** Object:  Table [dbo].[Dongho]    Script Date: 11/20/2024 11:07:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dongho](
	[Masp] [nvarchar](15) NOT NULL,
	[Tensp] [nvarchar](50) NULL,
	[Phanloai] [nvarchar](30) NULL,
	[Soluong] [int] NULL,
	[Dongia] [decimal](18, 0) NULL,
	[Hinhanh] [nvarchar](500) NULL,
 CONSTRAINT [PK_Dongho] PRIMARY KEY CLUSTERED 
(
	[Masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Dongho] ([Masp], [Tensp], [Phanloai], [Soluong], [Dongia], [Hinhanh]) VALUES (N'SP01', N'Đồng hồ Casino', N'Đồng hồ nam', 8, CAST(1120000 AS Decimal(18, 0)), N'dh4.jpg')
INSERT [dbo].[Dongho] ([Masp], [Tensp], [Phanloai], [Soluong], [Dongia], [Hinhanh]) VALUES (N'SP02', N'Đồng hồ Apple Watch', N'Đồng hồ nữ', 5, CAST(2500000 AS Decimal(18, 0)), N'dh2.jpg')
INSERT [dbo].[Dongho] ([Masp], [Tensp], [Phanloai], [Soluong], [Dongia], [Hinhanh]) VALUES (N'SP03', N'Đồng hồ Rolex', N'Đồng hồ nam', 10, CAST(2000000 AS Decimal(18, 0)), N'dh3.jpg')
INSERT [dbo].[Dongho] ([Masp], [Tensp], [Phanloai], [Soluong], [Dongia], [Hinhanh]) VALUES (N'SP04', N'Đồng hồ SR Watch', N'Đồng hồ nam', 10, CAST(10000000 AS Decimal(18, 0)), N'dh1.jpg')
INSERT [dbo].[Dongho] ([Masp], [Tensp], [Phanloai], [Soluong], [Dongia], [Hinhanh]) VALUES (N'SP06', N'Đồng hồ SamSung', N'Đồng hồ nữ', 100, CAST(2800000 AS Decimal(18, 0)), N'dh5.jpg')
INSERT [dbo].[Dongho] ([Masp], [Tensp], [Phanloai], [Soluong], [Dongia], [Hinhanh]) VALUES (N'SP10', N'Đồng hồ 10', N'Đồng hồ nam', 10, CAST(10 AS Decimal(18, 0)), N'dh6.jpg')
GO
