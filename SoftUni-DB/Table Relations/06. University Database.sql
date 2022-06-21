CREATE DATABASE University

CREATE TABLE Majors (

    MajorID INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL

)

CREATE TABLE Students (

    StudentID INT IDENTITY PRIMARY KEY,
    StudentNumber INT UNIQUE NOT NULL,
    StudentName NVARCHAR(50) NOT NULL,
    MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)

)

CREATE TABLE Payments (

    PaymentID INT IDENTITY PRIMARY KEY,
    PaymentDate DATE NOT NULL,
    PaymentAccount DECIMAL(8, 2),
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID)

)

CREATE TABLE Subjects (

    SubjectID INT IDENTITY PRIMARY KEY,
    SubjectName NVARCHAR(50) NOT NULL

)

CREATE TABLE Agenda (

    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
    PRIMARY KEY(StudentID, SubjectID)

)