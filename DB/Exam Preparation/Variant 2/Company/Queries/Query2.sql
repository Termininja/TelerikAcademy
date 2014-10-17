-- Get all departments and how many employees there are in each one.
-- Sort the result by the number of employees in descending order.

USE [Company]
GO

SELECT d.Name, COUNT(*) AS [Count]
	FROM Departments d
	JOIN Employees e
		ON e.DepartmentID = d.ID
	GROUP BY d.Name
	ORDER BY [Count] DESC