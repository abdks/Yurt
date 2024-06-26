USE [master]
GO
/****** Object:  Database [YurtOtomasyonu]    Script Date: 23.04.2023 21:33:23 ******/
CREATE DATABASE [YurtOtomasyonu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'YurtOtomasyonu', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.WINCC\MSSQL\DATA\YurtOtomasyonu.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'YurtOtomasyonu_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.WINCC\MSSQL\DATA\YurtOtomasyonu_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [YurtOtomasyonu] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YurtOtomasyonu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YurtOtomasyonu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET ARITHABORT OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [YurtOtomasyonu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [YurtOtomasyonu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [YurtOtomasyonu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YurtOtomasyonu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [YurtOtomasyonu] SET  MULTI_USER 
GO
ALTER DATABASE [YurtOtomasyonu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YurtOtomasyonu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [YurtOtomasyonu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [YurtOtomasyonu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [YurtOtomasyonu] SET DELAYED_DURABILITY = DISABLED 
GO
USE [YurtOtomasyonu]
GO
/****** Object:  User [SIMATIC HMI VIEWER User]    Script Date: 23.04.2023 21:33:23 ******/
CREATE USER [SIMATIC HMI VIEWER User] FOR LOGIN [DESKTOP-NIJEM97\SIMATIC HMI VIEWER]
GO
/****** Object:  User [SIMATIC HMI User]    Script Date: 23.04.2023 21:33:23 ******/
CREATE USER [SIMATIC HMI User] FOR LOGIN [DESKTOP-NIJEM97\SIMATIC HMI]
GO
/****** Object:  DatabaseRole [SIMATIC HMI VIEWER role]    Script Date: 23.04.2023 21:33:23 ******/
CREATE ROLE [SIMATIC HMI VIEWER role]
GO
/****** Object:  DatabaseRole [SIMATIC HMI role]    Script Date: 23.04.2023 21:33:23 ******/
CREATE ROLE [SIMATIC HMI role]
GO
ALTER ROLE [SIMATIC HMI VIEWER role] ADD MEMBER [SIMATIC HMI VIEWER User]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SIMATIC HMI VIEWER User]
GO
ALTER ROLE [SIMATIC HMI role] ADD MEMBER [SIMATIC HMI User]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [SIMATIC HMI User]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SIMATIC HMI User]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [SIMATIC HMI User]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SIMATIC HMI VIEWER role]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [SIMATIC HMI role]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SIMATIC HMI role]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [SIMATIC HMI role]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 23.04.2023 21:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[YoneticiId] [tinyint] IDENTITY(1,1) NOT NULL,
	[YoneticiAd] [varchar](20) NULL,
	[YoneticiSifre] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bolumler]    Script Date: 23.04.2023 21:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolumler](
	[Bolumid] [tinyint] IDENTITY(1,1) NOT NULL,
	[BolumAd] [varchar](80) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Borclar]    Script Date: 23.04.2023 21:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borclar](
	[Ogrid] [int] NULL,
	[OgrAd] [varchar](20) NULL,
	[OgrSoyad] [varchar](30) NULL,
	[OgrKalanBorc] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Giderler]    Script Date: 23.04.2023 21:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giderler](
	[Odemeid] [smallint] IDENTITY(1,1) NOT NULL,
	[Elektrik] [int] NULL,
	[Su] [int] NULL,
	[Dogalgaz] [int] NULL,
	[Internet] [int] NULL,
	[Gida] [int] NULL,
	[Personel] [int] NULL,
	[Diger] [int] NULL,
	[Toplam] [int] NULL,
	[KayitTarihi] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kasa]    Script Date: 23.04.2023 21:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kasa](
	[OdemeAy] [varchar](50) NULL,
	[OdemeMiktar] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odalar]    Script Date: 23.04.2023 21:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odalar](
	[Odaid] [tinyint] IDENTITY(1,1) NOT NULL,
	[OdaNo] [char](3) NULL,
	[OdaKapasite] [char](1) NULL,
	[OdaAktif] [char](1) NULL,
	[OdaDurum] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenci]    Script Date: 23.04.2023 21:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenci](
	[Ogrid] [int] IDENTITY(1,1) NOT NULL,
	[OgrAd] [varchar](30) NULL,
	[OgrSoyad] [varchar](30) NULL,
	[OgrTc] [char](11) NULL,
	[OgrTelefon] [varchar](20) NULL,
	[OgrDogum] [varchar](12) NULL,
	[OgrBolum] [varchar](50) NULL,
	[OgrMail] [varchar](50) NULL,
	[OgrOdaNo] [char](3) NULL,
	[OgrVeliAdSoyad] [varchar](50) NULL,
	[OgrVeliTelefon] [varchar](20) NULL,
	[OgrVeliAdres] [varchar](250) NULL,
 CONSTRAINT [PK_Ogrenci_1] PRIMARY KEY CLUSTERED 
(
	[Ogrid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 23.04.2023 21:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[Personelid] [tinyint] IDENTITY(1,1) NOT NULL,
	[PersonelAdSoyad] [varchar](100) NULL,
	[PersonelDepartman] [varchar](60) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([YoneticiId], [YoneticiAd], [YoneticiSifre]) VALUES (1, N'admin', N'admin')
INSERT [dbo].[Admin] ([YoneticiId], [YoneticiAd], [YoneticiSifre]) VALUES (2, N'1234', N'1234')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Bolumler] ON 

INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (1, N'Bilgisayar Müh.')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (2, N'Elektrik-Elektronik Müh.')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (3, N'Otomotiv Müh.')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (4, N'Yazılım Mühendisliği')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (5, N'Edebiyat')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (6, N'Sosyal Bilimler')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (7, N'Matematik')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (8, N'Tıp')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (9, N'Diş Hekimliği')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (10, N'Veterinerlik')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (11, N'Muhasebe')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (12, N'İşletme')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (13, N'Su Ürünleri')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (14, N'Yabancı Diller')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (15, N'Coğrafya')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (16, N'Bilgisayar Öğretmenliği')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (17, N'Branş Öğretmenlikleri')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (18, N'Konservatuvar')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (19, N'Uluslararası İlişkiler')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (20, N'Diyetisyenlik')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (21, N'Gastronomi')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (22, N'Hukuk')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (23, N'Tarih')
INSERT [dbo].[Bolumler] ([Bolumid], [BolumAd]) VALUES (24, N'Spor ve Sağlık')
SET IDENTITY_INSERT [dbo].[Bolumler] OFF
GO
INSERT [dbo].[Borclar] ([Ogrid], [OgrAd], [OgrSoyad], [OgrKalanBorc]) VALUES (1, N'Hasan', N'Tekinoğlu', 2500)
INSERT [dbo].[Borclar] ([Ogrid], [OgrAd], [OgrSoyad], [OgrKalanBorc]) VALUES (2, N'Mehmet', N'Karakaya', 2250)
INSERT [dbo].[Borclar] ([Ogrid], [OgrAd], [OgrSoyad], [OgrKalanBorc]) VALUES (3, N'Necdet', N'Yılmaz', 2450)
INSERT [dbo].[Borclar] ([Ogrid], [OgrAd], [OgrSoyad], [OgrKalanBorc]) VALUES (4, N'Faruk', N'Ateş', 2300)
INSERT [dbo].[Borclar] ([Ogrid], [OgrAd], [OgrSoyad], [OgrKalanBorc]) VALUES (5, N'Okan', N'Küçük', 2300)
GO
SET IDENTITY_INSERT [dbo].[Giderler] ON 

INSERT [dbo].[Giderler] ([Odemeid], [Elektrik], [Su], [Dogalgaz], [Internet], [Gida], [Personel], [Diger], [Toplam], [KayitTarihi]) VALUES (1, 100, 100, 100, 100, 100, 100, 100, 700, CAST(N'2023-02-10' AS Date))
INSERT [dbo].[Giderler] ([Odemeid], [Elektrik], [Su], [Dogalgaz], [Internet], [Gida], [Personel], [Diger], [Toplam], [KayitTarihi]) VALUES (2, 150, 200, 800, 560, 1000, 10000, 780, 13490, CAST(N'2023-03-15' AS Date))
INSERT [dbo].[Giderler] ([Odemeid], [Elektrik], [Su], [Dogalgaz], [Internet], [Gida], [Personel], [Diger], [Toplam], [KayitTarihi]) VALUES (4, 100, 100, 100, 100, 100, 100, 100, 700, CAST(N'2023-04-23' AS Date))
INSERT [dbo].[Giderler] ([Odemeid], [Elektrik], [Su], [Dogalgaz], [Internet], [Gida], [Personel], [Diger], [Toplam], [KayitTarihi]) VALUES (5, 50, 50, 50, 50, 50, 50, 50, 350, CAST(N'2023-04-23' AS Date))
SET IDENTITY_INSERT [dbo].[Giderler] OFF
GO
INSERT [dbo].[Kasa] ([OdemeAy], [OdemeMiktar]) VALUES (N'Ocak 2023', 200)
INSERT [dbo].[Kasa] ([OdemeAy], [OdemeMiktar]) VALUES (N'Ocak 2023', 400)
INSERT [dbo].[Kasa] ([OdemeAy], [OdemeMiktar]) VALUES (N'Ocak 2023', 150)
INSERT [dbo].[Kasa] ([OdemeAy], [OdemeMiktar]) VALUES (N'Ocak 2023', 450)
INSERT [dbo].[Kasa] ([OdemeAy], [OdemeMiktar]) VALUES (N'Şubat 2023', 100)
INSERT [dbo].[Kasa] ([OdemeAy], [OdemeMiktar]) VALUES (N'Mart 2023', 100)
INSERT [dbo].[Kasa] ([OdemeAy], [OdemeMiktar]) VALUES (N'Nisan 2023', 100)
INSERT [dbo].[Kasa] ([OdemeAy], [OdemeMiktar]) VALUES (N'Ocak 2023', 100)
GO
SET IDENTITY_INSERT [dbo].[Odalar] ON 

INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (1, N'101', N'1', N'1', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (2, N'102', N'1', N'1', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (3, N'103', N'1', N'1', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (4, N'104', N'1', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (5, N'105', N'1', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (6, N'201', N'2', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (7, N'202', N'2', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (8, N'203', N'2', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (9, N'204', N'2', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (10, N'205', N'2', N'1', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (11, N'301', N'3', N'1', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (12, N'302', N'3', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (13, N'303', N'3', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (14, N'304', N'3', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (15, N'305', N'3', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (16, N'401', N'4', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (17, N'402', N'4', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (18, N'403', N'4', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (19, N'404', N'4', N'0', 1)
INSERT [dbo].[Odalar] ([Odaid], [OdaNo], [OdaKapasite], [OdaAktif], [OdaDurum]) VALUES (20, N'405', N'4', N'0', 1)
SET IDENTITY_INSERT [dbo].[Odalar] OFF
GO
SET IDENTITY_INSERT [dbo].[Ogrenci] ON 

INSERT [dbo].[Ogrenci] ([Ogrid], [OgrAd], [OgrSoyad], [OgrTc], [OgrTelefon], [OgrDogum], [OgrBolum], [OgrMail], [OgrOdaNo], [OgrVeliAdSoyad], [OgrVeliTelefon], [OgrVeliAdres]) VALUES (1, N'Hasan', N'Tekinoğlu', N'99848480976', N'(889) 270-2651', N'10.05.1998', N'Bilgisayar Müh.', N'hasan@gmail.com', N'101', N'Ayşe Tekinoğlu', N'(639) 251-2170', N'deneme sok no:15
kadıköy/istanbul')
INSERT [dbo].[Ogrenci] ([Ogrid], [OgrAd], [OgrSoyad], [OgrTc], [OgrTelefon], [OgrDogum], [OgrBolum], [OgrMail], [OgrOdaNo], [OgrVeliAdSoyad], [OgrVeliTelefon], [OgrVeliAdres]) VALUES (2, N'Mehmet', N'Karakaya', N'90440398232', N'(474) 715-1489', N'06.12.2001', N'Branş Öğretmenlikleri', N'mehmet@outlook.com', N'301', N'Volkan Karakaya', N'(720) 757-2649', N'deneme bulvarı  no:8 daire:3
Mamak/Ankara')
INSERT [dbo].[Ogrenci] ([Ogrid], [OgrAd], [OgrSoyad], [OgrTc], [OgrTelefon], [OgrDogum], [OgrBolum], [OgrMail], [OgrOdaNo], [OgrVeliAdSoyad], [OgrVeliTelefon], [OgrVeliAdres]) VALUES (3, N'Necdet', N'Yılmaz', N'40020802062', N'(425) 657-3518', N'30.11.1999', N'Hukuk', N'necdet@outlook.com', N'102', N'Kamber Yılmaz', N'(664) 279-0618', N'deneme sokak deneme mahallesi
üsküdar/istanbul')
INSERT [dbo].[Ogrenci] ([Ogrid], [OgrAd], [OgrSoyad], [OgrTc], [OgrTelefon], [OgrDogum], [OgrBolum], [OgrMail], [OgrOdaNo], [OgrVeliAdSoyad], [OgrVeliTelefon], [OgrVeliAdres]) VALUES (4, N'Faruk', N'Ateş', N'89910460906', N'(264) 990-3808', N'12.03.2003', N'Sosyal Bilimler', N'faruk@gmailcom', N'205', N'Nazif Ateş', N'(546) 271-4651', N'deneme caddesi 105. sokak
Antalya')
INSERT [dbo].[Ogrenci] ([Ogrid], [OgrAd], [OgrSoyad], [OgrTc], [OgrTelefon], [OgrDogum], [OgrBolum], [OgrMail], [OgrOdaNo], [OgrVeliAdSoyad], [OgrVeliTelefon], [OgrVeliAdres]) VALUES (5, N'Okan', N'Küçük', N'42547228318', N'(949) 856-0352', N'05.02.2002', N'Diş Hekimliği', N'okanKucuk@hotmail.com', N'103', N'Fatma Küçük', N'(029) 167-1496', N'deneme sokak deneme apartmanı
Maltepe/İstanbul')
SET IDENTITY_INSERT [dbo].[Ogrenci] OFF
GO
SET IDENTITY_INSERT [dbo].[Personel] ON 

INSERT [dbo].[Personel] ([Personelid], [PersonelAdSoyad], [PersonelDepartman]) VALUES (1, N'Mehmet Alper', N'Müdür')
INSERT [dbo].[Personel] ([Personelid], [PersonelAdSoyad], [PersonelDepartman]) VALUES (2, N'Ahmet Çelik', N'Müdür Yardımcısı')
INSERT [dbo].[Personel] ([Personelid], [PersonelAdSoyad], [PersonelDepartman]) VALUES (3, N'Necati Kılıç', N'Müdür Yardımcısı')
INSERT [dbo].[Personel] ([Personelid], [PersonelAdSoyad], [PersonelDepartman]) VALUES (4, N'İlker Erdoğdu', N'Aşçı')
INSERT [dbo].[Personel] ([Personelid], [PersonelAdSoyad], [PersonelDepartman]) VALUES (5, N'Musa Hazinedaroğlu', N'Temizlik Personeli')
INSERT [dbo].[Personel] ([Personelid], [PersonelAdSoyad], [PersonelDepartman]) VALUES (6, N'Akif Coşkun', N'Şoför')
INSERT [dbo].[Personel] ([Personelid], [PersonelAdSoyad], [PersonelDepartman]) VALUES (7, N'Ferhat Güçlü', N'Güvenlik personeli')
INSERT [dbo].[Personel] ([Personelid], [PersonelAdSoyad], [PersonelDepartman]) VALUES (8, N'Ali Yalnız', N'Temizlik Personeli')
INSERT [dbo].[Personel] ([Personelid], [PersonelAdSoyad], [PersonelDepartman]) VALUES (9, N'Uygar Deniz', N'Güvenlik Personeli')
SET IDENTITY_INSERT [dbo].[Personel] OFF
GO
ALTER TABLE [dbo].[Borclar] ADD  CONSTRAINT [DF_Borçlar_OgrKalanBorc]  DEFAULT ((3000)) FOR [OgrKalanBorc]
GO
ALTER TABLE [dbo].[Odalar] ADD  CONSTRAINT [DF_Odalar_OdaAktif]  DEFAULT ((0)) FOR [OdaAktif]
GO
ALTER TABLE [dbo].[Odalar] ADD  CONSTRAINT [DF_Odalar_OdaDurum_1]  DEFAULT ((1)) FOR [OdaDurum]
GO
/****** Object:  DdlTrigger [OnTriggerDboSchema]    Script Date: 23.04.2023 21:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [OnTriggerDboSchema] ON database FOR create_table, create_view AS BEGIN   DECLARE @xmlEventData xml   SELECT    @xmlEventData = eventdata()   DECLARE @schemaName nvarchar(max)   DECLARE @objectName nvarchar(max)   DECLARE @DynSql nvarchar(max)      SET @schemaName    = convert(nvarchar(max), @xmlEventData.query('/EVENT_INSTANCE/SchemaName/text()'))   SET @objectName    = convert(nvarchar(max), @xmlEventData.query('/EVENT_INSTANCE/ObjectName/text()'))   IF(@schemaName='')   BEGIN     SET @DynSql = N'alter schema [dbo] transfer [' + @schemaName + N'].[' + @objectName + N']'     EXEC sp_executesql @statement=@DynSql   END END SET QUOTED_IDENTIFIER ON SET ANSI_NULLS ON 
GO
ENABLE TRIGGER [OnTriggerDboSchema] ON DATABASE
GO
USE [master]
GO
ALTER DATABASE [YurtOtomasyonu] SET  READ_WRITE 
GO
