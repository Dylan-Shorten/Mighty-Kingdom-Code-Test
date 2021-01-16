using System;
using UnityEngine;


public delegate void ClockModeEvent();


public abstract class ClockMode : ScriptableObject
{
    public DateTime ClockTime = default;

    public DateTime InitialClockTime => initialClockTime.DateTime;

    public TimeSpan DeltaTime => DateTime.Now - PreviousTime;

    public bool IsTicking = default;

    public ClockModeEvent OnUpdate = default;

    public ClockModeEvent OnReset = default;

    protected DateTime PreviousTime => previousTime;

    [SerializeField]
    EditableDateTime initialClockTime = default;

    DateTime previousTime = default;


    public void SetupClock(ClockMode clockMode)
    {
        initialClockTime.DateTime = clockMode.initialClockTime.DateTime;
        ClockTime = InitialClockTime;
        previousTime = DateTime.Now;
    }

    public void UpdateClock()
    {
        if (IsTicking)
        {
            OnUpdate?.Invoke();
        }

        previousTime = DateTime.Now;
    }

    public void ResetClock()
    {
        OnReset?.Invoke();
    }
}
