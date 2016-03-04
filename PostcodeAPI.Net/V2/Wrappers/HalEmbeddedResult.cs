using System.Collections.Generic;
using Newtonsoft.Json;
using PostcodeAPI.V2.Model;

namespace PostcodeAPI.V2.Wrappers
{
    public sealed class HalEmbeddedResult
    {
        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }
    }
}
