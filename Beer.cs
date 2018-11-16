using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouisvileOccupationdata
{

    public class RootObject
    {
        public Beer[] Beers { get; set; }
    }

    public class Beer
    {
        [JsonProperty(PropertyName = "_")]
        public string _ { get; set; }
        [JsonProperty(PropertyName = "abv")]
        public double Abv { get; set; }
        [JsonProperty(PropertyName = "ibu")]
        public double Ibu { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string BeerName { get; set; }
        [JsonProperty(PropertyName = "style")]
        public string Style { get; set; }
        [JsonProperty(PropertyName = "brewery_id")]
        public string Brewery_id { get; set; }
        [JsonProperty(PropertyName = "ounces")]
        public double Ounces { get; set; }
    }

}