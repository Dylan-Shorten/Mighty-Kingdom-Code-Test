using System;


public enum EDateTimeAddType
{
    Milliseconds = 0,
    Seconds = 1,
    Minutes = 2,
    Hours = 3,
    Days = 4,
    Months = 5,
    Years = 6
}


public static class DateTimeExtensions
{
    public static DateTime Add(this DateTime dateTime, double timeToAdd, EDateTimeAddType addType)
    {
        try
        {
            switch (addType)
            {
                case EDateTimeAddType.Seconds:
                    return dateTime.AddSeconds(timeToAdd);
                case EDateTimeAddType.Minutes:
                    return dateTime.AddMinutes(timeToAdd);
                case EDateTimeAddType.Hours:
                    return dateTime.AddHours(timeToAdd);
                case EDateTimeAddType.Days:
                    return dateTime.AddDays(timeToAdd);
                case EDateTimeAddType.Months:
                    return dateTime.AddMonths((int)timeToAdd);
                case EDateTimeAddType.Years:
                    return dateTime.AddYears((int)timeToAdd);
            }
        }
        // Catch if the addition is out of bounds. Prevents error message.
        // This is done because I have not found a reasonable way of validating before adding to a DateTime.
        catch { }

        return DateTime.MinValue;
    }
}