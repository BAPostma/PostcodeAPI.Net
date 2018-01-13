using Newtonsoft.Json;

namespace PostcodeAPI.Model
{
    public class GeographicExterior
    {
        [JsonProperty("wgs84")]
        public PolygonWGS WGSCoordinates { get; set; }
    }
}