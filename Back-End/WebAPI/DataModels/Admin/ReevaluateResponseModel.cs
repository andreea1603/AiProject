using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI.DataModels.Admin
{
    /*
     * 1 endp pe care admin ul sa vada toate sau un numar care trebuie reevaluate,
     * GET pe "/Admin/reevaluate"
        cu response body-ul de forma
        {
           "reevaluate": [
              {
                "id": ceva_id,
                "text": ceva_text
              },
              ....
           ]
        }
    */
    public class ReevalEntry
    {
        [JsonPropertyName("Id")]
        public string Id;

        [JsonPropertyName("Text")]
        public string Text;
    }

    public class ReevalResponseModel
    {
        [JsonPropertyName("reevaluate")]
        public List<ReevalEntry> Entries;
    }
}
