GO
ALTER PROCEDURE Northwind.ShippedOrdersDiff
	@SpecifiedDelay integer
AS
	SELECT
		OrderID, 
		OrderDate,
		ShippedDate,
		DATEDIFF(day,OrderDate,ShippedDate) AS ShippedDelay
	FROM Northwind.Orders
	WHERE DATEDIFF(day,OrderDate,ShippedDate) >= @SpecifiedDelay
	ORDER BY ShippedDelay
GO

EXEC Northwind.ShippedOrdersDiff 10;