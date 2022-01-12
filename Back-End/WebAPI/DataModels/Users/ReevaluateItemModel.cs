using System.Text.Json.Serialization;
using WebAPI.DataModels.Admin;

namespace WebAPI.DataModels.Users
{
    /*
     * 1 endp pe care user ul sa aduge un comment in bd ca sa fie reevaluat de admin,
     * POST pe "Users/reevaluate"
        cu request body-ul de forma
        {
            "reevaluate": [
                "comment text",
                ....
            ]
        }
     */
    public class ReevaluateItemModel
    {
        [JsonPropertyName("reevaluate")]
        public string[] texts { get; set; }
    }
}
