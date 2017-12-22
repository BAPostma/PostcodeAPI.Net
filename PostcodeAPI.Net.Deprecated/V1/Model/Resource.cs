namespace PostcodeAPI.V1.Model
{
    public class Resource
    {
        /// <summary>
        /// De straat die bij deze postcode hoort.
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Het huisnummer zelf, zonder eventuele toevoeging.
        /// </summary>
        public int HouseNumber { get; set; }
        /// <summary>
        /// De postcode zelf in het formaat 1234AB, dus zonder spatie.
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// De plaats die bij deze postcode hoort.
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// De gemiddelde breedtegraad van dit postcode gebied.
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// De gemiddelde lengtegraad van dit postcode gebied.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// X coördinaat van het Rijksdriehoek systeem, tot 3 cijfers achter de komma nauwkeurig.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y coördinaat van het Rijksdriehoek systeem, tot 3 cijfers achter de komma nauwkeurig.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Extra data bekend bij BAG
        /// </summary>
        public BAG BAG { get; set; }
    }
}