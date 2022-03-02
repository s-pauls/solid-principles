using ArdalisRating.Domain;
using System;

namespace ArdalisRating.Core.Raters
{
    public class RaterFactory
    {
        public RaterBase Create(Policy policy, RatingEngine engine)
        {
            try
            {
                return (RaterBase)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.Core.Raters.{policy.Type}PolicyRater"),
                        new object[] { engine, engine.Logger });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}