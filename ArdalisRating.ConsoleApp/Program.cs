﻿using ArdalisRating.Core;
using ArdalisRating.Logging;

namespace ArdalisRating.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            logger.Log("Ardalis Insurance Rating System Starting...");

            var engine = new RatingEngine();
            engine.Rate();

            if (engine.Rating > 0)
            {
                logger.Log($"Rating: {engine.Rating}");
            }
            else
            {
                logger.Log("No rating produced.");
            }

        }
    }
}
