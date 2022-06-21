CREATE OR ALTER PROC usp_GetEmployeesFromTown(@TownName VARCHAR(MAX))
AS 
    SELECT 
    e.FirstName
    ,e.LastName 
    FROM Addresses AS a
    JOIN Towns AS t ON t.TownID = a.TownID
    JOIN Employees AS e ON e.AddressID = a.AddressID
    WHERE t.Name = @TownName

GO

EXEC usp_GetEmployeesFromTown 'Sofia'

-- SELECT e.FirstName, e.LastName FROM Addresses AS a
-- JOIN Towns AS t ON t.TownID = a.TownID
-- JOIN Employees AS e ON E.AddressID = a.AddressID
-- WHERE t.Name = 'Sofia'