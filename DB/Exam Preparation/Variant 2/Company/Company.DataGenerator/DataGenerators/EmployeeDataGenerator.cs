namespace Company.DataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Logger;
    using RandomDataGenerators;
    using Company.Data;

    internal class EmployeeDataGenerator : DataGenerator
    {
        public EmployeeDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects, consoleLogger)
        {
        }

        public override void Generate()
        {
            var departmentIDs = this.Database.Departments.Select(c => c.ID).ToList();

            this.Logger.LogMessage("Adding employees");
            for (int i = 0; i < this.Count; i++)
            {
                var employee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    DepartmentID = departmentIDs[this.Random.GetRandomNumber(0, departmentIDs.Count - 1)],
                    Salary = this.Random.GetRandomNumber(50000, 200000),
                };

                if (i % 100 == 0)
                {
                    this.Logger.Dot();
                    this.Database.SaveChanges();
                }

                this.Database.Employees.Add(employee);
            }

            this.Logger.LogMessage(" Employees added!\n");
        }
    }
}
