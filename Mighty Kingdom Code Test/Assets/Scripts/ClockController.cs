using System;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class ClockEvent : UnityEvent<DateTime> { }

[Serializable]
public class ClockFormatEvent : UnityEvent<ClockDisplayFormat> { }

[Serializable]
public class ClockModeEvent : UnityEvent<ClockMode> { }


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
                OnTick?.Invoke(clockMode.ClockTime);
            }
        }
    }
        
    public ClockMode ClockMode
    {
        get => clockMode;
        set
        {
            clockMode = value;
            onModeChanged?.Invoke(clockMode);
            RefreshClock();
        }
    }

    public ClockDisplayFormat ClockFormat
    {
        get => clockMode.ClockFormat;
        set
        {
            clockMode.ClockFormat = value;
            onFormatChanged?.Invoke(clockMode.ClockFormat);
        }
    }

    public bool IsTicking { get => clockMode.IsTicking; set => clockMode.IsTicking = value; }

    public ClockEvent OnStart => onStart;

    public ClockEvent OnTick => onTick;

    public ClockEvent OnStop => onStop;

    public ClockEvent OnReset => onReset;

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
        clockMode.UpdateClock();

        if (IsTicking)
        {
            onTick?.Invoke(ClockTime);
        }

        if (ClockTime <= DateTime.MinValue || ClockTime >= DateTime.MaxValue)
        {
            StopClock();
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
