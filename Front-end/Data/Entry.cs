using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

public class Entry
{
    [JsonPropertyName("_id")]
    [BsonId]
    public string Id;

    [JsonPropertyName("Text")]
    [BsonElement("Text")]
    public string Text;
}