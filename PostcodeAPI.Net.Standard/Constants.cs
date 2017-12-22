namespace PostcodeAPI
{
    public static class Constants
    {
        public static class APIBaseUrls
        {
            public const string V1 = "http://api.postcodeapi.nu/";
            public const string V2 = "https://postcode-api.apiwise.nl/v2/";
        }

        public static class APIHeaderKeys
        {
            public const string AuthKeyV1 = "Api-Key";
            public const string AuthKeyV2 = "X-Api-Key";
        }

        public static class PostcodeFormatTypes
        {
            public const string P4 = "p4";
            public const string P5 = "p5";
            public const string P6 = "p6";
        }
    }
}
