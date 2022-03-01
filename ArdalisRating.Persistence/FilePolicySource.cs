using System;
using System.IO;

namespace ArdalisRating.Persistence
{
    public class FilePolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
