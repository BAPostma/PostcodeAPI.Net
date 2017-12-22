namespace PostcodeAPI.V2.Model
{
    public class Municipality : IGovernmentalRegion
    {
        /// <summary>
        /// Identifier of the municipality. 
        /// Equals that of the Dutch governmental standard BAG.
        /// </summary>
        public string ID { get; set; }
        public string Label { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}