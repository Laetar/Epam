SELECT 
ROUND(SUM((UnitPrice - UnitPrice*Discount)*Quantity),2) AS Total
FROM Northwind.[Order Details]

SELECT
COUNT(*) - COUNT(ShippedDate)
FROM Northwind.Orders

SELECT
COUNT(DISTINCT CustomerID)
FROM Northwind.Orders