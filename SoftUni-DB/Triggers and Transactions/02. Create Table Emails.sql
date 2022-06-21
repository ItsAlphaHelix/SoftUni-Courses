CREATE TRIGGER tr_createNewEmailWhenLogIsInserted
ON Logs FOR INSERT
AS
BEGIN 
        INSERT INTO NotificationEmails(Recipient, [Subject], Body)
                SELECT 
                    i.AccountId
                    ,CONCAT('Balance change for account: ', i.AccountId) AS [Subject]
                    ,CONCAT(
                            'On'
                            ,CAST(GETDATE() AS DATE)
                            ,'your balance was changed from'
                            ,i.OldSum
                            ,'to'
                            ,i.NewSum
                            ,'.') AS Body
                FROM inserted AS i
END