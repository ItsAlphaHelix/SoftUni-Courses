CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS 
BEGIN TRANSACTION
        IF(@MoneyAmount < 0)
            BEGIN
                ROLLBACK
            END
        UPDATE Accounts
        SET Balance += @MoneyAmount
        WHERE Id = @AccountId
COMMIT