using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PostcodeAPI.Tests
{
    public abstract class TestBase
    {
        protected string ApiKey;

        [TestInitialize]
        public void SetUp()
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                           .AddJsonFile("appsettings.json");
            var config = configurationBuilder.Build();
            ApiKey = config["ApiKey"];
        }
    }
}
