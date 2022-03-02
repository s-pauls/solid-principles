﻿using ArdalisRating.Core.Raters;
using ArdalisRating.Logging;
using ArdalisRating.Persistence;

namespace ArdalisRating.Core
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        private FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        private JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();

        public decimal Rating { get; set; }

        public void Rate()
        { 
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource();

            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);
            rater.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
