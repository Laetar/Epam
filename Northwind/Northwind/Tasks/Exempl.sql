CREATE PROC my_proc1
AS
SELECT Orders.OrderID AS Orders
  FROM Northwind.Orders
  WHERE Orders.Freight > 1

SELECT my_proc1
WHERE Orders > 10030