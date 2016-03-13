SELECT Employees.EmployeeID FROM Northwind.Employees
WHERE Employees.EmployeeID IN (SELECT EmployeeID FROM Northwind.Orders GROUP BY EmployeeID HAVING COUNT(OrderID) > 150)