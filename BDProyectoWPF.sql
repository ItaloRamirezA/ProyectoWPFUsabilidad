USE [master]
GO
/****** Object:  Database [ProyectoWPF]    Script Date: 21/11/2024 23:10:26 ******/
CREATE DATABASE [ProyectoWPF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoWPF', FILENAME = N'C:\Users\italo\ProyectoWPF.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyectoWPF_log', FILENAME = N'C:\Users\italo\ProyectoWPF_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProyectoWPF] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoWPF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoWPF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoWPF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoWPF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoWPF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoWPF] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoWPF] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProyectoWPF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoWPF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoWPF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoWPF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoWPF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoWPF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoWPF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoWPF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoWPF] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProyectoWPF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoWPF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoWPF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoWPF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoWPF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoWPF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoWPF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoWPF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProyectoWPF] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoWPF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoWPF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoWPF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoWPF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProyectoWPF] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyectoWPF] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProyectoWPF] SET QUERY_STORE = OFF
GO
USE [ProyectoWPF]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 21/11/2024 23:10:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Usuario] [nchar](10) NOT NULL,
	[Contrasena] [nchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 21/11/2024 23:10:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Tamano] [int] NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
	[Precio] [float] NOT NULL,
	[ImagenPath] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Login] ([Usuario], [Contrasena]) VALUES (N'admin     ', N'admin123  ')
INSERT [dbo].[Login] ([Usuario], [Contrasena]) VALUES (N'user1     ', N'password1 ')
INSERT [dbo].[Login] ([Usuario], [Contrasena]) VALUES (N'user2     ', N'password2 ')
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [Tamano], [Descripcion], [Precio], [ImagenPath]) VALUES (1, N'Cinamoroll Peluche', 28, N'Peluchito de Cinamoroll, serie clásica. Hecho con material suave para abrazar.', 29.99, N'Imagenes/Home/cinamorollPeluche.jpg')
INSERT [dbo].[Productos] ([Id], [Nombre], [Tamano], [Descripcion], [Precio], [ImagenPath]) VALUES (2, N'Hello Kitty Peluche', 30, N'Peluchito de Hello Kitty, serie clásica. Ideal para coleccionistas de peluches adorables.', 32.99, N'Imagenes/Home/kittyPeluche.jpg')
INSERT [dbo].[Productos] ([Id], [Nombre], [Tamano], [Descripcion], [Precio], [ImagenPath]) VALUES (3, N'Kuromi Peluche', 25, N'Peluchito de Kuromi, serie clásica. Un regalo perfecto para los fans del estilo punk y kawaii.', 27.99, N'Imagenes/Home/kuromiPeluche.jpg')
INSERT [dbo].[Productos] ([Id], [Nombre], [Tamano], [Descripcion], [Precio], [ImagenPath]) VALUES (4, N'My Melody Peluche', 23, N'Peluchito de My Melody, serie clásica. Un peluche suave y tierno que te hará sonreír cada día.', 25.99, N'Imagenes/Home/myMelodyPeluche.jpg')
INSERT [dbo].[Productos] ([Id], [Nombre], [Tamano], [Descripcion], [Precio], [ImagenPath]) VALUES (5, N'PomPomPurin Peluche', 26, N'Peluchito de PomPomPurin, serie clásica. Con un diseño adorable, ideal para abrazos y coleccionismo.', 26.99, N'Imagenes/Home/pompomPeluche.jpg')
GO
USE [master]
GO
ALTER DATABASE [ProyectoWPF] SET  READ_WRITE 
GO
