using System.Collections.Generic;
using System.Text.Json.Serialization;

public class ReevalResponse
{
    [JsonPropertyName("Entries")]
    public List<Entry> Entries;
}