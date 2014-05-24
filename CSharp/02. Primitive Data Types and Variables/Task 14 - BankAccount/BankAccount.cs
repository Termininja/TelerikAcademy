//Task 14: A bank account has a: holder name (first name, middle name and last name), available
//         amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers
//         associated with the account. Declare the variables needed to keep the information for
//         a single bank account using the appropriate data types and descriptive names.

using System;

class BankAccount
{
    static void Main()
    {
        // Read the information about a single bank account
        Console.Write("First name: ");
        string firstName = Console.ReadLine();

        Console.Write("Middle name: ");
        string middleName = Console.ReadLine();

        Console.Write("Last name: ");
        string lastName = Console.ReadLine();

        string holderName = firstName + " " + middleName + " " + lastName;

        Console.Write("Money ballance: ");
        decimal balance = decimal.Parse(Console.ReadLine());

        Console.Write("Bank name: ");
        string bankName = Console.ReadLine();

        Console.Write("IBAN: ");                            // for example: BG01DFSC9499867730018
        string IBAN = Console.ReadLine();
        Console.Write("BIC: ");                             // for example: CASFFGSE
        string BIC = Console.ReadLine();

        Console.Write("The number of Credit card 1: ");     // for example: 1270997209880604
        ulong CreditCard1 = ulong.Parse(Console.ReadLine());

        Console.Write("The number of Credit card 2: ");
        ulong CreditCard2 = ulong.Parse(Console.ReadLine());

        Console.Write("The number of Credit card 3: ");
        ulong CreditCard3 = ulong.Parse(Console.ReadLine());

        // Print the result
        Console.WriteLine();
        Console.WriteLine(@"Information about {0}
  Bank name: {1}
  BIC: {2}
  IBAN: {3}
  Money ballance: {4}
  Credit card numbers:
    Credit card 1: {5}
    Credit card 2: {6}
    Credit card 3: {7}", holderName, bankName, BIC, IBAN, balance, CreditCard1, CreditCard2, CreditCard3);
    }
}