CREATE TABLE Manufacturers (

    ManufacturerID INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    EstablishedOn DATE NOT NULL

)

CREATE TABLE Models (

    ModelId INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)

)

INSERT INTO Manufacturers VALUES
('Asus', '02/05/2001'),
('Nvidia', '03/07/2005'),
('Msi', '06/07/1999')

INSERT INTO [Models] VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

SELECT * FROM Models