using Newtonsoft.Json;
using PostcodeAPI.V1.Model;

namespace PostcodeAPI.V1.Wrappers
{
    public class ApiResultWrapper
    {
        public bool Success { get; set; }
        public Error Error { get; set; }
        public Resource Resource { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
