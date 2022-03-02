using ArdalisRating.Domain;
using ArdalisRating.Logging;
using System;

namespace ArdalisRating.Core.Raters
{
    public class AutoPolicyRater : RaterBase
    {
        public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");
            if (string.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _engine.Rating = 1000m;
                }
                _engine.Rating = 900m;
            }
        }
    }
}
