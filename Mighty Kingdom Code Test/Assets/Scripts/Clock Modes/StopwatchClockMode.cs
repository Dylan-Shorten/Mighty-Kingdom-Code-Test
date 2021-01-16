using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Stopwatch Clock Mode")]
public class StopwatchClockMode : ClockMode
{
    void OnEnable()
    {
        OnUpdate.AddListener(_ => OnUpdateClock());
        OnReset.AddListener(_ => OnResetClock());
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
