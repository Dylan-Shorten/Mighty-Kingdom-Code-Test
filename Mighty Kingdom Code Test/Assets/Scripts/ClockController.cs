using System;
using UnityEngine;


public class ClockController : MonoBehaviour
{
    public ClockDateTime ClockTime => clockTime;

    ClockDateTime clockTime = new ClockDateTime();

    bool isTicking = default;

    [SerializeField]
    ClockMode clockMode = default;


    private void Start()
    {
        StartClock();
        clockMode.ResetClockTime(ref clockTime);
    }

    void Update()
    {
        if (isTicking)
        {
            clockMode.UpdateClockTime(ref clockTime);
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
        clockMode.ResetClockTime(ref clockTime);
    }
}
