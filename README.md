# PostcodeAPI.Net
A .NET library for consuming the Dutch postcodeapi.nu post code database. Uses RestSharp and Newtonsoft.Json.

This .NET library wraps access to the Dutch Post Code API.
It relies on RestSharp for request handling and Newtonsoft's JSON.NET library for deserialisation.

More information can be found on <http://www.postcodeapi.nu>. Access tokens can also be requested here.
To contribute to the specification of this API, join the guys over at their repo: <https://github.com/apiwise/postcodeapi>.

Any contributions are welcome in the form of pull-requests.

## Installation
[![NuGet](https://img.shields.io/nuget/v/PostcodeAPI.Net.svg)](https://www.nuget.org/packages/postcodeapi.net/) 

The package can be installed via NuGet: <https://www.nuget.org/packages/postcodeapi.net/> or using the package manager console:

` PM> Install-Package postcodeapi.net `

## Consuming the API using this library
Consumption is very easy after you have obtained an access key from the [PostcodeAPI website](http://www.postcodeapi.nu).

```
// Instantiate the client with your API key
PostcodeApiClient client = new PostcodeApiClient("API KEY");

// Request address or postcode details with a (specific) postcode and an optional number
ApiHalResultWrapper result1 = client.GetAddress("1234AZ", 789);
ApiHalResultWrapper result2 = client.GetPostcodes("1234");

// ...or request information on a specific postcode
PostcodeArea result = client.GetPostcode("1097JR");

// ...or request information on a specific address using it's BAG identifier
Address addressInfo = client.GetAddressInfo("0268200000075156");
```

### Working with the `ApiHalResultWrapper`
Since the API wraps its results in pages of ~20 items (HAL), the results are wrapped in a class.
You can access the items by following the `ApiHalResultWrapper.Embedded.Addresses` and respective `ApiHalResultWrapper.Embedded.Postcodes` collections.

### Checking your request limits
The API does not provide a call for requesting limits. Instead, these are passed back _after each call_.
When you've instantiated the `PostcodeApiClient` and have made a first request (e.g. for a postcode) the following properties can be consulted:
```
client.RequestDayLimit; // null or a number
client.RequestsRemaining; // null or a number
```
