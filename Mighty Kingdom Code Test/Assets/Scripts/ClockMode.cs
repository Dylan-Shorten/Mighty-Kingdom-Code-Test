using System;
using UnityEngine;


public abstract class ClockMode : ScriptableObject
{
    public abstract DateTime UpdateClockTime(DateTime clockTime);

    public abstract DateTime ResetClockTime();
}
