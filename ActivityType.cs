namespace Bored;

/// <summary>
/// An activity type for a BoredAPI activity
/// </summary>
public sealed class ActivityType
{
    internal string Name { get; init; }

    private ActivityType(string name)
    {
        Name = name;
    }

    internal static ActivityType GetFromString(string activityTypeStr)
    {
        ActivityType[] activityTypes = new ActivityType[]
        {
            Busywork,
            Charity,
            Cooking,
            DIY,
            Education,
            Music,
            Recreational,
            Relaxation,
            Social
        };

        var activityType = activityTypes.FirstOrDefault(x => x?.Name == activityTypeStr, null);

        return activityType is null ? throw new Exception("Can't find that activity type") : activityType;
    }

    internal static ActivityType None { get; } = new("");

    /// <summary>
    /// Returns the Busywork activity type
    /// </summary>
    public static ActivityType Busywork { get; } = new("busywork");

    /// <summary>
    /// Returns the Charity activity type
    /// </summary>
    public static ActivityType Charity { get; } = new("charity");

    /// <summary>
    /// Returns the Cooking activity type
    /// </summary>
    public static ActivityType Cooking { get; } = new("cooking");

    /// <summary>
    /// Returns the DIY activity type
    /// </summary>
    public static ActivityType DIY { get; } = new("diy");

    /// <summary>
    /// Returns the Education activity type
    /// </summary>
    public static ActivityType Education { get; } = new("education");

    /// <summary>
    /// Returns the Music activity type
    /// </summary>
    public static ActivityType Music { get; } = new("music");

    /// <summary>
    /// Returns the Recreational activity type
    /// </summary>
    public static ActivityType Recreational { get; } = new("recreational");

    /// <summary>
    /// Returns the Relaxation activity type
    /// </summary>
    public static ActivityType Relaxation { get; } = new("relaxation");

    /// <summary>
    /// Returns the Social activity type
    /// </summary>
    public static ActivityType Social { get; } = new("social");

    /// <summary>
    /// Returns the activity type as a <see cref="string"/>
    /// </summary>
    public override string ToString() => Name;
}