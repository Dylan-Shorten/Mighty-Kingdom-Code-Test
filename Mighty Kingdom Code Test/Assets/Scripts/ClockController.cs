using System;
using UnityEngine;
using UltEvents;


[Serializable]
public class ClockEvent : UltEvent<DateTime> { }

[Serializable]
public class ClockFormatEvent : UltEvent<ClockDisplayFormat> { }

[Serializable]
public class ClockModeEvent : UltEvent<ClockMode> { }


public class ClockController : MonoBehaviour
{
    public DateTime ClockTime
    {
        get => clockMode.ClockTime;
        set
        {
            if (clockMode.ClockTime != value)
            {
                clockMode.ClockTime = value;
                onTick?.Invoke(clockMode.ClockTime);
            }
        }
    }
        
    public ClockMode ClockMode
    {
        get => clockMode;
        set
        {
            if (clockMode != value)
            {
                clockMode = value;
                onModeChanged?.Invoke(clockMode);
                RefreshClock();
            }
        }
    }

    public ClockDisplayFormat ClockFormat
    {
        get => clockMode.ClockFormat;
        set
        {
            if (clockMode.ClockFormat != value)
            {
                clockMode.ClockFormat = value;
                onFormatChanged?.Invoke(clockMode.ClockFormat);
            }
        }
    }

    public bool IsTicking { get => clockMode.IsTicking; set => clockMode.IsTicking = value; }

    public ClockEvent OnStart => onStart;

    public ClockEvent OnTick => onTick;

    public ClockEvent OnStop => onStop;

    public ClockEvent OnReset => onReset;

    public UltEvent OnFinished => onFinished;

    public ClockModeEvent OnModeChanged => onModeChanged;

    public ClockFormatEvent OnFormatChanged => onFormatChanged;

    [SerializeField]
    ClockMode clockMode = default;

    [SerializeField]
    ClockEvent onStart = default;

    [SerializeField]
    ClockEvent onTick = default;

    [SerializeField]
    ClockEvent onStop = default;

    [SerializeField]
    ClockEvent onReset = default;

    [SerializeField]
    UltEvent onFinished = default;

    [SerializeField]
    ClockModeEvent onModeChanged = default;

    [SerializeField]
    ClockFormatEvent onFormatChanged = default;


    void Start()
    {
        RefreshClock();
        ResetClock();
    }

    void Update()
    {
        DateTime initialClockTime = ClockTime;

        if (clockMode.UpdateClock())
        {
            onTick?.Invoke(ClockTime);
        }

        // Call OnFinished if the clock has reached the min or max DateTime value.
        if ((ClockTime <= DateTime.MinValue || ClockTime >= DateTime.MaxValue) && initialClockTime != ClockTime)
        {
            StopClock();
            onFinished?.Invoke();
        }
    }

    public void StartClock()
    {
        IsTicking = true;
        onStart?.Invoke(ClockTime);
    }

    public void StopClock()
    {
        IsTicking = false;
        onStop?.Invoke(ClockTime);
    }

    public void ResetClock()
    {
        clockMode.ResetClock();
        onReset?.Invoke(ClockTime);
    }

    public void RefreshClock()
    {
        if (clockMode.IsTicking)
        {
            StartClock();
        }
        else
        {
            StopClock();
        }
    }
}
