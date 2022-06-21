
SELECT TOP(10) [FirstTable].[FirstName], [FirstTable].[LastName], [FirstTable].[DepartmentID]
FROM [Employees] AS [FirstTable]
LEFT JOIN (SELECT [DepartmentID], AVG([Salary]) AS [AvgSalary]
					  FROM [Employees] 
					  GROUP BY [DepartmentID]) AS [SecondTable]
		  ON [FirstTable].[DepartmentID] = [SecondTable].[DepartmentID]
WHERE [Salary] > [AvgSalary]
ORDER BY [FirstTable].[DepartmentID]