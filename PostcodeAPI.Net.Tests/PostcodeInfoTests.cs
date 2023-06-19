using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PostcodeAPI;
using PostcodeAPI.Model;
using PostcodeAPI.Wrappers;
using RestSharp;

namespace PostcodeAPI.Tests
{
    [TestClass]
    public class PostcodeApiClientTests : TestBase
    {
        [TestMethod]
        public void GetLargePostcodeSet()
        {
            PostcodeApiClient client = new PostcodeApiClient(ApiKey);
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
            PostcodeApiClient client = new PostcodeApiClient(ApiKey);
            PostcodeArea result = client.GetPostcode("1097JR");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Streets.Count);
            Assert.AreEqual("Pierre Lallementstraat", result.Streets[0]);
            Assert.AreEqual("Amsterdam", result.City.Label);
        }

        [TestMethod]
        public void UserAgentIsSetToLibraryNameAndVersion()
        {
            var mock = new Mock<IRestClient>();
            mock.Setup(c => c.Execute<It.IsAnyType>(It.IsAny<IRestRequest>()));

            PostcodeApiClient client = new PostcodeApiClient(ApiKey, mock.Object);
            ApiHalResultWrapper result = client.GetPostcodes("1097");

            mock.VerifySet(e => e.UserAgent = string.Format("", ""));
        }
    }
}
