using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[Serializable]
public class ClockFormatEvent : UnityEvent<ClockDisplayFormat> { }

[ExecuteAlways]
public class ClockDisplay : MonoBehaviour
{
    public ClockDisplayFormat ClockDisplayFormat
    {
        get => clockDisplayFormat;
        set
        {
            if (value != clockDisplayFormat)
            {
                clockDisplayFormat = value;
                onFormatChanged?.Invoke(clockDisplayFormat);
            }
        }
    }

    public ClockFormatEvent OnFormatChanged => onFormatChanged;

    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    TMP_Text textDisplay = default;

    [SerializeField]
    ClockDisplayFormat clockDisplayFormat = default;

    [SerializeField]
    ClockFormatEvent onFormatChanged;


    private void Start()
    {
        clockController.OnTick.AddListener(_ => UpdateTextDisplay());
        clockController.OnStart.AddListener(_ => UpdateTextDisplay());
        clockController.OnStop.AddListener(_ => UpdateTextDisplay());
        clockController.OnReset.AddListener(_ => UpdateTextDisplay());

        OnFormatChanged.AddListener(_ => UpdateTextDisplay());
    }

    void UpdateTextDisplay()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        textDisplay.text = clockDisplayFormat.GetDateTimeFormatted(clockController.ClockTime);
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        textDisplay.text = clockDisplayFormat.Format;
    }
#endif
}
