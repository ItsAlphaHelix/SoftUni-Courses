SELECT SUM([Difference]) AS [SumDifference]
FROM (SELECT [FirstName] AS [Host Wizard], 
			 [DepositAmount][Host Wizard Deposit],
			 LEAD([FirstName]) OVER(ORDER BY [Id])[Guest Wizard],
			 LEAD([DepositAmount]) OVER(ORDER BY [Id])[Guest Wizard Deposit],
			 ([DepositAmount] - LEAD([DepositAmount]) OVER(ORDER BY [Id])) AS [Difference]
	  FROM [WizzardDeposits]) AS [SumTable]

