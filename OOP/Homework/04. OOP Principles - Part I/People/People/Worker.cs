using System;
using System.Collections.Generic;

namespace People
{
    class Worker : Human
    {
        #region Properties
        public decimal WeekSalary { get; private set; }
        public byte WorkHoursPerDay { get; private set; }
        #endregion

        #region Constructor
        public Worker(string firstName, string lastName, decimal weekSalary, byte workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        #endregion

        #region Methods
        // Returns the money earned by hour by the worker
        public decimal MoneyPerHour()
        {
            return (WeekSalary / 5) / WorkHoursPerDay;
        }

        // Print some list of workers
        public static void Print(List<Worker> list)
        {
            Console.WriteLine("┌──────────────────────┬─────────────┬────────────────────┬────────────────┐");
            Console.WriteLine("│ {0,-21}│ {1,11} │ {2,18} │ {3,14} │", "Workers", "Week Salary", "Work Hours Per Day", "Money Per Hour");
            Console.WriteLine("├──────────────────────┼─────────────┼────────────────────┼────────────────┤");
            foreach (Worker worker in list)
            {
                TableColumn("{0,-21}", worker, ConsoleColor.White);
                TableColumn("{0,11} ", "$" + worker.WeekSalary, ConsoleColor.White);
                TableColumn("{0,18} ", worker.WorkHoursPerDay, ConsoleColor.White);
                TableColumn("{0,14} ", "$" + worker.MoneyPerHour().ToString("F2"), ConsoleColor.Green);
                Console.WriteLine("│");
            }
            Console.WriteLine("└──────────────────────┴─────────────┴────────────────────┴────────────────┘");
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
        #endregion
    }
}
