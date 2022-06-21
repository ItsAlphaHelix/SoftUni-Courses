SELECT TOP 3
e.EmployeeID,
e.FirstName
FROM Employees AS e
WHERE e.EmployeeID NOT IN (SELECT EmployeeID FROM EmployeesProjects)
ORDER BY EmployeeID
