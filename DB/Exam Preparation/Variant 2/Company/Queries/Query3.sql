-- Get each employee’s full name (first name + “ “ + last name), project’s name, department’s name,
-- starting and ending date for each employee in project. Additionally get the number of all reports,
-- which time of reporting is between the start and end date. Sort the results first by the employee id,
-- then by the project id. (This query is slow, be patient!)

USE [Company]
GO

SELECT (e.FirstName + ' ' + e.LastName) AS [Full Name], 
		p.Name AS [Project's Name], 
		d.Name AS [Department's Name], 
		p.StartDate, 
		p.EndDate,
		e.ID AS [EmployeeID],
		p.ID AS [ProjectID]
	FROM Employees e
	JOIN EmployeesProjects ep
		ON e.ID = ep.EmployeeID
	JOIN Projects p
		ON p.ID = ep.ProjectID
	JOIN Departments d
		ON d.ID = e.DepartmentID
	ORDER BY e.ID, p.ID
	
SELECT COUNT(*) FROM Reports