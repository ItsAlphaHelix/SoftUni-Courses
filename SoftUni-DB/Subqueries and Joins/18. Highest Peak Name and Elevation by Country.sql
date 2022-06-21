SELECT TOP 5
c.CountryName AS Country,
(CASE
WHEN p.PeakName IS NULL THEN '(no highest peak)'
ELSE p.PeakName
END) AS [Highest Peak Name],

(CASE
WHEN p.Elevation IS NULL THEN 0
ELSE p.Elevation
END) AS [Highest Peak Elevation],

(CASE
WHEN m.MountainRange IS NULL THEN '(no mountain)'
ELSE m.MountainRange
END) AS Mountain

FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
ORDER BY c.CountryName, p.Elevation


-- SELECT TOP(5)
--     [CountryName] AS [Country],
-- 	ISNULL([Result].[PeakName], '(no highest peak)') AS [Highest Peak Name],
-- 	ISNULL([Result].[Elevation], 0) AS [Highest Peak Elevation],
-- 	ISNULL([Result].[MountainRange],'(no mountain)') AS [Mountain]
-- FROM(SELECT 
-- 		c.[CountryName],
-- 		p.[PeakName],
-- 		p.[Elevation],
-- 		m.[MountainRange],
-- 		DENSE_RANK() OVER (PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [Rank]
--      FROM [Countries] c
--             LEFT JOIN [MountainsCountries] mc ON c.[CountryCode] = mc.[CountryCode]
--             LEFT JOIN [Mountains] m ON mc.[MountainId] = m.[Id]
--             LEFT JOIN [Peaks] p  ON m.[Id] = p.[MountainId]
--           ) AS [Result]
--  WHERE [Rank] = 1
--  ORDER BY [Country], [Highest Peak Name]