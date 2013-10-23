/* Task 02.
 * A bank holds different types of accounts for its customers: deposit accounts,
 * loan accounts and mortgage accounts. Customers could be individuals or companies.
 * 
 * All accounts have customer, balance and interest rate (monthly based).
 * Deposit accounts are allowed to deposit and with draw money.
 * Loan and mortgage accounts can only deposit money.
 * 
 * All accounts can calculate their interest amount for a given period (in months).
 * In the common case its is calculated as follows: number_of_months * interest_rate.
 * 
 * Loan accounts have no interest for the first 3 months if are held by individuals
 * and for the first 2 months if are held by a company.
 * 
 * Deposit accounts have no interest if their balance is positive and less than 1000.
 * 
 * Mortgage accounts have ½ interest for the first 12 months for companies
 * and no interest for the first 6 months for individuals.
 * 
 * Your task is to write a program to model the bank system by classes and interfaces.
 * You should identify the classes, interfaces, base classes and abstract actions and
 * implement the calculation of the interest functionality through overridden methods.
 */

using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static void Main()
        {
            // Create a list of accounts
            List<Account> accounts = new List<Account>();
            accounts.Add(new Deposit("Customer 1", 400, 5));
            accounts.Add(new Loan("Customer 2", 200, 2));
            accounts.Add(new Mortgage("Customer 3", 500, 7));


            // Interest amount
            Console.WriteLine(accounts[0].InterestAmount(10));
            Console.WriteLine(accounts[1].InterestAmount(6));
            Console.WriteLine(accounts[2].InterestAmount(20));
        }
    }
}