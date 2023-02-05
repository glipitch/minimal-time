using Xunit;

namespace MinimalTime.Tests
{
    public class CtorTests
    {
        [Fact]
        public void Ctor_Empty_Correct()
        {
            new Time().VerifyDateTimeOffset(1, 1, 1, 0, 0, 0, 0);
        }

        [Theory]
        [MemberData(nameof(TestData.Data), MemberType = typeof(TestData))]
        public void Ctor_separate_ushorts(params ushort[] input)
        {
            var t = Helpers.NewWithMulipleParametersFromArray(input);

            t.VerifyDateTimeOffsetByArray(input);
        }
    }
}