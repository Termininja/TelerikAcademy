//Task 10: A marketing firm wants to keep record of its employees. Each record would have the following characteristics:
//first name, family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999).
//Declare the variables needed to keep the information for a single employee using appropriate data types and descriptive names.

using System;

class EmployeeRecords
{
    static void Main()
    {
        Console.Write("Please, enter the first name: ");
        string first = Console.ReadLine();
        Console.Write("Please, enter the family name: ");
        string family = Console.ReadLine();
        Console.Write("Please, enter the age: ");
        byte age = byte.Parse(Console.ReadLine());
        Console.Write("Please, enter the gender (m/f): ");
        char gender = char.Parse(Console.ReadLine());
        Console.Write("Please, enter the ID number: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Please, enter the Unique Employee Number (between 0 and 9999): ");
        ushort UEN = ushort.Parse(Console.ReadLine());
        Console.WriteLine(@"
        Personal Information:
        First Name: {0}
        Family Name: {1}
        Age: {2}
        Gender: {3}
        ID Number: {4}
        Unique Employee Number: {5}", first, family, age, gender, id, (27560000 + UEN));
    }
}