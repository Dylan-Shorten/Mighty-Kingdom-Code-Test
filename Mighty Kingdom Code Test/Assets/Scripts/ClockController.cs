using System;
using UnityEngine;


public class ClockController : MonoBehaviour
{
    public DateTime ClockTime => clockTime;

    DateTime clockTime = default;

    bool isTicking = default;

    [SerializeField]
    ClockMode clockMode = default;


    private void Start()
    {
        StartClock();
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
