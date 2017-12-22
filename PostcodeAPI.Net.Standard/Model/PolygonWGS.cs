using System.Collections.Generic;
using Newtonsoft.Json;

namespace PostcodeAPI.Model
{
    public class PolygonWGS : WorldGeodeticSystemBase
    {
        [JsonProperty("coordinates")]
        public List<List<List<double>>> Coordinates { get; set; }

    }
}