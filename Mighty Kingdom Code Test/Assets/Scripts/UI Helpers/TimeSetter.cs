using System;
using System.Globalization;
using UnityEngine;
using TMPro;


public class TimeSetter : MonoBehaviour
{
    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    ClockDisplay clockDisplay = default;

    [SerializeField]
    TMP_InputField timeInputField = default;

    [SerializeField]
    TMP_Text placeholderText = default;


    private void Start()
    {
        timeInputField.onEndEdit.AddListener(SetTime);
        clockDisplay.OnFormatChanged.AddListener(_ => RefreshPlaceholderText());

        RefreshPlaceholderText();
    }

    private void RefreshPlaceholderText()
    {
        placeholderText.text = GetFormatNoNewLines(clockDisplay.ClockDisplayFormat);
    }

    public void SetTime(string inputTime)
    {
        if (!DateTime.TryParseExact(inputTime, GetFormatNoNewLines(clockDisplay.ClockDisplayFormat), new CultureInfo("en-US"), DateTimeStyles.AllowWhiteSpaces, out DateTime parsedDateTime))
        {
            return;
        }

        clockController.ClockTime = parsedDateTime;
        timeInputField.text = string.Empty;
    }

    private string GetFormatNoNewLines(ClockDisplayFormat format)
    {
        return format.Format.Replace("\n", " ");
    }
}