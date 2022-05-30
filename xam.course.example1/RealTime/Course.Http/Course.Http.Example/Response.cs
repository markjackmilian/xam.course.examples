using Newtonsoft.Json;

namespace Course.Http.Example;

public class RickResponse
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("species")]
    public string Species { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }

    [JsonProperty("origin")]
    public Location Origin { get; set; }

    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("image")]
    public Uri Image { get; set; }

    [JsonProperty("episode")]
    public Uri[] Episode { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("created")]
    public DateTimeOffset Created { get; set; }
}

public class Location
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}