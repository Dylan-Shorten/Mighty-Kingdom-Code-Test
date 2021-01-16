using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


[ExecuteAlways]
public class ClockDisplay : MonoBehaviour
{
    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    TMP_Text textDisplay = default;


    private void Start()
    {
        clockController.OnTick.AddListener(_ => UpdateTextDisplay());
        clockController.OnStart.AddListener(_ => UpdateTextDisplay());
        clockController.OnStop.AddListener(_ => UpdateTextDisplay());
        clockController.OnReset.AddListener(_ => UpdateTextDisplay());
        clockController.OnFormatChanged.AddListener(_ => UpdateTextDisplay());
    }

    void UpdateTextDisplay()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        textDisplay.text = clockController.ClockFormat.GetDateTimeFormatted(clockController.ClockTime);
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        if (clockController == null || clockController.ClockMode == null || clockController.ClockFormat == null)
        {
            return;
        }

        textDisplay.text = clockController.ClockFormat.Format;
    }
#endif
}
