using System;
using Newtonsoft.Json;

namespace PostcodeAPI.Wrappers
{
    public class HalLink
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }

        public override string ToString()
        {
            return Href.ToString();
        }
    }
}