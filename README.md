# BoredAPI
Library for the Bored API(No API Key needed)
## How to use
### Create a new instance of the BoredClient
```
var client = new BoredClient();
```
### Get a random activity from the Website
```
ActivityInfo randomActivity = await client.GetAsync();
```
### Get a specific activity from the Website
```
ActivityInfo specificActivity = await client.GetByKeyAsync(ActivityKey.FromValue(1111111));
```
### Get a random activity from the Website by a property
```
ActivityInfo randomActivity = await client.GetByTypeAsync(ActivityType.DIY);
randomActivity = await client.GetByParticipantsAsync(3);
randomActivity = await client.GetByPriceAsync(0.2);
randomActivity = await client.GetByAccessibilityAsync(0.5);
```
### Get a random activity from the Website by a property range
```
ActivityInfo randomActivity = await client.GetByPriceAsync(0.1, 0.5);
randomActivity = await client.GetByAccessibilityAsync(0.5, 0.8);
```
### Dispose the BoredClient
```
client.Dispose();
```
## Dependency Injection Support
```
private readonly IBoredClient _client;

public Program(BoredClient client)
{
    _client = client;
}
```
