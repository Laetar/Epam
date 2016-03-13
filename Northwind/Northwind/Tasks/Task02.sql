SELECT CustomerID FROM Northwind.Customers 
WHERE Country IN ('USA','Canada')
ORDER BY CompanyName,Address

SELECT ContactName,Country FROM Northwind.Customers 
WHERE Country NOT IN ('USA','Canada')
ORDER BY CompanyName

SELECT DISTINCT Country FROM Northwind.Customers 
ORDER BY Country desc