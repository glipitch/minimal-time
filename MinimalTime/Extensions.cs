namespace MinimalTime;

public static class Extensions
{
    public static Time FloorToDay(this Time input) => new(input.Year, input.Month, input.Day);

    public static Time Time(this DateTime input)
    {
        if (input.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException("Input must specify UTC");
        }
        return new((ushort)input.Year,
               (ushort)input.Month,
               (ushort)input.Day,
               (ushort)input.Hour,
               (ushort)input.Minute,
               (ushort)input.Second,
               (ushort)input.Millisecond);
        ;
    }

    public static Time Time(this DateTimeOffset input)
    {
        if (input.Offset != TimeSpan.Zero)
        {
            throw new ArgumentException("Input must specify UTC");
        }

        return new((ushort)input.Year,
               (ushort)input.Month,
               (ushort)input.Day,
               (ushort)input.Hour,
               (ushort)input.Minute,
               (ushort)input.Second,
               (ushort)input.Millisecond);
    }
}