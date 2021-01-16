using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Countdown Clock Mode")]
public class CountdownClockMode : ClockMode
{
    public EditableDateTime StartTime => startTime;

    [SerializeField]
    EditableDateTime startTime = default;


    public override DateTime UpdateClockTime(DateTime clockTime)
    {
        return clockTime.Add(-Time.deltaTime, EDateTimeAddType.Seconds);
    }

    public override DateTime ResetClockTime()
    {
        return startTime.DateTime;
    }
}
