SELECT Customers.CustomerID FROM Northwind.Customers
WHERE NOT EXISTS (SELECT Orders.CustomerID FROM Northwind.Orders)