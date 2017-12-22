using Newtonsoft.Json;

namespace PostcodeAPI.Model
{
    public class Geo
    {
        [JsonProperty("center")]
        public GeographicCenter GeographicCenter { get; set; }
        /// <summary>
        /// Exterior geometric coordinates of the building.
        /// Only retrieved when a specific address' id is requested.
        /// </summary>
        [JsonProperty("exterior")]
        public GeographicExterior GeographicExterior { get; set; }
    }
}