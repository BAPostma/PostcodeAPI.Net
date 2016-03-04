using System.ComponentModel;

namespace PostcodeAPI.V1.Model
{
    /// <summary>
    /// Basisregistraties van het ministerie van Infrastructuur en Milieu
    /// </summary>
    public class BAG
    {
        /// <summary>
        /// Uniek adres-identificatienummer
        /// </summary>
        [Description("Kadastraal objectnummer")]
        public string ID { get; set; }
        /// <summary>
        /// Addresseerbaar object type
        /// </summary>
        [Description("Addresseerbaar object type")]
        public string Type { get; set; }
        /// <summary>
        /// Gebruiksdoel verblijfsobject
        /// </summary>
        [Description("Gebruiksdoel verblijfsobject")]
        public string Purpose { get; set; }
    }
}