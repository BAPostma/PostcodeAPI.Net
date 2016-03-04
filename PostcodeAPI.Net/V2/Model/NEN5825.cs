using System;
using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model
{
    public class NEN5825
    {
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", Street, Environment.NewLine, Postcode);
        }
    }
}