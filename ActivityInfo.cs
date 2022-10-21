namespace Bored;

/// <summary>
/// Represents an activity from the BoredAPI
/// </summary>
public sealed class ActivityInfo
{
    internal static ActivityInfo Empty { get; } = new("", ActivityType.None, -1, -1, "", new(), -1);

    /// <summary>
    /// The activity description
    /// </summary>
    public string Activity { get; init; }

    /// <summary>
    /// The activity type
    /// </summary>
    public ActivityType Type { get; init; }

    /// <summary>
    /// The activity participants count
    /// </summary>
    public int Participants { get; init; }

    /// <summary>
    /// The activity price [0-1]
    /// </summary>
    public double Price { get; init; }

    /// <summary>
    /// The activity link
    /// </summary>
    public string Link { get; init; }

    /// <summary>
    /// The activity key [1000000 - 9999999]
    /// </summary>
    public ActivityKey Key { get; init; }

    /// <summary>
    /// The activity accessibility [0-1]
    /// </summary>
    public double Accessibility { get; init; }

    internal ActivityInfo(string activity, ActivityType activityType, int participants, double price, string link, ActivityKey activityKey, double accessability)
    {
        Activity = activity;
        Type = activityType;
        Participants = participants;
        Price = price;
        Link = link;
        Key = activityKey;
        Accessibility = accessability;
    }

    /// <summary>
    /// Checks if the Activity is Empty
    /// </summary>
    /// <returns>Returns <see langword="true"/> if the activity is empty, otherwise <see langword="false"/></returns>
    public bool IsEmpty() => Type == ActivityType.None;
}