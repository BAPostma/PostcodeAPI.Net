using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using PostcodeAPI.V2.Model;
using PostcodeAPI.V2.Wrappers;
using RestSharp;

namespace PostcodeAPI.V2
{
    public sealed class PostcodeApiClient : PostcodeApiClientBase
    {
        private const string Resource = "addresses";

        public PostcodeApiClient(string apiKey) : base(apiKey)
        {
            EndpointUrl = "https://postcode-api.apiwise.nl/v2/";
            HeaderKey = "X-Api-Key";
            InitaliseClient();
        }

        public ApiHalResultWrapper GetAddress(string postcode)
        {
            if (FindPostcodeType(postcode) != Constants.PostcodeFormatTypes.P6)
            {
                throw new ArgumentException("Postcode is not of the correct format " + Constants.PostcodeFormatTypes.P6);
            }

            return GetAddress(null, postcode, null);
        }

        public ApiHalResultWrapper GetAddress(string postcode, int number)
        {
            return GetAddress(null, postcode, number);
        }

        public ApiHalResultWrapper GetAddress(string from, string postcode, int? number)
        {
            RestRequest request = new RestRequest(Resource, Method.GET);

            if (from != null)
            {
                request.AddParameter("from", from);
            }

            if (postcode != null)
            {
                postcode = postcode.Replace(" ", string.Empty);
                request.AddParameter("postcode", postcode);
            }

            if (number != null)
            {
                request.AddParameter("number", number);
            }

            IRestResponse<ApiHalResultWrapper> result = Client.Execute<ApiHalResultWrapper>(request);
            if (result.StatusCode != HttpStatusCode.OK) HandleStatusCodeResult(result);

            var instance = JsonConvert.DeserializeObject<ApiHalResultWrapper>(result.Content);
            return instance;
        }

        /// <summary>
        /// Gets information about a single address.
        /// </summary>
        /// <param name="id">Identifier of the address. Equal to that of the governmental standard BAG.</param>
        /// <example>0268200000075156</example>
        public Address GetAddressInfo(string id)
        {
            RestRequest request = new RestRequest(Resource + "/{id}", Method.GET);
            request.AddUrlSegment("id", id);

            IRestResponse<Address> result = Client.Execute<Address>(request);
            if (result.StatusCode != HttpStatusCode.OK) HandleStatusCodeResult(result);

            var instance = JsonConvert.DeserializeObject<Address>(result.Content);
            return instance;
        }

        private void HandleStatusCodeResult(IRestResponse restResponse)
        {
            dynamic result = JsonConvert.DeserializeObject(restResponse.Content);
            string error = result.error ?? restResponse.Content;

            throw new HttpRequestException(error, restResponse.ErrorException);
        }
    }
}
