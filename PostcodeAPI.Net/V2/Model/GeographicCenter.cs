using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model
{
    public class GeographicCenter
    {
        [JsonProperty("wgs84")]
        public WorldGeodeticSystem WGSCoordinates { get; set; }

        [JsonProperty("rd")]
        public RijksDriehoek RDCoordinates { get; set; }
    }
}