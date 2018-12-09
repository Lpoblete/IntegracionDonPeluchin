# IntegracionDonPeluchin
Este proyecto se inició el año 2016, en este proyecto se repartieron 4 grupos de compañeros y 
a cada uno se le asignaba a un módulo, en mi caso me asignaron al módulo Cobranza y Crédito,
desconozco los nombres de los integrantes de los demás módulos por ahora (conozco algunos).

para iniciar este proyecto se debe empezar por el proyecto 'ERPIntegracion' para tener al alcance de los 4 módulos.

A continuación, les dejo el script de la BD:

create table Usuario(
Nombre varchar(50),
Pass varchar(50),
TipoUsuario varchar(20)
);

insert into Usuario values('Job','123','Vendedor');
insert into Usuario values('Marcela','123','Bodegero');
insert into Usuario values('Leandro','123','Cajero');
insert into Usuario values('Leandro','123','Ejecutivo');



CREATE TABLE [dbo].[Factura] (
    [NoFactura]   NUMERIC (5)  NOT NULL,
    [Total]       NUMERIC (8)  NULL,
    [Cliente]     CHAR (10)    NULL,
    [Observacion] VARCHAR (50) NULL,
    [Entrega]     CHAR (2)     NULL,
    [fecha]       VARCHAR(20)  NULL,
    CONSTRAINT [NoFacturaFactura] PRIMARY KEY CLUSTERED ([NoFactura] ASC),
    CONSTRAINT [ClienteFactura] FOREIGN KEY ([Cliente]) REFERENCES [dbo].[Cliente] ([Rut_Cliente])
);

insert into Factura values(1,230000,'11-1','','si','08/01/2016');
insert into Factura values(2,100000,'11-2','','si','12/11/2015');
insert into Factura values(3,150000,'11-3','','si','02/06/2016');
insert into Factura values(4,200000,'11-4','','si','20/03/2016');
insert into Factura values(5,250000,'11-4','','si','24/02/2016');
insert into Factura values(6,57777,'11-2','','si','03/10/2016');
insert into Factura values(7,98820,'11-6','','si','01/09/2016');
insert into Factura values(8,110000,'11-5','','si','09/12/2015');
insert into Factura values(9,415020,'11-5','','si','11/05/2016');
insert into Factura values(10,150000,'11-7','','si','14/03/2015');
insert into Factura values(11,196330,'11-8','','si','17/02/2016');
insert into Factura values(12,112022,'11-9','','si','01/12/2016');

CREATE TABLE [dbo].[DetalleVenta] (
    [NoDetalle]  NUMERIC (10) NOT NULL,
    [Linea]      NUMERIC (2)  NULL,
    [NoFactura]  NUMERIC (5)  NULL,
    [Producto]   INT          NULL,
    [Cantidad]   NUMERIC (6)  NULL,
    [Existencia] INT          NULL,
    [subtotal]   INT          NULL,
    CONSTRAINT [NoDetalleDetalleVenta] PRIMARY KEY CLUSTERED ([NoDetalle] ASC),
    CONSTRAINT [NoFacturaDetalleVenta] FOREIGN KEY ([NoFactura]) REFERENCES [dbo].[Factura] ([NoFactura]),
    CONSTRAINT [ProductoDetalleVenta] FOREIGN KEY ([Producto]) REFERENCES [dbo].[Producto] ([ID_producto]),
    CONSTRAINT [ExistenciaDetalleVenta] FOREIGN KEY ([Existencia]) REFERENCES [dbo].[Existencia] ([Codigo_existencia])
);



Create table Bodega 
(
Codigo_bodega char(2) primary key,
Nombre_bodega varchar(25)
)

Create table Producto
(
ID_producto int IDENTITY(1,1) PRIMARY KEY,
Nombre_producto varchar(50),
Valor numeric(12),
Descripcion varchar (256)
)

Create table Existencia
(
Codigo_existencia int IDENTITY(1,1) PRIMARY KEY,
Codigo_bodega char(2) Foreign key References Bodega(Codigo_bodega),
Codigo_producto int Foreign key References Producto(ID_producto),
Cantidad numeric (10),
Fecha_Ingreso Date
)

Insert into Bodega Values('BN', 'Bodega Antofagasta')
Insert into Bodega Values('BC', 'Bodega Santiago')
Insert into Bodega Values('BS', 'Bodega Magallanes')


/*INSERT PRODUCTOS*/
Insert into Producto Values('Malla Polytex Rollo Negro',10690, 'Malla Raschel 100mt x 2.10m negro')
Insert into Producto Values('Malla Polytex Rollo Rojo',10690, 'Malla Raschel 100mt x 2.10m rojo')
Insert into Producto Values('Malla Polytex Negro Por Metro',650, 'Malla Raschel ancho 2.10m negro')
Insert into Producto Values('Malla Polytex Rojo Por Metro',650, 'Malla Raschel ancho 2.10m rojo')
Insert into Producto Values('Casco Seguridad V-Gard',7490,'Casco de seguridad blanco')
Insert into Producto Values('Casco Seguridad V-Gard',7490,'Casco de seguridad verde')
Insert into Producto Values('Mortero',6490,'Saco Mortero Anclaje y Nivelador')
Insert into Producto Values('Esmalte al agua',52000, 'Esmalte al agua semibrillo interior 5 gl blanco/pastel Kolor')
Insert into Producto Values('Membrana de curado',26606,'Tineta 18 lt Membrana de curado')
Insert into Producto Values('Alicate',2500,'Alicate Amarillo')

/*INSERT EXISTENCIA*/
Insert into Existencia Values('BN',1, 1,'2016-01-11')
Insert into Existencia Values('BC',2, 2,'2016-02-12')
Insert into Existencia Values('BS',5, 30,'2016-03-13')
Insert into Existencia Values('BN',6, 1,'2016-01-11')
Insert into Existencia Values('BC',9, 15,'2016-09-09')



/***************EXISTENCIA*****/
/*SUMA*/
CREATE PROC SP_SumarExistencia
@Codigo_bodega char(2),
@Codigo_producto int,
@Cantidad int,
@Fecha_Ingreso date
AS
IF EXISTS(SELECT @Codigo_producto FROM Existencia WHERE Codigo_producto = @Codigo_producto)
UPDATE Existencia SET Cantidad=Cantidad+@Cantidad, Fecha_Ingreso = @Fecha_Ingreso
WHERE Codigo_producto = @Codigo_producto AND Codigo_bodega = @Codigo_bodega
ELSE
INSERT INTO Existencia VALUES (@Codigo_bodega, @Codigo_producto, @Cantidad, @Fecha_Ingreso)

/*RESTA*/
CREATE PROC SP_RestaExistencia
@Codigo_bodega char(2),
@Codigo_producto int,
@Cantidad int,
@Fecha_Ingreso date
AS
IF EXISTS(SELECT @Codigo_producto FROM Existencia WHERE Codigo_producto = @Codigo_producto)
UPDATE Existencia SET Cantidad=Cantidad-@Cantidad
WHERE Codigo_producto = @Codigo_producto AND Codigo_bodega = @Codigo_bodega

/*NUEVO PRODUCTO*/
CREATE PROC SP_IngresoNuevoProducto
@Nombre_producto varchar(50),
@Valor numeric,
@Descripcion varchar(256)
AS
IF EXISTS(SELECT @Nombre_producto FROM Producto WHERE Nombre_producto = @Nombre_producto)
SELECT ID_producto, Nombre_producto FROM Producto WHERE Nombre_producto = @Nombre_producto
ELSE 
INSERT INTO Producto VALUES (@Nombre_producto, @Valor, @Descripcion)
SELECT * FROM Producto



create table Cobranza(
ID_Cobranza int primary key not null,
Factura_NO numeric(5) foreign key references Factura(NoFactura) not null,
Cliente_Rut char(10) foreign key references Cliente(Rut_Cliente) not null,
FechaCobranza date,
Saldo int,
MetodoPago varchar(30),
NumCuotas int,
Estado varchar(30)
);

create table Cuota(
ID_Cuota int primary key not null,
Cobranza_ID int foreign key references Cobranza(ID_Cobranza) not null,
Monto int,
Fecha varchar(30),
Estado varchar(30)
);

create table Pago(
ID_Pago int primary key not null,
Cobranza_ID int foreign key references Cobranza(ID_Cobranza) not null,
FechaImpresion date,
Comprobante varchar(max)
);



create table Cliente(
Rut_Cliente char(10) primary key not null,
Nombre_Cliente varchar(50),
Direccion_Cliente varchar(50),
Telefono_Cliente varchar(8)
);

insert into Cliente values('11-1','Alejandro','concha y toro xxxx','12345678');
insert into Cliente values('11-2','Juan','penon xxxx','87654321');
insert into Cliente values('11-3','Fernando','gabriela xxxx','12344321');
insert into Cliente values('11-4','Roberto','los nogales xxxx','43215678');
insert into Cliente values('11-5','Ernesto','chile chico xxxx','38498411');
insert into Cliente values('11-6','Humberto','las vizcachas xxxx','99448822');
insert into Cliente values('11-7','Alfonso','ramon venegas xxxx','99966669');
insert into Cliente values('11-8','Luis','cisterna xxxx','13375932');
insert into Cliente values('11-9','Jonathan','castillo xxxx','58991111');
insert into Cliente values('11-10','Israel','las nieves xxxx','94400122');
insert into Cliente values('11-11','Edward','dehesa xxxx','90804452');
insert into Cliente values('11-12','Kevin','la pintana xxxx','39800012');
insert into Cliente values('11-13','Pedro','gabriela xxxx','57483744');
insert into Cliente values('11-14','Belen','salesianos xxxx','57483744');
insert into Cliente values('11-15','Constanza','elisa correa xxxx','57483744');

create table Credito(
ID_Credito int primary key not null,
Cliente_Rut char(10) foreign key references Cliente(Rut_Cliente) not null,
FechaEmision date,
FechaVencimiento date,
LimiteCredito int,
Disp_Credito int,
Estado varchar(30)
);

insert into Credito values(1,'11-1','19/08/2016','15/04/2020',300000,300000,'Vigente');
insert into Credito values(2,'11-2','20/11/2015','11/07/2019',700000,450000,'Vigente');
insert into Credito values(3,'11-3','06/06/2016','28/06/2021',400000,230000,'Vigente');
insert into Credito values(4,'11-4','25/08/2017','02/07/2022',600000,500000,'Vigente');
insert into Credito values(5,'11-5','21/11/2017','09/09/2022',500000,190000,'Vigente');

create table Carga(
ID_Carga int primary key not null,
Cliente_Rut char(10) foreign key references Cliente(Rut_Cliente) not null,
FechaImpresion date,
Comprobante varchar(max)
);
