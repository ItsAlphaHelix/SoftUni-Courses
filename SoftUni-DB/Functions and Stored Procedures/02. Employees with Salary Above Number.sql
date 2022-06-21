CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber
        (@Number DECIMAL(18, 9))
AS
    SELECT 
    FirstName
    ,LastName
    FROM Employees
    WHERE Salary >= @Number

EXEC usp_GetEmployeesSalaryAboveNumber 20
    