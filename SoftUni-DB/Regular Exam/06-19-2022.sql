CREATE DATABASE Zoo

GO

--DDL

CREATE TABLE Owners(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    [Address] VARCHAR(50) 
)

CREATE TABLE AnimalTypes(
    Id INT PRIMARY KEY IDENTITY,
    AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
    Id INT PRIMARY KEY IDENTITY,
    AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) 
)

CREATE TABLE Animals(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL,
    BirthDate DATE NOT NULL,
    OwnerId INT NULL FOREIGN KEY REFERENCES Owners(Id),
    AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages(
    CageId INT FOREIGN KEY REFERENCES Cages(Id),
    AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
    PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
    Id INT PRIMARY KEY IDENTITY,
    DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    [Address] VARCHAR(50),
    AnimalId INT NULL FOREIGN KEY REFERENCES Animals(Id),
    DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

GO 

--DML

INSERT INTO Volunteers(Name, PhoneNumber, Address, AnimalId, DepartmentId)
    VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', NULL, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals(Name, BirthDate, OwnerId, AnimalTypeId)
    VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', NULL, 1),
('Tuatara', '2021-06-30', 2, 4)

GO

--Update

UPDATE Animals
SET OwnerId = AnimalTypeId
FROM Owners AS o
WHERE o.Name = 'Kaloqn Stoqnov' AND OwnerId IS NULL

GO

--DELETE 

DELETE  FROM Volunteers
                    WHERE DepartmentId IN (SELECT Id FROM VolunteersDepartments 
                                            WHERE Id = 2
                                            )


DELETE FROM VolunteersDepartments 
WHERE Id = 2

GO

--Querying

SELECT  Name,
        PhoneNumber,
        Address,
        AnimalId,
        DepartmentId
        FROM Volunteers
ORDER BY Name, AnimalId DESC, DepartmentId

GO

SELECT  Name,
        ant.AnimalType,
        FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
        FROM Animals AS a
        JOIN AnimalTypes AS ant ON ant.Id = a.AnimalTypeId
ORDER BY Name

GO

SELECT TOP 5 o.Name,
        COUNT(a.Id) AS CountOfAnimals
        FROM Owners AS o
        JOIN Animals AS a ON a.OwnerId = o.Id
GROUP BY o.Name
ORDER BY CountOfAnimals DESC, o.Name

GO

SELECT  CONCAT(o.Name, '-', a.Name) AS OwnersAnimals,
        o.PhoneNumber,
        CageId
        FROM Owners AS o
        JOIN Animals AS a ON a.OwnerId = o.Id 
        JOIN AnimalTypes AS ant ON ant.Id = a.AnimalTypeId
        JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
WHERE ant.AnimalType = 'Mammals'
ORDER BY o.Name, a.Name DESC

GO

SELECT  v.Name,
        v.PhoneNumber,
        TRIM(SUBSTRING(TRIM(Address), 8,  LEN(Address))) AS Address
        FROM Volunteers AS v
        JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
WHERE v.Address LIKE '%Sofia%' AND vd.DepartmentName = 'Education program assistant'
ORDER BY v.Name

SELECT * FROM VolunteersDepartments 
WHERE DepartmentName = 'Education program assistant'

SELECT TRIM(SUBSTRING(TRIM(Address),8,  LEN(Address))) FROM Volunteers
WHERE Address LIKE '%Sofia%'

GO

SELECT  a.Name,
        DATEPART(YEAR, a.BirthDate) AS BirthYear,
        ant.AnimalType
        FROM Animals AS a 
        JOIN AnimalTypes AS ant ON ant.Id = a.AnimalTypeId
WHERE a.OwnerId IS NULL AND DATEDIFF(YEAR, a.BirthDate, '01/01/2022') < 5 AND ant.AnimalType != 'Birds'
ORDER BY a.Name

GO

--Programmability

CREATE OR ALTER FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(50))
RETURNS INT
BEGIN
    DECLARE @count INT = (SELECT COUNT(*) FROM VolunteersDepartments AS vd
                                          JOIN Volunteers AS v ON v.DepartmentId = vd.Id
                          WHERE vd.DepartmentName = @VolunteersDepartment
                          )

    RETURN @count
END

GO

CREATE OR ALTER PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS 
BEGIN
    SELECT   a.Name,
             IIF(a.OwnerId IS NOT NULL, o.Name, 'For adoption') AS OwnersName
             FROM Animals AS a
             LEFT JOIN Owners AS o ON o.Id = a.OwnerId
    WHERE a.Name = @AnimalName
END

GO