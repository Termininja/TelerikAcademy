## Transact-SQL

**Task 01.** Create a database with two tables: `Persons(Id(PK), FirstName, LastName, SSN)` and `Accounts(Id(PK), PersonId(FK), Balance)`. Insert few records for testing. Write a stored procedure that selects the full names of all persons.

**Task 02.** Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.

**Task 03.** Create a function that accepts as parameters – sum, yearly interest rate and number of months. It should calculate and return the new sum. Write a `SELECT` to test whether the function works as expected.

**Task 04.** Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month. It should take the `AccountId` and the interest rate as parameters.

**Task 05.** Add two more stored procedures `WithdrawMoney(AccountId, money)` and `DepositMoney(AccountId, money)` that operate in transactions.

**Task 06.** Create another table – `Logs(LogID, AccountID, OldSum, NewSum)`. Add a trigger to the `Accounts` table that enters a new entry into the `Logs` table every time the sum on an account changes.

**Task 07.** Define a function in the database `TelerikAcademy` that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
>Example: 'oistmiahf' will return **'Sofia', 'Smith', ...** but not **'Rob'** and **'Guy'**.

**Task 08.** Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.

**Task 09\*.** Write a T-SQL script that shows for each town a list of all employees that live in it.
>Sample output:
 * Sofia -> **Svetlin Nakov, Martin Kulov, George Denchev**
 * Ottawa -> **Jose Saraiva**
 * ...
 
**Task 10.** Define a .NET aggregate function `StrConcat` that takes as input a sequence of strings and return a single string that consists of the input strings separated by '`,`'.
>Example: The following SQL statement should return a single string:
```
SELECT StrConcat(FirstName + ' ' + LastName)
FROM Employees
```