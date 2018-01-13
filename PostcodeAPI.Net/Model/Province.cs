namespace PostcodeAPI.Model
{
    public class Province : IGovernmentalRegion
    {
        /// <summary>
        /// Identifier of the province. 
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