using Newtonsoft.Json;

namespace PostcodeAPI.Wrappers
{
    public class HalNavigator
    {
        [JsonProperty("self")]
        public HalLink Self { get; set; }

        [JsonProperty("next")]
        public HalLink Next { get; set; }
    }
}
