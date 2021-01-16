using System;
using UnityEngine;


[CreateAssetMenu]
public class StopwatchClockMode : ClockMode
{
    [SerializeField]
    ClockDateTime startTime;


    public override void UpdateClockTime(ref ClockDateTime clockTime)
    {
        clockTime.DateTime = clockTime.DateTime.AddSeconds(Time.deltaTime);
    }

    public override void ResetClockTime(ref ClockDateTime clockTime)
    {
        clockTime = startTime;
    }
}
