using System.Collections.Generic;
using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model
{
    /// <summary>
    /// Coordinate Reference System
    /// </summary>
    public class CRS
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("properties")]
        public Dictionary<string,string> URNs { get; set; }
    }
}