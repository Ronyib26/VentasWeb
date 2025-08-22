CREATE DATABASE PruebaTecnica;

use PruebaTecnica;

CREATE TABLE Categoria (
    CodigoCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Producto (
    CodigoProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    CodigoCategoria INT NOT NULL,
    CONSTRAINT FK_Producto_Categoria 
        FOREIGN KEY (CodigoCategoria) REFERENCES Categoria(CodigoCategoria)
);

CREATE TABLE Venta (
    CodigoVenta INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    CodigoProducto INT NOT NULL,
    CONSTRAINT FK_Venta_Producto 
        FOREIGN KEY (CodigoProducto) REFERENCES Producto(CodigoProducto)
);

INSERT INTO Categoria (Nombre) VALUES 
('Electrónicos'),
('Ropa'),
('Hogar'),
('Deportes'),
('Libros');

INSERT INTO Producto (Nombre, CodigoCategoria) VALUES 
('Laptop HP', 1),
('Mouse Logitech', 1),
('Camisa Polo', 2),
('Pantalón Jeans', 2),
('Lámpara LED', 3),
('Sofá 3 plazas', 3),
('Balón de Fútbol', 4),
('Raqueta de Tenis', 4),
('Novela Ficción', 5),
('Manual de Programación', 5);

INSERT INTO Venta (Fecha, CodigoProducto) VALUES 
('2017-01-15 10:30:00', 1),
('2024-01-16 14:15:00', 3),
('2023-01-17 09:45:00', 5),
('2016-02-01 16:20:00', 2),
('2022-02-05 11:10:00', 7),
('2021-08-21 16:30:00', 10), 
('2021-03-10 10:15:00', 1), 
('2020-03-15 11:30:00', 2),   
('2020-05-20 14:45:00', 3), 
('2019-06-10 09:20:00', 4), 
('2018-07-05 16:10:00', 5), 
('2019-08-12 13:25:00', 7), 
('2015-09-18 15:40:00', 8), 
('2018-11-22 12:15:00', 9);

-- =====================================================
-- A. CONSULTA SOLICITADA 
-- =====================================================

SELECT TOP 1 
    c.Nombre AS NombreCategoria,
    v.Fecha AS FechaUltimaVenta,
    p.Nombre AS NombreProducto,
    v.CodigoVenta
FROM Venta v
    INNER JOIN Producto p ON v.CodigoProducto = p.CodigoProducto
    INNER JOIN Categoria c ON p.CodigoCategoria = c.CodigoCategoria
ORDER BY v.Fecha DESC;
