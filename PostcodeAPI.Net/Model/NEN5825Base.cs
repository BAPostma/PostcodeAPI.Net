using Newtonsoft.Json;

namespace PostcodeAPI.Model
{
    public abstract class NEN5825Base
    {
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        public override string ToString()
        {
            return Postcode;
        }

    }
}