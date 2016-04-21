GO
ALTER PROCEDURE Northwind.GreatestOrders1
	@Year datetime,
	@Top integer
AS
	SELECT TOP(@Top)
		FirstName + ' ' + LastName AS Name,
		Orders.OrderID,
		ROUND(SUM(Discount*UnitPrice*Quantity),4) AS SumQuantity
	FROM Northwind.Employees
	INNER JOIN Northwind.Orders ON Employees.EmployeeID = Orders.EmployeeID
	INNER JOIN Northwind.[Order Details] ON Orders.OrderID = [Order Details].OrderID
	WHERE Employees.EmployeeID IN 
		(
			SELECT Orders.EmployeeID FROM Northwind.Orders
			WHERE Orders.OrderDate BETWEEN '1997' AND DATEADD(year,1,'1997')
		)
	GROUP BY FirstName + ' ' + LastName,Orders.OrderID
	ORDER BY FirstName + ' ' + LastName,SumQuantity desc
GO

EXEC Northwind.GreatestOrders1 '1997',5000;

SELECT OrderID FROM Northwind.Orders WHERE OrderID = (SELECT MAX(OrderID) FROM Northwind.Orders)
