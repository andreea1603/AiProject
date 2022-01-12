using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using SentiTweet.Services;


namespace TestsSentiTweet.Services.Tweet
{
    [TestClass]
    public class TweetsByHashtag
    {
        public const string HASHTAG = "covid";
        public const int NUMBER_OF_TWEETS_RECEIVED = 100;

        [TestMethod]
        public void TestNumberOfTweetsReceived()
        {
            TweetService client = new TweetService();
            var result = client.GetPostByHashtagAsync(HASHTAG);

            Assert.AreEqual(
                result.Result.Length,
                NUMBER_OF_TWEETS_RECEIVED,
                "Wrong number of tweets received."
                );
        }

        [TestMethod]
        public void TestTypeOfTweetTextResult()
        {
            TweetService client = new TweetService();
            var result = client.GetPostByHashtagAsync(HASHTAG);

            foreach (var tweetResult in result.Result)
            {
                Assert.IsInstanceOfType(
                    tweetResult.Text,
                    typeof(String),
                    "Text result of tweets is not a String."
                    );
            }
        }
    }
}
