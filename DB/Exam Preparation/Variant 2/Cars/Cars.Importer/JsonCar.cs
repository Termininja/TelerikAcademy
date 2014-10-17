namespace Cars.Importer
{
    using System;
    using Newtonsoft.Json;
    using Cars.Models;

    public class JsonCar
    {
        [JsonProperty("Year")]
        public int Year { get; set; }

        [JsonProperty("TransmissionType")]
        public TransmissionType TransmissionType { get; set; }

        [JsonProperty("ManufacturerName")]
        public string ManufacturerName { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("Dealer")]
        public JsonDealer Dealer { get; set; }
    }
}