using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Time Display Clock Mode")]
public class TimeDisplayClockMode : ClockMode
{
    DateTime previousTime = default;


    void OnEnable()
    {
        previousTime = DateTime.Now;
        IsTicking = true;

        OnUpdate.AddListener(_ => OnUpdateClock());
    }

    void OnUpdateClock()
    {
        ClockTime = ClockTime.AddSafe(DeltaTime);
        previousTime = DateTime.Now;
    }
}
