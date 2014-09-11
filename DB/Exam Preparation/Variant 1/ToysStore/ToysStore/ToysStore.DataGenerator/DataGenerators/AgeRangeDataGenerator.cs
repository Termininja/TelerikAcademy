namespace ToysStore.DataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;

    using Logger;
    using RandomDataGenerators;
    using ToysStore.Data;

    internal class AgeRangeDataGenerator : DataGenerator
    {
        public AgeRangeDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toysStoreEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
            : base(randomDataGenerator, toysStoreEntities, countOfGeneratedObjects, consoleLogger)
        {
        }

        public override void Generate()
        {
            this.Logger.LogMessage("Adding age ranges");
            int count = 0;
            for (int i = 0; i < this.Count / 5; i++)
            {
                for (int j = i + 1; j <= i + 5; j++)
                {
                    var ageRange = new AgeRanx
                    {
                        MinimumAge = i,
                        MaximumAge = j
                    };

                    this.Database.AgeRanges.Add(ageRange);

                    count++;

                    if (count % 100 == 0)
                    {
                        this.Logger.LogMessage(".");
                        this.Database.SaveChanges();
                    }

                    if (count == this.Count)
                    {
                        this.Logger.LogMessage(" Age ranges added!\n");
                        return;
                    }
                }
            }
        }
    }
}
