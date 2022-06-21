CREATE TABLE Teachers (

    TeacherID INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
('Pesho', 1),
('Dimityr', 2),
('Gosho', 3)