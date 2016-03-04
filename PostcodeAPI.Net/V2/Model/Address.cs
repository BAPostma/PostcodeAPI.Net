using Newtonsoft.Json;
using PostcodeAPI.V2.Wrappers;

namespace PostcodeAPI.V2.Model
{
    public class Address
    {
        /// <summary>
        /// Cadastral object number functioning as the identifier of the address. 
        /// Equals that of the Dutch governmental standard BAG.
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("letter")]
        public string Letter { get; set; }
        [JsonProperty("addition")]
        public string Addition { get; set; }
        /// <summary>
        /// Post code in the P6 format
        /// </summary>
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        /// <summary>
        /// Address following the NEN5825 standard
        /// </summary>
        [JsonProperty("nen5825")]
        public NEN5825 NEN5825 { get; set; }
        [JsonProperty("city")]
        public City City { get; set; }
        [JsonProperty("municipality")]
        public Municipality Municipality { get; set; }
        [JsonProperty("province")]
        public Province Province { get; set; }
        [JsonProperty("geo")]
        public Geo Geo { get; set; }
        /// <summary>
        /// Type of the building or object (in Dutch)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// The object's intended purpose (in Dutch)
        /// </summary>
        [JsonProperty("purpose")]
        public string Purpose { get; set; }
        [JsonProperty("_links")]
        public HalNavigator Links { get; set; }
    }
}