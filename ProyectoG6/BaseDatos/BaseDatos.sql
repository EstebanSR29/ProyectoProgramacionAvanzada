USE [master]
GO
/****** Object:  Database [ProyectoG6]    Script Date: 26/8/2024 3:59:24 a. m. ******/
CREATE DATABASE [ProyectoG6]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoG6', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProyectoG6.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyectoG6_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProyectoG6_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProyectoG6] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoG6].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoG6] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoG6] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoG6] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoG6] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoG6] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoG6] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProyectoG6] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoG6] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoG6] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoG6] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoG6] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoG6] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoG6] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoG6] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoG6] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProyectoG6] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoG6] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoG6] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoG6] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoG6] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoG6] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoG6] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoG6] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProyectoG6] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoG6] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoG6] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoG6] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoG6] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProyectoG6] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyectoG6] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProyectoG6] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProyectoG6] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProyectoG6]
GO
/****** Object:  User [esteban]    Script Date: 26/8/2024 3:59:24 a. m. ******/
CREATE USER [esteban] FOR LOGIN [esteban] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [esteban]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[IdCarrito] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED 
(
	[IdCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[IdComentario] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Comentariotxt] [varchar](255) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Calificacion] [int] NOT NULL,
 CONSTRAINT [PK_Comentarios] PRIMARY KEY CLUSTERED 
(
	[IdComentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdMaestro] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[Impuesto] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Detalle] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maestro]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maestro](
	[IdMaestro] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[Impuesto] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Maestro] PRIMARY KEY CLUSTERED 
(
	[IdMaestro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Imagen] [varchar](255) NULL,
	[Categoria] [int] NOT NULL,
	[Inventario] [int] NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [tinyint] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Contrasenna] [varchar](20) NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdRol] [tinyint] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([IdCategoria], [Categoria]) VALUES (1, N'Ropa')
INSERT [dbo].[Categorias] ([IdCategoria], [Categoria]) VALUES (2, N'Calzado')
INSERT [dbo].[Categorias] ([IdCategoria], [Categoria]) VALUES (3, N'Accesorios')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Imagen], [Categoria], [Inventario], [Estado]) VALUES (1, N'Calzado Nike', CAST(50000.00 AS Decimal(10, 2)), N'https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/503e9eea-02dd-4f8f-91e3-6ad74a9225cc/calzado-de-running-en-carretera-quest-5-NxdqjN.png', 2, 87, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Imagen], [Categoria], [Inventario], [Estado]) VALUES (2, N'Camisa Entrenamiento', CAST(21000.00 AS Decimal(10, 2)), N'https://i.ebayimg.com/images/g/aC4AAOSw8W9f48LJ/s-l500.jpg', 1, 0, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Imagen], [Categoria], [Inventario], [Estado]) VALUES (4, N'Pantaloneta Nike', CAST(15000.00 AS Decimal(10, 2)), N'https://sportzone.vtexassets.com/arquivos/ids/187707-1600-auto?v=638356712119330000&width=1600&height=auto&aspect=true', 1, 20, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Imagen], [Categoria], [Inventario], [Estado]) VALUES (7, N'Botella Yeti', CAST(35000.00 AS Decimal(10, 2)), N'https://cuylas.com/img/products/0307_NAVY-1.jpg', 3, 19, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Imagen], [Categoria], [Inventario], [Estado]) VALUES (8, N'Botella Stanley', CAST(30000.00 AS Decimal(10, 2)), N'https://vastago.cr/wp-content/uploads/2023/08/Captura-de-Pantalla-2023-08-21-a-las-16.51.33.png', 3, 37, 1)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [Imagen], [Categoria], [Inventario], [Estado]) VALUES (9, N'Calzado Adidas', CAST(62000.00 AS Decimal(10, 2)), N'https://th.bing.com/th/id/OIP.LnQCJBMgREQbr5wHkqcPLgHaHa?w=969&h=969&rs=1&pid=ImgDetMain', 2, 97, 1)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IdRol], [NombreRol]) VALUES (1, N'Usuario')
INSERT [dbo].[Roles] ([IdRol], [NombreRol]) VALUES (2, N'Administrador')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [Correo], [Contrasenna], [Estado], [IdRol]) VALUES (10, N'Esteban Solis', N'e@mail.com', N'123', 1, 2)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Productos]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Usuarios]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Producto]
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Maestro] FOREIGN KEY([IdMaestro])
REFERENCES [dbo].[Maestro] ([IdMaestro])
GO
ALTER TABLE [dbo].[Detalle] CHECK CONSTRAINT [FK_Detalle_Maestro]
GO
ALTER TABLE [dbo].[Maestro]  WITH CHECK ADD  CONSTRAINT [FK_Maestro_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Maestro] CHECK CONSTRAINT [FK_Maestro_Usuarios]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Categoria] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Categoria]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarProducto]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarProducto]
	@Nombre VARCHAR(100),
	@Precio DECIMAL(10,2),
	@Imagen VARCHAR(255),
	@Inventario INT,
	@Categoria INT,
	@IdProducto INT
AS
BEGIN
	UPDATE Productos
	   SET  Nombre = @Nombre,
			Precio = @Precio,
			Imagen = @Imagen,
			Inventario = @Inventario,
			Categoria = @Categoria,
			Estado = 1
	 WHERE IdProducto = @IdProducto
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarProducto]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarProducto]
    @Nombre VARCHAR(50),
    @Precio DECIMAL(10, 2),
    @Imagen VARCHAR(50),
    @Categoria INT,
	@Inventario INT
AS
BEGIN
    INSERT INTO Productos (nombre, precio, imagen, categoria, Inventario, Estado)
    VALUES (@Nombre, @Precio, @Imagen, @Categoria, @Inventario, 1);
END;
GO
/****** Object:  StoredProcedure [dbo].[Comentar]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Comentar]
    @IdUsuario INT,
    @IdProducto INT,
    @Comentariotxt VARCHAR(255),
    @Calificacion INT
AS
BEGIN
    INSERT INTO Comentarios
        (IdProducto, IdUsuario, Comentariotxt, Fecha, Calificacion)
    VALUES
        (@IdProducto, @IdUsuario, @Comentariotxt, GETDATE(), @Calificacion);
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCarrito]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarCarrito]
	@IdUsuario INT
AS
BEGIN
	SELECT IdCarrito
      ,C.IdUsuario
	  ,U.Nombre as Usuario
      ,C.IdProducto
	  ,P.Nombre as Producto
	  ,p.Precio
      ,Cantidad
	  ,(p.Precio * Cantidad) Subtotal
	  ,(p.Precio * Cantidad) * 0.13 Impuesto
	  ,(p.Precio * Cantidad) + (p.Precio * Cantidad) * 0.13 Total
      ,Fecha
  FROM dbo.Carrito C
  INNER JOIN dbo.Usuarios U ON C.IdUsuario = U.IdUsuario
  INNER JOIN dbo.Productos P ON C.IdProducto = P.IdProducto
  WHERE C.IdUsuario = @IdUsuario


END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarFacturas]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarFacturas]
	@IdUsuario INT
AS
BEGIN

 SELECT IdMaestro
		,IdUsuario
        ,FechaCompra
        ,Subtotal
        ,Impuesto
        ,Total
     FROM dbo.Maestro
	 WHERE IdUsuario = @IdUsuario
	 ORDER BY 
        FechaCompra DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[DetallesProducto]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DetallesProducto]
	@IdProducto INT
AS
BEGIN
	SELECT 
        p.IdProducto,
        p.Nombre,
        p.Precio,
        p.Imagen,
        c.Categoria,
		p.Inventario
    FROM 
        Productos p
    INNER JOIN 
        Categorias c ON p.Categoria = c.IdCategoria
	WHERE IdProducto = @IdProducto
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarProducto]
	@IdProducto INT
AS
BEGIN
	UPDATE Productos
	SET Estado = 2
    WHERE IdProducto = @IdProducto;

	DELETE FROM Carrito
	WHERE IdProducto = @IdProducto;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminiarDelCarrito]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminiarDelCarrito]
	@IdCarrito INT,
	@IdProducto INT
AS
BEGIN
	DELETE FROM Carrito
	WHERE IdCarrito = @IdCarrito
	AND IdProducto = @IdProducto;
END
GO
/****** Object:  StoredProcedure [dbo].[FacturaDetalle]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FacturaDetalle]
	@IdUsuario INT
AS
BEGIN
	SELECT IdDetalle
      ,IdMaestro
      ,D.IdProducto
	  ,P.Nombre
      ,Cantidad
      ,PrecioUnitario
      ,Subtotal
      ,Impuesto
      ,Total
	 FROM dbo.Detalle D
	 INNER JOIN dbo.Productos P ON D.IdProducto = P.IdProducto
	 WHERE IdMaestro = @IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesion]
	@Correo varchar(100),
	@Contrasenna varchar(20)
AS
BEGIN
	SELECT IdUsuario, Nombre, Correo, Estado, IdRol 
	FROM Usuarios
	WHERE Correo = @Correo
	AND Contrasenna = @Contrasenna
	AND Estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[MostrarProductos]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarProductos]
AS
BEGIN
    SELECT 
        p.IdProducto,
        p.Nombre,
        p.Precio,
        p.Imagen,
        c.Categoria,
		p.Inventario
    FROM 
        Productos p
    INNER JOIN 
        Categorias c ON p.Categoria = c.IdCategoria
	WHERE p.Estado = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerComentarios]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerComentarios]
	@IdProducto INT
	AS
BEGIN
	SELECT 
        c.IdComentario,
        c.IdProducto,
        u.Nombre AS Usuario,
        c.Comentariotxt,
        c.Fecha,
		c.Calificacion
    FROM 
        Comentarios c
	JOIN 
        Usuarios u ON c.IdUsuario = u.IdUsuario
    WHERE 
        IdProducto = @IdProducto
    ORDER BY 
        Fecha DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[PagarCarrito]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PagarCarrito]
	@IdUsuario INT
AS
BEGIN
	INSERT INTO dbo.Maestro
           (IdUsuario, FechaCompra, Subtotal, Impuesto, Total)
	SELECT IdUsuario, GETDATE(), SUM(P.Precio * Cantidad), SUM(P.Precio * Cantidad) * 0.13, SUM(P.Precio * Cantidad) + SUM(P.Precio * Cantidad) * 0.13
	FROM Carrito C
	INNER JOIN Productos P ON C.IdProducto = P.IdProducto
	WHERE IdUsuario = @IdUsuario
	GROUP BY IdUsuario


	INSERT INTO dbo.Detalle
           (IdMaestro, IdProducto, Cantidad, PrecioUnitario, Subtotal, Impuesto, Total)
	SELECT @@IDENTITY, C.IdProducto, Cantidad, P.Precio, P.Precio * Cantidad, (P.Precio * Cantidad) * 0.13, P.Precio * Cantidad + (P.Precio * Cantidad) * 0.13
	FROM Carrito C
	INNER JOIN Productos P ON C.IdProducto = P.IdProducto
	WHERE IdUsuario = @IdUsuario
	
	UPDATE P
	SET Inventario = Inventario - Cantidad
	FROM Productos p
	INNER JOIN Carrito C ON P.IdProducto = C.IdProducto
	WHERE IdUsuario = @IdUsuario

	DELETE FROM Carrito
	WHERE IdUsuario = @IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCarrito]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarCarrito]
		@IdUsuario INT,
        @IdProducto INT,
        @Cantidad INT
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM Carrito WHERE IdUsuario = @IdUsuario
										AND IdProducto =@IdProducto)
	BEGIN
		INSERT INTO Carrito
           (IdUsuario
           ,IdProducto
           ,Cantidad
           ,Fecha)
     VALUES
           (@IdUsuario
           ,@IdProducto
           ,@Cantidad
           ,GETDATE())
	END
	ELSE
	BEGIN
		UPDATE Carrito
		SET Cantidad = @Cantidad
		WHERE IdUsuario = @IdUsuario
		AND IdProducto =@IdProducto
	END
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 26/8/2024 3:59:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarUsuario]
	@Nombre varchar(100),
	@Correo varchar(100),
	@Contrasenna varchar(20)
AS
BEGIN
	IF (NOT EXISTS(SELECT 1 FROM Usuarios WHERE Correo = @Correo))
	BEGIN
		INSERT INTO Usuarios(Nombre, Correo,Contrasenna,Estado,IdRol)
		VALUES (@Nombre,@Correo,@Contrasenna,1,1)
	END
END
GO
USE [master]
GO
ALTER DATABASE [ProyectoG6] SET  READ_WRITE 
GO
