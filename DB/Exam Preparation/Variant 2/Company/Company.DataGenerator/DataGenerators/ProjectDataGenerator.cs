namespace Company.DataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;

    using Logger;
    using RandomDataGenerators;
    using Company.Data;

    internal class ProjectDataGenerator : DataGenerator
    {
        public ProjectDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects, consoleLogger)
        {
        }

        public override void Generate()
        {
            this.Logger.LogMessage("Adding projects");
            for (int i = 0; i < this.Count; i++)
            {
                DateTime startDate = RandomDay();
                DateTime endDate = startDate.AddDays(this.Random.GetRandomNumber(1, 200));

                var project = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50),
                    StartDate = startDate,
                    EndDate = endDate
                };

                this.Database.Projects.Add(project);

                if (i % 100 == 0)
                {
                    this.Logger.Dot();
                    this.Database.SaveChanges();
                }
            }

            this.Logger.LogMessage(" Projects added!\n");
        }

        internal static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            Random gen = new Random();

            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
