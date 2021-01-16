using System;


public static class DateTimeExtensions
{
    public static DateTime AddSafe(this DateTime dateTime, TimeSpan timeSpan)
    {
        if (dateTime.Ticks + timeSpan.Ticks >= DateTime.MaxValue.Ticks)
        {
            return DateTime.MaxValue;
        }
        else if (dateTime.Ticks + timeSpan.Ticks <= DateTime.MinValue.Ticks)
        {
            return DateTime.MinValue;
        }
        else
        {
            return dateTime.Add(timeSpan);
        }
    }
}