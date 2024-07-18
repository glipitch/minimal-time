using Xunit;

namespace MinimalTime.Tests;

public class TestData : TheoryData<ushort[]>
{
    public TestData()
    {
        Add([1989, 1, 1]);
        Add([1919, 11, 5]);
        Add([1981, 11, 5, 2, 1, 3, 4]);
    }
}