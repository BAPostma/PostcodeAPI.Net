using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostcodeAPI.V2;
using PostcodeAPI.V2.Model;
using PostcodeAPI.V2.Wrappers;

namespace PostcodeAPI.Tests.V2
{
    [TestClass]
    //[Ignore]
    public class AddressInfoTests
    {
        private string _apiKey;

        [TestInitialize]
        public void SetUp()
        {
            _apiKey = ConfigurationManager.AppSettings.Get("ApiKeyV2");
        }

        [TestMethod]
        public void GetSingleAddress()
        {
            PostcodeApiClient client = new PostcodeApiClient(_apiKey);
            Address address = client.GetAddressInfo("0268200000075156");

            Assert.IsNotNull(address);
            Assert.IsNotNull(address.Geo.GeographicCenter);
            Assert.IsNotNull(address.Geo.GeographicExterior);
            Assert.AreEqual(1, address.Geo.GeographicExterior.WGSCoordinates.Coordinates.Count);
            Assert.AreEqual(5, address.Geo.GeographicExterior.WGSCoordinates.Coordinates[0].Count);
            Assert.AreEqual(2, address.Geo.GeographicExterior.WGSCoordinates.Coordinates[0][1].Count);
        }

        [TestMethod]
        public void GetSpecificAddress()
        {
            PostcodeApiClient client = new PostcodeApiClient(_apiKey);
            ApiHalResultWrapper result = client.GetAddress("1446WP", 106);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.AreEqual(1, result.Embedded.Addresses.Count);
            Assert.AreEqual("Component", result.Embedded.Addresses[0].Street);
            Assert.AreEqual("Purmerend", result.Embedded.Addresses[0].City.Label);
            Assert.AreEqual(1997, result.Embedded.Addresses[0].Year);
        }

        [TestMethod]
        public void GetAddressRange()
        {
            PostcodeApiClient client = new PostcodeApiClient(_apiKey);
            ApiHalResultWrapper result = client.GetAddress("1446WP");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.IsNull(result.Links.Next);
            Assert.IsTrue(result.Embedded.Addresses.Count > 1);
            Assert.AreEqual("Component", result.Embedded.Addresses[0].Street);
            Assert.AreEqual("Purmerend", result.Embedded.Addresses[0].City.Label);
        }

        [TestMethod]
        public void GetLargeAddressRange()
        {
            PostcodeApiClient client = new PostcodeApiClient(_apiKey);
            ApiHalResultWrapper result = client.GetAddress("1097JR");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Links.Self);
            Assert.IsNotNull(result.Links.Next);
            Assert.IsTrue(result.Embedded.Addresses.Count == 20);
            Assert.AreEqual("Pierre Lallementstraat", result.Embedded.Addresses[0].Street);
            Assert.AreEqual("Amsterdam", result.Embedded.Addresses[0].City.Label);

        }
    }
}
