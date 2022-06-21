CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(50)
AS 
BEGIN
    DECLARE @LvlOfSalary VARCHAR(50)
    IF(@SALARY < 30000)
    BEGIN
        SET @LvlOfSalary = 'Low'
    END
    ELSE IF(@Salary BETWEEN 30000 AND 50000)
    BEGIN
        SET @LvlOfSalary = 'Average'
    END 
    ELSE IF(@Salary > 50000)
    BEGIN
        SET @LvlOfSalary = 'High'
    END
    RETURN @LvlOfSalary
END

GO

SELECT
Salary
,dbo.ufn_GetSalaryLevel(Salary) AS [Salary level]
FROM Employees