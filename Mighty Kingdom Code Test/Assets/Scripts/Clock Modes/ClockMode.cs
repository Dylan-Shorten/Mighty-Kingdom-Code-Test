using UnityEngine;


public abstract class ClockMode : ScriptableObject
{
    public abstract void UpdateClockTime(ref ClockDateTime clockTime);

    public abstract void ResetClockTime(ref ClockDateTime clockTime);
}
