using Microsoft.ML.Data;


namespace SentiTweet.DataModels
{
    public class SentimentData
    {
        [LoadColumn(5)]
        public string SentimentText { get; set; }

        [LoadColumn(0), ColumnName("Label")]
        public bool Sentiment { get; set; }

    }
}
