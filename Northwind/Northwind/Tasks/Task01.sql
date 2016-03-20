SELECT Northwind.Orders.OrderID FROM Northwind.Orders
WHERE ShippedDate >= '1998-5-6' AND ShipVia > = 2

SELECT Northwind.Orders.OrderID, 
CASE
	WHEN ShippedDate IS NULL THEN 'Not Shipped'          
END AS ShippedDate
FROM Northwind.Orders 
WHERE ShippedDate IS NULL

SELECT OrderID AS 'Order Number',
CASE
	WHEN ShippedDate IS NULL THEN 'Not Shipped'
	ELSE CONVERT(nchar,ShippedDate)
END AS 'Shipped Date' 
FROM Northwind.Orders 
WHERE (ShippedDate >= '1998-5-6') OR (ShippedDate IS NULL)