namespace Cars.Importer
{
    using System;
    using Newtonsoft.Json;

    public class JsonDealer
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }
    }
}
