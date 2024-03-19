
CREATE DATABASE DBDGII;
Go

USE DBDGII;
GO


-- Crear la tabla de contribuyentes
CREATE TABLE Contribuyentes (
    rncCedula VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(100),
    tipo VARCHAR(50),
    estatus VARCHAR(20)
);
GO

CREATE TABLE ComprobantesFiscales (
    id INT PRIMARY KEY IDENTITY(1,1),
    rncCedula VARCHAR(20),
    NCF VARCHAR(50),
    monto DECIMAL(10, 2),
    itbis18 DECIMAL(10, 2),
    FOREIGN KEY (rncCedula) REFERENCES Contribuyentes(rncCedula)
);
GO
-- Insertar datos de contribuyentes
INSERT INTO Contribuyentes (rncCedula, nombre, tipo, estatus)
VALUES
('98754321012', 'JUAN PEREZ', 'PERSONA FISICA', 'activo'),
('123456789', 'FARMACIA TU SALUD', 'PERSONA JURIDICA', 'inactivo');
GO

-- Insertar datos de comprobantes fiscales
INSERT INTO ComprobantesFiscales (rncCedula, NCF, monto, itbis18)
VALUES
('98754321012', 'E310000000001', 200.00, 36.00),
('98754321012', 'E310000000002', 1000.00, 180.00);
GO

SELECT * FROM Contribuyentes;
SELECT * FROM ComprobantesFiscales;

drop table Contribuyentes;
-- Agregar la relaci�n entre las tablas
ALTER TABLE ComprobantesFiscales
ADD CONSTRAINT FK_Contribuyentes_rncCedula FOREIGN KEY (rncCedula)
REFERENCES Contribuyentes(rncCedula);