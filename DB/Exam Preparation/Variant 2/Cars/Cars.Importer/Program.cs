namespace Cars.Importer
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Cars.Data;
    using Cars.Models;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;

    public class Program
    {
        private static CarsDbContext db;

        public static void Main()
        {
            db = new CarsDbContext();

            JsonImporter(5);
        }

        private static void JsonImporter(int numberOfFiles)
        {
            for (int i = 0; i < numberOfFiles; i++)
            {
                IEnumerable<JsonCar> jsonCollection = ReadJSON<JsonCar>("../../../JSON/data." + i + ".json");

                foreach (var jsonCar in jsonCollection)
                {
                    var cities = new List<City>();
                    cities.Add(new City
                    {
                        Name = jsonCar.Dealer.City
                    });

                    var sqlCar = new Car
                    {
                        Year = jsonCar.Year,
                        TransmissionType = jsonCar.TransmissionType,
                        Manufacturer = new Manufacturer
                        {
                            Name = jsonCar.ManufacturerName
                        },
                        Model = jsonCar.Model,
                        Price = jsonCar.Price,
                        Dealer = new Dealer
                        {
                            Name = jsonCar.Dealer.Name,
                            Cities = cities
                        }
                    };

                    db.Cars.Add(sqlCar);
                    db.SaveChanges();
                }
            }
        }

        private static IEnumerable<T> ReadJSON<T>(string filePath)
        {
            using (StreamReader file = File.OpenText(filePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var jsonObject = JToken.ReadFrom(reader);
                var serializedObject = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                return JsonConvert.DeserializeObject<IEnumerable<T>>(serializedObject);
            }
        }
    }
}