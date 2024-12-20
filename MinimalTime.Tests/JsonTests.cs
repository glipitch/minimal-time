﻿using System.Text.Json;

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
    [ClassData(typeof(TestData))]
    public void RoundTrip(ushort[] input)
    {
        var originalTime = new Time(input);
        var originalObject = new SomeType { Name = "A Name", Time = originalTime };
        var json = JsonSerializer.Serialize(originalObject);
        var roundTripObject = JsonSerializer.Deserialize<SomeType>(json);
        Assert.Equal(roundTripObject, originalObject);
        Assert.True(roundTripObject.Time.ToString().Length <= originalTime.ToString().Length);
    }
}