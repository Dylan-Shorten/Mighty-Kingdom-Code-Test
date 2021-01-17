using UnityEngine;
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
        clockController.OnTick.DynamicCalls += _ => UpdateTextDisplay();
        clockController.OnStart.DynamicCalls += _ => UpdateTextDisplay();
        clockController.OnStop.DynamicCalls += _ => UpdateTextDisplay();
        clockController.OnReset.DynamicCalls += _ => UpdateTextDisplay();
        clockController.OnFormatChanged.DynamicCalls += _ => UpdateTextDisplay();
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
