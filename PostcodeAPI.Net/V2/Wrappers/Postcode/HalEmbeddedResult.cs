using System.Collections.Generic;
using Newtonsoft.Json;
using PostcodeAPI.V2.Model.Postcode;

namespace PostcodeAPI.V2.Wrappers.Postcode
{
    public sealed class HalEmbeddedResult
    {
        [JsonProperty("postcodes")]
        public List<Address> Postcodes { get; set; }
    }
}
