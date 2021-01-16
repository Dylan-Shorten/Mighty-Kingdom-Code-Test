using System;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class ClockEvent : UnityEvent<DateTime> { }


public class ClockController : MonoBehaviour
{
    public DateTime ClockTime
    {
        get => clockTime;
        set
        {
            if (clockTime != value)
            {
                clockTime = value;
                OnTick?.Invoke(clockTime);
            }
        }
    }
        

    public ClockMode ClockMode
    {
        get => clockMode;
        set
        {
            clockMode = value;
            onModeChanged?.Invoke();
            ResetClock();
        }
    }

    public ClockEvent OnStart => onStart;

    public ClockEvent OnTick => onTick;

    public ClockEvent OnStop => onStop;

    public ClockEvent OnReset => onReset;

    public UnityEvent OnModeChanged => onModeChanged;

    [SerializeField]
    ClockMode clockMode = default;

    [SerializeField]
    bool initiallyStarted = default;

    [SerializeField]
    ClockEvent onStart = default;

    [SerializeField]
    ClockEvent onTick = default;

    [SerializeField]
    ClockEvent onStop = default;

    [SerializeField]
    ClockEvent onReset = default;

    [SerializeField]
    UnityEvent onModeChanged = default;

    DateTime clockTime = default;

    bool isTicking = default;


    void Start()
    {
        ResetClock();

        if (initiallyStarted)
        {
            StartClock();
        }
        else
        {
            StopClock();
        }
    }

    void Update()
    {
        if (!isTicking)
        {
            return;
        }

        if (clockMode == null)
        {
            return;
        }

        ClockTime = clockMode.UpdateClockTime(ClockTime);
        onTick?.Invoke(ClockTime);

        if (ClockTime <= DateTime.MinValue || ClockTime >= DateTime.MaxValue)
        {
            StopClock();
        }
    }

    public void StartClock()
    {
        isTicking = true;
        onStart?.Invoke(ClockTime);
    }

    public void StopClock()
    {
        isTicking = false;
        onStop?.Invoke(ClockTime);
    }

    public void ResetClock()
    {
        ClockTime = clockMode.ResetClockTime();
        StopClock();
        onReset?.Invoke(ClockTime);
    }
}
