namespace Bored;

/// <summary>
/// An activity key for a BoredAPI activity
/// </summary>
public readonly struct ActivityKey
{
    /// <summary>
    /// Returns the key as an <see cref="int"/>
    /// </summary>
    public int Key { get; init; }

    private ActivityKey(int keyValue)
    {
        Key = keyValue;
    }

    /// <summary>
    /// Returns an activity key from an int value [1000000 - 9999999]
    /// </summary>
    /// <param name="keyValue"></param>
    /// <exception cref="Exception"></exception>
    public static ActivityKey FromValue(int keyValue)
    {
        return keyValue is <= 9999999 and >= 1000000
            ? new ActivityKey(keyValue)
            : throw new ArgumentOutOfRangeException(nameof(keyValue), $"{keyValue} is too {(keyValue > 9999999 ? "big" : "small")} for a key");
    }

    /// <summary>
    /// Returns the key as a <see cref="string"/>
    /// </summary>
    public override string ToString() => Key.ToString();
}