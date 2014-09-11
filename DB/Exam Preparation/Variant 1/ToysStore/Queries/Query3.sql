-- Get all toys' name, price and color from category "boys"

USE [ToysStore]
GO

SELECT t.Name, t.Price, t.Color
	FROM Toys t
	JOIN ToysCategories tc
		ON t.ID = tc.ToyID
	JOIN Categories c
		ON c.ID = tc.CategoryID
	WHERE c.Name = 'boys'