using System;
  
class NextDate
{
    static void Main()
    {
        byte day = byte.Parse(Console.ReadLine());
        byte month = byte.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        DateTime date = new DateTime(year, month, day);
        DateTime NewDate = date.AddDays(1);
        Console.WriteLine(NewDate.Day + "." + NewDate.Month + "." + NewDate.Year);
    }
}