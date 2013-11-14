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
 * Mortgage accounts have ½ interest for the first 12 months for companies and no
 * interest for the first 6 months for individuals.
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
            accounts.Add(new Deposit(new Individual("Leo EOOD"), 500, 0.05m));
            accounts.Add(new Loan(new Company("Telerik"), 200, 0.07m));
            accounts.Add(new Mortgage(new Individual("Sisi & Pisi"), 500, 0.02m));

            // Testing deposit
            accounts[0].Deposit(600);
            accounts[1].Deposit(200);
            accounts[2].Deposit(700);

            // Testing withdraw
            ((Deposit)accounts[0]).Withdraw(50);

            // Print the result
            PrintAccount("Account 1", accounts[0], 10);
            PrintAccount("Account 2", accounts[1], 6);
            PrintAccount("Account 3", accounts[2], 20);

            // Create some account
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Press Enter to create some new account . . .");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            CreateAccount(accounts);
            TestAccount(accounts);
        }

        // Print account information
        private static void PrintAccount(string text, Account account, int months)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine(account);
            Console.WriteLine("Interest amount: " + account.InterestAmount(months));
            Console.WriteLine();
        }

        private static void TestAccount(List<Account> accounts)
        {
            while (true)
            {
                try
                {
                    ConsoleKeyInfo key;
                    while (true)
                    {
                        StringColor("\r[D]eposit, [W]ithdraw, [I]nterest amount, [P]rint or [Q]uit: ", "3 14 26 45 56".Split());
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.D &&
                            key.Key != ConsoleKey.W &&
                            key.Key != ConsoleKey.I &&
                            key.Key != ConsoleKey.P &&
                            key.Key != ConsoleKey.Q)
                        {
                            Console.Write("\b \b");
                            continue;
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("\b{0}\n", key.Key);
                        Console.ResetColor();
                        break;
                    }
                    switch (key.Key)
                    {
                        case ConsoleKey.D:
                            Console.Write("Amount: ");
                            accounts[3].Deposit(decimal.Parse(Console.ReadLine()));
                            break;
                        case ConsoleKey.W:
                            if (accounts[3] is Deposit)
                            {
                                Console.Write("Amount: ");
                                ((Deposit)accounts[3]).Withdraw(decimal.Parse(Console.ReadLine()));
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Operation is not allowed!");
                                Console.ResetColor();
                            }
                            break;
                        case ConsoleKey.I:
                            Console.Write("Months: ");
                            int months = int.Parse(Console.ReadLine());
                            Console.WriteLine("Interest amount: " + accounts[3].InterestAmount(months));
                            break;
                        case ConsoleKey.P: Console.WriteLine(accounts[3]); break;
                        case ConsoleKey.Q: Environment.Exit(1); break;
                        default: break;
                    }
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    // Unexpected error
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Something's wrong!");
                    Console.ResetColor();
                }
            }
        }

        private static void CreateAccount(List<Account> acc)
        {
            // What is the type of account
            ConsoleKeyInfo key1;
            while (true)
            {
                StringColor("\r[D]eposit, [L]oan or [M]ortgage: ", "3 14 24".Split());
                key1 = Console.ReadKey();
                if (key1.Key != ConsoleKey.D && key1.Key != ConsoleKey.L && key1.Key != ConsoleKey.M)
                {
                    Console.Write("\b \b");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\b{0}\n", key1.Key);
                Console.ResetColor();
                break;
            }

            string name = String.Empty;

            // What type is the customer
            ConsoleKeyInfo key2;
            while (true)
            {
                StringColor("\r[I]ndividual or [C]ompany: ", "3 19".Split());
                key2 = Console.ReadKey();
                if (key2.Key != ConsoleKey.I && key2.Key != ConsoleKey.C)
                {
                    Console.Write("\b \b");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\b{0}\n", key2.Key);
                Console.ResetColor();

                // What is the customer's name
                if (key2.Key == ConsoleKey.I) Console.Write("Person's name: ");
                if (key2.Key == ConsoleKey.C) Console.Write("Company's name: ");
                name = Console.ReadLine();
                break;
            }

            // What is the interest rate
            Console.Write("Interest rate (from 0.01 to 0.07): ");
            decimal interetRate = decimal.Parse(Console.ReadLine());

            switch (key1.Key)
            {
                case ConsoleKey.D:
                    if (key2.Key == ConsoleKey.I) acc.Add(new Deposit(new Individual(name), 0, interetRate));
                    if (key2.Key == ConsoleKey.C) acc.Add(new Deposit(new Company(name), 0, interetRate));
                    break;
                case ConsoleKey.L:
                    if (key2.Key == ConsoleKey.I) acc.Add(new Loan(new Individual(name), 0, interetRate));
                    if (key2.Key == ConsoleKey.C) acc.Add(new Loan(new Company(name), 0, interetRate));
                    break;
                case ConsoleKey.M:
                    if (key2.Key == ConsoleKey.I) acc.Add(new Mortgage(new Individual(name), 0, interetRate));
                    if (key2.Key == ConsoleKey.C) acc.Add(new Mortgage(new Company(name), 0, interetRate));
                    break;
                default: break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nYour account is created successfully.");
            Console.ResetColor();
        }

        // Colorize some string
        private static void StringColor(string str, string[] position)
        {
            for (int letter = 0; letter < str.Length; letter++)
            {
                foreach (var pos in position)
                {
                    if (int.Parse(pos) == letter + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    }
                }
                Console.Write(str[letter]);
                Console.ResetColor();
            }
        }
    }
}