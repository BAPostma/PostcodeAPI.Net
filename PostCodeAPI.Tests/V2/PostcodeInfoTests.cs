using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostcodeAPI.V2;
using PostcodeAPI.V2.Model;
using PostcodeAPI.V2.Wrappers.Postcode;
using Address = PostcodeAPI.V2.Model.Postcode.Address;

namespace PostCodeAPI.Tests.V2
{
    [TestClass]
    [Ignore]
    public class PostcodeInfoTests
    {
        private string _apiKey;

        [TestInitialize]
        public void SetUp()
        {
            _apiKey = ConfigurationManager.AppSettings.Get("ApiKeyV2");
        }

        [TestMethod]
        public void GetLargePostcodeSet()
        {
            PostcodeApiClient client = new PostcodeApiClient(_apiKey);
            ApiHalResultWrapper result = client.GetPostcodes("1097");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.IsNotNull(result.Links.Next);
            Assert.IsTrue(result.Embedded.Postcodes.Count == 20);
            Assert.AreEqual("Amsterdam", result.Embedded.Postcodes[0].City.Label);
        }

        [TestMethod]
        public void GetSinglePostcodeInformation()
        {
            PostcodeApiClient client = new PostcodeApiClient(_apiKey);
            Address result = client.GetPostcode("1097JR");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Streets.Count);
            Assert.AreEqual("Pierre Lallementstraat", result.Streets[0]);
            Assert.AreEqual("Amsterdam", result.City.Label);
        }
    }
}
