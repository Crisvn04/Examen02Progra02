/*BASE DE DATOS DE COMPUELECTA
  TABLAS
  EQUIPOS:EquipoID,TipoEquipo,Modelo,UsuarioID
  USUARIOS:UsuarioID,Nombre,CorreoElectronico,Telefono
  TECNICOS:TecnicoID,Nombre,Especialidad
  REPARACIONES:ReparacionID,EquipoID,FechaSolicitud,Estado
  ASIGNACIONES:AsignacionID,ReparacionID,TecnicoID,FechaAsignacion
  DETALLESREPARACION:DetalleID,ReparacionID,Descripcion,FechaInicio,FechaInicio

*/
CREATE DATABASE COMPUELECTA
GO

USE COMPUELECTA
GO

CREATE TABLE USUARIOS
(
  UsuarioID int identity(1,1),
  Nombre varchar(50) not null,
  CorreoElectronico varchar(50),
  Telefono varchar(15) unique,
  constraint pk_UsuarioID primary key(UsuarioID),
)
GO

CREATE TABLE EQUIPOS
(
  EquipoID int identity(1,1),
  UsuarioID int,
  TiposEquipo varchar(50) not null,
  Modelo varchar(50),
  constraint pk_EquipoID primary key (EquipoID),
  constraint fk_UsuarioID foreign key (UsuarioID) references USUARIOS(UsuarioID),
)
GO

CREATE TABLE REPARACIONES1
(
  ReparacionID int primary key   identity(1,1),
  EquipoID int,
  FechaSolicitud datetime CONSTRAINT df_FechaSolicitud DEFAULT GETDATE(),
  Estado char(1),
  constraint fk_EquipoID foreign key (EquipoID) references EQUIPOS(EquipoID),
)
GO

CREATE TABLE TECNICOS1
(
  TecnicoID int identity(1,1),
  Nombre varchar(50),
  Especialidad varchar(30)
  constraint pk_TecnicoID primary key(TecnicoID),
)
GO

 CREATE TABLE ASIGNACIONES
 (
   AsignacionID int primary key identity(1,1),
   TecnicoID int,
   ReparacionID int,
   constraint fk_ReparacionID foreign key (ReparacionID) references REPARACIONES1(ReparacionID),
   constraint fk_TecnicoID foreign key (TecnicoID) references TECNICOS1(TecnicoID),
   FechaAsignacion datetime CONSTRAINT df_FechaAsignacion DEFAULT GETDATE()
 )
 GO

 CREATE TABLE DETALLESREPARACION
 (

   DetalleID int primary key identity(1,1),
   ReparacionID int,
   Descripcion varchar (50),
   FechaInicio datetime CONSTRAINT df_FechaInicio DEFAULT GETDATE(),
   FechaFin datetime CONSTRAINT df_FechaFin DEFAULT GETDATE(),
   constraint fk_ReparacionID foreign key (ReparacionID) references REPARACIONES1(ReparacionID)
 ) 
GO 

 --CREACION DE PROCEDIMIENTOS ALMACENADOS 
 INSERT INTO Usuarios(Nombre, CorreoElectronico, Telefono) VALUES 
('', 'sebas@sebas.com', '24951234'), 

GO

INSERT INTO Tecnicos(Nombre, Especialidad) VALUES 
('Erick', 'Reparacion de Hardware'), 
('Maria', 'Reparacion de Software')
GO

INSERT INTO Equipos(TipoEquipo, Modelo, UsuarioID) VALUES
('Computadora Escritorio', 'BQuiet', 1),
('Computadora Portatil', 'Dell', 2),
('Impresora', 'Epson Multitank', 3)
GO

INSERT INTO Reparaciones(EquipoID, Estado) VALUES
(1, 'c'),
(2, 'b'),
(3, 'c')
GO

INSERT INTO Asignaciones(ReparacionID, TecnidoID) VALUES
(1, 1),
(2, 1),
(3, 2)
GO

INSERT INTO DetallesReparacion(ReparacionID, Descripcion) VALUES
(1, 'Cambiar disco duro por ssd y cambiar pasta termica'),
(2, 'Computadora se apaga luego de 5 min encendida'),
(3, 'Actualizar firmware de la impresora')
GO

 
 
 


 create procedure CONSULTAR
 as
    begin
	 select * from EQUIPOS 
	end