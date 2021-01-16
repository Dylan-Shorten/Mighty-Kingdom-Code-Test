using System;
using UnityEngine;


[CreateAssetMenu]
public class TimeDisplayClockMode : ClockMode
{
    public override void UpdateClockTime(ref ClockDateTime clockTime)
    {
        clockTime.DateTime = DateTime.Now;
    }

    public override void ResetClockTime(ref ClockDateTime clockTime)
    {
        clockTime.DateTime = DateTime.Now;
    }
}
