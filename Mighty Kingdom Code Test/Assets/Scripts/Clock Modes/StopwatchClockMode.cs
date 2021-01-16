using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Stopwatch Clock Mode")]
public class StopwatchClockMode : ClockMode
{
    void OnEnable()
    {
        OnUpdate.DynamicCalls += _ => OnUpdateClock();
        OnReset.DynamicCalls += _ => OnResetClock();
    }

    void OnUpdateClock()
    {
        ClockTime = ClockTime.AddSafe(DeltaTime);
    }

    void OnResetClock()
    {
        ClockTime = InitialClockTime;
    }
}
