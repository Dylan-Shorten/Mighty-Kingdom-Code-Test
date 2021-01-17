using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Time Display")]
public class TimeDisplayClockMode : ClockMode
{
    DateTime previousTime = default;


    void OnEnable()
    {
        previousTime = DateTime.Now;

        StartClock();

        OnUpdate.DynamicCalls += _ => OnUpdateClock();
        OnStop.DynamicCalls += _ => OnStopClock();
    }

    void OnUpdateClock()
    {
        ClockTime = ClockTime.AddSafe(DeltaTime);
        previousTime = DateTime.Now;
    }

    void OnStopClock()
    {
        // Don't ever let the TimeDisplay be stopped.
        StartClock();
    }
}
