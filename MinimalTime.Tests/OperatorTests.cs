using Xunit;

namespace MinimalTime.Tests;

public class OperatorTests
{
    [Fact]
    public void Less_Than_Correct()
    {
        var earlier = new Time(2019);
        var later = earlier with { Millisecond = (ushort)(earlier.Millisecond + 1) };
        var earlierClone = earlier with { };
        Assert.True(earlier < later);
        Assert.False(later < earlier);
        Assert.False(earlier < earlierClone);
    }

    [Fact]
    public void Greater_Than_Correct()
    {
        var earlier = new Time(2019);
        var later = earlier with { Millisecond = (ushort)(earlier.Millisecond + 1) };
        var earlierClone = earlier with { };
        Assert.False(earlier > later);
        Assert.True(later > earlier);
        Assert.False(earlier > earlierClone);
    }
}