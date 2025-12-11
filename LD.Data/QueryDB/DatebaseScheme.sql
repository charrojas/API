CREATE DATABASE LogicalDataDB;
GO

USE LogicalDataDB;
GO

CREATE SCHEMA Usuarios;
GO

CREATE SCHEMA Inventarios;
GO

CREATE SCHEMA Ventas;
GO


CREATE TABLE Usuarios.Usuario (
	Id INT IDENTITY(1, 1),
	Nombre NVARCHAR(25) NOT NULL,
	Apellido NVARCHAR(25) NOT NULL,
	Username NVARCHAR(25) NOT NULL,
	Contrasenia NVARCHAR(25) NOT NULL,
	CONSTRAINT PkUsuarioId PRIMARY KEY(Id),
	CONSTRAINT UqNombre UNIQUE(Nombre)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena los usuarios del sistema.', 
	@level0type = N'SCHEMA',
	@level0name = N'Usuarios',
	@level1type = N'TABLE',
	@level1name = N'Usuario'
;
GO

CREATE TABLE Inventarios.Articulo (
	Id INT IDENTITY(1, 1),
	Nombre NVARCHAR(25) NOT NULL,
	Descripcion NVARCHAR(100) NOT NULL,
	Codigo NVARCHAR(25) NOT NULL,
	Precio decimal NOT NULL,
	IVA BIT NOT NULL,
	CONSTRAINT PkArticuloId PRIMARY KEY(Id),
	CONSTRAINT UqArticuloCodigo UNIQUE(Codigo)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena los productos del sistema.', 
	@level0type = N'SCHEMA',
	@level0name = N'Inventarios',
	@level1type = N'TABLE',
	@level1name = N'Articulo'
;
GO


CREATE TABLE Ventas.FacturaEncabezado (
	Id INT IDENTITY(1, 1),
	UsuarioId INT NOT NULL,
	Fecha date NOT NULL DEFAULT GETDATE(),
	Total decimal NOT NULL,
    CantidadArticulos INT NOT NULL,
	CONSTRAINT PkFacturaEncabezadoId PRIMARY KEY(Id),
	CONSTRAINT FkFacturaEncabezadoUsuarioId FOREIGN KEY(UsuarioId) REFERENCES Usuarios.Usuario(Id)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena las facturas del encabezado del sistema', 
	@level0type = N'SCHEMA',
	@level0name = N'Ventas',
	@level1type = N'TABLE',
	@level1name = N'FacturaEncabezado'
;
GO


CREATE TABLE Ventas.FacturaDetalle (
	Id INT IDENTITY(1, 1),
	FacturaEncabezadoId INT NOT NULL,
	ArticuloId INT NOT NULL,
	Cantidad int NOT NULL,
	IVA DECIMAL NOT NULL,
	Precio decimal NOT NULL,
	Total decimal NOT NULL,
	CONSTRAINT PkFacturaDetalle PRIMARY KEY(Id),
	CONSTRAINT FkFacturaDetalleFacturaEncabezadoId FOREIGN KEY(FacturaEncabezadoId) REFERENCES Ventas.FacturaEncabezado(Id),
	CONSTRAINT FkFacturaDetalleArticuloId FOREIGN KEY(ArticuloId) REFERENCES Inventarios.Articulo(Id)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena las factura detalle de las facturas del sistema.', 
	@level0type = N'SCHEMA',
	@level0name = N'Ventas',
	@level1type = N'TABLE',
	@level1name = N'FacturaDetalle'
;
GO 