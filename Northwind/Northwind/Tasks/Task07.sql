SELECT FirstName,TerritoryDescription FROM Northwind.Employees
INNER JOIN Northwind.EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID
INNER JOIN Northwind.Territories ON EmployeeTerritories.TerritoryID = Territories.TerritoryID
INNER JOIN Northwind.Region ON Territories.RegionID = Region.RegionID
WHERE RegionDescription = 'Western'