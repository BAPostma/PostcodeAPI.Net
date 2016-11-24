using System.Collections.Generic;
using Newtonsoft.Json;
using PostcodeAPI.V2.Wrappers;

namespace PostcodeAPI.V2.Model.Postcode
{
    public class Address
    {
        /// <summary>
        /// Post code in the P6 format
        /// </summary>
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("city")]
        public City City { get; set; }
        [JsonProperty("municipality")]
        public Municipality Municipality { get; set; }
        [JsonProperty("province")]
        public Province Province { get; set; }
        [JsonProperty("streets")]
        public List<string> Streets { get; set; }
        /// <summary>
        /// Streets following the NEN5825 standard
        /// </summary>
        [JsonProperty("nen5825")]
        public NEN5825 NEN5825 { get; set; }
        [JsonProperty("distance")]
        public double Distance { get; set; }
        [JsonProperty("geo")]
        public Geo Geo { get; set; }
        [JsonProperty("_links")]
        public HalNavigator Links { get; set; }
    }
}