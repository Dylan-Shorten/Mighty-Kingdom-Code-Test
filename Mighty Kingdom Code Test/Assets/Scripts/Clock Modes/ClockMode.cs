using System;
using UnityEngine;


public abstract class ClockMode : ScriptableObject
{
    public DateTime ClockTime { get => clockTime; set => clockTime = value; }

    public DateTime InitialClockTime => initialClockTime.DateTime;

    public TimeSpan DeltaTime => DateTime.Now - PreviousTime;

    public bool IsTicking { get => isTicking; set => isTicking = value; }

    public ClockDisplayFormat ClockFormat
    {
        get => clockFormat;
        set
        {
            if (clockFormat != value)
            {
                clockFormat = value;
                OnFormatChanged?.Invoke(clockFormat);
            }
        }
    }

    public ClockModeEvent OnUpdate => onUpdate;

    public ClockModeEvent OnReset => onReset;

    public ClockFormatEvent OnFormatChanged => onFormatChanged;

    protected DateTime PreviousTime => previousTime;

    [SerializeField]
    EditableDateTime initialClockTime = default;

    [SerializeField]
    ClockDisplayFormat clockFormat = default;

    DateTime clockTime = default;

    DateTime previousTime = default;

    bool isTicking = default;

    ClockModeEvent onUpdate = new ClockModeEvent();

    ClockModeEvent onReset = new ClockModeEvent();

    ClockFormatEvent onFormatChanged = new ClockFormatEvent();


    public void SetupClock(ClockMode clockMode)
    {
        initialClockTime.DateTime = clockMode.initialClockTime.DateTime;
        ClockTime = InitialClockTime;
        ClockFormat = clockMode.ClockFormat;
        previousTime = DateTime.Now;
    }

    public void UpdateClock()
    {
        if (IsTicking)
        {
            OnUpdate?.Invoke(this);
        }

        previousTime = DateTime.Now;
    }

    public void ResetClock()
    {
        OnReset?.Invoke(this);
    }
}
