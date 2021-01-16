using System.Collections.Generic;
using UnityEngine;


public class ClockDisplayFormatSetter : MonoBehaviour
{
    [SerializeField]
    ClockDisplay clockDisplay;

    [SerializeField]
    List<ClockDisplayFormat> clockDisplayFormats;


    private void Start()
    {
        if (clockDisplayFormats.Count > 0)
        {
            SetClockDisplayFormat(0);
        }
    }

    public void SetClockDisplayFormat(int clockFormatIndex)
    {
        if (clockDisplay == null || clockFormatIndex < 0 || clockFormatIndex >= clockDisplayFormats.Count)
        {
            return;
        }

        clockDisplay.ClockDisplayFormat = clockDisplayFormats[clockFormatIndex];
    }
}