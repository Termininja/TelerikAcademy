namespace ToysStore.DataGenerator.DataGenerators
{
    using System.Collections.Generic;

    using Logger;
    using RandomDataGenerators;
    using ToysStore.Data;

    internal class ManufacturerDataGenerator : DataGenerator
    {
        public ManufacturerDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toysStoreEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
            : base(randomDataGenerator, toysStoreEntities, countOfGeneratedObjects, consoleLogger)
        {
        }

        public override void Generate()
        {
            var manufacturerNamesToBeAdded = new HashSet<string>();                          // To be the name unique
            while (manufacturerNamesToBeAdded.Count != this.Count)
            {
                manufacturerNamesToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(5, 20));
            }

            int index = 0;
            this.Logger.LogMessage("Adding manufacturers");
            foreach (var manufacturerName in manufacturerNamesToBeAdded)
            {
                var manufacturer = new Manufacturer
                {
                    Name = manufacturerName,
                    Country = this.Random.GetRandomStringWithRandomLength(2, 50)
                };

                if (index % 100 == 0)
                {
                    this.Logger.LogMessage(".");
                    this.Database.SaveChanges();
                }

                this.Database.Manufacturers.Add(manufacturer);
                index++;
            }

            this.Logger.LogMessage(" Manufacturers added!\n");
        }
    }
}
