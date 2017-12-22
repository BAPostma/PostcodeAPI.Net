using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using PostcodeAPI.Model;
using PostcodeAPI.Wrappers;
using RestSharp;

namespace PostcodeAPI
{
    public sealed class PostcodeApiClient : PostcodeApiClientBase
    {
        private const string ResourceAddresses = "addresses";
        private const string ResourcePostcodes = "postcodes";

        /// <summary>
        /// The number of calls that the client is allowed to make per day
        /// Value is null when no call has been made yet.
        /// </summary>
        public int? RequestDayLimit { get; private set; } = null;
        /// <summary>
        /// The remaining number of calls that the client is still allowed to make this day.
        /// Value is null when no call has been made yet.
        /// </summary>
        public int? RequestsRemaining { get; private set; } = null;

        public PostcodeApiClient(string apiKey) : base(apiKey, Constants.APIBaseUrls.V2, Constants.APIHeaderKeys.AuthKeyV2)
        {
            InitialiseClient();
        }

        public PostcodeApiClient(string apiKey, IRestClient restClient) : base(apiKey, Constants.APIBaseUrls.V1, Constants.APIHeaderKeys.AuthKeyV2)
        {
            InitialiseClient(restClient);
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
            RestRequest request = new RestRequest(ResourceAddresses, Method.GET);

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
            UpdateLimitsAfterApiCall(result);

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
            RestRequest request = new RestRequest(ResourceAddresses + "/{id}", Method.GET);
            request.AddUrlSegment("id", id);

            IRestResponse<Address> result = Client.Execute<Address>(request);
            if (result.StatusCode != HttpStatusCode.OK) HandleStatusCodeResult(result);
            UpdateLimitsAfterApiCall(result);

            var instance = JsonConvert.DeserializeObject<Address>(result.Content);
            return instance;
        }

        /// <summary>
        /// Gets all postcodes in The Netherlands, paginated per 20 records.
        /// </summary>
        /// <param name="postcodeArea">Filter on post code area in P4 format (the numbers of a postcode only)</param>
        /// <param name="from">Meant for pagination. Use the HAL links for the correct value</param>
        public ApiHalResultWrapper GetPostcodes(string postcodeArea = null, string from = null)
        {
            RestRequest request = new RestRequest(ResourcePostcodes, Method.GET);

            if (postcodeArea != null)
            {
                if (FindPostcodeType(postcodeArea) != Constants.PostcodeFormatTypes.P4)
                {
                    throw new ArgumentException("Postcode is not of the correct format " + Constants.PostcodeFormatTypes.P4);
                }
                request.AddParameter("postcodeArea", postcodeArea);
            }

            if (from != null)
            {
                request.AddParameter("from", from);
            }
            
            IRestResponse<ApiHalResultWrapper> result = Client.Execute<ApiHalResultWrapper>(request);
            if (result.StatusCode != HttpStatusCode.OK) HandleStatusCodeResult(result);
            UpdateLimitsAfterApiCall(result);

            var instance = JsonConvert.DeserializeObject<ApiHalResultWrapper>(result.Content);
            return instance;
        }

        /// <summary>
        /// Gets information about a single postcode.
        /// </summary>
        /// <param name="postcode">The postcode in P6 format (<seealso cref="Constants.PostcodeFormatTypes.P6" />)</param>
        public PostcodeArea GetPostcode(string postcode)
        {
            RestRequest request = new RestRequest(ResourcePostcodes + "/{postcode}", Method.GET);
            request.AddUrlSegment("postcode", postcode);

            if (FindPostcodeType(postcode) != Constants.PostcodeFormatTypes.P6)
            {
                throw new ArgumentException("Postcode is not of the correct format " + Constants.PostcodeFormatTypes.P6, nameof(postcode));
            }

            IRestResponse<PostcodeArea> result = Client.Execute<PostcodeArea>(request);
            if (result.StatusCode != HttpStatusCode.OK) HandleStatusCodeResult(result);
            UpdateLimitsAfterApiCall(result);

            var instance = JsonConvert.DeserializeObject<PostcodeArea>(result.Content);
            return instance;
        }

        private void HandleStatusCodeResult(IRestResponse restResponse)
        {
            dynamic result = JsonConvert.DeserializeObject(restResponse.Content);
            string error = result.error ?? restResponse.Content;

            throw new HttpRequestException(error, restResponse.ErrorException);
        }

        private void UpdateLimitsAfterApiCall(IRestResponse restResponse)
        {
            int limitValue, remainingValue;

            Parameter limit = restResponse.Headers.FirstOrDefault(h => h.Name == "X-RateLimit-Limit" && h.Type == ParameterType.HttpHeader);
            Parameter remaining = restResponse.Headers.FirstOrDefault(h => h.Name == "X-RateLimit-Remaining" && h.Type == ParameterType.HttpHeader);

            if (limit != null && int.TryParse(limit.Value.ToString(), out limitValue))
            {
                RequestDayLimit = limitValue;
            }

            if (remaining != null && int.TryParse(remaining.Value.ToString(), out remainingValue))
            {
                RequestsRemaining = remainingValue;
            }
        }
    }
}
