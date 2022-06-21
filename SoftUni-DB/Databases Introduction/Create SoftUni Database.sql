CREATE DATABASE SoftUni

CREATE TABLE Towns (

    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(MAX) NOT NULL,

)

CREATE TABLE Addresses (

    Id INT PRIMARY KEY IDENTITY,
    AddressText NVARCHAR(MAX) NOT NULL,
    TownId INT FOREIGN KEY REFERENCES Towns(Id)

)

CREATE TABLE Departments (

    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(MAX) NOT NULL

)

CREATE TABLE Employees (

    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(MAX) NOT NULL,
    MiddleName NVARCHAR(MAX) NOT NULL,
    LastName NVARCHAR(MAX) NOT NULL,
    JobTitle NVARCHAR(MAX) NOT NULL,
    DepartmentId INT FOREIGN KEY REFERENCES  Departments(Id),
    HireDate DATE NOT NULL,
    Salary DECIMAL(5, 2),
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id)

)

INSERT INTO Towns (Id, Name) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Sliven')

INSERT INTO Addresses (Id, AddressText, TownId) VALUES
(1, 'kv Str', 1),
(2, 'kv Stoyan Zaimov', 3),
(3, 'kv Hm3', 2)

INSERT INTO Departments (Id, Name) VALUES
(1, 'It'),
(2, 'Management'),
(3, 'Talks')

INSERT INTO Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId) VALUES
(1, 'Dimityr', 'Dimitrov', 'Georgiev', '.NetDev', 1, '20-01-2023', 1700, 2),
(2, 'Ivaylo', 'Pavlov', 'Pavlovov', 'Manager', 3, '5-02-2023', 1300, 1),
(3, 'Simeon', 'Ivanov', 'Simeonov', 'Talker', 2, '10-05-2021', 1200, 3)

