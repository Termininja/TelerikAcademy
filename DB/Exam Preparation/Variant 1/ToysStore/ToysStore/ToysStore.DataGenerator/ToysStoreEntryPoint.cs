namespace ToysStore.DataGenerator
{
    using System.Collections.Generic;

    using DataGenerators;
    using Logger;
    using RandomDataGenerators;
    using ToysStore.Data;

    internal class ToysStoreEntryPoint
    {
        private static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new ToysStoreEntities();
            var logger = new ConsoleLogger();

            db.Configuration.AutoDetectChangesEnabled = false;              // To speed-up the application

            var listOfGenerators = new List<IDataGenerator>() { 
                new CategoryDataGenerator(random, db, 100, logger),         // Creates 100 categories
                new ManufacturerDataGenerator(random, db, 50, logger),      // Creates 50 manufacturers
                new AgeRangeDataGenerator(random, db, 100, logger),         // Creates 100 age ranges
                new ToyDataGenerator(random, db, 20000, logger)             // Creates 20 000 age ranges
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
