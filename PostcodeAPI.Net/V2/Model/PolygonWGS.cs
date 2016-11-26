using System.Collections.Generic;
using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model
{
    public class PolygonWGS : WorldGeodeticSystemBase
    {
        [JsonProperty("coordinates")]
        public List<List<List<double>>> Coordinates { get; set; }

    }
}