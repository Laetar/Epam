SELECT CompanyName FROM Northwind.Suppliers 
INNER JOIN Northwind.Products ON Products.SupplierID = Suppliers.SupplierID
WHERE Products.SupplierID IN -- Тут нельзя
(
	SELECT Suppliers.SupplierID FROM  Northwind.Suppliers
	WHERE UnitsInStock IN (0) -- А тут можно
)

-- Проверка 
SELECT CompanyName, UnitsInStock FROM Northwind.Suppliers 
INNER JOIN Northwind.Products ON Products.SupplierID = Suppliers.SupplierID
Order by UnitsInStock 