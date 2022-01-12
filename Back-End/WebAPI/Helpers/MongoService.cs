using MongoDB.Driver;
using WebAPI.DataModels.Admin;
namespace WebAPI.Services
{
    public class MongoService
    {
        static private IMongoCollection<ReevalEntry> collection = null;
        static private MongoClient _client = null;
        static private MongoDB.Driver.IMongoDatabase database = null;

        static public IMongoCollection<ReevalEntry> getToReviewCollection()
        {
            if(collection == null)
            {
                var settings = MongoClientSettings.FromConnectionString("mongodb+srv://pss-package-distribution-microservice:pss-package-distribution-microservice@cluster0.z6nnl.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
                _client = new MongoClient(settings);
                database = _client.GetDatabase("twittersentiments");
                collection = database.GetCollection<ReevalEntry>("toReview");
            }
            return collection;
        }
    }
}
