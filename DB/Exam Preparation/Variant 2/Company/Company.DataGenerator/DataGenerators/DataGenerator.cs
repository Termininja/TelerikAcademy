namespace Company.DataGenerator.DataGenerators
{
    using Logger;
    using RandomDataGenerators;
    using Company.Data;

    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;
        private IConsoleLogger logger;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
        {
            this.random = randomDataGenerator;
            this.db = companyEntities;
            this.count = countOfGeneratedObjects;
            this.logger = consoleLogger;
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected CompanyEntities Database
        {
            get { return this.db; }
        }

        protected int Count
        {
            get { return this.count; }
        }

        protected IConsoleLogger Logger
        {
            get { return this.logger; }
        }

        public abstract void Generate();
    }
}
