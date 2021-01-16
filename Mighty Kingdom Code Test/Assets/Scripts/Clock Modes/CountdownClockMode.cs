﻿using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Modes/Countdown Clock Mode")]
public class CountdownClockMode : ClockMode
{
    void OnEnable()
    {
        OnUpdate.AddListener(_ => OnUpdateClock());
    }

    void OnUpdateClock()
    {
        ClockTime = ClockTime.AddSafe(-DeltaTime);
    }
}
