using System.Collections.Generic;
using UnityEngine;


public class ClockModeSetter : MonoBehaviour
{
    [SerializeField]
    ClockController clockController;

    [SerializeField]
    List<ClockMode> clockModes;


    private void Start()
    {
        if (clockModes.Count > 0)
        {
            SetClockControllerMode(0);
        }
    }

    public void SetClockControllerMode(int clockModeIndex)
    {
        if (clockController == null || clockModeIndex < 0 || clockModeIndex >= clockModes.Count)
        {
            return;
        }

        clockController.ClockMode = clockModes[clockModeIndex];
    }
}