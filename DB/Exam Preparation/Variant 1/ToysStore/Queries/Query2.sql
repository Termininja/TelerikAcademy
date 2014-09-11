-- Get all manufacturers' name and how many toys they have in the age range of 5 to 10 years, inclusive

USE [ToysStore]
GO

-- Variant 1
SELECT m.Name, (SELECT COUNT(*)
	FROM Toys t
	JOIN AgeRanges a
		ON t.AgeRangeID = a.ID
	WHERE a.MinimumAge >= 5 AND a.MaximumAge <= 10 AND t.ManufacturerID = m.ID) AS [Count]
	FROM Manufacturers m

-- Variant 2
SELECT m.Name, COUNT(*) AS [Count]
	FROM Manufacturers m
	JOIN Toys t
		ON t.ManufacturerID = m.ID
	JOIN AgeRanges a
		ON t.AgeRangeID = a.ID
	WHERE a.MinimumAge >= 5 AND a.MaximumAge <= 10	
	GROUP BY m.Name

