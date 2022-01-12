namespace WebAPI.DataModels.Admin
{
    /*
     * 1 endp prin care adminul sa adauge un sample in training set
        PATCH pe "/Admin/retrain"
        cu request body-ul
        {
            "id": id-ul,
            "text": text-ul,
            "tag": 0 sau 4
        }    
     */
    public class NewSampleModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string tag { get; set; }
    }
}
