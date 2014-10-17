namespace Company.DataGenerator.DataGenerators
{
    using Logger;
    using RandomDataGenerators;
    using Company.Data;

    internal class DepartmentDataGenerator : DataGenerator
    {
        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects, consoleLogger)
        {
        }

        public override void Generate()
        {
            this.Logger.LogMessage("Adding departments");
            for (int i = 0; i < this.Count; i++)
            {
                var department = new Department
                {
                    Name = this.Random.GetRandomStringWithRandomLength(10, 50)
                };

                this.Database.Departments.Add(department);

                if (i % 100 == 0)
                {
                    this.Logger.Dot();
                    this.Database.SaveChanges();
                }
            }

            this.Logger.LogMessage(" Departments added!\n");
        }
    }
}
