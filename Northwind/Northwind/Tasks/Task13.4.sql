GO
ALTER PROCEDURE IsBoss
	@EmployerID integer
AS
	SELECT CAST
	(
		CASE 
			WHEN EXISTS (SELECT ReportsTo FROM Northwind.Employees WHERE ReportsTo = @EmployerID ) THEN 1
			ELSE 0
		END
	 AS BIT
	 ) 
GO

EXEC IsBoss 1;
EXEC IsBoss 5;