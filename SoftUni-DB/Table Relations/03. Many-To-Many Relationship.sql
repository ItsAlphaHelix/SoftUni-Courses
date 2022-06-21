CREATE TABLE Students (

    StudentID INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,

)

CREATE TABLE Exams (

    ExamID INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL

)

CREATE TABLE StudentsExams (

    [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
	PRIMARY KEY([StudentID], [ExamID])

)

INSERT INTO Students VALUES
('Pesho'),
('Mitko'),
('Angel')

INSERT INTO Exams VALUES
('C#-DB'),
('JavaScript'),
('C#-OPP')

INSERT INTO StudentsExams VALUES
(1, 2),
(2, 1),
(3, 3)

SELECT * FROM Students

SELECT * FROM Exams

SELECT * FROM StudentsExams

