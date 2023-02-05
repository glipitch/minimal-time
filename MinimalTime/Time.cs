using System.Text;
using System.Text.Json.Serialization;

namespace MinimalTime;

[JsonConverter(typeof(TimeJsonConverter))]
public readonly record struct Time : IComparable<Time>
{
    public Time()
    {
        Year = Minimum.Year;
        Month = Minimum.Month;
        Day = Minimum.Day;
        Hour = Minimum.Hour;
        Minute = Minimum.Minute;
        Second = Minimum.Second;
        Millisecond = Minimum.Millisecond;
    }

    public Time(params ushort[] parts)
    {
        Year = parts[0];
        if (parts.Length == 1)
        {
            return;
        }

        Month = parts[1];
        if (parts.Length == 2)
        {
            return;
        }
        Day = parts[2];
        if (parts.Length == 3)
        {
            return;
        }
        Hour = parts[3];
        if (parts.Length == 4)
        {
            return;
        }
        Minute = parts[4];
        if (parts.Length == 5)
        {
            return;
        }
        Second = parts[5];
        if (parts.Length == 6)
        {
            return;
        }
        Millisecond = parts[6];
    }

    public Time(ushort year = Minimum.Year, ushort month = Minimum.Month, ushort day = Minimum.Day, ushort hour = Minimum.Hour, ushort minute = Minimum.Minute, ushort second = Minimum.Second, ushort millisecond = Minimum.Millisecond)
    {
        Year = year;
        Month = month;
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }
    public ushort Year { get; init; } = Minimum.Year;
    public ushort Month { get; init; } = Minimum.Month;
    public ushort Day { get; init; } = Minimum.Day;
    public ushort Hour { get; init; } = Minimum.Hour;
    public ushort Minute { get; init; } = Minimum.Minute;
    public ushort Second { get; init; } = Minimum.Second;
    public ushort Millisecond { get; init; } = Minimum.Millisecond;

    public override string ToString()
    {
        var s = new StringBuilder();
        if (Millisecond != Minimum.Millisecond)
        {
            return s.AppendJoin(' ', Year, Month, Day, Hour, Minute, Second, Millisecond).ToString();
        }
        if (Second != Minimum.Second)
        {
            return s.AppendJoin(' ', Year, Month, Day, Hour, Minute, Second).ToString();
        }
        if (Minute != Minimum.Minute)
        {
            return s.AppendJoin(' ', Year, Month, Day, Hour, Minute).ToString();
        }
        if (Hour != Minimum.Hour)
        {
            return s.AppendJoin(' ', Year, Month, Day, Hour).ToString();
        }
        if (Day != Minimum.Day)
        {
            return s.AppendJoin(' ', Year, Month, Day).ToString();
        }
        if (Month != Minimum.Month)
        {
            return s.AppendJoin(' ', Year, Month).ToString();
        }
        return Year.ToString();
    }

    public static Time Parse(string input)
    {
        var parts = input.Split(' ').Select(p => ushort.Parse(p)).ToArray();
        return new Time(parts);
    }

    public int CompareTo(Time that)
    {
        if (Year != that.Year)
        {
            return Year.CompareTo(that.Year);
        }
        if (Month != that.Month)
        {
            return Month.CompareTo(that.Month);
        }
        if (Day != that.Day)
        {
            return Day.CompareTo(that.Day);
        }
        if (Hour != that.Hour)
        {
            return Hour.CompareTo(that.Hour);
        }
        if (Minute != that.Minute)
        {
            return Minute.CompareTo(that.Minute);
        }
        if (Second != that.Second)
        {
            return Second.CompareTo(that.Second);
        }

        return Millisecond.CompareTo(that.Millisecond);
    }

    public DateTime Dt => new(Year, Month, Day, Hour, Minute, Second, Millisecond, DateTimeKind.Utc);
    public DateTimeOffset Dto => new(Year, Month, Day, Hour, Minute, Second, Millisecond, TimeSpan.Zero);

    public static TimeSpan operator -(Time a, Time b)
    {
        return a.Dto - b.Dto;
    }

    public static Time operator +(Time a, TimeSpan b)
    {
        //test
        return (a.Dto + b).Time();
    }

    public static bool operator >(Time a, Time b)
    {
        return a.CompareTo(b) == 1;
    }
    public static bool operator <(Time a, Time b)
    {
        return a.CompareTo(b) == -1;
    }

    public static Time Min => new();
    public static Time Max => DateTimeOffset.MaxValue.Time();
}