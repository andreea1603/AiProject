using Tweetinvi;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
namespace SentiTweet.Services
{
    public class TweetService
    {
        private readonly TwitterClient userClient;
        public TweetService()
        {
           userClient = new TwitterClient("UFnTxZf4uTa4W0Wz6tYJ799Hb", "lOAFFtIp9y8wxBqzEyvKIcJdYKfzR18CCKbZOq4Vru20bfKk4k", "1454785203684130819-7hg41b1HpKnIIDKzXxJ3ZUzB0TtHww", "qXInN8pqOvMRwpayQsdSBSzKOelhll2rq6yab90JL4pfA");

        }
        public async Task<Tweetinvi.Models.V2.TweetV2[]> GetPostByHashtagAsync(string hashtag)
        {
            var searchResponse = await userClient.SearchV2.SearchTweetsAsync(hashtag);
            var tweets = searchResponse.Tweets;
            return tweets;
		}
		public String[] getRetweets(string tweets_url, int timeout_seconds = 10)
		{
			string tweet_id = tweets_url.Split('/')[^1];
#pragma warning disable S1075
			string bearer_token = "AAAAAAAAAAAAAAAAAAAAAJ65WwEAAAAAmPGFwBCISdY5mnu7IpT85777ayo%3DcmlxH78JPU0goFXZ9nUw90vsMO08fyxH01AE44aR9nJ4i2JHPQ";
			string final_url = "https://api.twitter.com/2/tweets/search/recent?query=conversation_id:" +
				tweet_id +
				"&tweet.fields=in_reply_to_user_id,author_id,created_at,conversation_id";
#pragma warning restore S1075
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(final_url);

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token);
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json")
			);
			String[] result= new string[100];
			HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
			if (response.IsSuccessStatusCode)
			{
				string responseBody = response.Content.ReadAsStringAsync().Result;

				dynamic stuff1 = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);


				for (int i = 0; i < stuff1.data.Count; i++)
				{
					result[i] = stuff1.data[i].text;
				}

			}
			else
			{
				Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
			}

			client.Dispose();
			return result;
		}
	}
}
