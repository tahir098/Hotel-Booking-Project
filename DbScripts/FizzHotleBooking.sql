USE [FizzHotleBooking]
GO
ALTER TABLE [Hotel].[RoomServices] DROP CONSTRAINT [FK_RoomServices_Services]
GO
ALTER TABLE [Hotel].[RoomServices] DROP CONSTRAINT [FK_RoomServices_Rooms]
GO
ALTER TABLE [Hotel].[Officers] DROP CONSTRAINT [FK_Officers_Roles]
GO
ALTER TABLE [Hotel].[Hotels] DROP CONSTRAINT [FK_Hotels_Cities]
GO
ALTER TABLE [Hotel].[HotelOfficers] DROP CONSTRAINT [FK_HotelOfficers_Hotels]
GO
ALTER TABLE [Hotel].[HotelOfficers] DROP CONSTRAINT [FK_HotelOfficers_HotelOfficerRoles]
GO
ALTER TABLE [Hotel].[HotelExpense] DROP CONSTRAINT [FK_HotelExpense_Hotels]
GO
ALTER TABLE [Hotel].[HotelExpense] DROP CONSTRAINT [FK_HotelExpense_HotelExpenTypes]
GO
/****** Object:  Table [Travel].[Route]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Travel].[Route]') AND type in (N'U'))
DROP TABLE [Travel].[Route]
GO
/****** Object:  Table [Setup].[RoomTypes]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Setup].[RoomTypes]') AND type in (N'U'))
DROP TABLE [Setup].[RoomTypes]
GO
/****** Object:  Table [Setup].[MenuRights]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Setup].[MenuRights]') AND type in (N'U'))
DROP TABLE [Setup].[MenuRights]
GO
/****** Object:  Table [Setup].[Menues]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Setup].[Menues]') AND type in (N'U'))
DROP TABLE [Setup].[Menues]
GO
/****** Object:  Table [Setup].[HotelTypes]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Setup].[HotelTypes]') AND type in (N'U'))
DROP TABLE [Setup].[HotelTypes]
GO
/****** Object:  Table [Setup].[Companies]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Setup].[Companies]') AND type in (N'U'))
DROP TABLE [Setup].[Companies]
GO
/****** Object:  Table [Setup].[Cities]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Setup].[Cities]') AND type in (N'U'))
DROP TABLE [Setup].[Cities]
GO
/****** Object:  Table [Hotel].[Tables]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Tables]') AND type in (N'U'))
DROP TABLE [Hotel].[Tables]
GO
/****** Object:  Table [Hotel].[Services]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Services]') AND type in (N'U'))
DROP TABLE [Hotel].[Services]
GO
/****** Object:  Table [Hotel].[RoomServices]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[RoomServices]') AND type in (N'U'))
DROP TABLE [Hotel].[RoomServices]
GO
/****** Object:  Table [Hotel].[Rooms]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Rooms]') AND type in (N'U'))
DROP TABLE [Hotel].[Rooms]
GO
/****** Object:  Table [Hotel].[Roles]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Roles]') AND type in (N'U'))
DROP TABLE [Hotel].[Roles]
GO
/****** Object:  Table [Hotel].[Officers]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Officers]') AND type in (N'U'))
DROP TABLE [Hotel].[Officers]
GO
/****** Object:  Table [Hotel].[Hotels]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Hotels]') AND type in (N'U'))
DROP TABLE [Hotel].[Hotels]
GO
/****** Object:  Table [Hotel].[HotelOfficers]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[HotelOfficers]') AND type in (N'U'))
DROP TABLE [Hotel].[HotelOfficers]
GO
/****** Object:  Table [Hotel].[HotelOfficerRoles]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[HotelOfficerRoles]') AND type in (N'U'))
DROP TABLE [Hotel].[HotelOfficerRoles]
GO
/****** Object:  Table [Hotel].[HotelExpenTypes]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[HotelExpenTypes]') AND type in (N'U'))
DROP TABLE [Hotel].[HotelExpenTypes]
GO
/****** Object:  Table [Hotel].[HotelExpense]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[HotelExpense]') AND type in (N'U'))
DROP TABLE [Hotel].[HotelExpense]
GO
/****** Object:  Table [Hotel].[Hall]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Hall]') AND type in (N'U'))
DROP TABLE [Hotel].[Hall]
GO
/****** Object:  Table [Hotel].[Floors]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Floors]') AND type in (N'U'))
DROP TABLE [Hotel].[Floors]
GO
/****** Object:  Table [Hotel].[Facilities]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Facilities]') AND type in (N'U'))
DROP TABLE [Hotel].[Facilities]
GO
/****** Object:  Table [Hotel].[ExpenseTypes]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[ExpenseTypes]') AND type in (N'U'))
DROP TABLE [Hotel].[ExpenseTypes]
GO
/****** Object:  Table [Hotel].[Expenses]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Expenses]') AND type in (N'U'))
DROP TABLE [Hotel].[Expenses]
GO
/****** Object:  Table [Hotel].[Countries]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Countries]') AND type in (N'U'))
DROP TABLE [Hotel].[Countries]
GO
/****** Object:  Table [Hotel].[Buildings]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Hotel].[Buildings]') AND type in (N'U'))
DROP TABLE [Hotel].[Buildings]
GO
/****** Object:  Table [Bookings].[Users]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Bookings].[Users]') AND type in (N'U'))
DROP TABLE [Bookings].[Users]
GO
/****** Object:  Table [Bookings].[TableBookings]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Bookings].[TableBookings]') AND type in (N'U'))
DROP TABLE [Bookings].[TableBookings]
GO
/****** Object:  Table [Bookings].[RoomBookings]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Bookings].[RoomBookings]') AND type in (N'U'))
DROP TABLE [Bookings].[RoomBookings]
GO
/****** Object:  Table [Bookings].[HotelBookings]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Bookings].[HotelBookings]') AND type in (N'U'))
DROP TABLE [Bookings].[HotelBookings]
GO
/****** Object:  Table [Bookings].[HallBookings]    Script Date: 07/04/2021 7:16:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Bookings].[HallBookings]') AND type in (N'U'))
DROP TABLE [Bookings].[HallBookings]
GO
/****** Object:  Schema [Travel]    Script Date: 07/04/2021 7:16:04 PM ******/
DROP SCHEMA [Travel]
GO
/****** Object:  Schema [Setup]    Script Date: 07/04/2021 7:16:04 PM ******/
DROP SCHEMA [Setup]
GO
/****** Object:  Schema [Hotel]    Script Date: 07/04/2021 7:16:04 PM ******/
DROP SCHEMA [Hotel]
GO
/****** Object:  Schema [Bookings]    Script Date: 07/04/2021 7:16:04 PM ******/
DROP SCHEMA [Bookings]
GO
USE [master]
GO
/****** Object:  Database [FizzHotleBooking]    Script Date: 07/04/2021 7:16:04 PM ******/
DROP DATABASE [FizzHotleBooking]
GO
/****** Object:  Database [FizzHotleBooking]    Script Date: 07/04/2021 7:16:04 PM ******/
CREATE DATABASE [FizzHotleBooking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FizzHotleBooking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FizzHotleBooking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FizzHotleBooking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FizzHotleBooking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FizzHotleBooking] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FizzHotleBooking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FizzHotleBooking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET ARITHABORT OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FizzHotleBooking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FizzHotleBooking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FizzHotleBooking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FizzHotleBooking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FizzHotleBooking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET RECOVERY FULL 
GO
ALTER DATABASE [FizzHotleBooking] SET  MULTI_USER 
GO
ALTER DATABASE [FizzHotleBooking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FizzHotleBooking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FizzHotleBooking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FizzHotleBooking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FizzHotleBooking] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FizzHotleBooking] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FizzHotleBooking', N'ON'
GO
ALTER DATABASE [FizzHotleBooking] SET QUERY_STORE = OFF
GO
USE [FizzHotleBooking]
GO
/****** Object:  Schema [Bookings]    Script Date: 07/04/2021 7:16:04 PM ******/
CREATE SCHEMA [Bookings]
GO
/****** Object:  Schema [Hotel]    Script Date: 07/04/2021 7:16:04 PM ******/
CREATE SCHEMA [Hotel]
GO
/****** Object:  Schema [Setup]    Script Date: 07/04/2021 7:16:04 PM ******/
CREATE SCHEMA [Setup]
GO
/****** Object:  Schema [Travel]    Script Date: 07/04/2021 7:16:04 PM ******/
CREATE SCHEMA [Travel]
GO
/****** Object:  Table [Bookings].[HallBookings]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bookings].[HallBookings](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CheckInDate] [date] NOT NULL,
	[CheckInTime] [time](7) NOT NULL,
	[CheckOutDate] [date] NULL,
	[CheckOutTime] [time](7) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
	[Status] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[Email] [nvarchar](50) NULL,
	[IsBooked] [bit] NULL,
	[IsBookedOnline] [bit] NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[HallId] [uniqueidentifier] NOT NULL,
	[TotalBill] [money] NULL,
	[DiscountAmount] [money] NULL,
	[HotelId] [uniqueidentifier] NULL,
	[BuildingId] [uniqueidentifier] NULL,
	[CityId] [uniqueidentifier] NULL,
	[CountryId] [uniqueidentifier] NULL,
	[Fare] [money] NULL,
	[FloorId] [uniqueidentifier] NULL,
	[IsLeave] [bit] NULL,
	[PaidAmount] [money] NULL,
	[IsPaid] [bit] NULL,
	[RemainingAmount] [money] NULL,
	[DaysCount] [int] NULL,
	[TotalFare] [money] NULL,
 CONSTRAINT [PK_HallBookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Bookings].[HotelBookings]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bookings].[HotelBookings](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContactNo] [nvarchar](50) NULL,
	[CheckInDate] [date] NOT NULL,
	[CheckInTime] [time](7) NOT NULL,
	[CheckOutDate] [date] NOT NULL,
	[CheckOutTime] [time](7) NOT NULL,
	[IsDeleted] [bit] NULL,
	[Status] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[Email] [nvarchar](50) NULL,
	[IsBooked] [bit] NULL,
	[IsBookedOnline] [bit] NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[TotalBill] [money] NULL,
	[DiscountAmount] [money] NULL,
	[CityId] [uniqueidentifier] NULL,
	[CountryId] [uniqueidentifier] NULL,
	[Fare] [money] NULL,
 CONSTRAINT [PK_HotelBookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Bookings].[RoomBookings]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bookings].[RoomBookings](
	[Id] [uniqueidentifier] NOT NULL,
	[TypeId] [uniqueidentifier] NOT NULL,
	[CheckInDate] [date] NULL,
	[CheckOutDate] [date] NULL,
	[Adults] [int] NULL,
	[Childrens] [int] NULL,
	[CheckInTime] [time](7) NULL,
	[CheckOutTime] [time](7) NULL,
	[IsDeleted] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[IsBooked] [bit] NULL,
	[IsBookedOnline] [bit] NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[RoomId] [uniqueidentifier] NOT NULL,
	[TotalBill] [money] NULL,
	[DiscountAmount] [money] NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[BuildingId] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[CityId] [uniqueidentifier] NOT NULL,
	[FloorId] [uniqueidentifier] NOT NULL,
	[IsPaid] [bit] NULL,
	[RemainingAmount] [money] NULL,
	[FarePerNight] [money] NULL,
	[NightsCount] [int] NULL,
	[TotalFare] [money] NULL,
	[PaidAmount] [money] NULL,
	[IsLeave] [bit] NULL,
 CONSTRAINT [PK_RoomBookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Bookings].[TableBookings]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bookings].[TableBookings](
	[Id] [uniqueidentifier] NOT NULL,
	[CheckInDate] [date] NULL,
	[CheckOutDate] [date] NULL,
	[NoOfPersons] [int] NULL,
	[CheckInTime] [time](0) NULL,
	[CheckOutTime] [time](0) NULL,
	[IsDeleted] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[IsBooked] [bit] NULL,
	[IsBookedOnline] [bit] NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[TableId] [uniqueidentifier] NOT NULL,
	[DiscountAmount] [money] NULL,
	[HotelId] [uniqueidentifier] NULL,
	[BuildingId] [uniqueidentifier] NULL,
	[CountryId] [uniqueidentifier] NULL,
	[CityId] [uniqueidentifier] NULL,
	[TotalFare] [money] NULL,
	[FloorId] [uniqueidentifier] NULL,
	[IsRemaining] [money] NULL,
	[IsPaid] [money] NULL,
	[FarePerHour] [money] NULL,
 CONSTRAINT [PK_TableBookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Bookings].[Users]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Bookings].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[CNIC] [nvarchar](13) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Buildings]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Buildings](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NULL,
	[Address] [nvarchar](500) NULL,
	[ImageUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Countries]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Countries](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Expenses]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Expenses](
	[Id] [uniqueidentifier] NOT NULL,
	[ExpenseTypeId] [uniqueidentifier] NOT NULL,
	[Amount] [int] NOT NULL,
	[ExpenseDescription] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreationDate] [datetime] NULL,
 CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[ExpenseTypes]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[ExpenseTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[ExpenseType] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ExpenseType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Facilities]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Facilities](
	[Id] [uniqueidentifier] NOT NULL,
	[FacilityName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Facilities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Floors]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Floors](
	[Id] [uniqueidentifier] NOT NULL,
	[FloorNo] [nvarchar](50) NULL,
	[BuildingId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[ImageUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Floors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Hall]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Hall](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Length] [nvarchar](50) NULL,
	[width] [nvarchar](50) NULL,
	[Height] [nvarchar](50) NULL,
	[RoomSize] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[IsBooked] [bit] NULL,
	[IsBookedOnline] [bit] NULL,
	[Fare] [money] NULL,
	[IsAvailable] [bit] NULL,
 CONSTRAINT [PK_Hall] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[HotelExpense]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[HotelExpense](
	[Id] [uniqueidentifier] NOT NULL,
	[ExpenseTypeId] [uniqueidentifier] NULL,
	[Amount] [int] NULL,
	[ExpenseDescription] [varchar](200) NULL,
	[IsDeleted] [bit] NULL,
	[CreationDate] [datetime] NOT NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_HotelExpense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[HotelExpenTypes]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[HotelExpenTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[ExpenseType] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_HotelExpenTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[HotelOfficerRoles]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[HotelOfficerRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_HotelOfficerRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[HotelOfficers]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[HotelOfficers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Mobile] [varchar](50) NULL,
	[IsDeleted] [bit] NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[HotelOfficerRoleId] [int] NOT NULL,
 CONSTRAINT [PK_Hotel.HotelOfficers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Hotels]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Hotels](
	[Id] [uniqueidentifier] NOT NULL,
	[HotelLogo] [nvarchar](200) NULL,
	[HotelName] [nvarchar](300) NOT NULL,
	[HotelPhone] [nvarchar](50) NULL,
	[HotelMobile] [nvarchar](50) NULL,
	[HotelEmail] [nvarchar](100) NULL,
	[HotelAddress] [nvarchar](1000) NULL,
	[HotelWebsite] [nvarchar](50) NULL,
	[HotelCityId] [uniqueidentifier] NOT NULL,
	[HotelCountryId] [uniqueidentifier] NOT NULL,
	[HotelTypeId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[Password] [nvarchar](max) NULL,
	[Location] [geography] NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Officers]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Officers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[Mobile] [nvarchar](50) NULL,
	[RoleId] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Officers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Roles]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Rooms]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Rooms](
	[Id] [uniqueidentifier] NOT NULL,
	[TypeId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[MaxNoOfPersons] [int] NULL,
	[RoomView] [nvarchar](200) NULL,
	[NoOfBeds] [int] NULL,
	[IsDeleted] [bit] NULL,
	[FloorId] [uniqueidentifier] NOT NULL,
	[BuildingId] [uniqueidentifier] NOT NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[RoomNo] [nvarchar](50) NULL,
	[FarePerNight] [money] NOT NULL,
	[IsBooked] [bit] NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[DiscountAmount] [money] NOT NULL,
	[IsBookedOnline] [bit] NULL,
	[IsAvailable] [bit] NULL,
 CONSTRAINT [PK_RoomTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[RoomServices]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[RoomServices](
	[Id] [uniqueidentifier] NOT NULL,
	[ServiceId] [uniqueidentifier] NOT NULL,
	[RoomId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_RoomServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Services]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Services](
	[Id] [uniqueidentifier] NOT NULL,
	[ServiceName] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hotel].[Tables]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hotel].[Tables](
	[Id] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NULL,
	[TableNo] [nvarchar](50) NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[TableView] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NOT NULL,
	[MaxNoOfPersons] [int] NULL,
	[FarePerHour] [money] NOT NULL,
	[FloorId] [uniqueidentifier] NOT NULL,
	[BuildingId] [uniqueidentifier] NOT NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[IsBooked] [bit] NULL,
	[IsBookedOnline] [bit] NULL,
	[IsAvailable] [bit] NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setup].[Cities]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setup].[Cities](
	[Id] [uniqueidentifier] NOT NULL,
	[CityName] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[IsDeleted] [bit] NULL,
	[CountryId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setup].[Companies]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setup].[Companies](
	[Id] [uniqueidentifier] NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[UserFirstName] [nvarchar](50) NULL,
	[UserLastName] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[CompanySite] [nvarchar](50) NULL,
	[AddressOne] [nvarchar](500) NULL,
	[AddressTwo] [nvarchar](500) NULL,
	[PostCode] [nvarchar](10) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setup].[HotelTypes]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setup].[HotelTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_HotelTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setup].[Menues]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setup].[Menues](
	[Id] [int] NOT NULL,
	[Area] [nvarchar](500) NULL,
	[Controller] [nvarchar](500) NULL,
	[Action] [nvarchar](500) NULL,
	[Name] [nvarchar](500) NULL,
	[ParentId] [int] NULL,
	[IsMenu] [bit] NULL,
	[IsSubMenu] [bit] NULL,
	[IsAction] [bit] NULL,
 CONSTRAINT [PK_Menues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setup].[MenuRights]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setup].[MenuRights](
	[Id] [int] NOT NULL,
	[RoleId] [int] NULL,
	[MenuId] [int] NULL,
	[IsAllowed] [int] NULL,
 CONSTRAINT [PK_MenuRights] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Setup].[RoomTypes]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setup].[RoomTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](200) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Travel].[Route]    Script Date: 07/04/2021 7:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Travel].[Route](
	[Id] [uniqueidentifier] NOT NULL,
	[FromCity] [nvarchar](50) NULL,
	[ToCity] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'21a09e48-53d6-436c-94b1-03ee82c6fa2b', N'teest user1', CAST(N'2021-06-16' AS Date), CAST(N'00:16:00' AS Time), NULL, NULL, N'3654d', NULL, NULL, CAST(N'2021-06-20T00:13:46.223' AS DateTime), N'email@em', 0, 0, N'd304188b-7228-4590-b02d-860a23239195', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'973251b1-51ab-494d-9907-064033769047', N'tahir', CAST(N'2021-06-22' AS Date), CAST(N'14:11:00' AS Time), CAST(N'2021-06-17' AS Date), CAST(N'02:50:00' AS Time), N'3654', 1, NULL, CAST(N'2021-06-21T00:11:59.000' AS DateTime), N'email@em', 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'32c0722b-78b5-4c94-a045-82994523eacd', 5000.0000, 1000.0000, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 2000.0000, NULL, NULL, 2000.0000, 0, 3000.0000, 3, 6000.0000)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'3c566577-4aff-428d-8d3e-07c353d27246', N'adnan', CAST(N'2021-05-06' AS Date), CAST(N'17:28:00' AS Time), CAST(N'2021-05-06' AS Date), CAST(N'17:28:00' AS Time), N'view', NULL, NULL, CAST(N'2021-05-06T17:29:06.257' AS DateTime), N'email', 1, 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'94cc0301-c449-44c8-8070-0df40bea7981', N'teest user1 edit', CAST(N'2021-07-09' AS Date), CAST(N'17:59:00' AS Time), NULL, NULL, N'3654d0000', 1, NULL, CAST(N'2021-07-03T15:59:35.980' AS DateTime), N'email@email.com', 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'3c111d3a-f79e-4cde-ade9-10cf75589ff8', N'tahir', CAST(N'2021-06-23' AS Date), CAST(N'00:11:00' AS Time), NULL, NULL, N'3654', NULL, NULL, CAST(N'2021-06-20T00:09:39.180' AS DateTime), N'email@em', 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'b40f78ab-20d8-4aa7-ab8e-11d744793579', N'NEW USER 01', CAST(N'2021-07-15' AS Date), CAST(N'16:00:00' AS Time), NULL, NULL, N'3654d0000', 1, NULL, CAST(N'2021-07-03T16:00:55.690' AS DateTime), N'email@emai.com', 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'aaa31d18-deff-4cf6-aa49-14679cc8b23f', N'ADNAN', CAST(N'2021-05-05' AS Date), CAST(N'17:00:00' AS Time), CAST(N'2021-05-06' AS Date), CAST(N'17:00:00' AS Time), N'03003000000', NULL, NULL, CAST(N'2021-05-05T17:00:29.523' AS DateTime), N'MAIL@mail.com', 1, 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'c31f7119-f19e-461d-9c38-1e2173eaec1f', N'tahir', CAST(N'2021-06-18' AS Date), CAST(N'13:39:00' AS Time), NULL, NULL, N'3654', 1, NULL, CAST(N'2021-06-19T23:40:08.473' AS DateTime), N'email@em', 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'f5a066cb-c23e-4504-a25c-a1016954a937', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'3c1b2bae-49f1-4d70-933c-262dfa897bc3', N'teest user1', CAST(N'2021-06-16' AS Date), CAST(N'03:25:00' AS Time), CAST(N'0001-01-01' AS Date), CAST(N'00:00:00' AS Time), N'3654d', NULL, NULL, CAST(N'2021-06-16T01:25:32.123' AS DateTime), N'email@em', 0, 0, N'd304188b-7228-4590-b02d-860a23239195', N'64bd13b8-6fa7-4214-bd0e-0844fc89b27b', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'd01f0a9f-9944-4f83-a280-2f90be6d3636', N'tahir', CAST(N'2021-06-19' AS Date), CAST(N'13:51:00' AS Time), CAST(N'2021-06-24' AS Date), CAST(N'14:52:00' AS Time), N'3654', NULL, NULL, CAST(N'2021-06-19T23:51:46.000' AS DateTime), N'email@em', 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', 4000.0000, 1000.0000, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, 1, 2000.0000, 0, 2000.0000, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'9cccc941-0045-403a-bdbc-3cc421eff50c', N'teest user1 edit', CAST(N'2021-07-09' AS Date), CAST(N'17:47:00' AS Time), NULL, NULL, N'3654d', 1, NULL, CAST(N'2021-07-03T15:45:08.737' AS DateTime), N'email@email.com', 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'dd105bce-b12a-427d-b2f3-411502dc58be', N'name', CAST(N'2021-05-06' AS Date), CAST(N'17:44:00' AS Time), CAST(N'2021-05-07' AS Date), CAST(N'17:45:00' AS Time), N'03003000000', NULL, NULL, CAST(N'2021-05-06T17:44:47.017' AS DateTime), N'email', 1, 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'aefebb91-546f-47fa-a8fb-4bbf33136b73', N'tahir', CAST(N'2021-06-21' AS Date), CAST(N'03:14:00' AS Time), NULL, NULL, N'3654', 1, NULL, CAST(N'2021-06-20T00:14:04.673' AS DateTime), N'email@em', 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'd7e46ec0-fccf-445f-aaf1-53c647cfd00c', N'tahir', CAST(N'2021-07-07' AS Date), CAST(N'15:28:00' AS Time), NULL, NULL, N'3654', 1, NULL, CAST(N'2021-07-03T15:27:26.493' AS DateTime), N'email@em', 0, 1, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'0217dfb2-6da5-457f-ad96-5c47bd465e2e', N'tahir testing 2', CAST(N'2021-06-25' AS Date), CAST(N'12:49:00' AS Time), CAST(N'2021-06-25' AS Date), CAST(N'12:43:00' AS Time), N'3362444766', NULL, NULL, CAST(N'2021-06-19T23:53:02.000' AS DateTime), N'Mail@.com123', 0, NULL, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'd114a1f3-c982-49b1-8209-fe2b85ad4a07', 4500.0000, 500.0000, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, 1, 1000.0000, 1, 3500.0000, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'0c056c1e-facf-4c43-97bb-5f57691274ff', N'tahir', CAST(N'2021-06-10' AS Date), CAST(N'02:14:00' AS Time), CAST(N'2021-06-13' AS Date), CAST(N'14:12:00' AS Time), N'3654', NULL, NULL, CAST(N'2021-06-20T00:14:19.000' AS DateTime), N'email@em', 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'd114a1f3-c982-49b1-8209-fe2b85ad4a07', 8000.0000, 1000.0000, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 3000.0000, NULL, 1, 4000.0000, 0, 4000.0000, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'dd7e374f-fd15-4354-9946-646ded3bbd0f', N'tahir', CAST(N'2021-07-14' AS Date), CAST(N'15:38:00' AS Time), NULL, NULL, N'3654', 1, NULL, CAST(N'2021-07-03T15:36:09.223' AS DateTime), N'email@em', 0, 1, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'ac74a3d8-8abb-4831-9d97-7095ee0c56a5', N'tahir', CAST(N'2021-06-18' AS Date), CAST(N'23:58:00' AS Time), NULL, NULL, N'3654', NULL, NULL, CAST(N'2021-06-19T23:58:25.587' AS DateTime), N'email@em', 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'd114a1f3-c982-49b1-8209-fe2b85ad4a07', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 3000.0000, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'06a2edd6-fdb7-428b-9adf-79ba68e5a9a9', N'teest user12', CAST(N'2021-07-15' AS Date), CAST(N'18:37:00' AS Time), NULL, NULL, N'3654d', 1, NULL, CAST(N'2021-07-03T15:37:46.303' AS DateTime), N'email@em', 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'c41f833d-1fe7-4910-b9a0-7cb1f911ea5b', N'adnan', CAST(N'2021-05-05' AS Date), CAST(N'18:10:00' AS Time), CAST(N'2021-05-05' AS Date), CAST(N'05:10:00' AS Time), N'03003000000', NULL, NULL, CAST(N'2021-05-06T17:11:04.387' AS DateTime), N'email', 1, 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'dd658868-f6cb-4418-b2d4-860bc955ff12', N'teest user1', CAST(N'2021-07-09' AS Date), CAST(N'18:34:00' AS Time), NULL, NULL, N'3654d', 1, NULL, CAST(N'2021-07-03T15:34:51.267' AS DateTime), N'email@em', 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'd114a1f3-c982-49b1-8209-fe2b85ad4a07', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 3000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'0fb2cd00-5d30-47b6-a229-8805a86c1d35', N'tahir', CAST(N'2021-07-07' AS Date), CAST(N'15:28:00' AS Time), NULL, NULL, N'3654', NULL, NULL, CAST(N'2021-07-03T15:29:18.680' AS DateTime), N'email@em', 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'143829b9-557c-4ca9-bc0f-9735bb8cd248', N'NEW USER 03', CAST(N'2021-07-30' AS Date), CAST(N'19:15:00' AS Time), NULL, NULL, N'3654d0000', NULL, NULL, CAST(N'2021-07-03T17:15:54.150' AS DateTime), N'email@emai.com', 1, 1, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'd114a1f3-c982-49b1-8209-fe2b85ad4a07', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'26a5211d-4a8b-46b1-a846-f78e78631560', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'94fa72f3-9184-410f-803a-76e624767b81', NULL, N'064fa944-f2ad-4d6b-820e-0952955ac849', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'08aa3ae8-3d7f-4b61-a254-98b570cf5c8a', N'teest user1', CAST(N'2021-07-01' AS Date), CAST(N'17:34:00' AS Time), NULL, NULL, N'3654d', 1, NULL, CAST(N'2021-07-03T15:34:07.840' AS DateTime), N'email@em', 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'430a0bc8-73a3-4a9c-9e87-a07b9c22384a', N'teest user1', CAST(N'2021-07-08' AS Date), CAST(N'15:35:00' AS Time), NULL, NULL, N'3654d', 1, NULL, CAST(N'2021-07-03T15:33:21.117' AS DateTime), N'email@em', 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'31f153ef-9ace-4e17-9630-a25cf23c7611', N'teest user1', CAST(N'2021-07-08' AS Date), CAST(N'18:39:00' AS Time), NULL, NULL, N'3654d', 1, NULL, CAST(N'2021-07-03T15:40:08.310' AS DateTime), N'email@em', 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'17683e2e-c561-4714-9856-b2ba930a2428', N'teest user1', CAST(N'2021-06-18' AS Date), CAST(N'04:22:00' AS Time), CAST(N'0001-01-12' AS Date), CAST(N'01:00:00' AS Time), N'3654d', 1, NULL, CAST(N'2021-06-16T01:22:45.000' AS DateTime), N'email@em', 0, 0, N'd304188b-7228-4590-b02d-860a23239195', N'00000000-0000-0000-0000-000000000000', 2000.0000, 1000.0000, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 3000.0000, NULL, NULL, 1000.0000, 1, 1000.0000, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'afa78920-2321-431b-8f09-b3df9cf27b17', N'teest user1', CAST(N'2021-06-17' AS Date), CAST(N'01:20:00' AS Time), CAST(N'0001-01-01' AS Date), CAST(N'00:00:00' AS Time), N'3654d', 1, NULL, CAST(N'2021-06-16T01:19:00.000' AS DateTime), N'email@em', 0, 0, N'd304188b-7228-4590-b02d-860a23239195', N'00000000-0000-0000-0000-000000000000', 0.0000, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, NULL, NULL, NULL, 0.0000, 1, 0.0000, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'c610e8a9-871f-4784-b7ba-c252526bcadf', N'teest user1 edit', CAST(N'2021-07-14' AS Date), CAST(N'18:51:00' AS Time), NULL, NULL, N'3654d0000', 1, NULL, CAST(N'2021-07-03T15:48:33.850' AS DateTime), N'email@email.com', 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'0fc16db1-3316-43df-b724-c6a348192120', N'a', CAST(N'2021-05-05' AS Date), CAST(N'18:09:00' AS Time), CAST(N'2021-05-06' AS Date), CAST(N'19:09:00' AS Time), N'ss', NULL, NULL, CAST(N'2021-05-05T18:10:01.287' AS DateTime), N'a', 1, 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'2f963786-b577-4ac1-987a-c9a5814a482d', N'teest user1', CAST(N'2021-06-11' AS Date), CAST(N'14:55:00' AS Time), NULL, NULL, N'3654d', NULL, NULL, CAST(N'2021-06-19T23:55:11.457' AS DateTime), N'email@em', 0, 0, N'd304188b-7228-4590-b02d-860a23239195', N'd114a1f3-c982-49b1-8209-fe2b85ad4a07', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 3000.0000, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'6bc2cecc-6e8c-486a-a98b-e37e9cef7d09', N'adnan', CAST(N'2021-05-05' AS Date), CAST(N'18:10:00' AS Time), CAST(N'2021-05-05' AS Date), CAST(N'05:10:00' AS Time), N'03003000000', NULL, NULL, CAST(N'2021-05-06T17:11:02.443' AS DateTime), N'email', 1, 0, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'67c5f21e-18a6-4dff-a696-ee2892c9d61c', N'tahir123', CAST(N'0001-01-01' AS Date), CAST(N'00:00:00' AS Time), NULL, NULL, N'3654000', NULL, NULL, NULL, N'email@em', NULL, NULL, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Bookings].[HallBookings] ([Id], [Name], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [ContactNo], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HallId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CityId], [CountryId], [Fare], [FloorId], [IsLeave], [PaidAmount], [IsPaid], [RemainingAmount], [DaysCount], [TotalFare]) VALUES (N'3e175381-8be6-4f51-b277-f6eda81e47e9', N'NEW USER 02', CAST(N'2021-07-08' AS Date), CAST(N'16:05:00' AS Time), NULL, NULL, N'3654', NULL, NULL, CAST(N'2021-07-03T16:03:21.150' AS DateTime), N'email@email.com', 1, 1, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, 5000.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [Bookings].[HotelBookings] ([Id], [Name], [ContactNo], [CheckInDate], [CheckInTime], [CheckOutDate], [CheckOutTime], [IsDeleted], [Status], [CreateDate], [Email], [IsBooked], [IsBookedOnline], [UserId], [HotelId], [TotalBill], [DiscountAmount], [CityId], [CountryId], [Fare]) VALUES (N'af1e1e2a-cb39-4af0-8825-f6125a235849', N'tahir', N'09898', CAST(N'2021-06-02' AS Date), CAST(N'10:32:00' AS Time), CAST(N'2021-06-09' AS Date), CAST(N'20:33:00' AS Time), NULL, NULL, CAST(N'2021-06-05T20:30:16.017' AS DateTime), N'email@us', NULL, NULL, N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'98aa9663-3fe9-4226-aaa8-1b63963977a3', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', CAST(N'2021-07-01' AS Date), NULL, NULL, NULL, CAST(N'16:41:00' AS Time), NULL, NULL, CAST(N'2021-07-04T15:42:00.803' AS DateTime), 0, NULL, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'e6ff6e10-842e-4cf0-b204-3154fe268771', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'033837f0-4fcb-433a-9507-5016da697dfd', 0, NULL, 2000.0000, 0, NULL, NULL, 1)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'f2422e5f-8766-4f43-ba63-230c6b092e18', N'0257fb01-85f4-4a25-99ef-947e79c35899', CAST(N'2021-06-04' AS Date), NULL, NULL, NULL, CAST(N'22:29:00' AS Time), NULL, 1, CAST(N'2021-06-07T22:26:17.343' AS DateTime), 0, NULL, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'7843cf78-fb5f-4572-b593-3574170dbdaa', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 0.0000, NULL, NULL, NULL, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'd1b6e06b-3b89-4ad6-8fc0-2edcd02eb185', N'0257fb01-85f4-4a25-99ef-947e79c35899', CAST(N'2021-06-13' AS Date), CAST(N'2021-06-17' AS Date), NULL, NULL, CAST(N'12:50:00' AS Time), CAST(N'03:19:00' AS Time), NULL, CAST(N'2021-06-13T23:51:01.000' AS DateTime), 0, NULL, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'6ba029bb-7b24-4628-a3b2-57dc00d909e0', 6000.0000, 1000.0000, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'033837f0-4fcb-433a-9507-5016da697dfd', 1, 2000.0000, 1000.0000, 6, 6000.0000, 2000.0000, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'd5233856-31a1-49b6-8946-490df788fab9', N'0257fb01-85f4-4a25-99ef-947e79c35899', CAST(N'2021-06-17' AS Date), NULL, NULL, NULL, CAST(N'22:49:00' AS Time), NULL, NULL, CAST(N'2021-06-07T22:46:38.570' AS DateTime), 1, NULL, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'7843cf78-fb5f-4572-b593-3574170dbdaa', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 0.0000, NULL, NULL, NULL, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'335de895-c452-47d5-862a-4a3af679e22d', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', CAST(N'2021-06-16' AS Date), NULL, NULL, NULL, CAST(N'01:57:00' AS Time), NULL, NULL, CAST(N'2021-06-07T22:54:06.633' AS DateTime), 0, NULL, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'e6ff6e10-842e-4cf0-b204-3154fe268771', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 2000.0000, NULL, NULL, NULL, 1)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'd55a88c5-682c-4922-a45a-5e01bd99b2bf', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', CAST(N'2021-05-30' AS Date), NULL, NULL, NULL, CAST(N'21:25:00' AS Time), NULL, NULL, CAST(N'2021-05-30T21:25:42.760' AS DateTime), 1, NULL, N'df426a0c-4325-4efc-ba8f-bf5ffffdd235', N'4083acc8-8e4d-4022-9914-dc30281d5a63', NULL, NULL, N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'd142e96b-5e8a-4605-b4ee-c884450e24e5', NULL, NULL, 1200.0000, NULL, NULL, NULL, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'7facc473-eb43-475a-a20e-5e8081b8b6e9', N'0257fb01-85f4-4a25-99ef-947e79c35899', CAST(N'2021-05-30' AS Date), NULL, NULL, NULL, CAST(N'19:35:00' AS Time), NULL, NULL, CAST(N'2021-05-30T19:35:24.257' AS DateTime), 1, NULL, N'df426a0c-4325-4efc-ba8f-bf5ffffdd235', N'3d1d958e-3beb-4b23-838a-0c9494a373eb', 1080.0000, 120.0000, N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'd142e96b-5e8a-4605-b4ee-c884450e24e5', 1, NULL, 1200.0000, NULL, NULL, NULL, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'9ffeb443-b948-42ec-866f-65043a5a73f9', N'0257fb01-85f4-4a25-99ef-947e79c35899', CAST(N'2021-06-11' AS Date), NULL, NULL, NULL, CAST(N'22:42:00' AS Time), NULL, 1, CAST(N'2021-06-07T22:39:13.323' AS DateTime), 0, NULL, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'7843cf78-fb5f-4572-b593-3574170dbdaa', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 0.0000, NULL, NULL, NULL, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'6dace4b0-0da6-44da-b578-7fef6fc5d29b', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', CAST(N'2021-06-12' AS Date), NULL, NULL, NULL, CAST(N'01:24:00' AS Time), NULL, 1, CAST(N'2021-06-07T01:21:22.473' AS DateTime), 0, NULL, N'd304188b-7228-4590-b02d-860a23239195', N'e6ff6e10-842e-4cf0-b204-3154fe268771', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 2000.0000, NULL, NULL, NULL, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'b6bd1cc6-d9e9-4a93-9d4d-99752f9b9ca3', N'0257fb01-85f4-4a25-99ef-947e79c35899', CAST(N'2021-05-30' AS Date), NULL, NULL, NULL, CAST(N'20:09:00' AS Time), NULL, NULL, CAST(N'2021-05-30T20:10:09.910' AS DateTime), 1, NULL, N'df426a0c-4325-4efc-ba8f-bf5ffffdd235', N'f2243f59-fe01-431f-abb9-c64e0b2ae70a', 1000.0000, 200.0000, N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'd142e96b-5e8a-4605-b4ee-c884450e24e5', 1, 200.0000, 1200.0000, NULL, NULL, NULL, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'2f573400-0dc2-4749-ae0e-9bf21481fa29', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', CAST(N'2021-06-12' AS Date), NULL, NULL, NULL, CAST(N'00:50:00' AS Time), NULL, NULL, CAST(N'2021-06-12T23:50:01.057' AS DateTime), 0, NULL, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'ceacc8e4-f712-4a59-acbc-e3ac5d6c69ff', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'5176df2b-d23d-4ea7-8611-bc66754ea9f7', NULL, NULL, 3500.0000, NULL, NULL, NULL, 1)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'32d644a9-b678-404c-ae7d-a7a15309cbf3', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', CAST(N'2021-07-30' AS Date), NULL, NULL, NULL, CAST(N'19:36:00' AS Time), NULL, NULL, CAST(N'2021-07-03T16:34:04.780' AS DateTime), 0, 1, N'd304188b-7228-4590-b02d-860a23239195', N'e6ff6e10-842e-4cf0-b204-3154fe268771', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'688f8c5c-1fd7-493a-a6bf-b03184638370', N'0257fb01-85f4-4a25-99ef-947e79c35899', CAST(N'2021-06-16' AS Date), NULL, NULL, NULL, CAST(N'01:22:00' AS Time), NULL, NULL, CAST(N'2021-06-15T01:20:37.000' AS DateTime), 0, NULL, N'd304188b-7228-4590-b02d-860a23239195', N'10b6b9b3-7c25-4722-9a83-0dfa26f0704c', 5000.0000, 5000.0000, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'033837f0-4fcb-433a-9507-5016da697dfd', 1, 0.0000, 1000.0000, 10, 10000.0000, 5000.0000, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'61c5dca5-7c4a-48ed-a606-ea76b9def19f', N'0257fb01-85f4-4a25-99ef-947e79c35899', CAST(N'2021-06-03' AS Date), NULL, NULL, NULL, CAST(N'13:48:00' AS Time), NULL, 1, CAST(N'2021-06-07T22:45:44.210' AS DateTime), 0, NULL, N'd304188b-7228-4590-b02d-860a23239195', N'7843cf78-fb5f-4572-b593-3574170dbdaa', NULL, NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 0.0000, NULL, NULL, NULL, NULL)
INSERT [Bookings].[RoomBookings] ([Id], [TypeId], [CheckInDate], [CheckOutDate], [Adults], [Childrens], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [IsBooked], [IsBookedOnline], [UserId], [RoomId], [TotalBill], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [FloorId], [IsPaid], [RemainingAmount], [FarePerNight], [NightsCount], [TotalFare], [PaidAmount], [IsLeave]) VALUES (N'913bc626-bfaf-4e3b-9a45-f0c659a357b6', N'00000000-0000-0000-0000-000000000000', CAST(N'2021-07-07' AS Date), NULL, NULL, NULL, CAST(N'18:29:00' AS Time), NULL, NULL, CAST(N'2021-07-03T16:29:24.800' AS DateTime), 1, 1, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'3d1d958e-3beb-4b23-838a-0c9494a373eb', NULL, NULL, N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', N'd142e96b-5e8a-4605-b4ee-c884450e24e5', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [Bookings].[TableBookings] ([Id], [CheckInDate], [CheckOutDate], [NoOfPersons], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [Status], [IsBooked], [IsBookedOnline], [UserId], [TableId], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [TotalFare], [FloorId], [IsRemaining], [IsPaid], [FarePerHour]) VALUES (N'e3b9d2a3-4e4c-4150-9db8-12209036965c', CAST(N'2021-05-31' AS Date), NULL, NULL, CAST(N'09:20:00' AS Time), NULL, NULL, CAST(N'2021-05-30T09:20:27.427' AS DateTime), NULL, 1, 0, N'df426a0c-4325-4efc-ba8f-bf5ffffdd235', N'908d5f29-c77d-4980-894a-82274083167a', NULL, N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', NULL, N'd142e96b-5e8a-4605-b4ee-c884450e24e5', NULL, NULL, 100.0000)
INSERT [Bookings].[TableBookings] ([Id], [CheckInDate], [CheckOutDate], [NoOfPersons], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [Status], [IsBooked], [IsBookedOnline], [UserId], [TableId], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [TotalFare], [FloorId], [IsRemaining], [IsPaid], [FarePerHour]) VALUES (N'6ed99b4c-cea7-4dac-806b-3fa4f3f63045', CAST(N'2021-06-11' AS Date), NULL, NULL, CAST(N'02:51:00' AS Time), NULL, 1, CAST(N'2021-06-06T00:52:00.917' AS DateTime), NULL, 0, 0, N'd304188b-7228-4590-b02d-860a23239195', N'0e6e3951-8675-4eb1-875c-4455faf67402', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', NULL, N'a5c5ccb3-1186-49c8-a6ea-0d0004ea461f', NULL, NULL, 33232.0000)
INSERT [Bookings].[TableBookings] ([Id], [CheckInDate], [CheckOutDate], [NoOfPersons], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [Status], [IsBooked], [IsBookedOnline], [UserId], [TableId], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [TotalFare], [FloorId], [IsRemaining], [IsPaid], [FarePerHour]) VALUES (N'd77774d5-db4e-48a1-a015-5bc21330df2e', CAST(N'2021-06-12' AS Date), NULL, NULL, CAST(N'03:27:00' AS Time), NULL, 1, CAST(N'2021-06-06T00:25:32.607' AS DateTime), NULL, 0, 0, N'd304188b-7228-4590-b02d-860a23239195', N'eb6d31e2-bea0-4a33-88c4-4e13b8a49150', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', NULL, N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 0.0000)
INSERT [Bookings].[TableBookings] ([Id], [CheckInDate], [CheckOutDate], [NoOfPersons], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [Status], [IsBooked], [IsBookedOnline], [UserId], [TableId], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [TotalFare], [FloorId], [IsRemaining], [IsPaid], [FarePerHour]) VALUES (N'bb0f6077-100c-47df-aeea-75eb8301ee93', CAST(N'2021-06-16' AS Date), NULL, NULL, CAST(N'02:14:00' AS Time), NULL, 1, CAST(N'2021-06-06T00:13:06.927' AS DateTime), NULL, 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'f3d8da0f-eeb3-4343-bde3-6d3e249861a7', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', NULL, N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 2300.0000)
INSERT [Bookings].[TableBookings] ([Id], [CheckInDate], [CheckOutDate], [NoOfPersons], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [Status], [IsBooked], [IsBookedOnline], [UserId], [TableId], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [TotalFare], [FloorId], [IsRemaining], [IsPaid], [FarePerHour]) VALUES (N'35dc9355-5339-4c77-b110-89377dd8fa67', CAST(N'2021-06-18' AS Date), NULL, NULL, CAST(N'23:37:00' AS Time), NULL, 1, CAST(N'2021-06-05T20:36:04.440' AS DateTime), NULL, 0, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'cff59b3d-6f49-4be8-a32f-1b2abfa71969', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', NULL, N'a5c5ccb3-1186-49c8-a6ea-0d0004ea461f', NULL, NULL, 200.0000)
INSERT [Bookings].[TableBookings] ([Id], [CheckInDate], [CheckOutDate], [NoOfPersons], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [Status], [IsBooked], [IsBookedOnline], [UserId], [TableId], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [TotalFare], [FloorId], [IsRemaining], [IsPaid], [FarePerHour]) VALUES (N'c7ed0ca7-4876-4048-8fe5-93e1ec9e07eb', CAST(N'2021-07-14' AS Date), NULL, NULL, CAST(N'18:55:00' AS Time), NULL, NULL, CAST(N'2021-07-03T16:57:01.553' AS DateTime), NULL, 1, 1, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'cff59b3d-6f49-4be8-a32f-1b2abfa71969', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', NULL, N'13153ef9-1732-4774-a8af-837a2e39bfa5', NULL, N'a5c5ccb3-1186-49c8-a6ea-0d0004ea461f', NULL, NULL, NULL)
INSERT [Bookings].[TableBookings] ([Id], [CheckInDate], [CheckOutDate], [NoOfPersons], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [Status], [IsBooked], [IsBookedOnline], [UserId], [TableId], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [TotalFare], [FloorId], [IsRemaining], [IsPaid], [FarePerHour]) VALUES (N'7bc9087f-30e7-47bc-823a-c640d17c7939', CAST(N'2021-07-01' AS Date), NULL, NULL, CAST(N'12:27:00' AS Time), NULL, NULL, CAST(N'2021-07-03T22:27:19.997' AS DateTime), NULL, 1, 0, N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'eb6d31e2-bea0-4a33-88c4-4e13b8a49150', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', NULL, N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 0.0000)
INSERT [Bookings].[TableBookings] ([Id], [CheckInDate], [CheckOutDate], [NoOfPersons], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [Status], [IsBooked], [IsBookedOnline], [UserId], [TableId], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [TotalFare], [FloorId], [IsRemaining], [IsPaid], [FarePerHour]) VALUES (N'6239983e-69fe-4b6e-b45e-c7f39eec8681', CAST(N'2021-07-30' AS Date), NULL, NULL, CAST(N'19:59:00' AS Time), NULL, NULL, CAST(N'2021-07-03T17:00:08.643' AS DateTime), NULL, 1, 1, N'd304188b-7228-4590-b02d-860a23239195', N'eb6d31e2-bea0-4a33-88c4-4e13b8a49150', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', NULL, N'033837f0-4fcb-433a-9507-5016da697dfd', NULL, NULL, 0.0000)
INSERT [Bookings].[TableBookings] ([Id], [CheckInDate], [CheckOutDate], [NoOfPersons], [CheckInTime], [CheckOutTime], [IsDeleted], [CreateDate], [Status], [IsBooked], [IsBookedOnline], [UserId], [TableId], [DiscountAmount], [HotelId], [BuildingId], [CountryId], [CityId], [TotalFare], [FloorId], [IsRemaining], [IsPaid], [FarePerHour]) VALUES (N'12f026cf-bcf2-4d1d-a2c1-e4065c3db624', CAST(N'2021-07-09' AS Date), NULL, NULL, CAST(N'19:01:00' AS Time), NULL, NULL, CAST(N'2021-07-03T17:01:53.497' AS DateTime), NULL, 1, 1, N'd304188b-7228-4590-b02d-860a23239195', N'cff59b3d-6f49-4be8-a32f-1b2abfa71969', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', N'94fa72f3-9184-410f-803a-76e624767b81', N'13153ef9-1732-4774-a8af-837a2e39bfa5', NULL, N'a5c5ccb3-1186-49c8-a6ea-0d0004ea461f', NULL, NULL, 200.0000)
GO
INSERT [Bookings].[Users] ([Id], [Name], [ContactNo], [Email], [CNIC], [IsDeleted]) VALUES (N'cc1712a2-d78c-408a-b4c9-486ffeb7c29b', N'adnan adnan', N'03003000000', N'adnanhargan786@gmail.com', N'3944534234235', NULL)
INSERT [Bookings].[Users] ([Id], [Name], [ContactNo], [Email], [CNIC], [IsDeleted]) VALUES (N'08ae87cb-0f6a-4e3d-959f-6e5ec7392a45', N'tahir', N'3654', N'email@em', N'1234567891234', NULL)
INSERT [Bookings].[Users] ([Id], [Name], [ContactNo], [Email], [CNIC], [IsDeleted]) VALUES (N'd304188b-7228-4590-b02d-860a23239195', N'teest user1', N'3654d', N'email@em', N'3213121232131', NULL)
INSERT [Bookings].[Users] ([Id], [Name], [ContactNo], [Email], [CNIC], [IsDeleted]) VALUES (N'df426a0c-4325-4efc-ba8f-bf5ffffdd235', N'adnan adnan', N'03003000000', N'adnanhargan786@gmail.com', N'3829123183473', NULL)
INSERT [Bookings].[Users] ([Id], [Name], [ContactNo], [Email], [CNIC], [IsDeleted]) VALUES (N'815f1bf9-545a-4dc2-a9ec-f9f5480a839d', N'adnan adnan', N'03003000000', N'adnanhargan786@gmail.com', N'9678657456456', NULL)
GO
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'1c0d0e9e-ac1b-45c3-9af0-1d1adf9eb9bf', N'final building2', N'00000000-0000-0000-0000-000000000000', NULL, N'final add', NULL)
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'7a7e36ab-6468-4636-8add-3d7a9ed0fddc', N'Building2', N'3535d36c-c675-4f89-a6cb-7038d7e97f68', NULL, N'Address', NULL)
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'1b7ef165-fcfb-489f-ae73-74d010bf2733', N'Building3', N'3535d36c-c675-4f89-a6cb-7038d7e97f68', NULL, N'Address', NULL)
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'01b532f0-d550-40ef-bdff-9ab900616e58', N'adnan', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', NULL, N'address', NULL)
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'6df8d6f0-5ad5-4691-be79-ad3c0e362c0f', N'final building2', N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, N'final add2', NULL)
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'06df325e-e21a-4d42-a1d7-cdb66aa7a2b4', N'Bulding 2', N'00000000-0000-0000-0000-000000000000', NULL, N'test add', NULL)
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'Bulding 4', N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, N'test building add', N'203f4c08-496c-4ad2-93f8-0e2f7588be68_CS302-Assignment-02-Solution-Spring-2021-Complete-Solution.docx')
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'b06e1836-b6c9-4f8a-ae93-d7800dd840b4', N'final test', N'eba44979-7b0e-4776-863d-c63b15502c70', 1, N'addd', NULL)
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', N'Building112', N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, N'12', N'5694c8e1-880d-44b2-8356-a7e654aa86e8_adnan (2).jpg')
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'Building1', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', NULL, N'address', NULL)
INSERT [Hotel].[Buildings] ([Id], [Name], [HotelId], [IsDeleted], [Address], [ImageUrl]) VALUES (N'26a5211d-4a8b-46b1-a846-f78e78631560', N'Bulding 2', N'eba44979-7b0e-4776-863d-c63b15502c70', 1, N'test add33', NULL)
GO
INSERT [Hotel].[Countries] ([Id], [Name], [IsDeleted]) VALUES (N'94fa72f3-9184-410f-803a-76e624767b81', N'India', NULL)
INSERT [Hotel].[Countries] ([Id], [Name], [IsDeleted]) VALUES (N'd2def942-e31e-4782-9483-988a6e93c408', N'Pakistan', NULL)
GO
INSERT [Hotel].[Expenses] ([Id], [ExpenseTypeId], [Amount], [ExpenseDescription], [IsDeleted], [CreationDate]) VALUES (N'e6e72165-a211-44b1-9a87-88222f010f60', N'64a76145-3e75-4a46-8107-aca303933bc2', 100, N'testdesc', 0, CAST(N'2021-06-10T22:37:24.100' AS DateTime))
INSERT [Hotel].[Expenses] ([Id], [ExpenseTypeId], [Amount], [ExpenseDescription], [IsDeleted], [CreationDate]) VALUES (N'0d8562f0-3c2e-4559-a0f4-cde0237736a5', N'79e2124f-7ee6-4f1c-9fe8-64306e79a019', 120, N'Description', 0, CAST(N'2021-05-20T11:09:19.380' AS DateTime))
GO
INSERT [Hotel].[ExpenseTypes] ([Id], [ExpenseType], [IsDeleted]) VALUES (N'00000000-0000-0000-0000-000000000000', N'Electricity', 1)
INSERT [Hotel].[ExpenseTypes] ([Id], [ExpenseType], [IsDeleted]) VALUES (N'79e2124f-7ee6-4f1c-9fe8-64306e79a019', N'Fuel', 0)
INSERT [Hotel].[ExpenseTypes] ([Id], [ExpenseType], [IsDeleted]) VALUES (N'c00732cc-50ee-487c-ac1b-d47ac985aa60', N'fuel 2', 0)
GO
INSERT [Hotel].[Floors] ([Id], [FloorNo], [BuildingId], [IsDeleted], [HotelId], [ImageUrl]) VALUES (N'064fa944-f2ad-4d6b-820e-0952955ac849', N'floor 3', N'26a5211d-4a8b-46b1-a846-f78e78631560', 1, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL)
INSERT [Hotel].[Floors] ([Id], [FloorNo], [BuildingId], [IsDeleted], [HotelId], [ImageUrl]) VALUES (N'a5c5ccb3-1186-49c8-a6ea-0d0004ea461f', N'floor 3', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL)
INSERT [Hotel].[Floors] ([Id], [FloorNo], [BuildingId], [IsDeleted], [HotelId], [ImageUrl]) VALUES (N'033837f0-4fcb-433a-9507-5016da697dfd', N'floor 2 edit', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL)
INSERT [Hotel].[Floors] ([Id], [FloorNo], [BuildingId], [IsDeleted], [HotelId], [ImageUrl]) VALUES (N'bb37a25d-5fc6-460d-8104-6fe56f2661dc', N'Floor0002', N'7a7e36ab-6468-4636-8add-3d7a9ed0fddc', NULL, N'3535d36c-c675-4f89-a6cb-7038d7e97f68', NULL)
INSERT [Hotel].[Floors] ([Id], [FloorNo], [BuildingId], [IsDeleted], [HotelId], [ImageUrl]) VALUES (N'5176df2b-d23d-4ea7-8611-bc66754ea9f7', N'Floor000122', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', 1, N'eba44979-7b0e-4776-863d-c63b15502c70', N'0c199d80-e3d4-4deb-927e-cea9c7b0b853_adnan (2).jpg')
INSERT [Hotel].[Floors] ([Id], [FloorNo], [BuildingId], [IsDeleted], [HotelId], [ImageUrl]) VALUES (N'd142e96b-5e8a-4605-b4ee-c884450e24e5', N'Floor0001', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', NULL, N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'c8e7a772-adca-48db-90d1-59084c3c764e_adnan (2).jpg')
INSERT [Hotel].[Floors] ([Id], [FloorNo], [BuildingId], [IsDeleted], [HotelId], [ImageUrl]) VALUES (N'bdb3488e-e4c7-4dff-bd29-e6c6e080f54c', N'Floor0003', N'7a7e36ab-6468-4636-8add-3d7a9ed0fddc', NULL, N'3535d36c-c675-4f89-a6cb-7038d7e97f68', NULL)
INSERT [Hotel].[Floors] ([Id], [FloorNo], [BuildingId], [IsDeleted], [HotelId], [ImageUrl]) VALUES (N'd234a1f3-c982-49b1-8209-fe2b85ad4a07', N'Floor 01', N'26a5211d-4a8b-46b1-a846-f78e78631560', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', NULL)
GO
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'64bd13b8-6fa7-4214-bd0e-0844fc89b27b', N'hall 2 edit', N'eba44979-7b0e-4776-863d-c63b15502c70', N'hall 2 desc edit', N'22', N'3200', N'22', NULL, NULL, NULL, 1, NULL, 3000.0000, NULL)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'1a37bf6e-5336-4ea1-8805-2f594ceb5274', N'hall 3', N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, 3000.0000, NULL)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'ce1ac2d4-de09-4e83-955d-7ac93c61693b', N'hall 22', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'desc', N'3', N'32', N'3', NULL, NULL, NULL, NULL, NULL, 2000.0000, NULL)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'32c0722b-78b5-4c94-a045-82994523eacd', N'First Flor A1', N'eba44979-7b0e-4776-863d-c63b15502c70', N'testing hall', N'32', N'40', N'50', N'300', NULL, N'52575d38-372e-49ab-8aef-a0dbfd3db3c9_111.jpg', 1, 0, 2000.0000, NULL)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'09f5e1ba-740e-4450-9067-82a84eaf8f73', N'hall 2', N'00000000-0000-0000-0000-000000000000', N'hall 2 desc', N'3', N'23', N'1212', N'33', NULL, N'd5e3eedc-798e-4007-b538-fcc106a8d0d8_111.jpg', NULL, NULL, NULL, NULL)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'0ee9b5fc-1b12-415b-a5ee-9f6603570ec2', N'Hall kayber', N'eba44979-7b0e-4776-863d-c63b15502c70', N'decs', N'21', N'231', N'213', N'3', NULL, N'c46ba5e1-8133-4dc1-ad70-3f73ee85e944_111.jpg', 0, NULL, NULL, NULL)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'f5a066cb-c23e-4504-a25c-a1016954a937', N'Final hall2', N'eba44979-7b0e-4776-863d-c63b15502c70', N'hall 2 desc', N'2', N'32', N'21', N'3', NULL, NULL, 1, NULL, 6000.0000, NULL)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'90486f03-98ec-4dd7-8f16-d20ffb11a0ff', N'Hall 1', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'descriptio ', N'2', N'22', N'2', N'12', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'ba7187ab-b878-4062-b36e-e9ba12752f02', N'Final Hall', N'eba44979-7b0e-4776-863d-c63b15502c70', N'final hall desc', N'2', N'23', N'2', N'2', 1, NULL, 0, NULL, 2000.0000, NULL)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'9b11005d-5ed1-467b-b4fc-f2df4e9d2221', N'Final hall 3', N'eba44979-7b0e-4776-863d-c63b15502c70', N'test desc', N'22', N'33', N'44', N'3', NULL, NULL, 0, 0, 5000.0000, 1)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'd114a1f3-c982-49b1-8209-fe2b85ad4a07', N'Hall 1', N'eba44979-7b0e-4776-863d-c63b15502c70', N'test desc', N'3', N'44', N'3', N'21', NULL, NULL, 1, 1, 3000.0000, 1)
INSERT [Hotel].[Hall] ([Id], [Name], [HotelId], [Description], [Length], [width], [Height], [RoomSize], [IsDeleted], [ImageUrl], [IsBooked], [IsBookedOnline], [Fare], [IsAvailable]) VALUES (N'd084a1f3-c982-49b1-8209-fe2b85ad4a07', N'adnan adnan', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'description', N'2', N'22', N'2', N'12', NULL, N'80a5d3d2-92b6-4e4f-8acd-de2ac7358b55_adnan (2).jpg', NULL, NULL, NULL, NULL)
GO
INSERT [Hotel].[HotelExpense] ([Id], [ExpenseTypeId], [Amount], [ExpenseDescription], [IsDeleted], [CreationDate], [HotelId]) VALUES (N'37de2ef4-1671-47c7-bfe9-19c638b38250', N'8903b032-1bdc-434d-8485-b57d2186d526', 300, N'desc', 0, CAST(N'2021-06-12T16:07:34.683' AS DateTime), N'eba44979-7b0e-4776-863d-c63b15502c70')
INSERT [Hotel].[HotelExpense] ([Id], [ExpenseTypeId], [Amount], [ExpenseDescription], [IsDeleted], [CreationDate], [HotelId]) VALUES (N'1ca7de85-98cc-4d24-940b-a6ea4c195f89', N'64a76145-3e75-4a46-8107-aca303933bc2', 900, N'desc', 0, CAST(N'2021-06-11T23:03:46.353' AS DateTime), N'3d04f603-53e2-4bc1-9a76-80115ea0297b')
INSERT [Hotel].[HotelExpense] ([Id], [ExpenseTypeId], [Amount], [ExpenseDescription], [IsDeleted], [CreationDate], [HotelId]) VALUES (N'4dbdd1da-009f-43bf-8185-d70e8dbe03d8', N'0e4316ff-2071-4028-ad4f-e9265ea65893', 1000, N'final ', 0, CAST(N'2021-06-10T23:00:37.257' AS DateTime), N'eba44979-7b0e-4776-863d-c63b15502c70')
INSERT [Hotel].[HotelExpense] ([Id], [ExpenseTypeId], [Amount], [ExpenseDescription], [IsDeleted], [CreationDate], [HotelId]) VALUES (N'fa4edf9d-4c0a-4c4b-bea3-da76f9bef5bc', N'f33b1198-bdac-422a-bef5-71cf206e535f', 5000, N'hotel 1 decs edit', 0, CAST(N'2021-06-12T15:20:48.140' AS DateTime), N'eba44979-7b0e-4776-863d-c63b15502c70')
INSERT [Hotel].[HotelExpense] ([Id], [ExpenseTypeId], [Amount], [ExpenseDescription], [IsDeleted], [CreationDate], [HotelId]) VALUES (N'a56597fe-f02f-40e8-aab9-dea3214ec48d', N'64a76145-3e75-4a46-8107-aca303933bc2', 500, N'desc 2', 0, CAST(N'2021-06-10T23:00:14.340' AS DateTime), N'3535d36c-c675-4f89-a6cb-7038d7e97f68')
INSERT [Hotel].[HotelExpense] ([Id], [ExpenseTypeId], [Amount], [ExpenseDescription], [IsDeleted], [CreationDate], [HotelId]) VALUES (N'21bc38cb-979b-43ff-81d9-efa4e1ec2948', N'8903b032-1bdc-434d-8485-b57d2186d526', 200, N'test desc 1 eedit', 0, CAST(N'2021-06-10T22:48:35.807' AS DateTime), N'3d04f603-53e2-4bc1-9a76-80115ea0297b')
GO
INSERT [Hotel].[HotelExpenTypes] ([Id], [ExpenseType], [IsDeleted]) VALUES (N'f33b1198-bdac-422a-bef5-71cf206e535f', N'Water', 0)
INSERT [Hotel].[HotelExpenTypes] ([Id], [ExpenseType], [IsDeleted]) VALUES (N'378868fc-cae7-4b1f-bf05-854dc12fdf6e', N'fuel212', 1)
INSERT [Hotel].[HotelExpenTypes] ([Id], [ExpenseType], [IsDeleted]) VALUES (N'64a76145-3e75-4a46-8107-aca303933bc2', N'Food', 0)
INSERT [Hotel].[HotelExpenTypes] ([Id], [ExpenseType], [IsDeleted]) VALUES (N'8903b032-1bdc-434d-8485-b57d2186d526', N'Drinks', 0)
INSERT [Hotel].[HotelExpenTypes] ([Id], [ExpenseType], [IsDeleted]) VALUES (N'0e4316ff-2071-4028-ad4f-e9265ea65893', N'Fuel', 0)
GO
SET IDENTITY_INSERT [Hotel].[HotelOfficerRoles] ON 

INSERT [Hotel].[HotelOfficerRoles] ([Id], [Name], [IsDeleted]) VALUES (5, N'Super Admin (Hotel)', NULL)
INSERT [Hotel].[HotelOfficerRoles] ([Id], [Name], [IsDeleted]) VALUES (6, N'Super Admin (Hotel)', 1)
INSERT [Hotel].[HotelOfficerRoles] ([Id], [Name], [IsDeleted]) VALUES (7, N'Worker', NULL)
INSERT [Hotel].[HotelOfficerRoles] ([Id], [Name], [IsDeleted]) VALUES (9, N'Manager', NULL)
SET IDENTITY_INSERT [Hotel].[HotelOfficerRoles] OFF
GO
INSERT [Hotel].[HotelOfficers] ([Id], [Name], [UserName], [Password], [CreatedDate], [Mobile], [IsDeleted], [HotelId], [HotelOfficerRoleId]) VALUES (N'6a235d6e-2acc-4c8a-b8d8-0cdf147e8b61', N'teest user2', N'usern22', N'password2', CAST(N'2021-06-12T15:51:58.213' AS DateTime), N'890990', 0, N'eba44979-7b0e-4776-863d-c63b15502c70', 7)
INSERT [Hotel].[HotelOfficers] ([Id], [Name], [UserName], [Password], [CreatedDate], [Mobile], [IsDeleted], [HotelId], [HotelOfficerRoleId]) VALUES (N'9b04ac42-1980-483b-bf07-137fbfb3da69', N'teest user1 ', N'usern2290', N'password123', CAST(N'2021-06-11T23:45:20.873' AS DateTime), N'890990', 0, N'eba44979-7b0e-4776-863d-c63b15502c70', 7)
INSERT [Hotel].[HotelOfficers] ([Id], [Name], [UserName], [Password], [CreatedDate], [Mobile], [IsDeleted], [HotelId], [HotelOfficerRoleId]) VALUES (N'06eaa117-75ba-4bb3-b01e-1b817b5bf839', N'tahir', N'usern', N'password', CAST(N'2021-06-11T23:39:58.637' AS DateTime), N'8909', 0, N'3d04f603-53e2-4bc1-9a76-80115ea0297b', 5)
INSERT [Hotel].[HotelOfficers] ([Id], [Name], [UserName], [Password], [CreatedDate], [Mobile], [IsDeleted], [HotelId], [HotelOfficerRoleId]) VALUES (N'88e118e8-920e-4cc4-a142-43370256cdae', N'TAHIR ', N'admin', N'password', CAST(N'2021-06-12T15:40:10.417' AS DateTime), N'0332323232', NULL, N'eba44979-7b0e-4776-863d-c63b15502c70', 5)
GO
INSERT [Hotel].[Hotels] ([Id], [HotelLogo], [HotelName], [HotelPhone], [HotelMobile], [HotelEmail], [HotelAddress], [HotelWebsite], [HotelCityId], [HotelCountryId], [HotelTypeId], [IsDeleted], [ImageUrl], [Password], [Location]) VALUES (N'3535d36c-c675-4f89-a6cb-7038d7e97f68', NULL, N'Hotel2', N'03077910468', NULL, N'adnan@gmail.com', N'address', N'site.com', N'4b609abb-4575-4e29-8fd2-8e3023b31352', N'd2def942-e31e-4782-9483-988a6e93c408', N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'pass', NULL)
INSERT [Hotel].[Hotels] ([Id], [HotelLogo], [HotelName], [HotelPhone], [HotelMobile], [HotelEmail], [HotelAddress], [HotelWebsite], [HotelCityId], [HotelCountryId], [HotelTypeId], [IsDeleted], [ImageUrl], [Password], [Location]) VALUES (N'3d04f603-53e2-4bc1-9a76-80115ea0297b', NULL, N'Khyber', N'03077880840', NULL, N'Khyber@gmail.com', N'multan', NULL, N'4b609abb-4575-4e29-8fd2-8e3023b31352', N'd2def942-e31e-4782-9483-988a6e93c408', N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'Khyber123', NULL)
INSERT [Hotel].[Hotels] ([Id], [HotelLogo], [HotelName], [HotelPhone], [HotelMobile], [HotelEmail], [HotelAddress], [HotelWebsite], [HotelCityId], [HotelCountryId], [HotelTypeId], [IsDeleted], [ImageUrl], [Password], [Location]) VALUES (N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', NULL, N'Hotel1', N'03077910468', NULL, N'adnan@gmail.com', N'address', N'site.com', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'94fa72f3-9184-410f-803a-76e624767b81', N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL)
INSERT [Hotel].[Hotels] ([Id], [HotelLogo], [HotelName], [HotelPhone], [HotelMobile], [HotelEmail], [HotelAddress], [HotelWebsite], [HotelCityId], [HotelCountryId], [HotelTypeId], [IsDeleted], [ImageUrl], [Password], [Location]) VALUES (N'eba44979-7b0e-4776-863d-c63b15502c70', NULL, N'Hotel1', N'03077910468', NULL, N'adnanhargan786@gmail.com', N'Chak No 1, SB Hargan, Tehsiel Bhalwal, District Sargodha, Post office Dhori', N'Mysite.com', N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'94fa72f3-9184-410f-803a-76e624767b81', N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'password2', NULL)
GO
SET IDENTITY_INSERT [Hotel].[Officers] ON 

INSERT [Hotel].[Officers] ([Id], [Name], [UserName], [Password], [CreatedDate], [Mobile], [RoleId], [IsDeleted]) VALUES (4, N'adnan', N'adnanali', N'123456', CAST(N'2021-05-26T11:41:42.253' AS DateTime), N'03004004444', 6, NULL)
INSERT [Hotel].[Officers] ([Id], [Name], [UserName], [Password], [CreatedDate], [Mobile], [RoleId], [IsDeleted]) VALUES (5, N'Mehtab', N'mehtab', N'123456', CAST(N'2021-05-26T11:42:06.913' AS DateTime), N'03004004444', 7, NULL)
SET IDENTITY_INSERT [Hotel].[Officers] OFF
GO
SET IDENTITY_INSERT [Hotel].[Roles] ON 

INSERT [Hotel].[Roles] ([Id], [Name], [IsDeleted]) VALUES (6, N'Admin', NULL)
INSERT [Hotel].[Roles] ([Id], [Name], [IsDeleted]) VALUES (7, N'SuperAdmin', NULL)
INSERT [Hotel].[Roles] ([Id], [Name], [IsDeleted]) VALUES (8, N'Super Admin (Hotel)', NULL)
INSERT [Hotel].[Roles] ([Id], [Name], [IsDeleted]) VALUES (9, N'Super Admin (Hotel)', NULL)
INSERT [Hotel].[Roles] ([Id], [Name], [IsDeleted]) VALUES (10, N'Super Admin (Hotel)', NULL)
INSERT [Hotel].[Roles] ([Id], [Name], [IsDeleted]) VALUES (11, N'Super Admin (Hotel)', NULL)
INSERT [Hotel].[Roles] ([Id], [Name], [IsDeleted]) VALUES (12, N'tahir', NULL)
INSERT [Hotel].[Roles] ([Id], [Name], [IsDeleted]) VALUES (13, N'Super Admin (Hotel)', NULL)
SET IDENTITY_INSERT [Hotel].[Roles] OFF
GO
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'3d1d958e-3beb-4b23-838a-0c9494a373eb', N'0257fb01-85f4-4a25-99ef-947e79c35899', N'Description', 2, N'view', 2, NULL, N'd142e96b-5e8a-4605-b4ee-c884450e24e5', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'0003', 1200.0000, 1, N'57022e62-d9d3-4966-8aa4-e745e55f1739_who-we.jpg', 0.0000, 1, 1)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'10b6b9b3-7c25-4722-9a83-0dfa26f0704c', N'0257fb01-85f4-4a25-99ef-947e79c35899', N'dscscsc', 23, N'room view 1w', 4, NULL, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'eba44979-7b0e-4776-863d-c63b15502c70', N'room no3', 1000.0000, 1, N'17985882-7052-444a-a53a-f5fcefcaacc4_111.jpg', 0.0000, 0, 1)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'e6ff6e10-842e-4cf0-b204-3154fe268771', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', N'room no1 desc', 23, N'room view 1', 33, NULL, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'eba44979-7b0e-4776-863d-c63b15502c70', N'room no 1', 2000.0000, 0, N'ada43d50-34ed-431e-8a77-ca86c6f28b59_111.jpg', 0.0000, 0, 1)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'7843cf78-fb5f-4572-b593-3574170dbdaa', N'0257fb01-85f4-4a25-99ef-947e79c35899', NULL, NULL, NULL, NULL, NULL, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'eba44979-7b0e-4776-863d-c63b15502c70', N'room no 2 del', 0.0000, 1, NULL, 0.0000, NULL, 1)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'a9d33d25-3193-4172-a101-3a7adf759091', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', N'dd', 2, N'view', 33, NULL, N'd142e96b-5e8a-4605-b4ee-c884450e24e5', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'002my', 122.0000, NULL, N'f728df60-1929-4cfb-9d3e-1908c93bfe48_adnan (2).jpg', 0.0000, NULL, NULL)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'be027204-f928-4e31-8473-404361ad3f6f', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', N'Description', 4, N'view', 4, NULL, N'bb37a25d-5fc6-460d-8104-6fe56f2661dc', N'7a7e36ab-6468-4636-8add-3d7a9ed0fddc', N'3535d36c-c675-4f89-a6cb-7038d7e97f68', N'005', 2400.0000, NULL, N'0c311fad-795b-4fcc-a5fb-8140b43d47f0_who-we.jpg', 0.0000, NULL, NULL)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'6ba029bb-7b24-4628-a3b2-57dc00d909e0', N'0257fb01-85f4-4a25-99ef-947e79c35899', N'wadad', 123, N'room view 2wd', 123, NULL, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'eba44979-7b0e-4776-863d-c63b15502c70', N'room no 4', 1000.0000, 1, NULL, 0.0000, 0, 1)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'3630e94b-853d-417d-a6e1-5ef1d2d2047f', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', N'Description', 4, N'view', 4, NULL, N'd142e96b-5e8a-4605-b4ee-c884450e24e5', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'002', 2400.0000, NULL, NULL, 0.0000, NULL, NULL)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'2c471368-945c-4d5b-ba6a-9027c54908e8', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', NULL, NULL, NULL, NULL, 1, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'eba44979-7b0e-4776-863d-c63b15502c70', N'room no3 ed', 0.0000, NULL, NULL, 0.0000, NULL, 1)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'aab3bc70-bf1c-4b45-8cf7-aeee285448a0', N'0257fb01-85f4-4a25-99ef-947e79c35899', NULL, NULL, NULL, NULL, 1, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'eba44979-7b0e-4776-863d-c63b15502c70', N'room no 2 del', 0.0000, NULL, NULL, 0.0000, NULL, 1)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'f2243f59-fe01-431f-abb9-c64e0b2ae70a', N'0257fb01-85f4-4a25-99ef-947e79c35899', N'Description', 2, N'view', 2, NULL, N'd142e96b-5e8a-4605-b4ee-c884450e24e5', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'001', 1200.0000, 1, N'c76b1cd1-91c4-4228-a116-fdf0b0e84b9a_who-we.jpg', 0.0000, NULL, NULL)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'6bc2e022-f74e-4805-81c4-c6a354f4b8db', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', N'descripition', 4, N'view', 4, NULL, N'd142e96b-5e8a-4605-b4ee-c884450e24e5', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'004', 2400.0000, NULL, N'd8c0fd78-a008-4187-ad08-f64a2c2de901_who-we.jpg', 0.0000, NULL, NULL)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'4083acc8-8e4d-4022-9914-dc30281d5a63', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', N'Description', 2, N'view', 2, NULL, N'd142e96b-5e8a-4605-b4ee-c884450e24e5', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'0012', 1200.0000, 1, NULL, 0.0000, NULL, NULL)
INSERT [Hotel].[Rooms] ([Id], [TypeId], [Description], [MaxNoOfPersons], [RoomView], [NoOfBeds], [IsDeleted], [FloorId], [BuildingId], [HotelId], [RoomNo], [FarePerNight], [IsBooked], [ImageUrl], [DiscountAmount], [IsBookedOnline], [IsAvailable]) VALUES (N'ceacc8e4-f712-4a59-acbc-e3ac5d6c69ff', N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', N'desc edit', 4, N'room view 2 edit', 4, NULL, N'5176df2b-d23d-4ea7-8611-bc66754ea9f7', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', N'eba44979-7b0e-4776-863d-c63b15502c70', N'room no 2 ', 3500.0000, 0, N'c86671c8-202c-4c00-a707-068adba9a929_111.jpg', 0.0000, NULL, 1)
GO
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'753338e9-ab72-4759-b2b1-0d9f6a34059a', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'3d1d958e-3beb-4b23-838a-0c9494a373eb')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'3450b5c9-573f-4cd5-9329-0e22606e0402', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'e6ff6e10-842e-4cf0-b204-3154fe268771')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'ec61f2e4-cfca-4dba-9811-0eee729ba1cc', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'6ba029bb-7b24-4628-a3b2-57dc00d909e0')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'a9f41916-a82a-478c-8ce3-19af0d7e325b', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'3630e94b-853d-417d-a6e1-5ef1d2d2047f')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'b2cafe94-0599-45f7-a807-2f94ec2f95f6', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'e6ff6e10-842e-4cf0-b204-3154fe268771')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'3e6f5e1f-bd95-4b52-b15a-330523f61999', N'00716860-1afb-4993-803c-d6881b9c43d7', N'ceacc8e4-f712-4a59-acbc-e3ac5d6c69ff')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'592f8aef-c38f-4b9f-bdf2-341d4c509288', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'2c471368-945c-4d5b-ba6a-9027c54908e8')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'2ecef1c1-f9d6-458d-b60d-3b9fc82ff3ae', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'10b6b9b3-7c25-4722-9a83-0dfa26f0704c')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'82ac4b86-afa1-4506-b8e6-414237b2e48b', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'2c471368-945c-4d5b-ba6a-9027c54908e8')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'627d24f2-4145-468c-9801-49f815e2167d', N'42d9e856-9cda-4d42-8d13-f3d3f4d674c8', N'3d1d958e-3beb-4b23-838a-0c9494a373eb')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'4d4b9a2e-a23b-4f33-bbab-4b3a12af9523', N'42d9e856-9cda-4d42-8d13-f3d3f4d674c8', N'4083acc8-8e4d-4022-9914-dc30281d5a63')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'9719cf40-7553-4e95-a420-9aaaad6b2afb', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'6ba029bb-7b24-4628-a3b2-57dc00d909e0')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'ccd94afc-6d21-45f5-b631-9fb4b4162daf', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'3630e94b-853d-417d-a6e1-5ef1d2d2047f')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'3e459d4e-9237-4db4-9181-a62a349bfcca', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'f2243f59-fe01-431f-abb9-c64e0b2ae70a')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'390ef7bc-83bd-42f8-a9b7-b338f363fdc6', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'a9d33d25-3193-4172-a101-3a7adf759091')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'cca54b22-a85c-4062-8c4a-bc220aca5a03', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'6bc2e022-f74e-4805-81c4-c6a354f4b8db')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'f27aa9af-25d8-45d6-893a-beee7e1e5543', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'aab3bc70-bf1c-4b45-8cf7-aeee285448a0')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'92f7dbf2-ee7a-4fc8-b984-bf664ece265c', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'3d1d958e-3beb-4b23-838a-0c9494a373eb')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'6ec6d139-83f0-4619-93cc-c0429484ff97', N'00716860-1afb-4993-803c-d6881b9c43d7', N'e6ff6e10-842e-4cf0-b204-3154fe268771')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'63a8d93b-0af0-4d07-b8fc-c35b0e7648dd', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'be027204-f928-4e31-8473-404361ad3f6f')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'c5d11f7c-ed7e-4fc0-ada5-d5d92ab0afae', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'aab3bc70-bf1c-4b45-8cf7-aeee285448a0')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'b6b76931-ce25-46f5-ba6e-db88dc7accad', N'00716860-1afb-4993-803c-d6881b9c43d7', N'4083acc8-8e4d-4022-9914-dc30281d5a63')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'eac97060-6464-464a-a83e-e36537cb2d22', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'ceacc8e4-f712-4a59-acbc-e3ac5d6c69ff')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'8ab26df8-4fae-46d1-95db-eb3597254019', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'be027204-f928-4e31-8473-404361ad3f6f')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'901076bb-d778-47e8-8ae4-ed82c9bb9556', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'10b6b9b3-7c25-4722-9a83-0dfa26f0704c')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'aaa02f8a-1f48-4d8e-81d7-f274fb28bc5f', N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'6bc2e022-f74e-4805-81c4-c6a354f4b8db')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'29fec071-f052-4194-9702-fe6f96fa692c', N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'f2243f59-fe01-431f-abb9-c64e0b2ae70a')
INSERT [Hotel].[RoomServices] ([Id], [ServiceId], [RoomId]) VALUES (N'7029f2a0-bbf8-4629-a46d-ff8ee761b79e', N'00716860-1afb-4993-803c-d6881b9c43d7', N'3d1d958e-3beb-4b23-838a-0c9494a373eb')
GO
INSERT [Hotel].[Services] ([Id], [ServiceName], [IsDeleted]) VALUES (N'47bcf9ea-6cf0-4937-85c6-005983ace81d', N'Breakfast', NULL)
INSERT [Hotel].[Services] ([Id], [ServiceName], [IsDeleted]) VALUES (N'9abba0b7-4713-4a8f-bd21-10aac3b0da00', N'Lunch1', NULL)
INSERT [Hotel].[Services] ([Id], [ServiceName], [IsDeleted]) VALUES (N'f88b0c0b-5058-4d47-9b7a-abfe510f7ede', N'Lunch', 1)
INSERT [Hotel].[Services] ([Id], [ServiceName], [IsDeleted]) VALUES (N'00716860-1afb-4993-803c-d6881b9c43d7', N'Dinner', NULL)
INSERT [Hotel].[Services] ([Id], [ServiceName], [IsDeleted]) VALUES (N'42d9e856-9cda-4d42-8d13-f3d3f4d674c8', N'Wifi', NULL)
GO
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'cff59b3d-6f49-4be8-a32f-1b2abfa71969', NULL, N'table 2', N'eba44979-7b0e-4776-863d-c63b15502c70', N'table view 2', N'table 2 desc', 2, 200.0000, N'a5c5ccb3-1186-49c8-a6ea-0d0004ea461f', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', N'dac47a73-d66e-424a-a5de-af4717cfffc5_111.jpg', 1, 1, 1)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'0e6e3951-8675-4eb1-875c-4455faf67402', NULL, N'table 5', N'eba44979-7b0e-4776-863d-c63b15502c70', N'table view 232', N'descc', 3, 33232.0000, N'a5c5ccb3-1186-49c8-a6ea-0d0004ea461f', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', NULL, 1, NULL, 1)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'eb6d31e2-bea0-4a33-88c4-4e13b8a49150', NULL, N'table 4', N'eba44979-7b0e-4776-863d-c63b15502c70', N'table view 22', N'desc ', 3, 0.0000, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', NULL, 1, 0, 1)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'cb48106a-af02-41f7-93d5-67a8006c9590', NULL, N'table8', N'eba44979-7b0e-4776-863d-c63b15502c70', N'table view 312', N'dedscscsc', 123, 123123.0000, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', NULL, NULL, NULL, 1)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'f3d8da0f-eeb3-4343-bde3-6d3e249861a7', NULL, N'table 3', N'eba44979-7b0e-4776-863d-c63b15502c70', N'table view 3', N'hall 2 desc edit', 2, 2300.0000, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'730b6909-ac35-46ff-b08e-aee5e5f5737a_111.jpg', 1, NULL, 1)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'908d5f29-c77d-4980-894a-82274083167a', NULL, N'0001', N'c3d0bdab-9472-42c9-9e51-af2e98e2afc3', N'view', N'description', 1, 100.0000, N'd142e96b-5e8a-4605-b4ee-c884450e24e5', N'0ae41d6c-59e8-4f36-bedc-e17324b81a09', N'4f768307-2837-48af-9fd2-688164cad44f_adnan (2).jpg', NULL, NULL, NULL)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'cb4fe259-cfe3-49ed-b1f5-ca8dcb46cbf5', NULL, N'table 7', N'eba44979-7b0e-4776-863d-c63b15502c70', N'table view 21', N'descs', 213, 1213123.0000, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', NULL, NULL, NULL, 1)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'0a1fc6ad-95ad-4f9e-8303-cc910962b36f', NULL, N'table 6', N'eba44979-7b0e-4776-863d-c63b15502c70', N'table view 221', N'desc', 12, 23123.0000, N'033837f0-4fcb-433a-9507-5016da697dfd', N'818f3325-ebea-42d9-8ba3-d484c2f56aec', N'1af6c835-ddc7-4817-b6fc-5758ce6d5131_111.jpg', 1, NULL, 1)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'0517bc06-c7aa-46c6-a45e-d29e30d2239b', NULL, N'table 4', N'3535d36c-c675-4f89-a6cb-7038d7e97f68', N'table view 2', N'hall 2 desc', 3, 4000.0000, N'bb37a25d-5fc6-460d-8104-6fe56f2661dc', N'7a7e36ab-6468-4636-8add-3d7a9ed0fddc', NULL, NULL, NULL, 1)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'efb8471e-f2c0-407e-8950-d40ffc30a291', 1, N'table 4 edit', N'eba44979-7b0e-4776-863d-c63b15502c70', N'table view 4 edit', N'test desc edit', 5, 4000.0000, N'5176df2b-d23d-4ea7-8611-bc66754ea9f7', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', NULL, NULL, NULL, NULL)
INSERT [Hotel].[Tables] ([Id], [IsDeleted], [TableNo], [HotelId], [TableView], [Description], [MaxNoOfPersons], [FarePerHour], [FloorId], [BuildingId], [ImageUrl], [IsBooked], [IsBookedOnline], [IsAvailable]) VALUES (N'5ece5eba-f485-45a6-a1d5-e50b7078f204', NULL, N'0002', N'eba44979-7b0e-4776-863d-c63b15502c70', N'view', N'des', 2, 122.0000, N'5176df2b-d23d-4ea7-8611-bc66754ea9f7', N'2c1e2789-591e-4ef4-8c77-d7f5faa2d466', N'41a48427-717e-4961-ba86-cbc320996514_adnan (2).jpg', 1, NULL, NULL)
GO
INSERT [Setup].[Cities] ([Id], [CityName], [Description], [IsDeleted], [CountryId]) VALUES (N'13153ef9-1732-4774-a8af-837a2e39bfa5', N'NewDelhi', N'Description', NULL, N'94fa72f3-9184-410f-803a-76e624767b81')
INSERT [Setup].[Cities] ([Id], [CityName], [Description], [IsDeleted], [CountryId]) VALUES (N'4b609abb-4575-4e29-8fd2-8e3023b31352', N'Karachi', N'CityDescription', NULL, N'd2def942-e31e-4782-9483-988a6e93c408')
GO
INSERT [Setup].[Companies] ([Id], [CompanyName], [UserFirstName], [UserLastName], [ContactNo], [Email], [CompanySite], [AddressOne], [AddressTwo], [PostCode], [City], [State], [Country], [IsDeleted], [CreateDate]) VALUES (N'7c4456e3-0148-469c-9c8f-e015f403b4b1', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL)
GO
INSERT [Setup].[HotelTypes] ([Id], [Type], [IsDeleted], [Description]) VALUES (N'd87f97ad-a169-4770-9849-b45bc22136c4', N'Type1', NULL, N'Description')
GO
INSERT [Setup].[RoomTypes] ([Id], [Name], [Description], [IsDeleted]) VALUES (N'0257fb01-85f4-4a25-99ef-947e79c35899', N'Single', N'Single Room', NULL)
INSERT [Setup].[RoomTypes] ([Id], [Name], [Description], [IsDeleted]) VALUES (N'17834a85-668a-4961-a5e7-dfeb0b0ef0f8', N'DoubleRoom', N'Double bed room', NULL)
GO
ALTER TABLE [Hotel].[HotelExpense]  WITH CHECK ADD  CONSTRAINT [FK_HotelExpense_HotelExpenTypes] FOREIGN KEY([ExpenseTypeId])
REFERENCES [Hotel].[HotelExpenTypes] ([Id])
GO
ALTER TABLE [Hotel].[HotelExpense] CHECK CONSTRAINT [FK_HotelExpense_HotelExpenTypes]
GO
ALTER TABLE [Hotel].[HotelExpense]  WITH CHECK ADD  CONSTRAINT [FK_HotelExpense_Hotels] FOREIGN KEY([HotelId])
REFERENCES [Hotel].[Hotels] ([Id])
GO
ALTER TABLE [Hotel].[HotelExpense] CHECK CONSTRAINT [FK_HotelExpense_Hotels]
GO
ALTER TABLE [Hotel].[HotelOfficers]  WITH CHECK ADD  CONSTRAINT [FK_HotelOfficers_HotelOfficerRoles] FOREIGN KEY([HotelOfficerRoleId])
REFERENCES [Hotel].[HotelOfficerRoles] ([Id])
GO
ALTER TABLE [Hotel].[HotelOfficers] CHECK CONSTRAINT [FK_HotelOfficers_HotelOfficerRoles]
GO
ALTER TABLE [Hotel].[HotelOfficers]  WITH CHECK ADD  CONSTRAINT [FK_HotelOfficers_Hotels] FOREIGN KEY([HotelId])
REFERENCES [Hotel].[Hotels] ([Id])
GO
ALTER TABLE [Hotel].[HotelOfficers] CHECK CONSTRAINT [FK_HotelOfficers_Hotels]
GO
ALTER TABLE [Hotel].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_Cities] FOREIGN KEY([HotelCityId])
REFERENCES [Setup].[Cities] ([Id])
GO
ALTER TABLE [Hotel].[Hotels] CHECK CONSTRAINT [FK_Hotels_Cities]
GO
ALTER TABLE [Hotel].[Officers]  WITH CHECK ADD  CONSTRAINT [FK_Officers_Roles] FOREIGN KEY([RoleId])
REFERENCES [Hotel].[Roles] ([Id])
GO
ALTER TABLE [Hotel].[Officers] CHECK CONSTRAINT [FK_Officers_Roles]
GO
ALTER TABLE [Hotel].[RoomServices]  WITH CHECK ADD  CONSTRAINT [FK_RoomServices_Rooms] FOREIGN KEY([RoomId])
REFERENCES [Hotel].[Rooms] ([Id])
GO
ALTER TABLE [Hotel].[RoomServices] CHECK CONSTRAINT [FK_RoomServices_Rooms]
GO
ALTER TABLE [Hotel].[RoomServices]  WITH CHECK ADD  CONSTRAINT [FK_RoomServices_Services] FOREIGN KEY([ServiceId])
REFERENCES [Hotel].[Services] ([Id])
GO
ALTER TABLE [Hotel].[RoomServices] CHECK CONSTRAINT [FK_RoomServices_Services]
GO
USE [master]
GO
ALTER DATABASE [FizzHotleBooking] SET  READ_WRITE 
GO
