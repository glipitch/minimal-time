﻿using Xunit;

namespace MinimalTime.Tests;

public class CtorTests
{
    [Fact]
    public void Ctor_Empty_Correct()
    {
        new Time().VerifyDateTimeOffset(1, 1, 1, 0, 0, 0, 0);
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void Ctor_separate_ushorts(ushort[] input)
    {
        var t = Helpers.NewWithMultipleParametersFromArray(input);
        t.VerifyDateTimeOffsetByArray(input);
    }
}