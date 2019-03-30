USE [master]
GO
/****** Object:  Database [Mechanic]    Script Date: 7.06.2018 09:50:43 ******/
CREATE DATABASE [Mechanic]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mechanic', FILENAME = N'C:\Users\Muhammed\Mechanic.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mechanic_log', FILENAME = N'C:\Users\Muhammed\Mechanic_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Mechanic] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mechanic].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mechanic] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mechanic] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mechanic] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mechanic] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mechanic] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mechanic] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mechanic] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mechanic] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mechanic] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mechanic] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mechanic] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mechanic] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mechanic] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mechanic] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mechanic] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mechanic] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mechanic] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mechanic] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mechanic] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mechanic] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mechanic] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mechanic] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mechanic] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mechanic] SET  MULTI_USER 
GO
ALTER DATABASE [Mechanic] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mechanic] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mechanic] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mechanic] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mechanic] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Mechanic] SET QUERY_STORE = OFF
GO
USE [Mechanic]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Mechanic]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 7.06.2018 09:50:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LanguageCulture] [nvarchar](20) NOT NULL,
	[UniqueSeoCode] [nvarchar](2) NULL,
	[FlagImageFileName] [nvarchar](50) NULL,
	[Published] [bit] NULL,
	[DisplayOrder] [int] NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocaleStringResource]    Script Date: 7.06.2018 09:50:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocaleStringResource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[ResourceName] [nvarchar](200) NOT NULL,
	[ResourceValue] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LocaleStringResource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Language] ON 

INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (1, N'Turkçe', N'tr', NULL, NULL, 0, 0)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (2, N'English', N'en', NULL, NULL, 1, 2)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3, N'Russian', N'rs', NULL, NULL, 0, 0)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (1003, N'Arabic', N'ar-AR', N'ar', NULL, 0, 4)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (2002, N'Almanca', N'al', NULL, NULL, 1, 5)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (2003, N'Farsça', N'ir', NULL, NULL, 1, 6)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (2004, N'Finlandia', N'fi', NULL, NULL, 1, 7)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3003, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3004, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3005, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3006, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3007, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3008, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3009, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3010, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3011, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3012, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3013, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3014, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3015, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3016, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3017, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3018, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3019, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3020, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3021, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3022, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3023, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3024, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3025, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3026, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3027, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3028, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3029, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3030, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3031, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3032, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3033, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3034, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3035, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3036, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3037, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3038, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3039, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3040, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3041, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3042, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3043, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3044, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3045, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3046, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3047, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3048, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3049, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3050, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3051, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3052, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3053, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3054, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3055, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3056, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3057, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3059, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3060, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3061, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3062, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3063, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3064, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3065, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3066, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3067, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3068, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3069, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3070, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3071, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3072, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3073, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3074, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3075, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3076, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3077, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3078, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3079, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3080, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3081, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3082, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3083, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3084, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3085, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3086, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3087, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3088, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3089, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3090, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3091, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3093, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (3094, N'Test', N'test', NULL, NULL, 1, 9)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (4002, N'English', N'en', NULL, NULL, 0, 0)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (4003, N'test', N'test', N'', NULL, 0, 0)
GO
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (4004, N'Yamyamca', N'ya', N'ym', NULL, 0, 0)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [FlagImageFileName], [Published], [DisplayOrder]) VALUES (5002, N'halilce', N'hl', NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Language] OFF
SET IDENTITY_INSERT [dbo].[LocaleStringResource] ON 

INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (1, 1, N'account.accountactivation', N'Hesap Aktivasyonu')
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (2, 2, N'account.accountactivation', N'	Account activation')
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (3, 1, N'account.accountactivation.activated', N'hesabınız aktive edildi
')
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (5, 2, N'account.accountactivation.activated', N'Your account has been activated')
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (6, 3, N'account.accountactivation.activated', N'Ваша учетная запись активирована')
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (7, 3, N'account.accountactivation', N'Активация аккаунта
')
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (1002, 4002, N'test', N'test')
SET IDENTITY_INSERT [dbo].[LocaleStringResource] OFF
ALTER TABLE [dbo].[LocaleStringResource]  WITH CHECK ADD  CONSTRAINT [FK_LocaleStringResource_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
GO
ALTER TABLE [dbo].[LocaleStringResource] CHECK CONSTRAINT [FK_LocaleStringResource_Language]
GO
USE [master]
GO
ALTER DATABASE [Mechanic] SET  READ_WRITE 
GO
