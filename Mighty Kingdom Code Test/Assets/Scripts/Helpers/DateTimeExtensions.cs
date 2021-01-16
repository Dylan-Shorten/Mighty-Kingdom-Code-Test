using System;


public static class DateTimeExtensions
{
    public static DateTime AddSafe(this DateTime dateTime, TimeSpan timeSpan)
    {
        try
        {
            return dateTime.Add(timeSpan);
        }

        // Catch if the addition is out of bounds. Prevents error message.
        // This is done because I have not found a reasonable way of validating before adding to a DateTime.
        catch
        {
        }

        return dateTime;
    }
}