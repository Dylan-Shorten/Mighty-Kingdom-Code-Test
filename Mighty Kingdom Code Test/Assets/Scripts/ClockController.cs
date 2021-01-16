using System;
using UnityEngine;


public class ClockController : MonoBehaviour
{
    public DateTime ClockTime => clockTime;

    public ClockMode ClockMode
    {
        get => clockMode;
        set
        {
            clockMode = value;
            ResetClock();
        }
    }

    DateTime clockTime;

    bool isTicking = default;

    [SerializeField]
    ClockMode clockMode = default;


    void Start()
    {
        ResetClock();
        StartClock();
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

        clockTime = clockMode.UpdateClockTime(clockTime);
    }

    public void StartClock()
    {
        isTicking = true;
    }

    public void StopClock()
    {
        isTicking = false;
    }

    public void ResetClock()
    {
        clockTime = clockMode.ResetClockTime();
    }
}
