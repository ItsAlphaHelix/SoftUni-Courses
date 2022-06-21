SELECT DepositGroup, Max(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
GROUP BY DepositGroup