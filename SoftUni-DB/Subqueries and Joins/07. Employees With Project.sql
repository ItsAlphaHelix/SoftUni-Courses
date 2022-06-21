SELECT TOP 5
e.EmployeeID,
e.FirstName,
p.Name
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
AND StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY EmployeeID
