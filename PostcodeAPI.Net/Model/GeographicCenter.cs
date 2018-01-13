using Newtonsoft.Json;

namespace PostcodeAPI.Model
{
    public class GeographicCenter
    {
        [JsonProperty("wgs84")]
        public PointWGS WGSCoordinates { get; set; }

        [JsonProperty("rd")]
        public RijksDriehoek RDCoordinates { get; set; }
    }
}