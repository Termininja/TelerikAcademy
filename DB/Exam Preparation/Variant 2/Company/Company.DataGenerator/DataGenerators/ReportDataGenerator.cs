namespace Company.DataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Logger;
    using RandomDataGenerators;
    using Company.Data;

    internal class ReportDataGenerator : DataGenerator
    {
        public ReportDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects, consoleLogger)
        {
        }

        public override void Generate()
        {
            var employeeIDs = this.Database.Employees.Select(c => c.ID).ToList();

            this.Logger.LogMessage("Adding reports");
            for (int i = 0; i < this.Count; i++)
            {
                var report = new Report
                {
                    Content = this.Random.GetRandomStringWithRandomLength(10, 100),
                    Date = ProjectDataGenerator.RandomDay(),
                    EmployeeID = employeeIDs[this.Random.GetRandomNumber(0, employeeIDs.Count - 1)]
                };

                this.Database.Reports.Add(report);

                if (i % 100 == 0)
                {
                    this.Logger.Dot();
                    this.Database.SaveChanges();
                }
            }

            this.Logger.LogMessage(" Reports added!\n");
        }
    }
}
