using System.Collections.Generic;
using Newtonsoft.Json;
using PostcodeAPI.Model;

namespace PostcodeAPI.Wrappers
{
    public sealed class HalEmbeddedResult
    {
        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }

        [JsonProperty("postcodes")]
        public List<PostcodeArea> Postcodes { get; set; }
    }
}
