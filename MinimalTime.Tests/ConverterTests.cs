using System;

using Xunit;

namespace MinimalTime.Tests;

public class ConvertTests
{
    [Fact]
    public void From_DateTime_Utc_Not_Specified_Throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Unspecified).Time());
        Assert.Throws<ArgumentException>(() => new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Local).Time());
    }

    [Fact]
    public void From_DateTimeOffset_Offset_Not_Zero_Throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new DateTimeOffset(2022, 11, 1, 0, 0, 0, TimeSpan.FromHours(1)).Time());
    }

    [Fact]
    public void From_DateTime_Utc_Returns_Correct_Value()
    {
        var expected = new DateTime(2022, 11, 23, 6, 30, 0, 998, DateTimeKind.Utc).Time();
        expected.VerifyDateTimeOffsetByArray(2022, 11, 23, 6, 30, 0, 998);
    }

    [Fact]
    public void From_DateTimeOffset_Utc_Returns_Correct()
    {
        var expected = new DateTimeOffset(2019, 2, 4, 12, 22, 54, 998, TimeSpan.Zero).Time();

        expected.VerifyDateTimeOffsetByArray(2019, 2, 4, 12, 22, 54, 998);
    }
}