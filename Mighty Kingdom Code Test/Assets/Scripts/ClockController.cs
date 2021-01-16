using System;
using UnityEngine;


public class ClockController : MonoBehaviour
{
    public DateTime ClockTime => clockTime;

    DateTime clockTime;

    bool isTicking = default;

    [SerializeField]
    ClockMode clockMode = default;


    private void Start()
    {
        StartClock();
        clockTime = clockMode.ResetClockTime();
    }

    void Update()
    {
        if (isTicking)
        {
            clockTime = clockMode.UpdateClockTime(clockTime);
        }
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
