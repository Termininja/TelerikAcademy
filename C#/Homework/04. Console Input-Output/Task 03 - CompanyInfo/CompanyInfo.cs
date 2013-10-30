//Task 3: A company has name, address, phone number, fax number, web site and manager.
//        The manager has first name, last name, age and a phone number.
//        Write a program that reads the information about a company and its manager and prints them on the console.

using System;

class CompanyInfo
{
    static void Main()
    {
        while (true)
        {
            /* Table */
            Console.WriteLine(@"
   Information     │ Read                  │ Print
  ─────────────────┼───────────────────────┼───────────────────────
   Company         │                       │
    Name:          │                       │
    Adress:        │                       │
    Phone number:  │                       │
    Fax number:    │                       │
    Web site:      │                       │
  ─────────────────┼───────────────────────┼───────────────────────
   Manager         │                       │
    First name:    │                       │
    Last name:     │                       │
    Age:           │                       │
    Phone number:  │                       │");

            try
            {
                string str;
                Console.CursorTop = 4;                                
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.CursorLeft = 21;                              
                string CompanyName = Console.ReadLine();                                // read a company name

                Console.CursorLeft = 21;
                string CompanyAdress = Console.ReadLine();                               // read a company address

                Console.CursorLeft = 21;
                str = Console.ReadLine();                                               // read a company phone number
                ulong CompanyPhone = ulong.Parse(str);                                  // extract the number from the string
                byte count1 = 0;
                foreach (char a in str)                                                 // count a digits in the phone number
                {
                    if (char.IsDigit(a))
                    {
                        count1++;
                    }
                }

                Console.CursorLeft = 21;
                str = Console.ReadLine();                                               // read a company fax number
                ulong CompanyFax = ulong.Parse(str);                                    // extract the number from the string
                byte count2 = 0;
                foreach (char a in str)                                                 // count a digits in the fax number
                {
                    if (char.IsDigit(a))
                    {
                        count2++;
                    }
                }

                Console.CursorLeft = 21;
                string WebSite = Console.ReadLine();                                    // read the name of web site

                Console.WriteLine("\n");

                Console.CursorLeft = 21;
                string FirstName = Console.ReadLine();                                  // read the manager's first name

                Console.CursorLeft = 21;
                string LastName = Console.ReadLine();                                   // read the manager's last name

                Console.CursorLeft = 21;
                str = Console.ReadLine();                                               // read the manager's age
                byte Age = byte.Parse(str);                                             // extract the age from the string

                Console.CursorLeft = 21;
                str = Console.ReadLine();                                               // read a manager's phone number
                ulong ManagerPhone = ulong.Parse(str);                                  // extract the manager's phone number from the string
                byte count3 = 0;
                foreach (char a in str)                                                 // count a digits in the manager's phone number
                {
                    if (char.IsDigit(a))
                    {
                        count3++;
                    }
                }

                Console.ResetColor();
                Console.Write("\nPress any key to print the result. . .");
                Console.ReadKey();                                                      // we have to press any key to continue

                /* Print the results */
                Console.CursorTop = 4;
                Console.CursorLeft = 57;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = 45;
                Console.WriteLine(CompanyName);
                Console.CursorLeft = 45;
                Console.WriteLine(CompanyAdress);
                Console.CursorLeft = 45;
                Console.WriteLine(CompanyPhone.ToString().PadLeft(count1, '0'));
                Console.CursorLeft = 45;
                Console.WriteLine(CompanyFax.ToString().PadLeft(count2, '0'));
                Console.CursorLeft = 45;
                Console.WriteLine(WebSite);
                Console.WriteLine("\n");
                Console.CursorLeft = 45;
                Console.WriteLine(FirstName);
                Console.CursorLeft = 45;
                Console.WriteLine(LastName);
                Console.CursorLeft = 45;
                Console.WriteLine(Age);
                Console.CursorLeft = 45;
                Console.WriteLine(ManagerPhone.ToString().PadLeft(count3, '0'));
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\n\nPress Enter to continue, or X to exit . . .");
            key:
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.X)                                            // you will exit if you press "X"
                {
                    break;
                }
                else if (key.Key != ConsoleKey.Enter)                                   // you will continue only when you press "Enter"
                {
                    Console.Write("\b \b");                                             // clear the wrong keys from the console
                    goto key;
                }
                Console.ResetColor();
                Console.Clear();
            }
            catch (Exception)                                                           // this rows below will be executed if there are some errors
            {
                Console.CursorTop = 17;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Something's wrong!");                                    // this message will be shown when there is some error
                Console.ReadKey();                                                      // you will continue if you press any Key
                Console.Clear();
                Console.ResetColor();
            }
        }
    }
}