//Task 10: A marketing firm wants to keep record of its employees. Each record
//         would have the following characteristics: first name, family name,
//         age, gender (m or f), ID number, unique employee number (27560000 to
//         27569999). Declare the variables needed to keep the information for
//         a single employee using appropriate data types and descriptive names.

using System;

class EmployeeRecords
{
    static void Main()
    {
        // Read information for a single employee
        Console.Write("First name: ");
        string first = Console.ReadLine();

        Console.Write("Family name: ");
        string family = Console.ReadLine();

        Console.Write("Age: ");
        byte age = byte.Parse(Console.ReadLine());

        Console.Write("Gender (m/f): ");
        char gender = char.Parse(Console.ReadLine());

        Console.Write("ID number: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Unique Employee Number (0 - 9999): ");
        ushort UEN = ushort.Parse(Console.ReadLine());

        // Print the result
        Console.WriteLine(@"
  Personal Information:
  First Name: {0}
  Family Name: {1}
  Age: {2}
  Gender: {3}
  ID Number: {4}
  Unique Employee Number: {5}", first, family, age, gender, id, (27560000 + UEN));
        Console.WriteLine();
    }
}