using System.Collections.Generic;
using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model
{
    public class RijksDriehoek
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
        [JsonProperty("crs")]
        public CRS ReferenceSystem { get; set; }
    }
}