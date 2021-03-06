USE [master]
GO
/****** Object:  Database [travel]    Script Date: 9/24/2018 15:15:01 ******/
CREATE DATABASE [travel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'travel', FILENAME = N'E:\Program\Microsoft SQL\MSSQL14.MSSQLSERVER\MSSQL\DATA\travel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'travel_log', FILENAME = N'E:\Program\Microsoft SQL\MSSQL14.MSSQLSERVER\MSSQL\DATA\travel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [travel] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [travel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [travel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [travel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [travel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [travel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [travel] SET ARITHABORT OFF 
GO
ALTER DATABASE [travel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [travel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [travel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [travel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [travel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [travel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [travel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [travel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [travel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [travel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [travel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [travel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [travel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [travel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [travel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [travel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [travel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [travel] SET RECOVERY FULL 
GO
ALTER DATABASE [travel] SET  MULTI_USER 
GO
ALTER DATABASE [travel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [travel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [travel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [travel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [travel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [travel] SET QUERY_STORE = OFF
GO
USE [travel]
GO
/****** Object:  Table [dbo].[DiaDanh]    Script Date: 9/24/2018 15:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiaDanh](
	[MaDiaDanh] [nchar](10) NOT NULL,
	[MoTaDiaDanh] [nvarchar](max) NULL,
	[DiaDanhConTieuBieu] [nvarchar](100) NULL,
	[MaVungMien] [int] NULL,
	[TenDiaDanh] [nvarchar](50) NOT NULL,
	[SoKhachDaThamQuan] [int] NULL,
	[Anh] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HuongDanVien]    Script Date: 9/24/2018 15:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HuongDanVien](
	[MaHuongDanVien] [nchar](10) NOT NULL,
	[HoTenHDV] [nvarchar](50) NULL,
	[SoDienThoaiHDV] [nchar](12) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 9/24/2018 15:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nchar](10) NOT NULL,
	[HoTenKhachHang] [nvarchar](50) NULL,
	[SoDienThoaiKH] [nchar](12) NULL,
	[SoHoChieuCMND] [nchar](15) NULL,
	[Email] [nchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuDatTour]    Script Date: 9/24/2018 15:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDatTour](
	[MaTour] [nchar](10) NOT NULL,
	[MaKhachHang] [nchar](10) NOT NULL,
	[TinhTranThanhToan] [bit] NULL,
	[XacNhanThamGia] [bit] NULL,
	[DanhGia] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhuongTien]    Script Date: 9/24/2018 15:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuongTien](
	[MaPhuongTien] [nchar](10) NULL,
	[ThoiGianDen] [datetime] NULL,
	[ThoiGianDi] [datetime] NULL,
	[TenSanBay] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinChiTietTour]    Script Date: 9/24/2018 15:15:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinChiTietTour](
	[MaChiTietTour] [nchar](10) NULL,
	[NgayGioTapTrung] [datetime] NULL,
	[NoiTapTrung] [nvarchar](50) NULL,
	[MaPhuongTien] [nchar](10) NULL,
	[MaLuuY] [nchar](10) NULL,
	[CoBaoHiem] [bit] NULL,
	[QuaTang] [nvarchar](20) NULL,
	[LichTrinh] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tour]    Script Date: 9/24/2018 15:15:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tour](
	[MaTour] [nchar](10) NOT NULL,
	[MoTaTour] [nvarchar](100) NULL,
	[DanhGia] [float] NULL,
	[TongSoDanhGia] [int] NULL,
	[SoNgay] [float] NULL,
	[SoChoConLai] [int] NULL,
	[NgayKhoiHanh] [date] NULL,
	[NgayTroVe] [date] NULL,
	[GiaTien] [int] NULL,
	[GiaTienTreEm] [int] NULL,
	[NoiKhoiHanh] [nvarchar](50) NULL,
	[GiamGia] [float] NULL,
	[MaChiTietTour] [nchar](10) NULL,
	[MaHuongDanVien] [nchar](10) NULL,
	[MaDiaDanh] [nchar](10) NULL,
	[TinhTrang] [bit] NULL,
	[PhuongTien] [nvarchar](30) NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [travel] SET  READ_WRITE 
GO
