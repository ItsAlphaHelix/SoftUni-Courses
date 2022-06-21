 USE People   
 
CREATE TABLE [People] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL,
    [Picture] VARBINARY(MAX),
    CHECK (DATALENGTH([Picture]) <= 2000000),
    [Height] DECIMAL(3,2),
    [Weight] DECIMAL(5, 2),
    [Gender] CHAR(1) NOT NULL,
    CHECK ([Gender] = 'm' OR [Gender] = 'f'),
    [Birthdate] DATE NOT NULL,
    [Biography] NVARCHAR(MAX)  
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
    VALUES
('Pesho', 1.77, 75.2, 'm', '1998-05-25'),
('Gosho', NULL, NULL, 'm', '1997-11-05'),
('Maria', 1.65, 52.3, 'f', '2001-02-11'),
('Viki', NULL, NULL, 'f', '2001-05-20'),
('Ivan', 1.96, 80.2, 'm', '2003-07-25')   

SELECT * FROM [People]