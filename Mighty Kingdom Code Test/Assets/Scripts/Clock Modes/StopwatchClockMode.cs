using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Stopwatch")]
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
        StopClock();
    }
}
