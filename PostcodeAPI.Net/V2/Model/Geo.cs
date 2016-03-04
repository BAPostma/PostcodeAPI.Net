using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model
{
    public class Geo
    {
        [JsonProperty("center")]
        public GeographicCenter GeographicCenter { get; set; }
    }
}