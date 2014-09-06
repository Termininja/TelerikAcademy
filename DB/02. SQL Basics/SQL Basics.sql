/* SQL Basics */

--Task 01: What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
	-- Structured Query Language (SQL) is declarative language for query and manipulation of relational data.
	-- A data manipulation language (DML) is a family of syntax elements similar to a computer programming language used for selecting, inserting, deleting and updating data in a database. Performing read-only queries of data is sometimes also considered a component of DML.
	-- A data definition language or data description language (DDL) is a syntax similar to a computer programming language for defining data structures, especially database schemas.
	-- The most important SQL commands are: SELECT, INSERT INTO, UPDATE and DELETE.

--Task 02: What is Transact-SQL (T-SQL)?
	-- T-SQL (Transact SQL) is an extension to the standard SQL language. T-SQL is the standard language used in MS SQL Server.
	-- Supports if statements, loops, exceptions. Constructions used in the high-level procedural programming languages.
	-- T-SQL is used for writing stored procedures, functions, triggers, etc.

--Task 03: Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
	-- Done!

--Task 04: Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT *
	FROM Departments

--Task 05: Write a SQL query to find all department names.
SELECT Name
	FROM Departments

--Task 06: Write a SQL query to find the salary of each employee.
SELECT Salary
	FROM Employees

--Task 07: Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS FullName
	FROM Employees

--Task 08: Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like "John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
	FROM Employees

--Task 09: Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary
	FROM Employees

--Task 10: Write a SQL query to find all information about the employees whose job title is "Sales Representative".
SELECT *
	FROM Employees
	WHERE JobTitle = 'Sales Representative'

--Task 11: Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT FirstName
	FROM Employees
	WHERE FirstName LIKE 'Sa%'

--Task 12: Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

--Task 13: Write a SQL query to find the salary of all employees whose salary is in the range [20000�30000].
SELECT Salary
	FROM Employees
	WHERE Salary BETWEEN 20000 AND 30000

--Task 14: Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName, Salary
	FROM Employees
	WHERE Salary IN (25000, 14000, 12500, 23600)

--Task 15: Write a SQL query to find all employees that do not have manager.
SELECT FirstName
	FROM Employees
	WHERE ManagerID IS NULL

--Task 16: Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT FirstName, Salary
	FROM Employees
	WHERE Salary > 50000 
	ORDER BY Salary DESC

--Task 17: Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 FirstName, Salary
	FROM Employees
	ORDER BY Salary DESC

--Task 18: Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName, e.LastName, a.AddressText
	FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID

--Task 19: Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName, e.LastName, a.AddressText
	FROM Employees e, Addresses a
	WHERE e.AddressID = a.AddressID

--Task 20: Write a SQL query to find all employees along with their manager.
SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS Manager
	FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID

--Task 21: Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS Manager, a.AddressText
	FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
		ON e.AddressID = a.AddressID

--Task 22: Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT Name
	FROM Departments
UNION 
SELECT Name
	FROM Towns

--Task 23: Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS Manager
	FROM Employees m
	RIGHT JOIN Employees e
		ON m.EmployeeID = e.ManagerID

SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS Manager
	FROM Employees e
	LEFT JOIN Employees m
		ON m.EmployeeID = e.ManagerID

--Task 24: Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS [Department Name]
	FROM Employees e 
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID   
	WHERE DATEPART(YEAR, e.HireDate) BETWEEN 1995 AND 2005
		AND d.Name IN ('Sales', 'Finance')