using System.Text.RegularExpressions;
using PostcodeAPI.V1;
using RestSharp;

namespace PostcodeAPI
{
    public abstract class PostcodeApiClientBase
    {
        protected RestClient Client;

        public string EndpointUrl { get; set; }
        public string HeaderKey { get; set; }
        public string APIKey { get; set; }

        protected PostcodeApiClientBase(string apiKey)
        {
            APIKey = apiKey;
        }

        protected void InitaliseClient()
        {
            Client = new RestClient(EndpointUrl);
            Client.AddDefaultHeader(HeaderKey, APIKey);
        }

        //public abstract ApiResultWrapper GetAddress(string postcode);

        //public abstract ApiResultWrapper GetAddress(string postcode, int number);

        /// <summary>
        /// Returns the P4, P5 or P6 format detected by the input.
        /// </summary>
        public string FindPostcodeType(string postcode)
        {
            if (Regex.IsMatch(postcode, @"^[0-9]{4}[a-zA-Z]{2}$")) return Constants.PostcodeFormatTypes.P6;

            if (Regex.IsMatch(postcode, @"^[0-9]{4}[a-zA-Z]{1}$")) return Constants.PostcodeFormatTypes.P5;

            if (Regex.IsMatch(postcode, @"^[0-9]{4}$")) return Constants.PostcodeFormatTypes.P4;

            return string.Empty;
        }
    }
}