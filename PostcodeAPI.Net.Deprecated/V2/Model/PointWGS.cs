using System.Collections.Generic;
using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model
{
    public class PointWGS : WorldGeodeticSystemBase
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

    }
}