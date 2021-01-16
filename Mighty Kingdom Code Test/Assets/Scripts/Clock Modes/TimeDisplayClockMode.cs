using System;
using UnityEngine;


[CreateAssetMenu]
public class TimeDisplayClockMode : ClockMode
{
    public override DateTime UpdateClockTime(DateTime clockTime)
    {
        return DateTime.Now;
    }

    public override DateTime ResetClockTime()
    {
        return DateTime.Now;
    }
}
