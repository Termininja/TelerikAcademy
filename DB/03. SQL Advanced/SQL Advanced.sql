/* SQL Advanced */

--Task 01: Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.
SELECT FirstName + ' ' + LastName [Name], Salary
	FROM Employees
	WHERE Salary = 
		(SELECT MIN(Salary) FROM Employees)

--Task 02: Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName + ' ' + LastName [Name], Salary
	FROM Employees
	WHERE Salary <
		(SELECT (MIN(Salary) * 1.1) FROM Employees)

--Task 03: Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName [Name], e.Salary, e.DepartmentID
	FROM Employees e
	WHERE Salary =
		(SELECT MIN(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID)

--Task 04: Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) [Average salary]
	FROM Employees
	WHERE DepartmentID = 1

--Task 05: Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(Salary) [Average Salary]
	FROM Employees e
		JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'

--Task 06: Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) [Employees]
	FROM Employees e 
		JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'

--Task 07: Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(ManagerID) [Employees]
	FROM Employees

--Task 08: Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(EmployeeID) [Employees]
	FROM Employees
	WHERE ManagerID IS NULL

--Task 09: Write a SQL query to find all departments and the average salary for each of them.
SELECT DepartmentID, AVG(Salary) [Average Salary]
	FROM Employees
	GROUP BY DepartmentID

--Task 10: Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name [Department], t.Name [Town], COUNT(*) [Employees]
	FROM Employees e
		JOIN Departments d ON e.DepartmentID = d.DepartmentID
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID = t.TownID
	GROUP BY t.Name, d.Name

--Task 11: Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName + ' ' + m.LastName [Manager], COUNT(e.EmployeeID) [Employees]
	FROM Employees e
		JOIN Employees m ON e.ManagerID = m.EmployeeID
	GROUP BY m.FirstName, m.LastName
	HAVING COUNT(e.EmployeeID) = 5

--Task 12: Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ' ' + e.LastName [Employee], ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') [Manager]
	FROM Employees e
		LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID

--Task 13: Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT FirstName + ' ' + LastName [Employee]
	FROM Employees
	WHERE LEN(LastName) = 5

--Task 14: Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff');

--Task 15: Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users (
    UserId Int IDENTITY,
    Username nvarchar(50) NOT NULL,
    [Password] nvarchar(50) CHECK (LEN(Password) > 4),
    FullName nvarchar(50) NOT NULL,
    LastLoginTime DATETIME,
    CONSTRAINT PK_Users PRIMARY KEY(UserId),
    CONSTRAINT UQ_Username UNIQUE(Username)
) 
GO

--Task 16: Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. Test if the view works correctly.
CREATE VIEW	[UsersFromToday] AS
SELECT *
	FROM Users
	WHERE DATEDIFF(DAY, LastLoginTime, GETDATE())= 0
GO

--Task 17: Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). Define primary key and identity column.
CREATE TABLE Groups (
    GroupId Int IDENTITY,
    Name nvarchar(50) NOT NULL
    CONSTRAINT PK_Groups PRIMARY KEY(GroupId),
    CONSTRAINT UQ_Name UNIQUE(Name),
)
GO

--Task 18: Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column and as well in the Groups table. Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users
	ADD GroupId int

ALTER TABLE Users
    ADD CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupId) REFERENCES Groups(GroupId)

--Task 19: Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups
	VALUES ('Group1'), ('Group2'), ('Group3')

INSERT INTO Users 
	VALUES
		('Username1', 'Password1', 'FullName1', GETDATE()),
		('Username2', 'Password2', 'FullName2', GETDATE()),
		('Username3', 'Password3', 'FullName3', GETDATE())

--Task 20: Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
	SET Username = 'NewUsername', [Password] = 'NewPassword'
	WHERE UserId = 3

UPDATE Groups
	SET Name='NewGroup'
	WHERE GroupID = 3

--Task 21: Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
	WHERE UserId IN (1, 3)

DELETE FROM Groups
	WHERE GroupId = 3

--Task 22: Write SQL statements to insert in the Users table the names of all employees from the Employees table. Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). Use the same for the password, and NULL for last login time.
INSERT INTO Users(Username, FullName, [Password], LastLoginTime)
    SELECT
		LEFT(FirstName, 1) + LOWER(LastName),
		FirstName + ' ' + LastName,
		LEFT(FirstName, 1) + LOWER(LastName),
		NULL
	FROM Employees

--Task 23: Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
	SET [Password] = NULL
	WHERE LastLoginTime < CONVERT(DATETIME,'10-03-2010')

--Task 24: Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
	WHERE [Password] IS NULL

--Task 25: Write a SQL query to display the average employee salary by department and job title.
SELECT DepartmentID [Department], JobTitle, AVG(Salary) [Average Salary]
	FROM Employees
	GROUP BY JobTitle, DepartmentID

--Task 26: Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT DepartmentID [Department], JobTitle, MIN(FirstName + ' ' + LastName) [Name], MIN(Salary) [Salary]
	FROM Employees
	GROUP BY DepartmentID, JobTitle

--Task 27: Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(e.EmployeeID) [Employees]
	FROM Employees e 
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON t.TownID = a.TownID
	GROUP BY t.Name
	ORDER BY Employees DESC

--Task 28: Write a SQL query to display the number of managers from each town.
SELECT t.Name [Town], COUNT(e.EmployeeID) [Managers]
	FROM Employees e 
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON t.TownID = a.TownID
	GROUP BY t.Name
