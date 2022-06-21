CREATE DATABASE CigarShop

GO

USE CigarShop

GO

CREATE TABLE Sizes(
    Id INT PRIMARY KEY IDENTITY,
    [Length] INT NOT NULL
    CHECK([Length] >= 10 OR [Length] <= 25),
    RingRange DECIMAL(18, 2) NOT NULL
    CHECK(RingRange >= 1.5 OR RingRange <= 7.5)
)

CREATE TABLE Tastes(
    Id INT PRIMARY KEY IDENTITY,
    TasteType VARCHAR(20) NOT NULL,
    TasteStrength VARCHAR(15),
    ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
    Id INT PRIMARY KEY IDENTITY,
    BrandName VARCHAR(30) UNIQUE NOT NULL,
    BrandDescription VARCHAR(MAX) NOT NULL
) 

CREATE TABLE Cigars(
    Id INT PRIMARY KEY IDENTITY,
    CigarName VARCHAR(80) NOT NULL,
    BrandId INT FOREIGN KEY REFERENCES Brands(Id),
    TastId INT FOREIGN KEY REFERENCES Tastes(Id),
    SizeId INT FOREIGN KEY REFERENCES Sizes(Id),
    PriceForSingleCigar MONEY NOT NULL,
    ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses(
    Id INT PRIMARY KEY IDENTITY,
    Town VARCHAR(30) NOT NULL,
    Country VARCHAR(30) NOT NULL,
    Streat NVARCHAR(100) NOT NULL,
    ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients(
    Id INT PRIMARY KEY IDENTITY,
    FirstName  NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars(
    ClientId INT FOREIGN KEY REFERENCES Clients(Id),
    CigarId INT FOREIGN KEY REFERENCES Cigars(Id)
    PRIMARY KEY(ClientId, CigarId)
)

GO

INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
    VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP)
    VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

GO

UPDATE Cigars
SET PriceForSingleCigar *= 1.20
FROM Cigars AS c
JOIN Tastes AS t ON t.Id = c.TastId
WHERE t.TasteType LIKE '%Spicy%'

UPDATE Brands 
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

GO

DELETE FROM Clients
        WHERE AddressId IN (
                                SELECT Id
                                FROM Addresses
                                WHERE Country LIKE 'C%'
                            )

DELETE FROM Addresses
            WHERE Country LIKE 'C%'

GO

SELECT CigarName, 
       PriceForSingleCigar,
       ImageURL 
       FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC

GO

SELECT c.Id,
       c.CigarName,
       c.PriceForSingleCigar,
       t.TasteType,
       t.TasteStrength
    FROM Cigars AS c
    JOIN Tastes AS t ON t.Id = c.TastId
WHERE t.TasteType IN('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC

GO

SELECT c.id,
       CONCAT(c.FirstName, ' ', c.LastName) AS ClientName,
       c.Email
       FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
WHERE cc.CigarId IS NULL
ORDER BY ClientName

GO

SELECT TOP 5 c.CigarName,
       c.PriceForSingleCigar,
       c.ImageURL 
       FROM Cigars AS c
JOIN Sizes AS s ON s.Id = c.SizeId
WHERE s.Length >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

GO

SELECT  CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
        a.Country,
        a.ZIP,
        CONCAT('$', MAX(cig.PriceForSingleCigar)) AS CigarPrice
       FROM ClientsCigars AS cc
       JOIN Clients AS c ON c.Id = cc.ClientId
       JOIN Addresses AS a ON a.Id = c.AddressId
       JOIN Cigars AS cig ON cig.Id = cc.CigarId
WHERE a.ZIP NOT LIKE '%[^0-9.]%'
GROUP BY FirstName, LastName, a.Id, a.Country, a.ZIP
ORDER BY FullName

GO

SELECT
	cl.LastName,
	AVG(s.[Length])CigarLength,
	CEILING(AVG(s.RingRange))CigarRingRange
FROM Clients cl
JOIN ClientsCigars cc ON cl.Id = cc.ClientId
JOIN Cigars c ON c.Id = cc.CigarId
JOIN Sizes s ON c.SizeId = s.Id
--WHERE cl.Id IN (SELECT cc.ClientId FROM ClientsCigars)
GROUP BY cl.LastName
ORDER BY CigarLength DESC

GO 

CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(30))
RETURNS INT
AS 
BEGIN
    DECLARE @count INT
    SET @count = (SELECT COUNT(*) 
                    FROM Clients AS cl 
                    JOIN ClientsCigars AS cc ON Cc.ClientId = cl.Id
                    WHERE cl.FirstName = @name
                 )
        RETURN @count
END

GO 

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
    SELECT  c.CigarName,
            CONCAT('$', c.PriceForSingleCigar) AS Price,
            t.TasteType,
            b.BrandName,
            CONCAT(s.Length, ' ', 'cm') AS CigarLength,
            CONCAT(s.RingRange, ' ', 'cm') AS CigarRingRange
           FROM Cigars AS c
           JOIN Tastes AS t ON t.Id = c.TastId
           JOIN Brands AS b ON b.Id = c.BrandId
           JOIN Sizes AS s ON s.Id = c.SizeId
    WHERE TasteType = @taste
    ORDER BY CigarLength, CigarRingRange DESC
END