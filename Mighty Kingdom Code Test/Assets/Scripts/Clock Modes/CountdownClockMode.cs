﻿using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Countdown Clock Mode")]
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
