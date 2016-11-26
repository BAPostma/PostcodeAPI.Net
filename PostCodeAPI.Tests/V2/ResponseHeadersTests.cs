using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostcodeAPI.V2;

namespace PostCodeAPI.Tests.V2
{
    [TestClass]
    [Ignore]
    public class ResponseHeadersTests
    {
        private string _apiKey;

        [TestInitialize]
        public void SetUp()
        {
            _apiKey = ConfigurationManager.AppSettings.Get("ApiKeyV2");
        }

        [TestMethod]
        public void RequestsLimitsAreFilled()
        {
            PostcodeApiClient client = new PostcodeApiClient(_apiKey);

            Assert.IsNull(client.RequestDayLimit);
            Assert.IsNull(client.RequestsRemaining);

            client.GetAddressInfo("0268200000075156");

            Assert.IsNotNull(client.RequestDayLimit);
            Assert.IsNotNull(client.RequestsRemaining);
        }

        [TestMethod]
        public void RequestLimitsAreUpdatedAfterEachRequest()
        {
            PostcodeApiClient client = new PostcodeApiClient(_apiKey);
            client.GetAddressInfo("0268200000075156");

            int? remaining = client.RequestsRemaining;
            int? limit = client.RequestDayLimit;

            Assert.IsNotNull(remaining, "Calls remaining: {0}", remaining);
            Assert.IsNotNull(limit, "Max calls: {0}", limit);

            client.GetAddressInfo("0268200000075156");

            Assert.IsTrue(client.RequestsRemaining < remaining, "Calls remaining (after query): {0}", client.RequestsRemaining);
            Assert.AreEqual(limit, client.RequestDayLimit);
        }
    }
}
