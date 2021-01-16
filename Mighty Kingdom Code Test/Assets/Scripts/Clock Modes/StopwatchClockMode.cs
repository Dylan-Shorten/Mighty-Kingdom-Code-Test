using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Stopwatch Clock Mode")]
public class StopwatchClockMode : ClockMode
{
    public EditableDateTime StartTime => startTime;

    [SerializeField]
    EditableDateTime startTime = default;


    public override DateTime UpdateClockTime(DateTime clockTime)
    {
        // Ensure that the time does not go above MaxValue.
        if (clockTime >= DateTime.MaxValue.AddSeconds(-1))
        {
            return DateTime.MaxValue;
        }

        return clockTime.AddSeconds(Time.deltaTime);
    }

    public override DateTime ResetClockTime()
    {
        return startTime.DateTime;
    }
}
