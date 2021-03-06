USE [master]
GO
/****** Object:  Database [PeopleDB]    Script Date: 8/24/2014 11:48:50 AM ******/
CREATE DATABASE [PeopleDB]
GO
ALTER DATABASE [PeopleDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PeopleDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PeopleDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PeopleDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PeopleDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PeopleDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PeopleDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PeopleDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PeopleDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PeopleDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PeopleDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PeopleDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PeopleDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PeopleDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PeopleDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PeopleDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PeopleDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PeopleDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PeopleDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PeopleDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PeopleDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PeopleDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PeopleDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PeopleDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PeopleDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PeopleDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PeopleDB] SET  MULTI_USER 
GO
ALTER DATABASE [PeopleDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PeopleDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PeopleDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PeopleDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PeopleDB', N'ON'
GO
USE [PeopleDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 8/24/2014 11:48:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[TownID] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 8/24/2014 11:48:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 8/24/2014 11:48:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentID] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 8/24/2014 11:48:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[AddressID] [int] NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 8/24/2014 11:48:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (1, N'Str. 1, No145', 3)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (3, N'Str. 1, No12', 4)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (4, N'Str. 3, No13', 1)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (5, N'Str. 3, No6', 1)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (6, N'Str. 11, No16', 6)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (7, N'Str. 12, No4', 9)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (8, N'Str. 8, No37', 12)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (1, N'Asia')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (2, N'Africa')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (3, N'North America')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (4, N'South America')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (5, N'Antarctica')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (6, N'Europe')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (7, N'Australia')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (3, N'Afghanistan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (4, N'Armenia', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (5, N'Azerbaijan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (6, N'Bahrain', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (7, N'Bangladesh', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (8, N'Bhutan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (9, N'Brunei', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (10, N'Burma', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (11, N'Cambodia', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (12, N'China', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (13, N'Cyprus', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (14, N'Egypt', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (15, N'Georgia', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (16, N'India', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (17, N'Indonesia', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (18, N'Iran', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (19, N'Iraq', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (20, N'Israel', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (21, N'Japan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (22, N'Jordan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (23, N'Kazakhstan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (24, N'North Korea', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (25, N'South Korea', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (26, N'Kuwait', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (27, N'Kyrgyzstan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (28, N'Laos', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (29, N'Lebanon', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (30, N'Malaysia', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (31, N'Maldives', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (32, N'Mongolia', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (33, N'Nepal', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (34, N'Oman', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (35, N'Pakistan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (36, N'Palestine', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (37, N'Philippines', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (38, N'Qatar', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (39, N'Russia', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (40, N'Saudi Arabia', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (41, N'Singapore', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (42, N'Sri Lanka', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (43, N'Syria', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (44, N'Tajikistan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (45, N'Thailand', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (46, N'East Timor', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (47, N'Turkey', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (48, N'Turkmenistan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (49, N'United Arab Emirates', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (50, N'Uzbekistan', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (51, N'Vietnam', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (52, N'Yemen', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (53, N'Algeria', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (54, N'Angola', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (55, N'Benin', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (56, N'Botswana', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (57, N'Burkina Faso', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (58, N'Burundi', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (59, N'Cameroon', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (60, N'Cape Verde', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (61, N'Central African Republic', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (62, N'Chad', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (63, N'Comoros', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (64, N'Democratic Republic of the Congo', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (65, N'Republic of the Congo', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (66, N'Djibouti', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (67, N'Egypt', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (68, N'Equatorial Guinea', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (69, N'Eritrea', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (70, N'Ethiopia', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (71, N'Gabon', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (72, N'The Gambia', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (73, N'Ghana', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (74, N'Guinea', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (75, N'Guinea Bissau', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (76, N'Ivory Coast', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (77, N'Kenya', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (78, N'Lesotho', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (79, N'Liberia', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (80, N'Libya', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (81, N'Madagascar', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (82, N'Malawi', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (83, N'Mali', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (84, N'Mauritania', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (85, N'Mauritius', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (86, N'Morocco', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (87, N'Mozambique', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (88, N'Namibia', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (89, N'Niger', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (90, N'Nigeria', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (91, N'Rwanda', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (92, N'Sao Tome and Principe', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (93, N'Senegal', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (94, N'Seychelles', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (95, N'Sierra Leone', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (96, N'Somalia', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (97, N'South Africa', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (98, N'South Sudan', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (99, N'Sudan', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (100, N'Swaziland', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (101, N'Tanzania', 2)
GO
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (102, N'Togo', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (103, N'Tunisia', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (104, N'Uganda', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (105, N'Zambia', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (106, N'Zimbabwe', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (107, N'Antigua and Barbuda', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (108, N'Bahamas', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (109, N'Barbados', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (110, N'Belize', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (111, N'Canada', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (112, N'Costa Rica', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (113, N'Cuba', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (114, N'Dominica', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (115, N'Dominican Republic', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (116, N'El Salvador', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (117, N'Grenada', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (118, N'Guatemala', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (119, N'Haiti', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (120, N'Honduras', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (121, N'Iceland', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (122, N'Jamaica', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (123, N'Mexico', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (124, N'Nicaragua', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (125, N'Panama', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (126, N'St. Kitts and Nevis', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (127, N'Saint Lucia', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (128, N'St. Vincent and the Grenadines', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (129, N'Trinidad and Tobago', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (130, N'United States', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (131, N'Argentina', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (132, N'Bolivia', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (133, N'Brazil', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (134, N'Chile', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (135, N'Colombia', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (136, N'Ecuador', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (137, N'Guyana', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (138, N'Paraguay', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (139, N'Peru', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (140, N'Suriname', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (141, N'Trinidad and Tobago', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (142, N'Uruguay', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (143, N'Venezuela', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (144, N'Albania', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (145, N'Andorra', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (146, N'Armenia1', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (147, N'Austria', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (148, N'Azerbaijan1', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (149, N'Belarus', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (150, N'Belgium', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (151, N'Bosnia and Herzegovina', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (152, N'Bulgaria', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (153, N'Croatia', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (154, N'Cyprus1', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (155, N'Czech Republic', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (156, N'Denmark', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (157, N'Estonia', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (158, N'Finland', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (159, N'France', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (160, N'Georgia', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (161, N'Germany', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (162, N'Greece', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (163, N'Hungary', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (164, N'Iceland', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (165, N'Ireland', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (166, N'Italy', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (167, N'Kazakhstan', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (168, N'Latvia', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (169, N'Liechtenstein', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (170, N'Lithuania', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (171, N'Luxembourg', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (172, N'Macedonia', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (173, N'Malta', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (174, N'Moldova', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (175, N'Monaco', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (176, N'Montenegro', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (177, N'Netherlands', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (178, N'Norway', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (179, N'Poland', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (180, N'Portugal', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (181, N'Romania', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (182, N'Russia1', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (183, N'San Marino', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (184, N'Serbia', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (185, N'Slovakia', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (186, N'Slovenia', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (187, N'Spain', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (188, N'Sweden', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (189, N'Switzerland', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (190, N'Turkey', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (191, N'Ukraine', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (192, N'United Kingdom', 6)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (193, N'Vatican City', 6)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (1, N'Ivan', N'Ivanov', 1)
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (2, N'Maria', N'Petrova', 4)
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (3, N'Pesho', N'Stoyanov', 6)
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (4, N'Bob', NULL, NULL)
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (5, N'Ricky', N'Murra', 8)
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (1, N'Sofia', 152)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (3, N'Plovdiv', 152)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (4, N'Varna', 152)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (5, N'Warsaw', 179)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (6, N'Madrid', 187)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (7, N'Buenos Aires', 131)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (8, N'Ottawa', 111)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (9, N'Moscow', 39)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (11, N'Novosibirsk', 39)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (12, N'Cairo', 67)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownID])
REFERENCES [dbo].[Towns] ([TownID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continents] ([ContinentID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Addresses] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [PeopleDB] SET  READ_WRITE 
GO
