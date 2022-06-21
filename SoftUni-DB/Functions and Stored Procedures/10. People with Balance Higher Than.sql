CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan(@SuppliedBalance MONEY)
AS 
    SELECT
    ah.FirstName AS [First Name]
    ,ah.LastName AS [Last Name]
    FROM AccountHolders AS ah
    JOIN Accounts AS a ON a.AccountHolderId = ah.Id
    GROUP BY ah.FirstName, ah.LastName
    HAVING SUM(a.Balance) > @SuppliedBalance
    ORDER BY ah.FirstName, ah.LastName

EXEC usp_GetHoldersWithBalanceHigherThan 10000