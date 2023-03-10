USE [master]
GO
/****** Object:  Database [CES]    Script Date: 12/20/2022 5:09:53 PM ******/
CREATE DATABASE [CES]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CES', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\CES.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CES_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\CES_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CES] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CES].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CES] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CES] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CES] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CES] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CES] SET ARITHABORT OFF 
GO
ALTER DATABASE [CES] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CES] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CES] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CES] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CES] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CES] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CES] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CES] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CES] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CES] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CES] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CES] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CES] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CES] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CES] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CES] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CES] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CES] SET RECOVERY FULL 
GO
ALTER DATABASE [CES] SET  MULTI_USER 
GO
ALTER DATABASE [CES] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CES] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CES] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CES] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CES] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CES] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CES', N'ON'
GO
ALTER DATABASE [CES] SET QUERY_STORE = OFF
GO
USE [CES]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 12/20/2022 5:09:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Website] [varchar](500) NOT NULL,
	[PhoneNo] [varchar](20) NOT NULL,
	[Image] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 12/20/2022 5:09:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[SpeakerId] [int] NOT NULL,
	[Image] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Speaker]    Script Date: 12/20/2022 5:09:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speaker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Profile] [varchar](50) NOT NULL,
	[LinkedInUrl] [varchar](100) NOT NULL,
	[Twitter] [varchar](50) NOT NULL,
	[Pic] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Speaker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TalkDetails]    Script Date: 12/20/2022 5:09:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TalkDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpeakerId] [int] NOT NULL,
	[Title] [varchar](500) NOT NULL,
	[Room] [varchar](50) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Talks] [varchar](50) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Speakers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [CityName], [Address], [Website], [PhoneNo], [Image]) VALUES (1, N'Vadodara', N'Laxmi Villas Palace', N'www.lvp.com', N'9738283722', N'city1.jpg')
INSERT [dbo].[Cities] ([Id], [CityName], [Address], [Website], [PhoneNo], [Image]) VALUES (2, N'Ahmedabad', N'Marriot ', N'www.marriot.com', N'+91 9834278673', N'city2.jpg')
INSERT [dbo].[Cities] ([Id], [CityName], [Address], [Website], [PhoneNo], [Image]) VALUES (3, N'Ahmedabad', N'Asopalav', N'www.asoplav_best.com', N'3828939299', N'city3.jpg')
INSERT [dbo].[Cities] ([Id], [CityName], [Address], [Website], [PhoneNo], [Image]) VALUES (4, N'Jaipur', N'Jaipur ki gali', N'www.jaipur.com', N'20253013314', N'city4.jpg')
INSERT [dbo].[Cities] ([Id], [CityName], [Address], [Website], [PhoneNo], [Image]) VALUES (5, N'Vadodara', N'20 Pushti Bunglows', N'cyber.com', N'9808376392', N'jayy.jpg')
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [CityId], [Address], [StartDate], [EndDate], [IsCompleted], [Name], [Description], [SpeakerId], [Image]) VALUES (1, 1, N'Laxmi Villas Palace', CAST(N'2022-11-26T00:00:00.000' AS DateTime), CAST(N'2022-11-27T00:00:00.000' AS DateTime), 0, N'Science', N'dadwiadebansjakh', 1, N'city1.jpg')
INSERT [dbo].[Events] ([Id], [CityId], [Address], [StartDate], [EndDate], [IsCompleted], [Name], [Description], [SpeakerId], [Image]) VALUES (2, 2, N'Asopalav', CAST(N'2021-08-12T00:00:00.000' AS DateTime), CAST(N'2021-08-15T00:00:00.000' AS DateTime), 1, N'Maths', N'jnskaxauyaayh', 2, N'city2.jpg')
INSERT [dbo].[Events] ([Id], [CityId], [Address], [StartDate], [EndDate], [IsCompleted], [Name], [Description], [SpeakerId], [Image]) VALUES (3, 3, N'Surya Palace', CAST(N'2021-07-18T00:00:00.000' AS DateTime), CAST(N'2021-07-20T00:00:00.000' AS DateTime), 1, N'English', N'Very good english speaker', 1, N'city3.jpg')
INSERT [dbo].[Events] ([Id], [CityId], [Address], [StartDate], [EndDate], [IsCompleted], [Name], [Description], [SpeakerId], [Image]) VALUES (4, 4, N'Grand Hayyat', CAST(N'2022-11-11T00:00:00.000' AS DateTime), CAST(N'2022-11-11T00:00:00.000' AS DateTime), 1, N'Physics', N'physics rocks', 1, N'city4.jpg')
INSERT [dbo].[Events] ([Id], [CityId], [Address], [StartDate], [EndDate], [IsCompleted], [Name], [Description], [SpeakerId], [Image]) VALUES (5, 1, N'1331', CAST(N'2022-05-04T00:00:00.000' AS DateTime), CAST(N'2022-05-05T00:00:00.000' AS DateTime), 1, N'Chemistry', N'h2so4 and hcl', 3, N'city1.jpg')
INSERT [dbo].[Events] ([Id], [CityId], [Address], [StartDate], [EndDate], [IsCompleted], [Name], [Description], [SpeakerId], [Image]) VALUES (6, 3, N'Eva Mall', CAST(N'2022-09-24T00:00:00.000' AS DateTime), CAST(N'2022-09-25T00:00:00.000' AS DateTime), 1, N'Cyber Security', N'ethical hacking learning', 2, N'city2.jpg')
INSERT [dbo].[Events] ([Id], [CityId], [Address], [StartDate], [EndDate], [IsCompleted], [Name], [Description], [SpeakerId], [Image]) VALUES (7, 3, N'jaipur ki gali', CAST(N'2022-12-19T05:44:12.237' AS DateTime), CAST(N'2022-12-20T05:44:12.237' AS DateTime), 1, N'Software Engineering', N'learn something new', 2, N'omen.png')
INSERT [dbo].[Events] ([Id], [CityId], [Address], [StartDate], [EndDate], [IsCompleted], [Name], [Description], [SpeakerId], [Image]) VALUES (8, 1, N'vrundavan', CAST(N'2022-12-12T00:00:00.000' AS DateTime), CAST(N'2022-12-13T00:00:00.000' AS DateTime), 1, N'Testing Event', N'description about events', 4, N'54693.jpg')
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Speaker] ON 

INSERT [dbo].[Speaker] ([Id], [Name], [Profile], [LinkedInUrl], [Twitter], [Pic]) VALUES (1, N'Jay Chaniyara', N'Software Engineer', N'jay_chaniyara_007', N'jay.chaniyara', N'person14.jpg')
INSERT [dbo].[Speaker] ([Id], [Name], [Profile], [LinkedInUrl], [Twitter], [Pic]) VALUES (2, N'Janaki Chaniayara', N'Teacher', N'janaki_0209`', N'janaki-chaniyara', N'person9.jpg')
INSERT [dbo].[Speaker] ([Id], [Name], [Profile], [LinkedInUrl], [Twitter], [Pic]) VALUES (3, N'aditi', N'aditi007', N'aditi123', N'coolAditi', N'person14.jpg')
INSERT [dbo].[Speaker] ([Id], [Name], [Profile], [LinkedInUrl], [Twitter], [Pic]) VALUES (4, N'Jay Chaniyara', N'jayychaniyara', N'jay2021', N'jayy2030', N'omen.png')
SET IDENTITY_INSERT [dbo].[Speaker] OFF
GO
SET IDENTITY_INSERT [dbo].[TalkDetails] ON 

INSERT [dbo].[TalkDetails] ([Id], [SpeakerId], [Title], [Room], [Description], [Talks], [StartTime], [EndTime]) VALUES (1, 2, N'Maths', N'A-21', N'nshqwiqkjsnii', N'60 Min', CAST(N'2021-11-12T12:00:00.000' AS DateTime), CAST(N'2021-11-12T01:00:00.000' AS DateTime))
INSERT [dbo].[TalkDetails] ([Id], [SpeakerId], [Title], [Room], [Description], [Talks], [StartTime], [EndTime]) VALUES (2, 1, N'Physics', N'B-22', N'is good', N'60 Min', CAST(N'2022-11-11T00:00:00.000' AS DateTime), CAST(N'2022-11-12T00:00:00.000' AS DateTime))
INSERT [dbo].[TalkDetails] ([Id], [SpeakerId], [Title], [Room], [Description], [Talks], [StartTime], [EndTime]) VALUES (3, 3, N'Hacking', N'b-106', N'hackers gang', N'60mins', CAST(N'2022-12-12T05:58:52.730' AS DateTime), CAST(N'2022-12-12T05:58:52.730' AS DateTime))
INSERT [dbo].[TalkDetails] ([Id], [SpeakerId], [Title], [Room], [Description], [Talks], [StartTime], [EndTime]) VALUES (4, 4, N'Hacking Talks', N'E-404', N'lets describe here', N'90min', CAST(N'2022-12-12T10:00:00.000' AS DateTime), CAST(N'2022-12-12T11:30:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[TalkDetails] OFF
GO
USE [master]
GO
ALTER DATABASE [CES] SET  READ_WRITE 
GO
