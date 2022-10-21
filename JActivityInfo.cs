namespace Bored;

using Newtonsoft.Json;

[Serializable]
internal sealed record JActivityInfo
{
    [JsonRequired]
    [JsonProperty("activity")]
    public string Activity { get; init; }

    [JsonRequired]
    [JsonProperty("type")]
    public string Type { get; init; }

    [JsonRequired]
    [JsonProperty("participants")]
    public string Participants { get; init; }

    [JsonRequired]
    [JsonProperty("price")]
    public string Price { get; init; }

    [JsonRequired]
    [JsonProperty("link")]
    public string Link { get; init; }

    [JsonRequired]
    [JsonProperty("key")]
    public string Key { get; init; }

    [JsonRequired]
    [JsonProperty("accessibility")]
    public string Accessibility { get; init; }

    [JsonConstructor]
    internal JActivityInfo(string activity, string type, string participants, string price, string link, string key, string accessibility)
    {
        Activity = activity;
        Type = type;
        Participants = participants;
        Price = price;
        Link = link;
        Key = key;
        Accessibility = accessibility;
    }
}