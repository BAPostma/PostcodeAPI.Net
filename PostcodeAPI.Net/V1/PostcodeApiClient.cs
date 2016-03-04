using System.Text.RegularExpressions;
using PostcodeAPI.V1.Wrappers;
using RestSharp;

namespace PostcodeAPI.V1
{
    public sealed class PostcodeApiClient : PostcodeApiClientBase
    {
        public PostcodeApiClient(string apiKey) : base(apiKey)
        {
            EndpointUrl = "http://api.postcodeapi.nu/";
            HeaderKey = "Api-Key";
            InitaliseClient();
        }

        public ApiResultWrapper GetAddress(string postcode)
        {
            postcode = postcode.Replace(" ", string.Empty);

            RestRequest request = new RestRequest(postcode, Method.GET);
            request.AddParameter("type", FindPostcodeType(postcode), ParameterType.QueryString);

            return Client.Execute<ApiResultWrapper>(request).Data;
        }

        public ApiResultWrapper GetAddress(string postcode, int number)
        {
            postcode = postcode.Replace(" ", string.Empty);

            RestRequest request = new RestRequest("{postcode}/{number}", Method.GET);
            request.AddParameter("view", "bag", ParameterType.QueryString);

            request.AddUrlSegment("postcode", postcode);
            request.AddUrlSegment("number", number.ToString());

            return Client.Execute<ApiResultWrapper>(request).Data;
        }
    }
}
