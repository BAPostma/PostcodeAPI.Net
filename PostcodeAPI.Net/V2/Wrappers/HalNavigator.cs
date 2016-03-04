using Newtonsoft.Json;

namespace PostcodeAPI.V2.Wrappers
{
    public class HalNavigator
    {
        [JsonProperty("self")]
        public HalLink Self { get; set; }

        [JsonProperty("next")]
        public HalLink Next { get; set; }
    }
}
