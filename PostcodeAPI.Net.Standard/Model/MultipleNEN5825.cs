using System.Collections.Generic;
using Newtonsoft.Json;

namespace PostcodeAPI.Model
{
    public class MultipleNEN5825 : NEN5825Base
    {
        [JsonProperty("streets")]
        public List<string> Streets { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", string.Join(";", Streets), Postcode);
        }
    }
}