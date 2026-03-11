
--TABLA CLIENTES
CREATE TABLE Clientes (
    IdClientes INT PRIMARY KEY,
    Ingresos INT,
    Fecha_nacimiento DATE );

--TABLA TRANSACCIONES
CREATE TABLE Transacciones (
    IDTransaccion INT IDENTITY(1,1) PRIMARY KEY,
    Cliente INT,
    Valor INT,
    FechaTRN DATE,
    CantidadProductos INT );

--LIMPIEZA 
DELETE FROM Transacciones
WHERE Cliente IS NULL;

--TABLA RESUMEN
CREATE TABLE Resumen (
    IdCliente INT,
    IngresosCliente INT,
    Año_Transaccion INT,
    NumeroTRN_Anual INT,
    ValorTotalTRN_Anual INT );

--se importó el excel usando el Import Wizard de SQL Server.

INSERT INTO Resumen
SELECT
    c.IdClientes,
    c.Ingresos,
    YEAR(t.FechaTRN) AS Año_Transaccion,
    COUNT(*) AS NumeroTRN_Anual,
    SUM(t.Valor) AS ValorTotalTRN_Anual
FROM Clientes c
INNER JOIN Transacciones t
    ON c.IdClientes = t.Cliente
GROUP BY
    c.IdClientes,
    c.Ingresos,
    YEAR(t.FechaTRN);


/*Test:
SELECT * FROM Resumen; */