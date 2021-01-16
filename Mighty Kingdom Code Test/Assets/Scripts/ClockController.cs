using System;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class ClockEvent : UnityEvent { }


public class ClockController : MonoBehaviour
{
    public DateTime ClockTime;

    public ClockMode ClockMode
    {
        get => clockMode;
        set
        {
            clockMode = value;
            ResetClock();
        }
    }

    bool isTicking = default;

    [SerializeField]
    ClockMode clockMode = default;

    [SerializeField]
    bool initiallyStarted = default;

    [SerializeField]
    UnityEvent onStart = default;

    [SerializeField]
    UnityEvent onStop = default;

    [SerializeField]
    UnityEvent onReset = default;


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

        if (ClockTime <= DateTime.MinValue || ClockTime >= DateTime.MaxValue)
        {
            StopClock();
        }
    }

    public void StartClock()
    {
        isTicking = true;
        onStart?.Invoke();
    }

    public void StopClock()
    {
        isTicking = false;
        onStop?.Invoke();
    }

    public void ResetClock()
    {
        ClockTime = clockMode.ResetClockTime();
        StopClock();
        onReset?.Invoke();
    }
}
