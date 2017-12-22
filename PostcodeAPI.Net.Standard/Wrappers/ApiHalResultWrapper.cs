using Newtonsoft.Json;

namespace PostcodeAPI.Wrappers
{
    public class ApiHalResultWrapper
    {
        [JsonProperty("_embedded")]
        public HalEmbeddedResult Embedded { get; set; }

        [JsonProperty("_links")]
        public HalNavigator Links { get; set; }
    }
}