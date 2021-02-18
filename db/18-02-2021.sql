USE [BonusCardDB]
GO
ALTER TABLE [dbo].[Client] DROP CONSTRAINT [FK_Client_BonusCard]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 18.02.2021 23:21:54 ******/
DROP TABLE [dbo].[Client]
GO
/****** Object:  Table [dbo].[BonusCard]    Script Date: 18.02.2021 23:21:54 ******/
DROP TABLE [dbo].[BonusCard]
GO
USE [master]
GO
/****** Object:  Database [BonusCardDB]    Script Date: 18.02.2021 23:21:54 ******/
DROP DATABASE [BonusCardDB]
GO
/****** Object:  Database [BonusCardDB]    Script Date: 18.02.2021 23:21:54 ******/
CREATE DATABASE [BonusCardDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BonusCardDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BonusCardDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BonusCardDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BonusCardDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BonusCardDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BonusCardDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BonusCardDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BonusCardDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BonusCardDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BonusCardDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BonusCardDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BonusCardDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BonusCardDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BonusCardDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BonusCardDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BonusCardDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BonusCardDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BonusCardDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BonusCardDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BonusCardDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BonusCardDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BonusCardDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BonusCardDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BonusCardDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BonusCardDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BonusCardDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BonusCardDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BonusCardDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BonusCardDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BonusCardDB] SET  MULTI_USER 
GO
ALTER DATABASE [BonusCardDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BonusCardDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BonusCardDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BonusCardDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BonusCardDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BonusCardDB]
GO
/****** Object:  Table [dbo].[BonusCard]    Script Date: 18.02.2021 23:21:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BonusCard](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [nvarchar](6) NULL,
	[ExpirationDate] [datetime] NULL,
	[Balance] [int] NULL,
	[CreationDate] [datetime] NOT NULL CONSTRAINT [DF_BonusCard_CreationDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_BonusCard] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 18.02.2021 23:21:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[BonusCardID] [int] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BonusCard] ON 

INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (1, N'000001', NULL, 500, CAST(N'2021-02-15 21:28:53.843' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (2, N'000002', NULL, 500, CAST(N'2021-02-15 21:29:38.823' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (3, N'000003', CAST(N'2025-03-08 00:00:00.000' AS DateTime), NULL, CAST(N'2021-02-17 18:31:24.137' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (4, N'000004', CAST(N'2021-02-25 00:00:00.000' AS DateTime), NULL, CAST(N'2021-02-17 22:12:23.777' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (5, N'000005', CAST(N'2022-02-17 20:13:08.823' AS DateTime), NULL, CAST(N'2021-02-17 22:13:08.853' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (6, N'000006', CAST(N'2023-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-17 22:15:13.380' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (8, N'000008', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-17 22:34:37.640' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (9, N'000009', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-17 22:36:22.903' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (10, N'000010', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-18 14:38:23.383' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (11, N'000011', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-18 14:42:07.073' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (12, N'000012', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-18 14:42:20.670' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (13, N'000013', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-18 14:45:04.197' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (14, N'000014', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-18 14:58:06.703' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (15, N'000015', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-18 15:02:18.057' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (16, N'000016', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-18 15:02:47.963' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (17, N'000017', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-18 15:38:24.533' AS DateTime))
INSERT [dbo].[BonusCard] ([ID], [CardNumber], [ExpirationDate], [Balance], [CreationDate]) VALUES (18, N'000018', CAST(N'2025-02-25 00:00:00.000' AS DateTime), 0, CAST(N'2021-02-18 15:56:02.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[BonusCard] OFF
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ID], [Firstname], [Lastname], [PhoneNumber], [BonusCardID]) VALUES (1, N'Vasia', N'Pupkin', N'+30505281475', 1)
INSERT [dbo].[Client] ([ID], [Firstname], [Lastname], [PhoneNumber], [BonusCardID]) VALUES (2, N'Fedor', N'Karnavalenko', N'+30661234567', 2)
INSERT [dbo].[Client] ([ID], [Firstname], [Lastname], [PhoneNumber], [BonusCardID]) VALUES (3, N'Oxana', N'Vinchecnko', N'+30675260303', 17)
INSERT [dbo].[Client] ([ID], [Firstname], [Lastname], [PhoneNumber], [BonusCardID]) VALUES (4, N'Timophei', N'Sytnikov', N'+05052852584', 18)
SET IDENTITY_INSERT [dbo].[Client] OFF
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_BonusCard] FOREIGN KEY([BonusCardID])
REFERENCES [dbo].[BonusCard] ([ID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_BonusCard]
GO
USE [master]
GO
ALTER DATABASE [BonusCardDB] SET  READ_WRITE 
GO
