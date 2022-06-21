CREATE DATABASE [Service]

GO

USE [Service]

GO

--DDL

CREATE TABLE Users(
    Id INT PRIMARY KEY IDENTITY,
    Username VARCHAR(30) UNIQUE NOT NULL,
    [Password] VARCHAR(50) NOT NULL,
    [Name] VARCHAR(50),
    Birthdate DATETIME,
    Age INT
    CHECK(Age BETWEEN 14 AND 110),
    Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    Birthdate DATETIME,
    Age INT
    CHECK(Age BETWEEN 18 AND 110),
    DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE [Status](
    Id INT PRIMARY KEY IDENTITY,
    Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
    Id INT PRIMARY KEY IDENTITY,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
    StatusId INT FOREIGN KEY REFERENCES [Status](Id),
    OpenDate DATETIME NOT NULL,
    CloseDate DATETIME,
    [Description] VARCHAR(200) NOT NULL,
    UserId INT FOREIGN KEY REFERENCES Users(Id),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)  
)

GO

--DML

INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
    VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
    VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

GO

--UPDATE

UPDATE Reports
SET CloseDate = OpenDate
WHERE CloseDate IS NULL

GO

--DELETE

DELETE FROM Reports
        WHERE StatusId IN (
                                SELECT Id 
                                       FROM [Status] 
                                WHERE Id = 4 
                             )

DELETE FROM [Status]
        WHERE Id = 4

GO

--Querying

SELECT  [Description],
        FORMAT(OpenDate, 'dd-MM-yyyy')  AS OpenDate
        FROM Reports
WHERE EmployeeId IS NULL
ORDER BY DATEPART(YEAR, OpenDate),
         DATEPART(MONTH, OpenDate), 
         DATEPART(DAY, OpenDate),
        [Description]

GO

SELECT  r.[Description],
        c.Name AS CategoryName
        FROM Reports AS r
        JOIN Categories AS c ON C.Id = r.CategoryId
ORDER BY r.[Description], CategoryName

GO

SELECT TOP 5 c.Name AS CategoryName,
        COUNT(r.Id) AS ReportsNumber
        FROM Reports AS r
        JOIN Categories AS c ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY ReportsNumber DESC, CategoryName


GO

SELECT  CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
        COUNT(r.Id) AS UsersCount
        FROM Employees AS e
        LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName

GO

SELECT   CASE
            WHEN e.FirstName IS NULL OR e.LastName IS NULL THEN 'None'
            ELSE CONCAT(e.FirstName, ' ', e.LastName)           
        END AS Employee,
        CASE
            WHEN d.Name IS NULL THEN 'None'
            ELSE d.Name
        END AS Department,
        CASE
            WHEN c.Name IS NULL THEN 'None'
            ELSE c.Name
        END AS Category,
        CASE
            WHEN r.[Description] IS NULL THEN 'None'
            ELSE r.[Description]
        END AS [Description],
        CASE
            WHEN r.OpenDate IS NULL THEN 'None'
            ELSE FORMAT(r.OpenDate, 'dd.MM.yyyy')
        END AS OpenDate,
        CASE
            WHEN s.Label IS NULL THEN 'None'
            ELSE s.Label
        END AS [Status],
        CASE
            WHEN u.Name IS NULL THEN 'None'
            ELSE u.Name
        END AS [User]
        FROM Reports AS r
        LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
        LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
        LEFT JOIN Categories AS c ON c.Id = r.CategoryId
        LEFT JOIN [Status] AS s ON s.Id = r.StatusId
        LEFT JOIN Users AS u ON u.Id = r.UserId
ORDER BY e.FirstName DESC, 
         e.LastName DESC,
         d.Name,
         c.Name,
         r.[Description],
        DATEPART(YEAR, r.OpenDate),
        DATEPART(MONTH, r.OpenDate),
        DATEPART(DAY, r.OpenDate), 
         s.Label,
         u.Name

GO

--Programmability

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS 
BEGIN
    DECLARE @totalHours INT = IIF(DATEDIFF(HOUR, @StartDate, @EndDate) IS NULL, 0, DATEDIFF(HOUR, @StartDate, @EndDate))  

    RETURN @totalHours
END

GO

GO

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN

    DECLARE @edID INT = (SELECT e.DepartmentId 
                               FROM Employees AS e
                         WHERE e.Id = @EmployeeId
                         )  

    DECLARE @rcdID INT = (SELECT c.DepartmentId 
                                 FROM Reports AS r
                                 JOIN Categories AS c ON c.Id = r.CategoryId
                                 WHERE r.Id = @ReportId
                          )

    IF(@edID = @rcdID)           
        BEGIN
            UPDATE Reports 
            SET EmployeeId = @EmployeeId
            WHERE Id = @ReportId
        END
    ELSE
        BEGIN
            THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
        END
END
