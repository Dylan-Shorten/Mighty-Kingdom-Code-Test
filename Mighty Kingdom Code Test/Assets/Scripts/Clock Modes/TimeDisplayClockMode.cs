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

        OnUpdate += OnUpdateClock;
    }

    void OnUpdateClock()
    {
        ClockTime = ClockTime.AddSafe(DeltaTime);
        previousTime = DateTime.Now;
    }
}
