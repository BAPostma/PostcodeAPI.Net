using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model
{
    public class GeographicExterior
    {
        [JsonProperty("wgs84")]
        public PolygonWGS WGSCoordinates { get; set; }
    }
}