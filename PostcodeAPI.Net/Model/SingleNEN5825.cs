using System;
using Newtonsoft.Json;

namespace PostcodeAPI.Model
{
    public class SingleNEN5825 : NEN5825Base
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", Street, Environment.NewLine, Postcode);
        }
    }
}