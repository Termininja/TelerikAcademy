namespace ToysStore.DataGenerator.DataGenerators
{
    using Logger;
    using RandomDataGenerators;
    using ToysStore.Data;

    internal class CategoryDataGenerator : DataGenerator
    {
        public CategoryDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toysStoreEntities, int countOfGeneratedObjects, IConsoleLogger consoleLogger)
            : base(randomDataGenerator, toysStoreEntities, countOfGeneratedObjects, consoleLogger)
        {
        }

        public override void Generate()
        {
            this.Logger.LogMessage("Adding categories");
            for (int i = 0; i < this.Count; i++)
            {
                var category = new Category
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 20)       // Change it!
                };

                this.Database.Categories.Add(category);

                if (i % 100 == 0)
                {
                    this.Logger.LogMessage(".");
                    this.Database.SaveChanges();
                }
            }

            this.Logger.LogMessage(" Categories added!\n");
        }
    }
}
