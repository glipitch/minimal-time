using Xunit;

namespace MinimalTime.Tests;

public class TestData
{
    public static TheoryData<ushort[]> Data
    {
        get
        {
            return new TheoryData<ushort[]> {
                new ushort[] { 1989,1,1},
                new ushort[] { 1989, 11, 5 },
                new ushort[] { 1919, 11, 5 },
                new ushort[] { 1939, 11, 5 },
                new ushort[] { 1986, 11, 5 },
                new ushort[] { 1981, 11, 5 },
                new ushort[] { 1981, 11, 5,2,1,3,4 },
            };
        }
    }
}