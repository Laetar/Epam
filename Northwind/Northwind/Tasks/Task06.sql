SELECT COUNT(OrderID) AS 'TOTAL', year(OrderDate) AS 'YEAR' FROM Northwind.Orders
GROUP BY (year(OrderDate)) 

SELECT COUNT(OrderID) FROM Northwind.Orders



SELECT COUNT(OrderID) AS Amount, FirstName + ' ' + LastName  AS Seller
FROM Northwind.Orders 
INNER JOIN Northwind.Employees ON Employees.EmployeeID = Northwind.Orders.EmployeeID
GROUP BY FirstName + ' ' + LastName 
ORDER BY Amount desc



SELECT 
CASE 
	WHEN CompanyName IS NULL THEN 'ALL'
	ELSE CompanyName
END AS Seller,
CASE
	WHEN FirstName IS NULL THEN 'ALL'
	ELSE FirstName
END AS Customer,
COUNT(OrderID) AS Amount 
FROM Northwind.Orders
INNER JOIN Northwind.Customers ON Orders.CustomerID = Customers.CustomerID
INNER JOIN Northwind.Employees ON Orders.EmployeeID = Employees.EmployeeID
WHERE OrderDate > '1998-01-01' AND OrderDate < '1999-01-01'
GROUP BY CUBE  (CompanyName,FirstName)
ORDER BY Seller,Customer,Amount desc

--4

--5
SELECT a.CustomerID, a.City FROM Northwind.Customers a
JOIN Northwind.Customers b ON a.City = b.City
GROUP BY a.CustomerID,a.City
HAVING COUNT(a.City) > 1
ORDER BY a.City

--6
SELECT b.LastName AS UserName, a.LastName AS BOSS FROM Northwind.Employees a
RIGHT JOIN Northwind.Employees b ON a.EmployeeID = b.ReportsTo
ORDER BY BOSS
