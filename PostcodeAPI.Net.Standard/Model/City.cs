namespace PostcodeAPI.Model
{
    public class City : IGovernmentalRegion
    {
        /// <summary>
        /// Identifier of the city. 
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