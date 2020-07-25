USE [master]
GO
/****** Object:  Database [Campeonato_App_Grupo4]    Script Date: 24/07/2020 22:12:10 ******/
CREATE DATABASE [Campeonato_App_Grupo4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Campeonato_App_Grupo4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.TSQLEXPRESS\MSSQL\DATA\Campeonato_App_Grupo4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Campeonato_App_Grupo4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.TSQLEXPRESS\MSSQL\DATA\Campeonato_App_Grupo4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Campeonato_App_Grupo4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET ARITHABORT OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET  MULTI_USER 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET QUERY_STORE = OFF
GO
USE [Campeonato_App_Grupo4]
GO
/****** Object:  Table [dbo].[Jogador]    Script Date: 24/07/2020 22:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jogador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Nascimento] [datetime] NOT NULL,
	[Posicao] [varchar](255) NOT NULL,
	[QTDEFaltas] [int] NOT NULL,
	[QTDECartoesAmarelo] [int] NOT NULL,
	[QTDECartoesVermelho] [int] NOT NULL,
	[QTDEGols] [int] NOT NULL,
	[Informacoes] [text] NOT NULL,
	[NumeroCamisa] [int] NOT NULL,
	[Foto] [image] NULL,
	[SelecaoID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jogo]    Script Date: 24/07/2020 22:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jogo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SelecaoCasa] [int] NULL,
	[SelecaoVisitante] [int] NULL,
	[PlacarCasa] [int] NOT NULL,
	[PlacarVisitante] [int] NOT NULL,
	[PenaltisCasa] [int] NOT NULL,
	[PenaltisVisitante] [int] NOT NULL,
	[Data] [datetime] NULL,
	[Estadio] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Selecao]    Script Date: 24/07/2020 22:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Selecao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Bandeira] [image] NULL,
	[Uniforme] [image] NULL,
	[Escalacao] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 24/07/2020 22:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Apelido] [varchar](255) NOT NULL,
	[Foto] [image] NULL,
	[Senha] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Apelido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Jogador] ADD  DEFAULT ((0)) FOR [QTDEFaltas]
GO
ALTER TABLE [dbo].[Jogador] ADD  DEFAULT ((0)) FOR [QTDECartoesAmarelo]
GO
ALTER TABLE [dbo].[Jogador] ADD  DEFAULT ((0)) FOR [QTDECartoesVermelho]
GO
ALTER TABLE [dbo].[Jogador] ADD  DEFAULT ((0)) FOR [QTDEGols]
GO
ALTER TABLE [dbo].[Jogo] ADD  DEFAULT ((0)) FOR [PlacarCasa]
GO
ALTER TABLE [dbo].[Jogo] ADD  DEFAULT ((0)) FOR [PlacarVisitante]
GO
ALTER TABLE [dbo].[Jogo] ADD  DEFAULT ((0)) FOR [PenaltisCasa]
GO
ALTER TABLE [dbo].[Jogo] ADD  DEFAULT ((0)) FOR [PenaltisVisitante]
GO
ALTER TABLE [dbo].[Jogador]  WITH CHECK ADD FOREIGN KEY([SelecaoID])
REFERENCES [dbo].[Selecao] ([Id])
GO
ALTER TABLE [dbo].[Jogo]  WITH CHECK ADD FOREIGN KEY([SelecaoCasa])
REFERENCES [dbo].[Selecao] ([Id])
GO
ALTER TABLE [dbo].[Jogo]  WITH CHECK ADD FOREIGN KEY([SelecaoVisitante])
REFERENCES [dbo].[Selecao] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Campeonato_App_Grupo4] SET  READ_WRITE 
GO
