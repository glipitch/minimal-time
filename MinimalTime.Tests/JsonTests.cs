using System.Text.Json;

using Xunit;

namespace MinimalTime.Tests;

public class JsonTests
{
    public struct SomeType
    {
        public string Name { get; set; }
        public Time Time { get; set; }
    }

    [Theory]
    [MemberData(nameof(TestData.Data), MemberType = typeof(TestData))]
    public void RoundTrip(params ushort[] input)
    {
        var originalTime = new Time(input);
        var originalObject = new SomeType { Name = "A Name", Time = originalTime };
        var json = JsonSerializer.Serialize(originalObject);

        var roundTripObject = JsonSerializer.Deserialize<SomeType>(json);

        Assert.Equal(roundTripObject, originalObject);

        Assert.True(roundTripObject.Time.ToString().Length <= originalTime.ToString().Length);
    }
}