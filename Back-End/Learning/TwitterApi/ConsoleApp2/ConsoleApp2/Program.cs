using System;
using Tweetinvi;
using System.Threading.Tasks;
using Tweetinvi.Exceptions;

namespace ConsoleApp2
{
    class pr
    {
        static async Task Main(string[] args)
        {
            var userClient = new TwitterClient("UFnTxZf4uTa4W0Wz6tYJ799Hb", "lOAFFtIp9y8wxBqzEyvKIcJdYKfzR18CCKbZOq4Vru20bfKk4k", "1454785203684130819-7hg41b1HpKnIIDKzXxJ3ZUzB0TtHww", "qXInN8pqOvMRwpayQsdSBSzKOelhll2rq6yab90JL4pfA");

            try
            {
                //dupa id-ul postarii
                var tweetResponse = await userClient.TweetsV2.GetTweetAsync(1462560443533193217);
                var tweet = tweetResponse.Tweet;
                var tweetAuthor = tweetResponse.Includes.Users[0];
                Console.WriteLine("Textul unei postari: " + tweet.Text);

                //dupa numele userului
                var userResponse = await userClient.UsersV2.GetUserByNameAsync("tweetinviapi");
                var user = userResponse.User;
                Console.WriteLine("numarul de postari: " + user.PublicMetrics.TweetCount);

                // 100 de tweet-uri dupa un anumit cuvant/hashtag
                var searchResponse = await userClient.SearchV2.SearchTweetsAsync("#hello");

                var tweets = searchResponse.Tweets;
                // informatii despre autorul primului tweet
                var userResponse1 = await userClient.UsersV2.GetUserByIdAsync(tweets[0].AuthorId);
            }
            catch (TwitterException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                // Other system exceptions like SocketException if you do not have internet
            }            //Console.WriteLine(user);
            var apiKey = "UFnTxZf4uTa4W0Wz6tYJ799Hb";
            var APISecret = "lOAFFtIp9y8wxBqzEyvKIcJdYKfzR18CCKbZOq4Vru20bfKk4k";
            var APIToken = "1454785203684130819-7hg41b1HpKnIIDKzXxJ3ZUzB0TtHww";
            var APITokenSecret = "qXInN8pqOvMRwpayQsdSBSzKOelhll2rq6yab90JL4pfA";
            //Tweetinvi.Auth.SetUserCredential(apiKey, APISecret, APIToken, APITokenSecret);
            Console.WriteLine(userClient.Users);

        }
    }
   
  
}
