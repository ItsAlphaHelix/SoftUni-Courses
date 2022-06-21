CREATE DATABASE Bitbucket

GO

USE Bitbucket

GO

CREATE TABLE Users(
    Id INT PRIMARY KEY IDENTITY,
    Username VARCHAR(30) NOT NULL,
    [Password] VARCHAR(30) NOT NULL,
    Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
    RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
    ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
    PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues(
   Id INT PRIMARY KEY IDENTITY,
   Title VARCHAR(255) NOT NULL,
   IssueStatus VARCHAR(6) NOT NULL,
   RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
   AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits(
    Id INT PRIMARY KEY IDENTITY,
    [Message] VARCHAR(255) NOT NULL,
    IssueId INT FOREIGN KEY REFERENCES Issues(Id),
    RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
    ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Files(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    Size DECIMAL(18, 2) NOT NULL,
    ParentId INT FOREIGN KEY REFERENCES Files(Id),
    CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id) 
)

INSERT INTO Files([Name], Size, ParentId, CommitId)
    VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)
    VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

UPDATE Issues 
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

DELETE FROM RepositoriesContributors
        WHERE RepositoryId = (
                                SELECT Id
                                FROM Repositories
                                WHERE [Name] = 'Softuni-Teamwork'
                            )

DELETE FROM Commits 
        WHERE IssueId IN (
                            SELECT Id
                            FROM Issues
                            WHERE RepositoryId = (
                                                    SELECT Id
                                                    FROM Repositories
                                                    WHERE [Name] = 'Softuni-Teamwork'
                                                )
                        )

DELETE FROM Issues
        WHERE RepositoryId = (
                                SELECT Id
                                FROM Repositories
                                WHERE [Name] = 'Softuni-Teamwork'
                            )

SELECT 
    Id,
    [Message],
    RepositoryId,
    ContributorId
    FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

SELECT 
    Id,
    [Name],
    Size
    FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
    ORDER BY Size DESC, Id, [Name] 

SELECT i.Title, u.Username FROM Issues AS i
JOIN Users AS u ON u.Id = i.Id

SELECT  i.Id,
        CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee 
        FROM Issues AS i
        LEFT JOIN Users AS u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, IssueAssignee 

SELECT  fp.Id,
        fp.[Name],
        CONCAT(fp.Size, 'KB') AS Size
        FROM Files AS ftc
FULL OUTER JOIN Files AS fp ON fp.Id = ftc.ParentId
WHERE ftc.Id IS NULL
ORDER BY fp.Id, fp.[Name], fp.Size DESC 

SELECT TOP 5
         r.Id,
        r.[Name],
        COUNT(c.[Message])
        FROM Repositories AS r
        JOIN Commits AS c ON c.RepositoryId = r.Id
        GROUP BY c.RepositoryId

SELECT TOP 5 r.Id,
       r.Name,
       COUNT(c.Id) AS Commits
    FROM Repositories AS r
LEFT JOIN Commits AS c ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id, r.Name

SELECT u.Username,
       AVG(f.[Size]) AS Size   
    FROM Users AS u
JOIN Commits AS c ON c.ContributorId = u.Id
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC, u.Username

GO

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @count INT
    SET @count = (SELECT COUNT(*) 
                    FROM Users AS u
                    JOIN Commits AS c ON c.ContributorId = u.Id
                    WHERE Username = @username
                 )

    RETURN @count             
END

GO

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

GO

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(30))
AS
BEGIN
    SELECT Id,
           [Name],
           CONCAT(Size, 'KB') AS Size
           FROM Files
    WHERE [Name] LIKE '%'+ @fileExtension + '%'
    ORDER BY Id, [Name], Size DESC
END

GO

EXEC usp_SearchForFiles 'txt'

