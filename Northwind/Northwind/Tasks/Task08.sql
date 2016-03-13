SELECT a.CustomerID, COUNT(b.OrderID) AS Orders FROM Northwind.Customers a
LEFT JOIN Northwind.Orders b ON a.CustomerID = b.CustomerID
GROUP BY a.CustomerID
ORDER BY Orders