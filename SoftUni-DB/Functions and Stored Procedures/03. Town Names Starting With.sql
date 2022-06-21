CREATE OR ALTER PROC usp_GetTownsStartingWith(@StartWith VARCHAR(50))
AS
    SELECT 
     [Name]
    FROM Towns
    WHERE [Name] LIKE @StartWith + '%'

GO

EXEC usp_GetTownsStartingWith 'c'