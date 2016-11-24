using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PostcodeAPI.V2.Model.Postcode
{
    public class NEN5825
    {
        [JsonProperty("streets")]
        public List<string> Streets { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", string.Join(";", Streets), Postcode);
        }
    }
}