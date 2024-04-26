USE saleDB
GO
-- Primer Ejercicio
SELECT U.Name as Vendedor, SUM(s.TotalAmount) AS ValorVentas from Sales AS S
INNER JOIN Users AS U ON S.UserId= U.Id
WHERE S.DateSale BETWEEN '2024-04-24'  AND '2024-04-26'
GROUP BY U.Name
ORDER BY ValorVentas desc
GO
-- Segundo Ejercicio
SELECT P.NAME AS Producto, SUM(S.Cantity) AS TotalProductos from Sales AS S
INNER JOIN Products AS P ON S.ProductId= P.Id
WHERE S.DateSale BETWEEN '0001-01-01 00:00:00'  AND '2024-12-12'
GROUP BY P.Name
ORDER BY TotalProductos desc
GO
--Tercer Ejercicio
SELECT P.Name AS ProductoNombre, P.Code ProductoCodigo, P.Price ProductoValor,
PR.Name ProveedorNombre, PR.Email ProveedorEmail, PR.Phone ProveedorCelular
FROM [dbo].[Products] as p
INNER JOIN [dbo].[Providers] AS PR ON P.ProviderId= PR.Id
