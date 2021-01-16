using System;
using UnityEngine;


[CreateAssetMenu]
public class CountdownClockMode : ClockMode
{
    public DateTime StartTime => startTime;

    DateTime startTime = default;


    public override DateTime UpdateClockTime(DateTime clockTime)
    {
        return clockTime.AddSeconds(-Time.deltaTime);
    }

    public override DateTime ResetClockTime() => startTime;
}
