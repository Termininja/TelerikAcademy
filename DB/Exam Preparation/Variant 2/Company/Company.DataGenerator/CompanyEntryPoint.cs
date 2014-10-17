namespace Company.DataGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGenerators;
    using Logger;
    using RandomDataGenerators;
    using Company.Data;

    internal class CompanyEntryPoint
    {
        private static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            var logger = new ConsoleLogger();

            db.Configuration.AutoDetectChangesEnabled = false;                  // Speed-up the application

            var listOfGenerators = new List<IDataGenerator>() { 
                new DepartmentDataGenerator(random, db, 100, logger),           // Creates 100 departments
                new EmployeeDataGenerator(random, db, 5000, logger),            // Creates 5 000 employees
                new ProjectDataGenerator(random, db, 1000, logger),             // Creates 1 000 projects
                new ReportDataGenerator(random, db, 250000, logger),            // Creates 250 000 reports
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            AddManagers(random, db);

            db.Configuration.AutoDetectChangesEnabled = true;
        }

        private static void AddManagers(IRandomDataGenerator random, CompanyEntities db)
        {
            var employeeIDs = db.Employees.Select(c => c.ID).ToList();
            int i = 0;

            foreach (var employee in db.Employees)
            {
                if (random.GetRandomNumber(0, employeeIDs.Count - 1) < 95 * employeeIDs.Count / 100)
                {
                    var managerID = random.GetRandomNumber(1, employeeIDs.Count - 1);
                    while (managerID == i)
                    {
                        managerID = random.GetRandomNumber(1, employeeIDs.Count - 1);
                    }

                    employee.ManagerID = managerID;
                    db.SaveChanges();
                }

                i++;
            }
        }
    }
}
