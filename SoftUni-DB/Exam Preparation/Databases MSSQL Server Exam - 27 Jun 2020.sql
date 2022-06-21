CREATE DATABASE WMS

GO

USE WMS

GO

--DDL

CREATE TABLE Clients(
    ClientId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Phone VARCHAR(12)
    CHECK(LEN(Phone) = 12)
)

CREATE TABLE Mechanics(
    MechanicId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    [Address] VARCHAR(255)
)

CREATE TABLE Models(
    ModelId INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) UNIQUE
)

CREATE TABLE Jobs(
    JobId INT PRIMARY KEY IDENTITY,
    ModelId INT FOREIGN KEY REFERENCES Models(ModelId),
    [Status] VARCHAR(11) DEFAULT 'Pending' CHECK([Status] IN ('Pending, In Progess, Finished')),
    ClientId INT FOREIGN KEY REFERENCES Clients(ClientId),
    MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
    IssueDate DATETIME,
    FinishDate DATETIME  
)

CREATE TABLE Orders(
    OrderId INT PRIMARY KEY IDENTITY,
    JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
    IssueDate DATETIME, 
    Delivered BIT DEFAULT 1
)

CREATE TABLE Vendors(
    VendorId INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) UNIQUE
)

CREATE TABLE Parts(
    PartId INT PRIMARY KEY IDENTITY,
    SerialNumber VARCHAR(50) UNIQUE,
    [Description] VARCHAR(255),
    Price MONEY
    CHECK(Price > 0),
    VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId),
    StockQty INT DEFAULT 0
    CHECK(StockQty > 0)
)

CREATE TABLE OrderParts(
    OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
    PartId INT FOREIGN KEY REFERENCES Parts(PartId)
    PRIMARY KEY(OrderId, PartId),
    Quantity INT DEFAULT 1
    CHECK(Quantity > 0)
)
CREATE TABLE PartsNeeded(
    JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
    PartId INT FOREIGN KEY REFERENCES Parts(PartId)
    PRIMARY KEY(JobId, PartId),
    Quantity INT DEFAULT 1
    CHECK(Quantity > 0)
)

GO
--DML

INSERT INTO Clients(FirstName, LastName, Phone)
    VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber, [Description], Price, VendorId)
    VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

GO

--UPDATE
UPDATE Jobs
SET MechanicId = 3, [Status] = 'In Progress'
WHERE [Status] = 'Pending'
-----

GO

--DELETE

DELETE FROM OrderParts
        WHERE OrderId = (
                                SELECT OrderId 
                                       FROM Orders 
                                WHERE OrderId = 19  
                        )

DELETE FROM Orders
        WHERE OrderId = 19

GO

--Querying

SELECT   CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, 
         j.[Status],
         j.IssueDate
         FROM Mechanics AS m
         JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

GO

SELECT  CONCAT(c.FirstName, ' ', c.LastName) AS Client,
        DATEDIFF(DAY, j.IssueDate , '04/24/2017') AS [Days going],
        j.[Status]
        FROM Clients AS c
        JOIN Jobs AS j ON j.ClientId = c.ClientId
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.ClientId

GO

SELECT  CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
        AVG(DATEDIFF(DAY, IssueDate, j.FinishDate)) AS [Average Days]
        FROM Mechanics AS m
        JOIN Jobs AS j ON j.MechanicId = m.MechanicId
GROUP BY j.MechanicId, FirstName, m.LastName -- here i can remove j.MechanicId
ORDER BY j.MechanicId -- here i can order by MAX(m.MechanicId)

GO

SELECT  CONCAT(m.FirstName, ' ', m.LastName) AS Available
        FROM Mechanics AS m
        LEFT JOIN Jobs AS j ON J.MechanicId = m.MechanicId 
WHERE j.JobId IS NULL OR (SELECT COUNT(*)
                                 FROM Jobs
                          WHERE [Status] != 'Finished' AND MechanicId = m.MechanicId
                          GROUP BY MechanicId, [Status]
                          ) IS NULL
GROUP BY m.MechanicId, m.FirstName, m.LastName

GO

SELECT  j.JobId,
        ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
        FROM Jobs AS j
        LEFT JOIN Orders AS o ON o.JobId = j.JobId
        LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
        LEFT JOIN Parts AS p ON p.PartId = op.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

GO

SELECT  p.PartId,
        p.[Description],
        pn.Quantity AS [Required],
        p.StockQty AS [In Stock],
        IIF(o.Delivered = 0, op.Quantity, 0) AS Ordered
        FROM Parts AS p
        LEFT JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
        LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
        LEFT JOIN Jobs AS j ON j.JobId = pn.JobId
        LEFT JOIN Orders AS o ON o.JobId = j.JobId
WHERE j.[Status] != 'Finished' AND p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0) < pn.Quantity
ORDER BY p.PartId

GO

CREATE PROC usp_PlaceOrder
(
@jobId INT,
@serialNumber VARCHAR(50),
@quantity INT
)
AS 
BEGIN
    DECLARE @status VARCHAR(10) = (SELECT [Status] 
                                                 FROM Jobs 
                                          WHERE JobId = @jobId
                                         )
    DECLARE @partId INT = (SELECT PartId 
                                  FROM Parts
                            WHERE SerialNumber = @serialNumber
                          )
    IF(@quantity <= 0)
    THROW 50012, 'Part quantity must be more than zero!', 1
    ELSE IF(@status IS NULL)
    THROW 50013, 'Job not found!', 1
    ELSE IF(@status = 'Finished')
    THROW 50011, 'This job is not active!', 1
    ELSE IF(@partId IS NULL)
    THROW 50014, 'Part not found!', 1

    DECLARE @orderId INT = (SELECT o.OrderId 
                                   FROM Orders AS o
                            WHERE JobId = @jobId AND o.IssueDate IS NULL
                            )

    IF(@orderId IS NULL)
    BEGIN
        INSERT INTO Orders (JobId, IssueDate) VALUES
        (@jobId, NULL)
    END
    SET @orderId = (SELECT o.OrderId 
                           FROM Orders AS o
                    WHERE JobId = @jobId AND o.IssueDate IS NULL
                    )

    DECLARE @orderPartExists INT = (SELECT OrderId 
                                       FROM OrderParts
                                WHERE OrderId = @orderId AND PartId = @partId
                               )

    IF(@orderPartExists IS NULL)
    BEGIN
        INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
        (@orderId, @partId, @quantity)
    END
    ELSE
    BEGIN
    
    UPDATE OrderParts
    SET Quantity += @quantity
    WHERE OrderId = @orderId AND PartId = @partId
    END
END

GO 

CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15, 2)
AS
BEGIN
DECLARE @result DECIMAL(15, 2)
SET @result = (SELECT 
        SUM(p.Price * op.Quantity) AS TotalSum
        FROM Jobs AS j
        JOIN Orders AS o ON o.JobId = j.JobId
        JOIN OrderParts AS op ON op.OrderId = o.OrderId
        JOIN Parts AS p ON P.PartId = op.PartId
WHERE j.JobId = @jobId
GROUP BY j.JobId)

IF(@result IS NULL)
SET @result = 0
RETURN @result
END
