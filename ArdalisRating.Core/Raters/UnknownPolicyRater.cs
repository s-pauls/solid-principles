using ArdalisRating.Domain;
using ArdalisRating.Logging;

namespace ArdalisRating.Core.Raters
{
    public class UnknownPolicyRater : RaterBase
    {
        public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger)
            : base(engine, logger)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Unknown policy type");
        }
    }
}
