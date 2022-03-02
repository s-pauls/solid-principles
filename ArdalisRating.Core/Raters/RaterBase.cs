using ArdalisRating.Domain;
using ArdalisRating.Logging;

namespace ArdalisRating.Core.Raters
{
    public abstract class RaterBase
    {
        protected readonly RatingEngine _engine;
        protected readonly ConsoleLogger _logger;

        public RaterBase(RatingEngine engine, ConsoleLogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public abstract void Rate(Policy policy);
    }
}
