using ArdalisRating.Domain;

namespace ArdalisRating.Core.Raters
{
    public class RaterFactory
    {
        public RaterBase Create(Policy policy, RatingEngine engine)
        {
            switch (policy.Type)
            {
                case PolicyType.Life:
                    return new LifePolicyRater(engine, engine.Logger);
                case PolicyType.Land:
                    return new LandPolicyRater(engine, engine.Logger);
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine, engine.Logger);
                default:
                    return new UnknownPolicyRater(engine, engine.Logger);
            }
        }
    }
}