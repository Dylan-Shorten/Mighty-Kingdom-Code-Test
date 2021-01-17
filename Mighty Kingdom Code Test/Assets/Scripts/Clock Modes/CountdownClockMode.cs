using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Countdown")]
public class CountdownClockMode : ClockMode
{
    void OnEnable()
    {
        OnUpdate.DynamicCalls += _ => OnUpdateClock();
    }

    void OnUpdateClock()
    {
        ClockTime = ClockTime.AddSafe(-DeltaTime);
    }
}
