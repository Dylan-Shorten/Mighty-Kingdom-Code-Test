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
        // Ensure that the time does not go below MinValue.
        if (clockTime <= DateTime.MinValue.AddSeconds(1))
        {
            return DateTime.MinValue;
        }

        return clockTime.AddSeconds(-Time.deltaTime);
    }

    public override DateTime ResetClockTime()
    {
        return startTime.DateTime;
    }
}
