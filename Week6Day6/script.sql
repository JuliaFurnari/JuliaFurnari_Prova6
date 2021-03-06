USE [master]
GO
/****** Object:  Database [Insurance]    Script Date: 03-Sep-21 3:17:14 PM ******/
CREATE DATABASE [Insurance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Insurance', FILENAME = N'C:\Users\julia.furnari\Insurance.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Insurance_log', FILENAME = N'C:\Users\julia.furnari\Insurance_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Insurance] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Insurance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Insurance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Insurance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Insurance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Insurance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Insurance] SET ARITHABORT OFF 
GO
ALTER DATABASE [Insurance] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Insurance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Insurance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Insurance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Insurance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Insurance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Insurance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Insurance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Insurance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Insurance] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Insurance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Insurance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Insurance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Insurance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Insurance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Insurance] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Insurance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Insurance] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Insurance] SET  MULTI_USER 
GO
ALTER DATABASE [Insurance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Insurance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Insurance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Insurance] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Insurance] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Insurance] SET QUERY_STORE = OFF
GO
USE [Insurance]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Insurance]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 03-Sep-21 3:17:14 PM ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 03-Sep-21 3:17:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FiscalCode] [nchar](16) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](20) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Policies]    Script Date: 03-Sep-21 3:17:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PolicyNumber] [int] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[MonthlyPayment] [decimal](18, 2) NOT NULL,
	[Type] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Policies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210903080221_CreateDb', N'5.0.9')
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [FiscalCode], [FirstName], [LastName]) VALUES (1, N'frnamd70p56c345j', N'Mario', N'Rossi')
INSERT [dbo].[Customers] ([Id], [FiscalCode], [FirstName], [LastName]) VALUES (2, N'frnamd70p56c345k', N'Laura', N'Bisicchia')
INSERT [dbo].[Customers] ([Id], [FiscalCode], [FirstName], [LastName]) VALUES (3, N'frnamd70p56c345c', N'Rita', N'Bruno')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Policies] ON 

INSERT [dbo].[Policies] ([Id], [PolicyNumber], [ExpirationDate], [MonthlyPayment], [Type], [CustomerId]) VALUES (1, 2, CAST(N'2021-12-03' AS Date), CAST(10.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Policies] ([Id], [PolicyNumber], [ExpirationDate], [MonthlyPayment], [Type], [CustomerId]) VALUES (2, 34, CAST(N'2021-12-01' AS Date), CAST(50.00 AS Decimal(18, 2)), 2, 2)
INSERT [dbo].[Policies] ([Id], [PolicyNumber], [ExpirationDate], [MonthlyPayment], [Type], [CustomerId]) VALUES (3, 23, CAST(N'2022-01-01' AS Date), CAST(5.00 AS Decimal(18, 2)), 0, 3)
INSERT [dbo].[Policies] ([Id], [PolicyNumber], [ExpirationDate], [MonthlyPayment], [Type], [CustomerId]) VALUES (4, 24, CAST(N'2022-01-01' AS Date), CAST(50.00 AS Decimal(18, 2)), 2, 3)
INSERT [dbo].[Policies] ([Id], [PolicyNumber], [ExpirationDate], [MonthlyPayment], [Type], [CustomerId]) VALUES (5, 56, CAST(N'2021-12-12' AS Date), CAST(2.00 AS Decimal(18, 2)), 1, 3)
SET IDENTITY_INSERT [dbo].[Policies] OFF
GO
/****** Object:  Index [IX_Policies_CustomerId]    Script Date: 03-Sep-21 3:17:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Policies_CustomerId] ON [dbo].[Policies]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Policies]  WITH CHECK ADD  CONSTRAINT [FK_Policies_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Policies] CHECK CONSTRAINT [FK_Policies_Customers_CustomerId]
GO
USE [master]
GO
ALTER DATABASE [Insurance] SET  READ_WRITE 
GO
