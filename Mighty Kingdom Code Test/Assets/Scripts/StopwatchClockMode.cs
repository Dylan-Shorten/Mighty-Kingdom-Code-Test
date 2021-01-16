using System;
using UnityEngine;


[CreateAssetMenu]
public class StopwatchClockMode : ClockMode
{
    public override DateTime UpdateClockTime(DateTime clockTime)
    {
        return clockTime.AddSeconds(Time.deltaTime);
    }

    public override DateTime ResetClockTime()
    {
        return DateTime.MinValue;
    }
}
