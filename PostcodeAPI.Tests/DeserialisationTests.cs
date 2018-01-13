using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using PostcodeAPI.Wrappers;
using Newtonsoft.Json;

namespace PostcodeAPI.Tests
{
    [TestClass]
    public class DeserialisationTests
    {
        [TestMethod]
        public void Fix_Issue3_MultipleAddressesWhereOneOrMoreHaveNoYearThrowException()
        {
            try
            {
                ApiHalResultWrapper model = JsonConvert.DeserializeObject<ApiHalResultWrapper>(TestDataIssue3);
                Assert.IsNotNull(model);
                Assert.IsTrue(model.Embedded.Addresses[3].Year.HasValue);
                Assert.IsFalse(model.Embedded.Addresses[4].Year.HasValue);
            }
            catch(JsonException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #region Test Data
        public string TestDataIssue3 => @"{
  ""_embedded"": {
    ""addresses"": [
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195419.529, 394852.616 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9698403, 51.5411889 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 1,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000023135"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000023135/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195428.79, 394858.164 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9699745, 51.5412381 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 2,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000023136"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000023136/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195438.733, 394864.114 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9701185, 51.5412909 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 3,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000023137"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000023137/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195448.336, 394869.871 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9702576, 51.5413419 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 4,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000023138"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000023138/"" } }
      },
      {
        ""purpose"": null,
        ""postcode"": ""5804XG"",
        ""surface"": null,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195461.996, 394870.127 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9704545, 51.5413433 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 5,
        ""year"": null,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000027540"",
        ""type"": ""Standplaats"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000027540/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195497.121, 394877.649 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9709616, 51.5414083 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 6,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000022864"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000022864/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195491.914, 394867.089 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9708854, 51.5413138 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 7,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000022865"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000022865/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195486.496, 394857.348 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9708062, 51.5412266 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 8,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000022866"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000022866/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195480.206, 394847.516 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9707144, 51.5411387 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 9,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000022867"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000022867/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195473.82, 394838.648 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9706213, 51.5410595 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 10,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000022868"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000022868/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195466.813, 394829.882 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9705193, 51.5409812 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 11,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000022869"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000022869/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 95,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195459.921, 394821.141 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9704189, 51.5409031 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 12,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000022870"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000022870/"" } }
      },
      {
        ""purpose"": ""woonfunctie"",
        ""postcode"": ""5804XG"",
        ""surface"": 85,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195452.778, 394812.102 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9703149, 51.5408224 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 13,
        ""year"": 2001,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000022871"",
        ""type"": ""Verblijfsobject"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000022871/"" } }
      },
      {
        ""purpose"": null,
        ""postcode"": ""5804XG"",
        ""surface"": null,
        ""municipality"": {
          ""id"": ""0984"",
          ""label"": ""Venray""
        },
        ""city"": {
          ""id"": ""2335"",
          ""label"": ""Venray""
        },
        ""letter"": null,
        ""geo"": {
          ""center"": {
            ""rd"": {
              ""type"": ""Point"",
              ""coordinates"": [ 195433.608, 394830.676 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:EPSG::28992"" }
              }
            },
            ""wgs84"": {
              ""type"": ""Point"",
              ""coordinates"": [ 5.9700407, 51.5409907 ],
              ""crs"": {
                ""type"": ""name"",
                ""properties"": { ""name"": ""urn:ogc:def:crs:OGC:1.3:CRS84"" }
              }
            }
          }
        },
        ""nen5825"": {
          ""postcode"": ""5804 XG"",
          ""street"": ""STRUIKHEIDE""
        },
        ""addition"": null,
        ""number"": 14,
        ""year"": null,
        ""province"": {
          ""id"": ""31"",
          ""label"": ""Limburg""
        },
        ""id"": ""0984200000027541"",
        ""type"": ""Standplaats"",
        ""street"": ""Struikheide"",
        ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/0984200000027541/"" } }
      }
    ]
  },
  ""_links"": { ""self"": { ""href"": ""https://postcode-api.apiwise.nl/v2/addresses/?postcode=5804XG"" } }
}";
        #endregion
    }
}
