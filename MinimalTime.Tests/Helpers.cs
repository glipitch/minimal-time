using System;

using Xunit;

namespace MinimalTime.Tests
{
    public static class Helpers
    {
        public static Time NewWithMulipleParametersFromArray(params ushort[] input) => input.Length switch
        {
            0 => new Time(),
            1 => new Time(year: input[0]),
            2 => new Time(year: input[0], input[1]),
            3 => new Time(year: input[0], input[1], input[2]),
            4 => new Time(year: input[0], input[1], input[2], input[3]),
            5 => new Time(year: input[0], input[1], input[2], input[3], input[4]),
            6 => new Time(year: input[0], input[1], input[2], input[3], input[4], input[5]),
            7 => new Time(year: input[0], input[1], input[2], input[3], input[4], input[5], input[6]),
            _ => throw new ArgumentException("Too many paramters")
        };

        public static void VerifyDateTimeOffset(this Time dateTimeOffset, int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            Assert.Equal(year, dateTimeOffset.Year);
            Assert.Equal(month, dateTimeOffset.Month);
            Assert.Equal(day, dateTimeOffset.Day);
            Assert.Equal(hour, dateTimeOffset.Hour);
            Assert.Equal(minute, dateTimeOffset.Minute);
            Assert.Equal(second, dateTimeOffset.Second);
            Assert.Equal(millisecond, dateTimeOffset.Millisecond);
        }

        public static void VerifyDateTimeOffsetByArray(this Time dateTimeOffset, params ushort[] input)
        {
            if (input.Length == 0)
            {
                throw new ApplicationException("Cannot test zero arguments");
            }
            Assert.Equal(input[0], dateTimeOffset.Year);

            if (input.Length == 1)
            {
                return;
            }
            Assert.Equal(input[1], dateTimeOffset.Month);

            if (input.Length == 2)
            {
                return;
            }
            Assert.Equal(input[2], dateTimeOffset.Day);

            if (input.Length == 3)
            {
                return;
            }
            Assert.Equal(input[3], dateTimeOffset.Hour);
            if (input.Length == 4)
            {
                return;
            }
            Assert.Equal(input[4], dateTimeOffset.Minute);
            if (input.Length == 5)
            {
                return;
            }
            Assert.Equal(input[5], dateTimeOffset.Second);
            if (input.Length == 6)
            {
                return;
            }
            Assert.Equal(input[6], dateTimeOffset.Millisecond);
        }
    }
}