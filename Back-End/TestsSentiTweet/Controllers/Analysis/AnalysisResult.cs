using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;

using WebAPI.Controllers;
using SentiTweet.DataModels;


namespace TestsSentiTweet.Controllers.Analysis
{
    [TestClass]
    public class AnalysisResult
    {
        public const string TEXT = "I am happy.";
        public const string TEXT_PREDICTION = "4";

        [TestMethod]
        public void TestGetMethodAnalysis()
        {
            ModelInput input = new ModelInput()
            {
                Col5 = TEXT
            };

            AnalysisController analysis = new AnalysisController();
            var okObjectResult = analysis.Get(input);
            string resultValue = getOkObjectValue(okObjectResult);

            Assert.AreEqual(
                resultValue,
                TEXT_PREDICTION,
                "Wrong text prediction in GET Method."
                );
        }

        [TestMethod]
        public void TestPostMethodAnalysis()
        {
            ModelInput input = new ModelInput()
            {
                Col5 = TEXT
            };

            AnalysisController analysis = new AnalysisController();
            var okObjectResult = analysis.Post(input);
            string resultValue = getOkObjectValue(okObjectResult);

            Assert.AreEqual(
                resultValue,
                TEXT_PREDICTION,
                "Wrong text prediction in Post Method."
                );
        }

        [TestMethod]
        public void TestPostMethodTweet()
        {
            ModelInput input = new ModelInput()
            {
                Col5 = TEXT
            };

            TweetController analysis = new TweetController();
            var okObjectResult = analysis.Post(input);
            string resultValue = getOkObjectValue(okObjectResult);

            Assert.AreEqual(
                resultValue,
                TEXT_PREDICTION,
                "Wrong text prediction in Post Method On Tweet Controller."
                );
        }

        [TestMethod]
        public void TestPostMethodTweetThread()
        {
            ModelInput input = new ModelInput()
            {
                Col5 = TEXT
            };

            TweetThreadController analysis = new TweetThreadController();
            var okObjectResult = analysis.Post(input);
            string resultValue = getOkObjectValue(okObjectResult);

            Assert.AreEqual(
                resultValue,
                TEXT_PREDICTION,
                "Wrong text prediction in Post Method On Tweet Controller."
                );
        }

        private static string getOkObjectValue(ActionResult<int> result)
        {
            var okObjectResult = result.Result as OkObjectResult;
            return (string)okObjectResult.Value;
        }
    }
}
