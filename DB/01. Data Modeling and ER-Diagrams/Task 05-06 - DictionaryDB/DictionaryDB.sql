USE [master]
GO
/****** Object:  Database [DictionaryDB]    Script Date: 8/24/2014 4:13:46 PM ******/
CREATE DATABASE [DictionaryDB]
GO
ALTER DATABASE [DictionaryDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DictionaryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DictionaryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DictionaryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DictionaryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DictionaryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DictionaryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DictionaryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DictionaryDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DictionaryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DictionaryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DictionaryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DictionaryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DictionaryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DictionaryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DictionaryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DictionaryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DictionaryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DictionaryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DictionaryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DictionaryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DictionaryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DictionaryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DictionaryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DictionaryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DictionaryDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DictionaryDB] SET  MULTI_USER 
GO
ALTER DATABASE [DictionaryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DictionaryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DictionaryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DictionaryDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DictionaryDB', N'ON'
GO
USE [DictionaryDB]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 8/24/2014 4:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartOfSpeechInformations]    Script Date: 8/24/2014 4:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartOfSpeechInformations](
	[PartOfSpeechID] [int] IDENTITY(1,1) NOT NULL,
	[Information] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PartOfSpeechInformations] PRIMARY KEY CLUSTERED 
(
	[PartOfSpeechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 8/24/2014 4:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[LanguageID] [int] NOT NULL,
	[PartOfSpeechID] [int] NULL,
	[AntonymWordID] [int] NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Explanations]    Script Date: 8/24/2014 4:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Explanations](
	[WordID] [int] NOT NULL,
	[LanguageID] [int] NOT NULL,
	[Explanation] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Hyponyms]    Script Date: 8/24/2014 4:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Hyponyms](
	[WordID] [int] NOT NULL,
	[HyponymID] [int] NOT NULL,
 CONSTRAINT [PK_Words_Hyponyms] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[HyponymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Synonyms]    Script Date: 8/24/2014 4:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Synonyms](
	[WordID] [int] NOT NULL,
	[SynonymID] [int] NOT NULL,
 CONSTRAINT [PK_Words_Synonyms] PRIMARY KEY CLUSTERED 
(
	[SynonymID] ASC,
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Translations]    Script Date: 8/24/2014 4:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Translations](
	[WordsID] [int] NOT NULL,
	[TranslationWordID] [int] NOT NULL,
 CONSTRAINT [PK_Words_Translations_1] PRIMARY KEY CLUSTERED 
(
	[WordsID] ASC,
	[TranslationWordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (1, N'English')
INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (2, N'Bulgarian')
INSERT [dbo].[Languages] ([LanguageID], [Language]) VALUES (3, N'Italian')
SET IDENTITY_INSERT [dbo].[Languages] OFF
SET IDENTITY_INSERT [dbo].[Words] ON 

INSERT [dbo].[Words] ([WordID], [Word], [LanguageID], [PartOfSpeechID], [AntonymWordID]) VALUES (1, N'Cow', 1, NULL, NULL)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID], [PartOfSpeechID], [AntonymWordID]) VALUES (2, N'Dog', 1, NULL, NULL)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID], [PartOfSpeechID], [AntonymWordID]) VALUES (3, N'Куче', 2, NULL, NULL)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID], [PartOfSpeechID], [AntonymWordID]) VALUES (4, N'Крава', 2, NULL, NULL)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID], [PartOfSpeechID], [AntonymWordID]) VALUES (5, N'Мucca', 3, NULL, NULL)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID], [PartOfSpeechID], [AntonymWordID]) VALUES (6, N'Cane', 3, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Words] OFF
INSERT [dbo].[Words_Explanations] ([WordID], [LanguageID], [Explanation]) VALUES (2, 1, N'Four-legged mammal')
INSERT [dbo].[Words_Explanations] ([WordID], [LanguageID], [Explanation]) VALUES (2, 2, N'Четирикрак бозайник')
INSERT [dbo].[Words_Translations] ([WordsID], [TranslationWordID]) VALUES (1, 4)
INSERT [dbo].[Words_Translations] ([WordsID], [TranslationWordID]) VALUES (1, 5)
INSERT [dbo].[Words_Translations] ([WordsID], [TranslationWordID]) VALUES (2, 3)
INSERT [dbo].[Words_Translations] ([WordsID], [TranslationWordID]) VALUES (2, 6)
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartOfSpeechInformations] FOREIGN KEY([PartOfSpeechID])
REFERENCES [dbo].[PartOfSpeechInformations] ([PartOfSpeechID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartOfSpeechInformations]
GO
ALTER TABLE [dbo].[Words_Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Explanations_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Words_Explanations] CHECK CONSTRAINT [FK_Words_Explanations_Languages]
GO
ALTER TABLE [dbo].[Words_Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Explanations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Explanations] CHECK CONSTRAINT [FK_Words_Explanations_Words]
GO
ALTER TABLE [dbo].[Words_Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Hyponyms_Words1] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Hyponyms] CHECK CONSTRAINT [FK_Words_Hyponyms_Words1]
GO
ALTER TABLE [dbo].[Words_Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Hyponyms_Words2] FOREIGN KEY([HyponymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Hyponyms] CHECK CONSTRAINT [FK_Words_Hyponyms_Words2]
GO
ALTER TABLE [dbo].[Words_Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Synonyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Synonyms] CHECK CONSTRAINT [FK_Words_Synonyms_Words]
GO
ALTER TABLE [dbo].[Words_Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Synonyms_Words1] FOREIGN KEY([SynonymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Synonyms] CHECK CONSTRAINT [FK_Words_Synonyms_Words1]
GO
ALTER TABLE [dbo].[Words_Translations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations_Words] FOREIGN KEY([WordsID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Translations] CHECK CONSTRAINT [FK_Words_Translations_Words]
GO
ALTER TABLE [dbo].[Words_Translations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations_Words1] FOREIGN KEY([TranslationWordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Translations] CHECK CONSTRAINT [FK_Words_Translations_Words1]
GO
USE [master]
GO
ALTER DATABASE [DictionaryDB] SET  READ_WRITE 
GO
