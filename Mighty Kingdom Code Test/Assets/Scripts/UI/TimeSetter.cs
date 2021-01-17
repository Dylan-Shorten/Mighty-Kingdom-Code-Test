using System;
using System.Globalization;
using UnityEngine;
using TMPro;


public class TimeSetter : MonoBehaviour
{
    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    TMP_InputField timeInputField = default;

    [SerializeField]
    TMP_Text formatText = default;


    void Start()
    {
        timeInputField.onEndEdit.AddListener(SetTime);

        clockController.OnFormatChanged.DynamicCalls += _ => RefreshFormatText();
        clockController.OnModeChanged.DynamicCalls += _ => RefreshFormatText();

        RefreshFormatText();
    }

    void RefreshFormatText()
    {
        formatText.text = GetFormatNoNewLines(clockController.ClockFormat);
    }

    public void SetTime(string inputTime)
    {
        if (!DateTime.TryParseExact(inputTime, GetFormatNoNewLines(clockController.ClockFormat), new CultureInfo("en-US"), DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault, out DateTime parsedDateTime))
        {
            return;
        }

        clockController.ClockTime = parsedDateTime;
        timeInputField.text = string.Empty;
    }

    static string GetFormatNoNewLines(ClockFormat format)
    {
        return format.Format.Replace(Environment.NewLine, " ").Replace("\n", " ");
    }
}