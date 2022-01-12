using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using WebAPI.Controllers;
using WebAPI.Services;
using SentiTweet.DataModels;


namespace TestsSentiTweet.Controllers.Tweet
{
    [TestClass]
    public class NumberOfTweetsByHashtag
    {
        public const string HASHTAG = "covid";
        public const int EXPECTED_NUMBER_OF_CLASSIFIED_TWEETS = 100;

        [TestMethod]
        public void TestTotalNumberOfClassifiedTweetsReceived()
        {
            String[] resultOutput = getTweetsByHashtagResult();

            Assert.AreEqual(
                resultOutput.Length,
                EXPECTED_NUMBER_OF_CLASSIFIED_TWEETS,
                "Wrong number of classified tweets received."
                );
        }

        [TestMethod]
        public void TestNumberOfEveryClassOfTweets()
        {
            String[] resultOutput = getTweetsByHashtagResult();

            int numberOfNegativeTweets = Int32.Parse(resultOutput[0].Split(' ')[3]);
            int numberOfPositiveTweets = Int32.Parse(resultOutput[1].Split(' ')[3]);

            Assert.AreEqual(
                numberOfNegativeTweets + numberOfPositiveTweets,
                EXPECTED_NUMBER_OF_CLASSIFIED_TWEETS,
                "Wrong number of classified tweets received."
                );

            Assert.IsTrue(
                numberOfNegativeTweets >= 0 && numberOfNegativeTweets <= EXPECTED_NUMBER_OF_CLASSIFIED_TWEETS,
                "Wrong number of negative tweets received."
                );

            Assert.IsTrue(
                numberOfPositiveTweets >= 0 && numberOfPositiveTweets <= EXPECTED_NUMBER_OF_CLASSIFIED_TWEETS,
                "Wrong number of positive tweets received."
                );
        }

        public static String[] getTweetsByHashtagResult()
        {
            TweetController tweetController = new TweetController();
            var result = tweetController.Get(HASHTAG);
            var okObjectResult = result.Result as OkObjectResult;

            return (String[])okObjectResult.Value;
        }
    }
}
