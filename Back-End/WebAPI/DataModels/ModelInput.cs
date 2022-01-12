using Microsoft.ML.Data;

namespace SentiTweet.DataModels
{
        public class ModelInput
        {
            [ColumnName("col0"), LoadColumn(0)]
            public string Col0 { get; set; }


            [ColumnName("col1"), LoadColumn(1)]
            public float Col1 { get; set; }


            [ColumnName("col2"), LoadColumn(2)]
            public string Col2 { get; set; }


            [ColumnName("col3"), LoadColumn(3)]
            public string Col3 { get; set; }


            [ColumnName("col4"), LoadColumn(4)]
            public string Col4 { get; set; }


            [ColumnName("col5"), LoadColumn(5)]
            public string Col5 { get; set; }


        }
    }
