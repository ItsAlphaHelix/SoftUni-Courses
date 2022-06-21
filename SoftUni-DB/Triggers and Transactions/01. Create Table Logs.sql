CREATE TRIGGER tr_AddLogForEachSumChange
ON dbo.Accounts FOR UPDATE
AS 
BEGIN
        INSERT INTO Logs(AccountId, OldSum, NewSum)
                SELECT i.id, d.Balance AS OldSum, i.Balance AS NewSum
                FROM inserted AS i
                JOIN deleted AS d ON i.Id = d.Id
END

