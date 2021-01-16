using System;
using UnityEngine;
using TMPro;


public class TimeAdder : MonoBehaviour
{
    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    TMP_InputField timeToAddInputField = default;

    [SerializeField]
    TMP_Dropdown timeTypeDropdown = default;


    private void Start()
    {
        timeToAddInputField.contentType = TMP_InputField.ContentType.DecimalNumber;
    }

    public void AddTime()
    {
        if (!Enum.TryParse(timeTypeDropdown.options[timeTypeDropdown.value].text, out EDateTimeAddType addType))
        {
            return;
        }

        if (!double.TryParse(timeToAddInputField.text, out double timeToAdd))
        {
            return;
        }
        
        clockController.ClockTime = clockController.ClockTime.Add(timeToAdd, addType);
    }
}