using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using WebAPI.Services;
using SentiTweet.DataModels;


namespace TestsSentiTweet.Controllers.Tweet
{
    [TestClass]
    public class ClassificationOfTweetsByHashtag
    {
        public const int P = 30;
        public const string POSITIVE_PREDICTION = "4", NEGATIVE_PREDICTION = "0";

        [TestMethod]
        public void TestTweetsCorrectlyClassified()
        {
            String[] resultOutput = NumberOfTweetsByHashtag.getTweetsByHashtagResult();
            
            for(int index = 2; index < 100; ++index)
            {
                if (resultOutput[index] != null)
                {
                    ModelInput input = new ModelInput()
                    {
                        Col5 = resultOutput[index]
                    };

                    Assert.AreEqual(
                        AnalysisService.Predict(input).Prediction,
                        index <= P ? NEGATIVE_PREDICTION : POSITIVE_PREDICTION,
                        $"Tweet wrong classified."
                        );
                }
            }
        }
    }
}
