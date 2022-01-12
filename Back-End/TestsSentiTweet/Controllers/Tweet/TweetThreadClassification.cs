using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using WebAPI.Services;
using WebAPI.Controllers;
using SentiTweet.DataModels;


namespace TestsSentiTweet.Controllers.Tweet
{
    [TestClass]
    public class TweetThreadClassification
    {
        public const int P = 30;
        public const string POSITIVE_PREDICTION = "4", NEGATIVE_PREDICTION = "0";
        public const string LINK = "https://twitter.com/TKlun1/status/1467583806072893446";

        [TestMethod]
        public void TestTweetsCorrectlyClassified()
        {
            TweetThreadController tweetController = new TweetThreadController();
            var result = tweetController.Get(LINK);
            var okObjectResult = result.Result as OkObjectResult;

            String[] resultOutput = (String[])okObjectResult.Value;

            for (int index = 2; index < 100; ++index)
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
