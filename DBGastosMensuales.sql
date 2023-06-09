USE [master]
GO
/****** Object:  Database [GastosMensuales]    Script Date: 6/9/2021 18:10:23 ******/
CREATE DATABASE [GastosMensuales]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GastosMensuales', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.KAIZENET\MSSQL\DATA\GastosMensuales.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GastosMensuales_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.KAIZENET\MSSQL\DATA\GastosMensuales_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GastosMensuales] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GastosMensuales].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GastosMensuales] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GastosMensuales] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GastosMensuales] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GastosMensuales] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GastosMensuales] SET ARITHABORT OFF 
GO
ALTER DATABASE [GastosMensuales] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GastosMensuales] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GastosMensuales] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GastosMensuales] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GastosMensuales] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GastosMensuales] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GastosMensuales] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GastosMensuales] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GastosMensuales] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GastosMensuales] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GastosMensuales] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GastosMensuales] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GastosMensuales] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GastosMensuales] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GastosMensuales] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GastosMensuales] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GastosMensuales] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GastosMensuales] SET RECOVERY FULL 
GO
ALTER DATABASE [GastosMensuales] SET  MULTI_USER 
GO
ALTER DATABASE [GastosMensuales] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GastosMensuales] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GastosMensuales] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GastosMensuales] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GastosMensuales] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GastosMensuales', N'ON'
GO
ALTER DATABASE [GastosMensuales] SET QUERY_STORE = OFF
GO
USE [GastosMensuales]
GO
/****** Object:  Table [dbo].[Gastos]    Script Date: 6/9/2021 18:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gastos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Monto] [decimal](10, 3) NOT NULL,
	[Periodicidad] [int] NOT NULL,
	[Cuotas] [int] NULL,
	[TipoMonto] [int] NOT NULL,
 CONSTRAINT [PK_Gastos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingresos]    Script Date: 6/9/2021 18:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingresos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Monto] [decimal](10, 3) NOT NULL,
	[TipoMonto] [int] NOT NULL,
 CONSTRAINT [PK_Ingresos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presupuestos]    Script Date: 6/9/2021 18:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presupuestos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Año] [int] NOT NULL,
	[Mes] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Ingresos] [decimal](10, 3) NOT NULL,
	[Gastos] [decimal](10, 3) NOT NULL,
	[Total] [decimal](10, 3) NOT NULL,
 CONSTRAINT [PK_Presupuestos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[R_PresupuestoGasto]    Script Date: 6/9/2021 18:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_PresupuestoGasto](
	[Id_Presupuesto] [int] NOT NULL,
	[Id_Gasto] [int] NOT NULL,
 CONSTRAINT [PK_R_PresupuestoGasto] PRIMARY KEY CLUSTERED 
(
	[Id_Presupuesto] ASC,
	[Id_Gasto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[R_PresupuestoIngreso]    Script Date: 6/9/2021 18:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_PresupuestoIngreso](
	[Id_Presupuesto] [int] NOT NULL,
	[Id_Ingreso] [int] NOT NULL,
 CONSTRAINT [PK_R_PresupuestoIngreso] PRIMARY KEY CLUSTERED 
(
	[Id_Presupuesto] ASC,
	[Id_Ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMonto]    Script Date: 6/9/2021 18:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMonto](
	[Id] [int] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoMonto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TipoMonto] ([Id], [Tipo]) VALUES (1, N'Fijo')
INSERT [dbo].[TipoMonto] ([Id], [Tipo]) VALUES (2, N'Variable')
GO
USE [master]
GO
ALTER DATABASE [GastosMensuales] SET  READ_WRITE 
GO
