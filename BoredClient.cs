namespace Bored;

using Newtonsoft.Json;
using System.Globalization;

/// <summary>
/// An interface for the <see cref="BoredClient"/>
/// </summary>
public interface IBoredClient : IDisposable
{
    /// <summary>
    /// Get a random activity from the BoredAPI
    /// </summary>
    public ValueTask<ActivityInfo> GetAsync();

    /// <summary>
    /// Get an actvitiy per key [1000000 - 9999999] from the BoredAPI
    /// </summary>
    /// <param name="activityKey">The key to search by [1000000 - 9999999]</param>
    public ValueTask<ActivityInfo> GetByKeyAsync(ActivityKey activityKey);

    /// <summary>
    /// Get a random activity that has the given activity type from the BoredAPI
    /// </summary>
    /// <param name="activityType">The type to search by</param>
    public ValueTask<ActivityInfo> GetByTypeAsync(ActivityType activityType);

    /// <summary>
    /// Get a random activity with the given participants count from the BoredAPI
    /// </summary>
    /// <param name="participants">The participants count to search by</param>
    public ValueTask<ActivityInfo> GetByParticipantsAsync(int participants);

    /// <summary>
    /// Get a random activity with the given price [0-1] from the BoredAPI
    /// </summary>
    /// <param name="price">The price to search by [0-1]</param>
    public ValueTask<ActivityInfo> GetByPriceAsync(double price);

    /// <summary>
    /// Get a random activity that is in range of the given prices [0-1] from the BoredAPI
    /// </summary>
    /// <param name="minPrice">The min price to search by range [0-1]</param>
    /// <param name="maxPrice">The max price to search by range [0-1]</param>
    public ValueTask<ActivityInfo> GetByPriceAsync(double minPrice, double maxPrice);

    /// <summary>
    /// Get a random activity with the given accessibility [0-1] from the BoredAPI
    /// </summary>
    /// <param name="accessibility">The accessibility to search by [0-1]</param>
    public ValueTask<ActivityInfo> GetByAccessibilityAsync(double accessibility);

    /// <summary>
    /// Get a random activity that is in range of the given accessibilities [0-1] from the BoredAPI
    /// </summary>
    /// <param name="minAccessibility">The min accessibility to search by range [0-1]</param>
    /// <param name="maxAccessibility">The max accessibility to search by range [0-1]</param>
    public ValueTask<ActivityInfo> GetByAccessibilityAsync(double minAccessibility, double maxAccessibility);
}

/// <summary>
/// A client to get data from the BoredAPI
/// </summary>
public sealed class BoredClient : IBoredClient, IDisposable
{
    private const string BASE_URL = "http://www.boredapi.com/api";

    private HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="BoredClient"/>
    /// </summary>
    public BoredClient()
    {
        _client = new();
    }

    /// <summary>
    /// Get a random activity from the BoredAPI
    /// </summary>
    public async ValueTask<ActivityInfo> GetAsync()
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/activity");

        return DecodeJActivityInfo(json);
    }

    /// <summary>
    /// Get an actvitiy per key [1000000 - 9999999] from the BoredAPI
    /// </summary>
    /// <param name="activityKey">The key to search by [1000000 - 9999999]</param>
    public async ValueTask<ActivityInfo> GetByKeyAsync(ActivityKey activityKey)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/activity?key={activityKey.Key}");

        return DecodeJActivityInfo(json);
    }

    /// <summary>
    /// Get a random activity that has the given activity type from the BoredAPI
    /// </summary>
    /// <param name="activityType">The type to search by</param>
    public async ValueTask<ActivityInfo> GetByTypeAsync(ActivityType activityType)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/activity?type={activityType}");

        return DecodeJActivityInfo(json);
    }

    /// <summary>
    /// Get a random activity with the given participants count from the BoredAPI
    /// </summary>
    /// <param name="participants">The participants count to search by</param>
    public async ValueTask<ActivityInfo> GetByParticipantsAsync(int participants)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/activity?participants={participants}");

        return DecodeJActivityInfo(json);
    }

    /// <summary>
    /// Get a random activity with the given price [0-1] from the BoredAPI
    /// </summary>
    /// <param name="price">The price to search by [0-1]</param>
    public async ValueTask<ActivityInfo> GetByPriceAsync(double price)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/activity?price={price.ToString(CultureInfo.CreateSpecificCulture("en-US"))}");

        return DecodeJActivityInfo(json);
    }

    /// <summary>
    /// Get a random activity that is in range of the given prices [0-1] from the BoredAPI
    /// </summary>
    /// <param name="minPrice">The min price to search by range [0-1]</param>
    /// <param name="maxPrice">The max price to search by range [0-1]</param>
    public async ValueTask<ActivityInfo> GetByPriceAsync(double minPrice, double maxPrice)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/activity?minprice={minPrice.ToString(CultureInfo.CreateSpecificCulture("en-US"))}&maxprice={maxPrice.ToString(CultureInfo.CreateSpecificCulture("en-US"))}");

        return DecodeJActivityInfo(json);
    }

    /// <summary>
    /// Get a random activity with the given accessibility [0-1] from the BoredAPI
    /// </summary>
    /// <param name="accessibility">The accessibility to search by [0-1]</param>
    public async ValueTask<ActivityInfo> GetByAccessibilityAsync(double accessibility)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/activity?accessibility={accessibility.ToString(CultureInfo.CreateSpecificCulture("en-US"))}");

        return DecodeJActivityInfo(json);
    }

    /// <summary>
    /// Get a random activity that is in range of the given accessibilities [0-1] from the BoredAPI
    /// </summary>
    /// <param name="minAccessibility">The min accessibility to search by range [0-1]</param>
    /// <param name="maxAccessibility">The max accessibility to search by range [0-1]</param>
    public async ValueTask<ActivityInfo> GetByAccessibilityAsync(double minAccessibility, double maxAccessibility)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/activity?minaccessibility={minAccessibility.ToString(CultureInfo.CreateSpecificCulture("en-US"))}&maxaccessibility={maxAccessibility.ToString(CultureInfo.CreateSpecificCulture("en-US"))}");

        return DecodeJActivityInfo(json);
    }

    private static ActivityInfo DecodeJActivityInfo(string json)
    {
        if (json.StartsWith("{\"error\"")) return ActivityInfo.Empty;

        var jActivityInfo = JsonConvert.DeserializeObject<JActivityInfo>(json);

        return jActivityInfo is null
            ? throw new Exception("Something went wrong in decoding the ActivityInfo")
            : new ActivityInfo(jActivityInfo.Activity,
            ActivityType.GetFromString(jActivityInfo.Type),
            Convert.ToInt32(jActivityInfo.Participants),
            Convert.ToDouble(jActivityInfo.Price, CultureInfo.CreateSpecificCulture("en-US")),
            jActivityInfo.Link,
            ActivityKey.FromValue(Convert.ToInt32(jActivityInfo.Key)),
            Convert.ToDouble(jActivityInfo.Accessibility, CultureInfo.CreateSpecificCulture("en-US")));
    }

    /// <summary>
    /// Disposes the client
    /// </summary>
    public void Dispose()
    {
        _client.Dispose();
        GC.Collect();
        GC.SuppressFinalize(this);
    }
}