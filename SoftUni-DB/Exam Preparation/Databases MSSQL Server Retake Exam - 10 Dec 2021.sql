CREATE DATABASE Airport

GO

USE Airport

GO

--DDL

CREATE TABLE Passengers
(
	Id INT IDENTITY PRIMARY KEY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL CHECK(Age BETWEEN 21 AND 62),
	Rating FLOAT CHECK(Rating BETWEEN 0 AND 10)
)

CREATE TABLE AircraftTypes
(
	Id INT IDENTITY PRIMARY KEY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT IDENTITY PRIMARY KEY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PilotId INT NOT NULL REFERENCES Pilots(Id),
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports
(
	Id INT IDENTITY PRIMARY KEY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations 
(
	Id INT IDENTITY PRIMARY KEY,
	AirportId INT NOT NULL REFERENCES Airports(Id),
	[Start] DATETIME NOT NULL,
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)

GO

--DML

INSERT INTO Passengers
SELECT 
	CONCAT(FirstName, ' ', LastName) FullName,
	CONCAT(FirstName, LastName, '@gmail.com')Email
FROM Pilots
WHERE Id BETWEEN 5 AND 15

GO

--UPDATE

UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN('C', 'B') AND (FlightHours IS NULL OR FlightHours <= 100) AND [Year] >= 2013

GO

--DELETE

DELETE FROM FlightDestinations
        WHERE PassengerId IN (
                                SELECT Id 
                                       FROM Passengers 
                                WHERE LEN(FullName) <= 10   
                             )

DELETE FROM Passengers
        WHERE LEN(FullName) <= 10

GO

--QUERYING

SELECT Manufacturer,
       Model,
       FlightHours,
       Condition
       FROM Aircraft
ORDER BY FlightHours DESC

GO

SELECT p.FirstName,
       p.LastName,
       a.Manufacturer,
       a.Model,
       a.FlightHours  
       FROM PilotsAircraft AS pa
       JOIN Aircraft AS a ON a.Id = pa.AircraftId
       JOIN Pilots AS p ON p.Id = pa.PilotId
WHERE FlightHours IS NOT NULL AND FlightHours <= 304
ORDER BY FlightHours DESC, FirstName

GO

SELECT TOP 20 d.Id AS DestinationId,
       d.[Start],
       p.FullName,
       a.AirportName,
       d.TicketPrice
       FROM FlightDestinations AS d
       JOIN Passengers AS p ON p.Id = d.PassengerId
       JOIN Airports AS a ON a.Id = d.AirportId
WHERE DATEPART(DAY, d.[Start]) % 2 = 0
ORDER BY d.TicketPrice DESC, a.AirportName

GO

SELECT a.Id AS AircraftId,
       a.Manufacturer,
       a.FlightHours,
       COUNT(fd.Id) AS FlightDestinationsCount,
       ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
       FROM Aircraft AS a
       JOIN FlightDestinations AS fd ON fd.AircraftId = a.Id
GROUP BY a.Id, a.Manufacturer, a.FlightHours
HAVING COUNT(fd.Id) >= 2
ORDER BY FlightDestinationsCount DESC, a.Id

GO 

SELECT
	p.FullName,
	(SELECT COUNT(a.Id) FROM Aircraft a 
				JOIN FlightDestinations fd ON fd.AircraftId = a.Id  
	WHERE p.Id = fd.PassengerId) CountOfAircraft,
	(SELECT SUM(fd.TicketPrice) FROM Aircraft a 
				JOIN FlightDestinations fd ON fd.AircraftId = a.Id  
	WHERE p.Id = fd.PassengerId) TotalPayed
FROM Passengers p
WHERE SUBSTRING(p.FullName, 2, 1) LIKE 'a' 
	AND (SELECT COUNT(a.Id) FROM Aircraft a 
				JOIN FlightDestinations fd ON fd.AircraftId = a.Id  
	WHERE p.Id = fd.PassengerId) > 1 
ORDER BY p.FullName

GO

SELECT 	a.AirportName,
		fd.[Start] AS DayTime,
		fd.TicketPrice,
		p.FullName,
		ac.Manufacturer,
		ac.Model
		FROM Airports AS a
		JOIN FlightDestinations AS fd ON fd.AirportId = a.Id
		JOIN Passengers AS p ON p.Id = fd.PassengerId
		JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
WHERE DATEPART(HOUR, fd.[Start]) BETWEEN 6.00 AND 20.00 AND fd.TicketPrice > 2500
ORDER BY ac.Model

GO

--Programmability

CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @count INT
	SET @count = (SELECT COUNT(*) FROM Passengers AS p
							JOIN FlightDestinations AS fd ON fd.PassengerId = p.Id
							WHERE P.Email = @email		 			
				 )
	RETURN @count
END

GO

CREATE OR ALTER PROC usp_SearchByAirportName(@nameOfAirport VARCHAR(70))
AS
BEGIN
	SELECT 	a.AirportName,
			p.FullName,
			(CASE
				WHEN fd.TicketPrice <= 400 THEN 'Low'
				WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
				ELSE 'High'
			END) AS LevelOfTickerPrice,
			ac.Manufacturer,
			ac.Condition,
			[at].TypeName
			FROM Airports AS a
			JOIN FlightDestinations AS fd ON fd.AirportId = a.Id
			JOIN Passengers AS p ON p.Id  = fd.PassengerId
			JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
			JOIN AircraftTypes AS [at] ON [at].Id = ac.TypeId
	WHERE a.AirportName = @nameOfAirport
	ORDER BY ac.Manufacturer, p.FullName
END

GO

		