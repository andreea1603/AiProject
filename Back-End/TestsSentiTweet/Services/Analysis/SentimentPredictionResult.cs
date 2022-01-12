using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using WebAPI.Services;
using SentiTweet.DataModels;


namespace TestsSentiTweet.Services.Analysis
{
    [TestClass]
    public class SentimentPredictionResult
    {
        public const string POSITIVE_TEXT = "I love my life.";
        public const string EXPECTED_POSITIVE_TEXT_PREDICTION = "4";

        public const string NEGATIVE_TEXT = "I hate my life.";
        public const string EXPECTED_NEGATIVE_TEXT_PREDICTION = "0";

        [TestMethod]
        public void TestPositiveTextResult()
        {
            ModelInput positiveInput = new ModelInput()
            {
                Col5 = POSITIVE_TEXT
            };
            ModelOutput result = AnalysisService.Predict(positiveInput);

            Assert.AreEqual(
                result.Prediction,
                EXPECTED_POSITIVE_TEXT_PREDICTION,
                "Wrong positive text prediciton"
                );
        }

        [TestMethod]
        public void TestNegativeTextResult()
        {
            ModelInput negativeInput = new ModelInput()
            {
                Col5 = NEGATIVE_TEXT
            };
            ModelOutput result = AnalysisService.Predict(negativeInput);

            Assert.AreEqual(
                result.Prediction,
                EXPECTED_NEGATIVE_TEXT_PREDICTION, 
                "Wrong negative text prediciton"
                );
        }
    }
}
