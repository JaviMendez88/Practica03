-- Práctica 03

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Practica03DB')
BEGIN
    CREATE DATABASE Practica03DB;
END
GO

USE Practica03DB;
GO



CREATE TABLE PrincipalTB (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(100) NOT NULL,
    MontoTotal DECIMAL(10,2) NOT NULL,
    Saldo DECIMAL(10,2) NOT NULL,
    Estado VARCHAR(20) NOT NULL -- (Pendiente / Cancelado)
);



CREATE TABLE AbonosTB (
    IdAbono INT IDENTITY(1,1) PRIMARY KEY,
    IdCompra INT NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    MontoAbono DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_AbonosTB_PrincipalTB
        FOREIGN KEY (IdCompra) REFERENCES PrincipalTB(IdCompra)
);