namespace ToysStore.DataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Logger;
    using RandomDataGenerators;
    using ToysStore.Data;

    internal class ToyDataGenerator : DataGenerator
    {
        public ToyDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toysStoreEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
            : base(randomDataGenerator, toysStoreEntities, countOfGeneratedObjects, consoleLogger)
        {
        }

        //By using the generated data from CategoryDataGenerator, ManufacturerDataGenerator and AgeRangeDataGenerator
        public override void Generate()
        {
            var ageRangeIDs = this.Database.AgeRanges.Select(a => a.ID).ToList();
            var manufacturerIDs = this.Database.Manufacturers.Select(m => m.ID).ToList();
            var categoryIDs = this.Database.Categories.Select(c => c.ID).ToList();

            this.Logger.LogMessage("Adding toys");
            for (int i = 0; i < this.Count; i++)
            {
                var toy = new Toy
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Type = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Price = this.Random.GetRandomNumber(10, 500),
                    //XXX = this.Random.GetRandomNumber(0, 100) < 65 ? 0 : 1,       //for < 65%
                    Color = this.Random.GetRandomNumber(1, 5) == 5 ? null : this.Random.GetRandomStringWithRandomLength(5, 20),
                    ManufacturerID = manufacturerIDs[this.Random.GetRandomNumber(0, manufacturerIDs.Count - 1)],
                    AgeRangeID = ageRangeIDs[this.Random.GetRandomNumber(0, ageRangeIDs.Count - 1)]
                };

                if (categoryIDs.Count > 0)
                {
                    var uniqueCategoryIDs = new HashSet<int>();
                    var categoriesInToy = this.Random.GetRandomNumber(1, Math.Min(10, categoryIDs.Count));

                    while (uniqueCategoryIDs.Count != categoriesInToy)
                    {
                        uniqueCategoryIDs.Add(categoryIDs[this.Random.GetRandomNumber(0, categoryIDs.Count - 1)]);
                    }

                    foreach (var uniqueCategoryID in uniqueCategoryIDs)
                    {
                        toy.Categories.Add(this.Database.Categories.Find(uniqueCategoryID));
                    }
                }

                if (i % 100 == 0)
                {
                    this.Logger.LogMessage(".");
                    this.Database.SaveChanges();
                }

                this.Database.Toys.Add(toy);
            }

            this.Logger.LogMessage(" Toys added!\n");
        }
    }
}
