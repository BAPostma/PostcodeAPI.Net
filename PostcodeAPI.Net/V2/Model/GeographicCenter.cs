using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model
{
    public class GeographicCenter
    {
        [JsonProperty("wgs84")]
        public PointWGS WGSCoordinates { get; set; }

        [JsonProperty("rd")]
        public RijksDriehoek RDCoordinates { get; set; }
    }
}