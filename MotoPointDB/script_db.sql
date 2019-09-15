USE [master]
GO
/****** Object:  Database [MotoPoint]    Script Date: 15/9/2019 16:30:55 ******/
CREATE DATABASE [MotoPoint]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MotoPoint', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MotoPoint.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MotoPoint_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MotoPoint_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MotoPoint] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MotoPoint].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MotoPoint] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MotoPoint] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MotoPoint] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MotoPoint] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MotoPoint] SET ARITHABORT OFF 
GO
ALTER DATABASE [MotoPoint] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MotoPoint] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MotoPoint] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MotoPoint] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MotoPoint] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MotoPoint] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MotoPoint] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MotoPoint] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MotoPoint] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MotoPoint] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MotoPoint] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MotoPoint] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MotoPoint] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MotoPoint] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MotoPoint] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MotoPoint] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MotoPoint] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MotoPoint] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MotoPoint] SET  MULTI_USER 
GO
ALTER DATABASE [MotoPoint] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MotoPoint] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MotoPoint] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MotoPoint] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MotoPoint] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MotoPoint] SET QUERY_STORE = OFF
GO
USE [MotoPoint]
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 15/9/2019 16:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad](
	[id] [int] NULL,
	[codRuta] [nvarchar](50) NULL,
	[titulo] [nvarchar](50) NULL,
	[descripcion] [nvarchar](250) NULL,
	[codAct] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActividadPrecio]    Script Date: 15/9/2019 16:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActividadPrecio](
	[id] [int] NULL,
	[codAct] [nvarchar](50) NULL,
	[tituloActividad] [nvarchar](100) NULL,
	[descripcion] [nvarchar](250) NULL,
	[precio] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriaMoto]    Script Date: 15/9/2019 16:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaMoto](
	[id] [int] NOT NULL,
	[categoriaMoto] [int] NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Categoria_Moto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConeccionesUsuario]    Script Date: 15/9/2019 16:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConeccionesUsuario](
	[idUsuario] [int] NOT NULL,
	[reitento] [int] NULL,
	[fecha] [nvarchar](50) NULL,
 CONSTRAINT [PK_ConeccionesUsuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 15/9/2019 16:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[id] [int] NULL,
	[codEvento] [nvarchar](50) NULL,
	[desde] [nvarchar](50) NULL,
	[hasta] [nvarchar](50) NULL,
	[cantidadMinimaUsuarios] [nvarchar](50) NULL,
	[cantidadActualUsuarios] [nvarchar](50) NULL,
	[cantidadMaximaUsuarios] [nvarchar](50) NULL,
	[estado] [nvarchar](50) NULL,
	[detalleEvento] [nvarchar](250) NULL,
	[fecha] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventoEstado]    Script Date: 15/9/2019 16:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventoEstado](
	[id] [nvarchar](50) NULL,
	[desc] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experto]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experto](
	[id] [int] NULL,
	[codExp] [nvarchar](50) NULL,
	[nombre] [nvarchar](50) NULL,
	[descripcion] [nvarchar](250) NULL,
	[email] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembresiaPrecio]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembresiaPrecio](
	[idMembresia] [int] NULL,
	[precio] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembresiaTipo]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembresiaTipo](
	[idMembresia] [int] NULL,
	[tipoMembresia] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembresiaUsuario]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembresiaUsuario](
	[idUsuario] [int] NOT NULL,
	[idMembresia] [int] NULL,
 CONSTRAINT [PK_MembresiaUsuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ofertas]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ofertas](
	[id] [int] NULL,
	[empresa] [nvarchar](50) NULL,
	[titulo] [nvarchar](50) NULL,
	[descripcion] [nvarchar](300) NULL,
	[fechaVigencia] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PagoUsuario]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagoUsuario](
	[idNumeroOrden] [int] NULL,
	[idUsuario] [nvarchar](50) NULL,
	[nombreApellido] [nvarchar](50) NULL,
	[descripcion] [nvarchar](50) NULL,
	[monto] [nvarchar](50) NULL,
	[fechaPago] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ruta]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ruta](
	[id] [int] NULL,
	[codRuta] [nvarchar](50) NULL,
	[desde] [nvarchar](50) NULL,
	[hasta] [nvarchar](50) NULL,
	[minMotos] [int] NULL,
	[maxMotos] [int] NULL,
	[detalleRuta] [nvarchar](250) NULL,
	[fecha] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RutaUsuario]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RutaUsuario](
	[id] [int] NULL,
	[codRuta] [nvarchar](50) NULL,
	[usuario] [nvarchar](50) NULL,
	[fecha] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RutaVotacion]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RutaVotacion](
	[Id] [int] NULL,
	[codRuta] [nvarchar](50) NULL,
	[desde] [nvarchar](50) NULL,
	[hasta] [nvarchar](50) NULL,
	[cantUsuario] [int] NULL,
	[estado] [nvarchar](50) NULL,
	[detalleRutaVotacion] [nvarchar](550) NULL,
	[fechaLimite] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Bitacora]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Bitacora](
	[idEvento] [int] NOT NULL,
	[idUsuario] [varchar](50) NULL,
	[descripcion] [varchar](100) NULL,
	[fecha] [varchar](50) NULL,
	[digitoVerificador] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Bitacora] PRIMARY KEY CLUSTERED 
(
	[idEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Grupo]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Grupo](
	[idGrupo] [int] NOT NULL,
	[grupo] [varchar](20) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Grupo] PRIMARY KEY CLUSTERED 
(
	[idGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_GrupoPermisos]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GrupoPermisos](
	[idGrupo] [int] NOT NULL,
	[idPermisos] [int] NOT NULL,
 CONSTRAINT [PK_tbl_GrupoPermisos] PRIMARY KEY CLUSTERED 
(
	[idGrupo] ASC,
	[idPermisos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MultiIdioma]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MultiIdioma](
	[componente] [varchar](25) NOT NULL,
	[ikey] [varchar](50) NOT NULL,
	[value] [varchar](60) NOT NULL,
 CONSTRAINT [PK_tbl_Multi_Idioma] PRIMARY KEY CLUSTERED 
(
	[componente] ASC,
	[ikey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Permisos]    Script Date: 15/9/2019 16:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Permisos](
	[idPermiso] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Permisos] PRIMARY KEY CLUSTERED 
(
	[idPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Usuario]    Script Date: 15/9/2019 16:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Usuario](
	[idUsuario] [int] NOT NULL,
	[nombreApellido] [varchar](50) NULL,
	[fechaNacimiento] [varchar](50) NULL,
	[categoriaMoto] [varchar](50) NULL,
	[usuario] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
	[digitoVerificador] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UsuarioGrupo]    Script Date: 15/9/2019 16:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UsuarioGrupo](
	[idUsuario] [int] NOT NULL,
	[idGrupo] [int] NOT NULL,
 CONSTRAINT [PK_tbl_UsuarioGrupo] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[idGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Actividad] ([id], [codRuta], [titulo], [descripcion], [codAct]) VALUES (1, N'CHS01', N'QUE HACER EN CHASCOMÚS', N'Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica.', N'ACTCHS01')
INSERT [dbo].[Actividad] ([id], [codRuta], [titulo], [descripcion], [codAct]) VALUES (2, N'MDQ01', N'QUE HACER EN MAR DEL PLATA', N'Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica.', N'ACTMDQ01')
INSERT [dbo].[Actividad] ([id], [codRuta], [titulo], [descripcion], [codAct]) VALUES (3, N'COR01', N'QUE HACER EN CORDOBA', N'Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica.', N'ACTCOR01')
INSERT [dbo].[Actividad] ([id], [codRuta], [titulo], [descripcion], [codAct]) VALUES (4, N'ROS01', N'QUE HACER EN ROSARIO', N'Las actividades turísticas encaminadas a ofrecer al moto aficionado, la posibilidad de ocupar su tiempo ocio y/o vacacional, forman parte de vivir una experiencia unica.', N'ACTROS01')
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (1, N'ACTCHS01', N'Laguna de Cascomus', N'Parque historico de la ciudad.', 50)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (2, N'ACTCHS01', N'Capilla de los Negros', N'La Capilla de los negros de la ciudad argentina de Chascomús fue originalmente creada en 1867 como sede de una hermandad de negros', 25)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (3, N'ACTCHS01', N'Estancia La Alameda en Chascomus', N'En este paseo podrás disfrutar un día en el campo en la Estancia La Alameda y aprovechar sus instalaciones, como canchas de fútbol y voley. ¡Además de no tener que preocuparte por las comidas!', 2790)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (4, N'ACTCHS01', N'Museo Ferroviario Chascomús', N'Se trata de la vieja estación del ferrocarril por lo cual tiene su propio encanto mas el pequeño Museo Ferroviario', 50)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (5, N'ACTMDQ01', N'Excursión a Sierra de los Padres', N'A solo 15 minutos de Mar del Plata, se encuentra este paraíso escondido. Entre colinas, huertas y granjas con las Sierras de los Padres como fondo, encontrarás toda lo necesario para pasar un día diferente.', 1876)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (6, N'ACTMDQ01', N'Experiencia Surf', N'La capital nacional del Surf brinda una experiencia inolvidable para aquellos que nunca practicaron el deporte.', 1012)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (7, N'ACTMDQ01', N'Bodega Costa y Pampa', N'Visita a Bodega Costa y Pampa, un tesoro escondido entre el mar y la pampa cultivado para revolucionar todo lo conocido. ', 2450)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (8, N'ACTMDQ01', N'Desayuno en Torreón del Monje', N'El Torreón del Monje es uno de los referentes edilicios más importantes de Mar del Plata, que aporta gran valor a la identidad de la ciudad.', 350)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (9, N'ACTCOR01', N'La Cumbrecita', N'La Cumbrecita. Un pueblito alpino enclavado en las sierras', 1770)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (10, N'ACTCOR01', N'Tour por la ciudad', N'Esta ciudad del centro del país es la 2da más poblada y cuenta con una rica historia', 1176)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (11, N'ACTCOR01', N'Excursión a Alta Gracia', N'La ciudad es un conocido centro turístico gracias a su patrimonio arquitectónico', 1500)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (12, N'ACTCOR01', N'Valle de Traslasierra', N'Valle de Traslasierra. El mirador de Córdoba.', 1924)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (13, N'ACTROS01', N'Escapada a la ciudad de Victoria', N'Salida desde Rosario con destino a la ciudad de Victoria', 2430)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (14, N'ACTROS01', N'Escapada a San Lorenzo', N'Salida desde Rosario hacia San Lorenzo, ubicada a solo 20 km de distancia', 3915)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (15, N'ACTROS01', N'Día de Isla en El Pimpollal', N'Un lugar donde se vive intensamente cada momento, con los sentidos y sentimientos a flor de piel', 3375)
INSERT [dbo].[ActividadPrecio] ([id], [codAct], [tituloActividad], [descripcion], [precio]) VALUES (16, N'ACTROS01', N'Paseo en el Barco ciudad de Rosario ', N'Este paseo parte desde la est. Fluvial de Rosario', 533)
INSERT [dbo].[CategoriaMoto] ([id], [categoriaMoto], [descripcion]) VALUES (1, 1, N'0cc-150cc')
INSERT [dbo].[CategoriaMoto] ([id], [categoriaMoto], [descripcion]) VALUES (2, 2, N'150cc-250cc')
INSERT [dbo].[CategoriaMoto] ([id], [categoriaMoto], [descripcion]) VALUES (3, 3, N'+300cc')
INSERT [dbo].[ConeccionesUsuario] ([idUsuario], [reitento], [fecha]) VALUES (1, 3, N'12/1/2019 14:41:26')
INSERT [dbo].[ConeccionesUsuario] ([idUsuario], [reitento], [fecha]) VALUES (2, 0, N'12/1/2019 14:41:26')
INSERT [dbo].[ConeccionesUsuario] ([idUsuario], [reitento], [fecha]) VALUES (3, 1, N'17/8/2019 20:21:21')
INSERT [dbo].[ConeccionesUsuario] ([idUsuario], [reitento], [fecha]) VALUES (4, 0, N'12/1/2019 14:41:26')
INSERT [dbo].[ConeccionesUsuario] ([idUsuario], [reitento], [fecha]) VALUES (5, 3, N'12/1/2019 14:41:26')
INSERT [dbo].[ConeccionesUsuario] ([idUsuario], [reitento], [fecha]) VALUES (6, 0, N'12/1/2019 14:41:26')
INSERT [dbo].[ConeccionesUsuario] ([idUsuario], [reitento], [fecha]) VALUES (7, 0, N'12/1/2019 14:41:26')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (1, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'01-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (2, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'05-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (3, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'10-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (4, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'20-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (5, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'01-02-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (6, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'01-03-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (7, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'01-04-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (8, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'01-05-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (9, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'01-06-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (10, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'01-07-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (11, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'15-07-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (12, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'01-08-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (13, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'30', N'30', N'FINALIZADO', N'Nos fuimos para la Feliz!!', N'15-08-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (14, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'01-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (15, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'10-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (16, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'20-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (17, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'01-02-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (18, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'01-03-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (19, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'01-04-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (20, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'01-05-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (21, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'01-06-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (22, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'01-07-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (23, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'15-07-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (24, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'01-08-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (25, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'15', N'15', N'FINALIZADO', N'A comer media lunas en un clasico Argentino.', N'15-08-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (26, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'01-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (27, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'10-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (28, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'20-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (29, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'01-02-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (30, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'01-03-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (31, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'01-04-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (32, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'01-05-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (33, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'01-06-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (34, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'01-07-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (35, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'15-07-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (36, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'01-08-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (37, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'30', N'30', N'FINALIZADO', N'Prepara el fernet y la coca.', N'15-08-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (38, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'01-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (39, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'10-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (40, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'20-01-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (41, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'01-02-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (42, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'01-03-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (43, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'01-04-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (44, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'01-05-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (45, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'01-06-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (46, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'01-07-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (47, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'15-07-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (48, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'01-08-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (49, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'15', N'15', N'FINALIZADO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'15-08-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (50, N'EVBUEMDQ', N'Buenos Aires', N'Mar del Plata', N'10', N'10', N'30', N'ABIERTO', N'Nos fuimos para la Feliz!!', N'15-10-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (51, N'EVBUECHM', N'Buenos Aires', N'Chascomus', N'5', N'5', N'15', N'ABIERTO', N'A comer media lunas en un clasico Argentino.', N'15-10-2019')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (52, N'EVBUECOR', N'Buenos Aires', N'Cordoba,AR', N'10', N'10', N'30', N'ABIERTO', N'Prepara el fernet y la coca.', N'15-11-2020')
INSERT [dbo].[Evento] ([id], [codEvento], [desde], [hasta], [cantidadMinimaUsuarios], [cantidadActualUsuarios], [cantidadMaximaUsuarios], [estado], [detalleEvento], [fecha]) VALUES (53, N'EVBUEROS', N'Buenos Aires', N'Rosario,Santa Fe', N'5', N'5', N'15', N'ABIERTO', N'Las chicas mas lindas de la Argentina esperan por vos.', N'15-11-2020')
INSERT [dbo].[EventoEstado] ([id], [desc]) VALUES (N'1', N'Abierto')
INSERT [dbo].[EventoEstado] ([id], [desc]) VALUES (N'2', N'Activo')
INSERT [dbo].[EventoEstado] ([id], [desc]) VALUES (N'3', N'Cerrado')
INSERT [dbo].[EventoEstado] ([id], [desc]) VALUES (N'4', N'Cancelado')
INSERT [dbo].[Experto] ([id], [codExp], [nombre], [descripcion], [email]) VALUES (1, N'EXP01', N'Pablo Imhoff', N'Pablo es un experto en la mesopotamia Argentina,  desde Bs As hasta Misiones.', N'angelbrunn@gmail.com')
INSERT [dbo].[Experto] ([id], [codExp], [nombre], [descripcion], [email]) VALUES (2, N'EXP02', N'Fernando Picasso', N'Si buscas una experiencia en el desierto de Mendoza, sin duda Fernando es la persona indicada.', N'angelbrunn@gmail.com')
INSERT [dbo].[Experto] ([id], [codExp], [nombre], [descripcion], [email]) VALUES (3, N'EXP03', N'Javier Pérez', N'Famosa Ruta40, Javier lleva años recorriendola y sin duda la conoce como la palma de su mano.', N'angelbrunn@gmail.com')
INSERT [dbo].[Experto] ([id], [codExp], [nombre], [descripcion], [email]) VALUES (4, N'EXP04', N'Valeria Grinblat
', N'Valeria ya tiene mas de 12 años viviendo la experiencia Bs As To Mendoza, las sierras son su pasion.', N'angelbrunn@gmail.com')
INSERT [dbo].[MembresiaPrecio] ([idMembresia], [precio]) VALUES (1, 195)
INSERT [dbo].[MembresiaPrecio] ([idMembresia], [precio]) VALUES (2, 125)
INSERT [dbo].[MembresiaPrecio] ([idMembresia], [precio]) VALUES (3, 80)
INSERT [dbo].[MembresiaTipo] ([idMembresia], [tipoMembresia]) VALUES (1, N'Oro')
INSERT [dbo].[MembresiaTipo] ([idMembresia], [tipoMembresia]) VALUES (2, N'Plata')
INSERT [dbo].[MembresiaTipo] ([idMembresia], [tipoMembresia]) VALUES (3, N'Bronce')
INSERT [dbo].[MembresiaUsuario] ([idUsuario], [idMembresia]) VALUES (1, 1)
INSERT [dbo].[MembresiaUsuario] ([idUsuario], [idMembresia]) VALUES (2, 1)
INSERT [dbo].[MembresiaUsuario] ([idUsuario], [idMembresia]) VALUES (3, 2)
INSERT [dbo].[MembresiaUsuario] ([idUsuario], [idMembresia]) VALUES (4, 3)
INSERT [dbo].[MembresiaUsuario] ([idUsuario], [idMembresia]) VALUES (5, 3)
INSERT [dbo].[MembresiaUsuario] ([idUsuario], [idMembresia]) VALUES (6, 2)
INSERT [dbo].[MembresiaUsuario] ([idUsuario], [idMembresia]) VALUES (7, 3)
INSERT [dbo].[Ofertas] ([id], [empresa], [titulo], [descripcion], [fechaVigencia]) VALUES (1, N'AUTOMOTERES DEL SUER', N'TALLER MECANICO AUTOMOTORES DEL SUR', N'Obtenga un 20% de descuento en unidades nuevas con el plan Oro, un 10% con el plan Plata y hasa un 5% con el plan Bronce. ', N'01-01-2021')
INSERT [dbo].[Ofertas] ([id], [empresa], [titulo], [descripcion], [fechaVigencia]) VALUES (2, N'YAMAHA ARGENTINA', N'YAMAHA ARGENTINA', N'Obtenga un 20% de descuento en unidades nuevas con el plan Oro, un 10% con el plan Plata y hasa un 5% con el plan Bronce. ', N'01-01-2021')
INSERT [dbo].[Ofertas] ([id], [empresa], [titulo], [descripcion], [fechaVigencia]) VALUES (3, N'ZANELLA ARGENTINA', N'ZANELLA ARGENTINA', N'Obtenga un 20% de descuento en unidades nuevas con el plan Oro, un 10% con el plan Plata y hasa un 5% con el plan Bronce. ', N'01-01-2021')
INSERT [dbo].[Ofertas] ([id], [empresa], [titulo], [descripcion], [fechaVigencia]) VALUES (4, N'NUEMATICOS PIRELLI', N'NUEMATICOS PIRELLI', N'Obtenga un 20% en descuento en Neumaticos nuevos gracias al plan Oro y un 10% gracias al plan Plata.', N'01-01-2021')
INSERT [dbo].[Ofertas] ([id], [empresa], [titulo], [descripcion], [fechaVigencia]) VALUES (5, N'PARADOR ATALAYA ', N'PARADOR ATALAYA - Chascomús', N'Presentando su carne o una impresion de su ultimo voucher pago obtenga 10% de la compra de un desayuno clasico.', N'01-01-2021')
INSERT [dbo].[Ofertas] ([id], [empresa], [titulo], [descripcion], [fechaVigencia]) VALUES (6, N'HONDA ARGENTINA', N'HONDA ARGENTINA', N'Obtenga un 20% de descuento en unidades nuevas con el plan Oro, un 10% con el plan Plata y hasa un 5% con el plan Bronce. ', N'01-01-2021')
INSERT [dbo].[Ofertas] ([id], [empresa], [titulo], [descripcion], [fechaVigencia]) VALUES (7, N'ACA - AUTOMOVIL CLUB ARGENTINO', N'ACA - AUTOMOVIL CLUB ARGENTINO', N'Obtenga un 20% de descuento en suscripciones nuevas con el plan Oro, un 10% con el plan Plata y hasa un 5% con el plan Bronce. ', N'01-01-2021')
INSERT [dbo].[Ofertas] ([id], [empresa], [titulo], [descripcion], [fechaVigencia]) VALUES (8, N'YPF', N'YPF', N'Obtenga 15% gracia al plan Oro.', N'01-01-2021')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (1, N'2', N'WebMaster', N'PAGOTEST', N'100', N'01012019')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (2, N'3', N'Angel G. Prado Brun', N'PAGO DE MEMBRESIA', N'150', N'8/1/2019 22:57:55')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (3, N'2', N'WebMaster', N'PAGO DE MEMBRESIA PLATA', N'250', N'8/1/2019 23:29:35')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (4, N'1', N'2bXQyhaT/bP3zy4ZEt+sqBUo6KFwmbx+Dwkg3AM7C3M=', N'PAGO DE MEMBRESIA ORO', N'450', N'10/1/2019 20:59:08')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (5, N'6', N'Mauricio Correa', N'PAGO DE MEMBRESIA ORO', N'450', N'10/1/2019 21:04:53')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (6, N'6', N'Mauricio Correa', N'PAGO DE MEMBRESIA ORO', N'450', N'10/1/2019 21:27:07')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (7, N'6', N'Mauricio Correa', N'PAGO DE MEMBRESIA BRONCE', N'150', N'10/1/2019 21:34:13')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (8, N'7', N'Miguel Alberto Restrepo', N'PAGO DE MEMBRESIA BRONCE', N'150', N'10/1/2019 21:37:09')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (9, N'6', N'Mauricio Correa', N'PAGO DE MEMBRESIA PLATA', N'250', N'11/1/2019 00:00:23')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (10, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'75', N'23/8/2019 19:36:21')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (11, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'75', N'23/8/2019 19:42:14')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (12, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'75', N'23/8/2019 19:49:31')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (13, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'2790', N'23/8/2019 19:59:29')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (14, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'2915', N'24/8/2019 18:01:21')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (15, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'4676', N'24/8/2019 18:05:17')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (16, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'7290', N'24/8/2019 18:08:04')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (18, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'75', N'10/9/2019 19:48:13')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (19, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'25', N'14/9/2019 21:15:40')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (20, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'50', N'14/9/2019 21:19:37')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (21, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'2790', N'14/9/2019 22:32:36')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (22, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'50', N'14/9/2019 22:49:52')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (23, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'50', N'14/9/2019 23:20:50')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (24, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'25', N'15/9/2019 00:03:04')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (25, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'25', N'15/9/2019 00:08:50')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (26, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'25', N'15/9/2019 00:10:44')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (27, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'25', N'15/9/2019 00:35:09')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (28, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'2790', N'15/9/2019 00:41:20')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (29, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'25', N'15/9/2019 00:43:30')
INSERT [dbo].[PagoUsuario] ([idNumeroOrden], [idUsuario], [nombreApellido], [descripcion], [monto], [fechaPago]) VALUES (17, N'3', N'Angel G. Prado Brun', N'ACTIVIDADES', N'2676', N'24/8/2019 18:26:52')
INSERT [dbo].[Ruta] ([id], [codRuta], [desde], [hasta], [minMotos], [maxMotos], [detalleRuta], [fecha]) VALUES (1, N'MDQ01', N'Buenos Aires', N'Mar del Plata', 10, 30, N'Nos fuimos para la Feliz!!', N'15-12-2019')
INSERT [dbo].[Ruta] ([id], [codRuta], [desde], [hasta], [minMotos], [maxMotos], [detalleRuta], [fecha]) VALUES (2, N'ATA01', N'Buenos Aires', N'Atalaya', 5, 15, N'A comer media lunas en un clasico Argentino.', N'15-12-2019')
INSERT [dbo].[Ruta] ([id], [codRuta], [desde], [hasta], [minMotos], [maxMotos], [detalleRuta], [fecha]) VALUES (3, N'COD01', N'Buenos Aires', N'Cordoba', 10, 30, N'Prepara el fernet y la coca.', N'15-01-2020')
INSERT [dbo].[Ruta] ([id], [codRuta], [desde], [hasta], [minMotos], [maxMotos], [detalleRuta], [fecha]) VALUES (4, N'ROS01', N'Buenos Aires', N'Rosario,Santa Fe', 5, 15, N'Las chicas mas lindas de la Argentina esperan por vos.', N'15-01-2021')
INSERT [dbo].[RutaUsuario] ([id], [codRuta], [usuario], [fecha]) VALUES (2, N'MDQ01', N'angelbrunn', N'15-12-2019')
INSERT [dbo].[RutaUsuario] ([id], [codRuta], [usuario], [fecha]) VALUES (1, N'RUT00', N'webmaster', N'01-01-2019')
INSERT [dbo].[RutaVotacion] ([Id], [codRuta], [desde], [hasta], [cantUsuario], [estado], [detalleRutaVotacion], [fechaLimite]) VALUES (1, N'MDQ01', N'BS AS', N'MAR DEL PLATA', 8, N'ABIERTO', N'Disfruta del clásicos en moto turismo de la Argentina, Partimos como siempre desde nuestro famus point de encuentro la <strong> YPF de Ruta Panamericana 3802</strong> (también ACA) desde las <strong>7 a las 9 check, 9.30 Go!</strong>', N'15-12-2019')
INSERT [dbo].[RutaVotacion] ([Id], [codRuta], [desde], [hasta], [cantUsuario], [estado], [detalleRutaVotacion], [fechaLimite]) VALUES (2, N'ATA01', N'BS AS', N'ATALAYA', 0, N'ABIERTO', N'Aquí otro de los clásicos en moto turismo,Sin alejarte de tanto de casa.Partimos como siempre desde nuestro famus point de encuentro la <strong> YPF de Ruta Panamericana 3802</strong> desde las <strong>7 a las 9 check, 9.30 Go!</strong>', N'15-12-2019')
INSERT [dbo].[RutaVotacion] ([Id], [codRuta], [desde], [hasta], [cantUsuario], [estado], [detalleRutaVotacion], [fechaLimite]) VALUES (3, N'COD01', N'BS AS', N'CORDOBA', 0, N'ABIERTO', N'Viaja al interior de tu país,con uno de los paisajes mas hermosos.Partimos como siempre desde nuestro famus point de encuentro la <strong> YPF de Ruta Panamericana 3802</strong> desde las <strong>7 a las 9 check, 9.30 Go!</strong>', N'15-01-2020')
INSERT [dbo].[RutaVotacion] ([Id], [codRuta], [desde], [hasta], [cantUsuario], [estado], [detalleRutaVotacion], [fechaLimite]) VALUES (4, N'ROS01', N'BS AS', N'ROSARIO, SANTA FE', 0, N'ABIERTO', N'Que mejor manera de conocer el monumento a la bandera.Recorriendo paisajes sobre la ruta 9,desde nuestro famus point de encuentro la <strong> YPF de Ruta Panamericana 3802</strong> desde las <strong>7 a las 9 check, 9.30 Go!</strong>', N'15-01-2020')
INSERT [dbo].[tbl_Bitacora] ([idEvento], [idUsuario], [descripcion], [fecha], [digitoVerificador]) VALUES (1, N'qN4WOGHuXoyGCF0J9n7qWQRTdqDwHcA3uJ6PDaidtdE=', N'pLqctleIu0S2A8/fmF2owFqwq64Oy3B9IkizVUK6vgg=', N'47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=', N'KEUpaaJQ+mmOX80jMCn2Qzo4JN/3CVRwC6bF8kV+XRU=')
INSERT [dbo].[tbl_Bitacora] ([idEvento], [idUsuario], [descripcion], [fecha], [digitoVerificador]) VALUES (2, N'2', N'BKPException:Test Iniciales.', N'2018-06-09 18:38:42.500', N'ylWph0yJ+bI6FHEkAnQo16cubn72r/kH9nJZjorAk+4=')
INSERT [dbo].[tbl_Bitacora] ([idEvento], [idUsuario], [descripcion], [fecha], [digitoVerificador]) VALUES (3, N'2', N'BKPException:Probando desde depuracion,insercion de Trazas.', N'07/07/2018 18:16:27', N'rp/4VL2ze6nGGcf2A+knM5B/aj50dklx6JHpK9Ma2lE=')
INSERT [dbo].[tbl_Bitacora] ([idEvento], [idUsuario], [descripcion], [fecha], [digitoVerificador]) VALUES (4, N'2', N'BKPException:Probando desde depuracion,insercion de Trazas.', N'07/07/2018 18:23:44', N'aDs1Fmw19nRa4QTiBfUPe4r/br5SFnfjP8M1nu46cRA=')
INSERT [dbo].[tbl_Grupo] ([idGrupo], [grupo], [descripcion]) VALUES (1, N'Admin', N'Administrador del Sistema')
INSERT [dbo].[tbl_Grupo] ([idGrupo], [grupo], [descripcion]) VALUES (2, N'Usuario', N'Perfil Usuario')
INSERT [dbo].[tbl_Grupo] ([idGrupo], [grupo], [descripcion]) VALUES (3, N'Jerarquico', N'Perfil Usuario Jerarquico')
INSERT [dbo].[tbl_GrupoPermisos] ([idGrupo], [idPermisos]) VALUES (1, 1)
INSERT [dbo].[tbl_GrupoPermisos] ([idGrupo], [idPermisos]) VALUES (1, 2)
INSERT [dbo].[tbl_GrupoPermisos] ([idGrupo], [idPermisos]) VALUES (1, 3)
INSERT [dbo].[tbl_GrupoPermisos] ([idGrupo], [idPermisos]) VALUES (2, 2)
INSERT [dbo].[tbl_GrupoPermisos] ([idGrupo], [idPermisos]) VALUES (3, 2)
INSERT [dbo].[tbl_GrupoPermisos] ([idGrupo], [idPermisos]) VALUES (3, 3)
INSERT [dbo].[tbl_Permisos] ([idPermiso], [descripcion]) VALUES (1, N'Full Access')
INSERT [dbo].[tbl_Permisos] ([idPermiso], [descripcion]) VALUES (2, N'Modulo Eventos')
INSERT [dbo].[tbl_Permisos] ([idPermiso], [descripcion]) VALUES (3, N'Modulo Eventos + Organizar')
INSERT [dbo].[tbl_Usuario] ([idUsuario], [nombreApellido], [fechaNacimiento], [categoriaMoto], [usuario], [password], [email], [estado], [digitoVerificador]) VALUES (1, N'zweLYXmXDNdGg9RqJPAbee7998StaIwGio46KLWAZes=', N'GiPGmvOBlpG5R41cJBNUqKg5T6QQHPWaGTEpHuAkYqo=', N'xW8KTID1tDLAVQzHnn+JkYTTIhVP3eDbxV3rtS3HxIM=', N'onywBIR8JYeHN2wAlJZZu9dY3g1kcr87jH2aGHUewAQ=', N'U9+dXfhIawwXMlN5yiFpJxsId5BiG8Kyw11VV7gvCG0=', N'gp59XhrnaHp8/8jhwSVbJ2Fu0LSGyfPjNRIgbfekOZg=', N'h1T7c7x5lv0hoZcklPS953FW4T6cJZNRbF6141kxt+c=', N'wCBpwMpJT8myHjhea/JqVpcL9of5a2Isl3cGzzCcWDw=')
INSERT [dbo].[tbl_Usuario] ([idUsuario], [nombreApellido], [fechaNacimiento], [categoriaMoto], [usuario], [password], [email], [estado], [digitoVerificador]) VALUES (2, N'WebMaster', N'01012019', N'999', N'WebMaster', N'AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=', N'angelbrunn@gmail.com', N'Activo', N'Q6Xp2vNMVzy8+78JBSh+YXEwy3iwv/cOj7wA1uNBFco=')
INSERT [dbo].[tbl_Usuario] ([idUsuario], [nombreApellido], [fechaNacimiento], [categoriaMoto], [usuario], [password], [email], [estado], [digitoVerificador]) VALUES (3, N'Angel G. Prado Brun', N'13071987', N'1', N'angelbrunn', N'AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=', N'angelbrunn@gmail.com', N'Activo', N'I647JKMofr/8x54RcfyCyErkYCAZiP8BIeUiByOliN0=')
INSERT [dbo].[tbl_Usuario] ([idUsuario], [nombreApellido], [fechaNacimiento], [categoriaMoto], [usuario], [password], [email], [estado], [digitoVerificador]) VALUES (4, N'eugeniocosta', N'01011970', N'1', N'eugenio.jorge.costa', N'AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=', N'eugenio.jorge.costa@gmail.com ', N'Inactivo', N'F4Polqn3OeymG2h9yERmDF1oJIlBIPPxGs2CwORWqfI=')
INSERT [dbo].[tbl_Usuario] ([idUsuario], [nombreApellido], [fechaNacimiento], [categoriaMoto], [usuario], [password], [email], [estado], [digitoVerificador]) VALUES (5, N'Felipe Rodriguez Henao', N'01011980', N'2', N'felipe.rodriguez3', N'AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=', N'felipe.rodriguez3@gmail.com', N'Inactivo', N'Ltsw3GJJKI3vrPho5AH3/33+p45eEVz9Lw0fnTWziG4=')
INSERT [dbo].[tbl_Usuario] ([idUsuario], [nombreApellido], [fechaNacimiento], [categoriaMoto], [usuario], [password], [email], [estado], [digitoVerificador]) VALUES (6, N'Mauricio Correa', N'01021979', N'3', N'mauricio.correa', N'AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=', N'mauricio.correa@yahoo.com.ar', N'Activo', N'54EOQOzPa6TQaEec2J3xhCfrEfc9woJ/g6hh/GfUu4I=')
INSERT [dbo].[tbl_Usuario] ([idUsuario], [nombreApellido], [fechaNacimiento], [categoriaMoto], [usuario], [password], [email], [estado], [digitoVerificador]) VALUES (7, N'Miguel Alberto Restrepo', N'23071980', N'2', N'miguel.restrepo', N'AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=', N'miguel.restrepo@gmail.com', N'Activo', N'YSWmR3hQWTgCtv0lRSwgWyDUmWTCsama6+O0plXojzo=')
INSERT [dbo].[tbl_UsuarioGrupo] ([idUsuario], [idGrupo]) VALUES (2, 1)
INSERT [dbo].[tbl_UsuarioGrupo] ([idUsuario], [idGrupo]) VALUES (3, 2)
INSERT [dbo].[tbl_UsuarioGrupo] ([idUsuario], [idGrupo]) VALUES (4, 2)
INSERT [dbo].[tbl_UsuarioGrupo] ([idUsuario], [idGrupo]) VALUES (5, 2)
INSERT [dbo].[tbl_UsuarioGrupo] ([idUsuario], [idGrupo]) VALUES (6, 2)
INSERT [dbo].[tbl_UsuarioGrupo] ([idUsuario], [idGrupo]) VALUES (7, 2)
USE [master]
GO
ALTER DATABASE [MotoPoint] SET  READ_WRITE 
GO
