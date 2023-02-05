using Xunit;

namespace MinimalTime.Tests;

public class IComparableTests
{
    [Fact]
    public void Returns_Correct()
    {
        var earlier = new Time(2019);
        var later = earlier with { Millisecond = (ushort)(earlier.Millisecond + 1) };

        Assert.Equal(-1, earlier.CompareTo(later));
        Assert.Equal(0, earlier.CompareTo(earlier));
        Assert.Equal(1, later.CompareTo(earlier));
    }
}