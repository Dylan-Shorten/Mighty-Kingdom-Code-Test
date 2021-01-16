using System;
using UnityEngine;
using TMPro;

public class ClockDisplayer : MonoBehaviour
{
    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    TMP_Text textDisplay = default;

    private void Update()
    {
        textDisplay.text = clockController.ClockTime.ToString();
    }
}
