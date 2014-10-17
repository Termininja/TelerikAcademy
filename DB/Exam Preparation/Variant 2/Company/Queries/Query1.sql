-- Get the full name (first name + “ “ + last name)  of every employee and its salary,
-- for each employee with salary between $100 000 and $150 000, inclusive.
-- Sort the results by salary in ascending order.

USE [Company]
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS;	--Empty the SQL Server cache

SELECT (e.FirstName + ' ' + e.LastName) AS [Full Name], e.Salary
	FROM Employees e
	WHERE 100000 <= e.Salary AND e.Salary <= 150000
	ORDER BY e.Salary