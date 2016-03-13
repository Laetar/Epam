SELECT DISTINCT OrderID FROM Northwind.[Order Details]
WHERE Quantity BETWEEN 3 and 10

SELECT DISTINCT CustomerID,Country FROM Northwind.Customers
WHERE Country BETWEEN 'b' and 'h'
ORDER BY Country


SELECT DISTINCT CustomerID,Country FROM Northwind.Customers
WHERE Country > 'b' and Country < 'h'
ORDER BY Country

--Честно я долго взглядывался в план выполнения,  в свтоиства разных запросов  сортировки и сканирования 
--но так и не нашел разницы в цифрах между этими запросами 