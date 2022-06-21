CREATE OR ALTER PROC usp_EmployeesBySalaryLevel(@LevelOfSalary VARCHAR(50))
AS
    SELECT
    FirstName
    ,LastName 
    FROM Employees
    WHERE @LevelOfSalary = dbo.ufn_GetSalaryLevel(Salary)
    
    GO

    EXEC usp_EmployeesBySalaryLevel 'High'