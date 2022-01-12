using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using WebAPI.Services;
using SentiTweet.DataModels;


namespace TestsSentiTweet.Services.Analysis
{
    [TestClass]
    public class SentimentPredictionScore
    {
        public const string TEXT = "It's nice to write tests at 2 in the morning.";

        [TestMethod]
        public void TestTextScore()
        {
            ModelInput input = new ModelInput()
            {
                Col5 = TEXT
            };
            float[] result = AnalysisService.SentimentPredictionProbability(input);
            float score = result[1];

            Assert.IsTrue(
                score >= 0.5 && score <= 1,
                "Wrong score obtained."
                );
        }
    }
}
