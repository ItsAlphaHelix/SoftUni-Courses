SELECT
EmployeeID,
FirstName,
LastName,
d.Name
FROM Employees AS e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
AND d.Name = 'Sales'
