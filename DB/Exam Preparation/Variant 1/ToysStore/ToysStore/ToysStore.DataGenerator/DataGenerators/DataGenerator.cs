namespace ToysStore.DataGenerator.DataGenerators
{
    using Logger;
    using RandomDataGenerators;
    using ToysStore.Data;

    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ToysStoreEntities db;
        private int count;
        private IConsoleLogger logger;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toysStoreEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
        {
            this.random = randomDataGenerator;
            this.db = toysStoreEntities;
            this.count = countOfGeneratedObjects;
            this.logger = consoleLogger;
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected ToysStoreEntities Database
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
