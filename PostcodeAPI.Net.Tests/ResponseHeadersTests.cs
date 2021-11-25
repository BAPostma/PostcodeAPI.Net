using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostcodeAPI;

namespace PostcodeAPI.Tests
{
    [TestClass]
    public class ResponseHeadersTests : TestBase
    {
        [TestMethod]
        public void RequestsLimitsAreFilled()
        {
            PostcodeApiClient client = new PostcodeApiClient(ApiKey);

            Assert.IsNull(client.RequestDayLimit);
            Assert.IsNull(client.RequestsRemaining);

            client.GetAddressInfo("0268200000075156");

            Assert.IsNotNull(client.RequestDayLimit);
            Assert.IsNotNull(client.RequestsRemaining);
        }

        [TestMethod]
        public void RequestLimitsAreUpdatedAfterEachRequest()
        {
            PostcodeApiClient client = new PostcodeApiClient(ApiKey);
            client.GetAddressInfo("0268200000075156");

            int? remaining = client.RequestsRemaining;
            int? limit = client.RequestDayLimit;

            Assert.IsNotNull(remaining, "Calls remaining: {0}", remaining);
            Assert.IsNotNull(limit, "Max calls: {0}", limit);

            client.GetAddressInfo("0268200000075156");

            Assert.IsTrue(client.RequestsRemaining <= remaining, "Calls remaining (after query): {0}", client.RequestsRemaining);
            Assert.AreEqual(limit, client.RequestDayLimit);
        }
    }
}
