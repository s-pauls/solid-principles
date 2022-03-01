using ArdalisRating.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating.Core
{
    public class JsonPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
               new StringEnumConverter());
        }
    }
}
