using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Time Display Clock Mode")]
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
