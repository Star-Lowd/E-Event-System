USE [master]
GO
/****** Object:  Database [EVENTS]    Script Date: 7/26/2016 8:22:50 AM ******/
CREATE DATABASE [EVENTS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EVENTS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EVENTS.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EVENTS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EVENTS_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EVENTS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EVENTS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EVENTS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EVENTS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EVENTS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EVENTS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EVENTS] SET ARITHABORT OFF 
GO
ALTER DATABASE [EVENTS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EVENTS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EVENTS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EVENTS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EVENTS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EVENTS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EVENTS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EVENTS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EVENTS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EVENTS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EVENTS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EVENTS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EVENTS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EVENTS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EVENTS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EVENTS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EVENTS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EVENTS] SET RECOVERY FULL 
GO
ALTER DATABASE [EVENTS] SET  MULTI_USER 
GO
ALTER DATABASE [EVENTS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EVENTS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EVENTS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EVENTS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EVENTS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EVENTS', N'ON'
GO
USE [EVENTS]
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[ACCOUNTID] [int] IDENTITY(45,45) NOT NULL,
	[LOGINID] [int] NULL,
	[COUNTRYID] [int] NULL,
	[FIRSTNAME] [varchar](50) NULL,
	[LASTNAME] [varchar](50) NULL,
	[GENDER] [varchar](1) NULL,
	[DOB] [date] NULL,
	[PHONENUMBER] [varchar](100) NULL,
	[MARITALSTATUS] [varchar](50) NULL,
	[IMAGE] [varchar](500) NULL,
	[CoverImage] [varchar](400) NULL,
PRIMARY KEY CLUSTERED 
(
	[ACCOUNTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COMMENT]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMMENT](
	[COMMENTID] [int] IDENTITY(12,12) NOT NULL,
	[ACCOUNTID] [int] NULL,
	[EVENTID] [int] NULL,
	[COMMENT] [varchar](700) NULL,
	[LOGINID] [int] NULL,
	[CREATEDATE] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[COMMENTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[COUNTRYID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COUNTRYID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EVENT]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EVENT](
	[EVENTID] [int] IDENTITY(134,90) NOT NULL,
	[NAME] [varchar](80) NULL,
	[DATE] [varchar](130) NULL,
	[STARTTIME] [varchar](120) NULL,
	[STOPTIME] [varchar](120) NULL,
	[LOCATION] [varchar](800) NULL,
	[SHORTDESC] [varchar](1300) NULL,
	[LONGDESC] [varchar](max) NULL,
	[POSTEDDATE] [varchar](500) NULL DEFAULT (getdate()),
	[EVENTTYPEID] [int] NULL,
	[RELEASED] [bit] NULL DEFAULT ((0)),
	[LOGINID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EVENTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EVENTIMAGE]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EVENTIMAGE](
	[EVENTIMAGEID] [int] IDENTITY(3,8) NOT NULL,
	[EVENTID] [int] NULL,
	[FILEPATH] [varchar](500) NULL,
	[FILENAME] [varchar](300) NULL,
	[FULLPATH] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[EVENTIMAGEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EVENTTYPE]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EVENTTYPE](
	[EVENTTYPEID] [int] IDENTITY(1,1) NOT NULL,
	[EVENTTYENAME] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[EVENTTYPEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EVENTVIDEO]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EVENTVIDEO](
	[EVENTIMAGEID] [int] IDENTITY(3,8) NOT NULL,
	[EVENTID] [int] NULL,
	[URL] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[EVENTIMAGEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LIKE]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIKE](
	[LIKEID] [int] IDENTITY(12,12) NOT NULL,
	[ACCOUNTID] [int] NULL,
	[EVENTID] [int] NULL,
	[LOGINID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LIKEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOGIN]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOGIN](
	[LOGINID] [int] IDENTITY(7,4) NOT NULL,
	[USERNAME] [varchar](50) NOT NULL,
	[PASSWORDHASH] [varchar](50) NOT NULL,
	[EMAIL] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[LOGINID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[REPLY]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[REPLY](
	[REPLYID] [int] IDENTITY(12,12) NOT NULL,
	[ACCOUNTID] [int] NULL,
	[COMMENTID] [int] NULL,
	[REPLY] [varchar](700) NULL,
	[LOGINID] [int] NULL,
	[CREATEDATE] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[REPLYID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VIEW]    Script Date: 7/26/2016 8:22:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VIEW](
	[VIEWID] [int] IDENTITY(12,12) NOT NULL,
	[ACCOUNTID] [int] NULL,
	[EVENTID] [int] NULL,
	[IPADDRESS] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[VIEWID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD FOREIGN KEY([COUNTRYID])
REFERENCES [dbo].[COUNTRY] ([COUNTRYID])
GO
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD FOREIGN KEY([LOGINID])
REFERENCES [dbo].[LOGIN] ([LOGINID])
GO
ALTER TABLE [dbo].[COMMENT]  WITH CHECK ADD FOREIGN KEY([ACCOUNTID])
REFERENCES [dbo].[ACCOUNT] ([ACCOUNTID])
GO
ALTER TABLE [dbo].[COMMENT]  WITH CHECK ADD FOREIGN KEY([EVENTID])
REFERENCES [dbo].[EVENT] ([EVENTID])
GO
ALTER TABLE [dbo].[COMMENT]  WITH CHECK ADD FOREIGN KEY([LOGINID])
REFERENCES [dbo].[LOGIN] ([LOGINID])
GO
ALTER TABLE [dbo].[EVENT]  WITH CHECK ADD FOREIGN KEY([EVENTTYPEID])
REFERENCES [dbo].[EVENTTYPE] ([EVENTTYPEID])
GO
ALTER TABLE [dbo].[EVENT]  WITH CHECK ADD FOREIGN KEY([LOGINID])
REFERENCES [dbo].[LOGIN] ([LOGINID])
GO
ALTER TABLE [dbo].[EVENTIMAGE]  WITH CHECK ADD FOREIGN KEY([EVENTID])
REFERENCES [dbo].[EVENT] ([EVENTID])
GO
ALTER TABLE [dbo].[EVENTVIDEO]  WITH CHECK ADD FOREIGN KEY([EVENTID])
REFERENCES [dbo].[EVENT] ([EVENTID])
GO
ALTER TABLE [dbo].[LIKE]  WITH CHECK ADD FOREIGN KEY([ACCOUNTID])
REFERENCES [dbo].[ACCOUNT] ([ACCOUNTID])
GO
ALTER TABLE [dbo].[LIKE]  WITH CHECK ADD FOREIGN KEY([EVENTID])
REFERENCES [dbo].[EVENT] ([EVENTID])
GO
ALTER TABLE [dbo].[LIKE]  WITH CHECK ADD FOREIGN KEY([LOGINID])
REFERENCES [dbo].[LOGIN] ([LOGINID])
GO
ALTER TABLE [dbo].[REPLY]  WITH CHECK ADD FOREIGN KEY([ACCOUNTID])
REFERENCES [dbo].[ACCOUNT] ([ACCOUNTID])
GO
ALTER TABLE [dbo].[REPLY]  WITH CHECK ADD FOREIGN KEY([COMMENTID])
REFERENCES [dbo].[COMMENT] ([COMMENTID])
GO
ALTER TABLE [dbo].[REPLY]  WITH CHECK ADD FOREIGN KEY([LOGINID])
REFERENCES [dbo].[LOGIN] ([LOGINID])
GO
ALTER TABLE [dbo].[VIEW]  WITH CHECK ADD FOREIGN KEY([ACCOUNTID])
REFERENCES [dbo].[ACCOUNT] ([ACCOUNTID])
GO
ALTER TABLE [dbo].[VIEW]  WITH CHECK ADD FOREIGN KEY([EVENTID])
REFERENCES [dbo].[EVENT] ([EVENTID])
GO
USE [master]
GO
ALTER DATABASE [EVENTS] SET  READ_WRITE 
GO
