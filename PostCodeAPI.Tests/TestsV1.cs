using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostcodeAPI.V1;
using PostcodeAPI.V1.Wrappers;

namespace PostcodeAPI.Tests
{
    [TestClass]
    [Ignore] // V1 has been officially deprecated as of 2016-03-01
    public class TestsV1
    {
        private PostcodeApiClient _client;

        [TestInitialize]
        public void SetUp()
        {
            string apiKey = ConfigurationManager.AppSettings.Get("ApiKeyV1");
            _client = new PostcodeApiClient(apiKey);
        }

        [TestMethod]
        public void GetSingleAddress()
        {
            ApiResultWrapper address = _client.GetAddress("1446WP", 104);

            Assert.IsNotNull(address);
            Assert.IsNotNull(address.Resource);
            Assert.IsNotNull(address.Resource.BAG);
        }

        [TestMethod]
        public void GetAddressByFullPostcode()
        {
            ApiResultWrapper result = _client.GetAddress("1446WP");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Resource);
            Assert.AreEqual(0, result.Resource.HouseNumber);
            Assert.IsNull(result.Resource.BAG);
        }

        [TestMethod]
        public void GetAddressByPostcodeNumbers()
        {
            ApiResultWrapper result = _client.GetAddress("1446");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Resource);
            Assert.IsNull(result.Resource.Street);
            Assert.AreEqual(0, result.Resource.HouseNumber);
            Assert.IsNull(result.Resource.Postcode);
            Assert.IsNull(result.Resource.BAG);
        }
    }
}
