GO
ALTER PROCEDURE SubordinationInfo
	@EmployerID integer
AS
	DECLARE @SPACE nvarchar(50) = '';
	DECLARE @result nvarchar(50);
	WHILE (@EmployerID IS NOT NULL)
	BEGIN
		SET @result = 
		(
			SELECT @SPACE + LastName FROM Northwind.Employees 
			WHERE EmployeeID = @EmployerID
		)
		PRINT @result
		SET @EmployerID = (SELECT ReportsTo FROM Northwind.Employees WHERE EmployeeID = @EmployerID)
		SET @SPACE = @SPACE + '  '
	END
GO

EXEC SubordinationInfo 3;
