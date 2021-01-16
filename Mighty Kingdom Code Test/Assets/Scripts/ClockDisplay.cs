using UnityEngine;
using TMPro;


[ExecuteAlways]
public class ClockDisplay : MonoBehaviour
{
    public ClockDisplayFormat ClockDisplayFormat { get => clockDisplayFormat; set => clockDisplayFormat = value; }

    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    TMP_Text textDisplay = default;

    [SerializeField]
    ClockDisplayFormat clockDisplayFormat = default;


    void Update()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        if (clockDisplayFormat == null || textDisplay == null)
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

        if (clockDisplayFormat == null || textDisplay == null)
        {
            return;
        }

        textDisplay.text = clockDisplayFormat.Format;
    }
#endif
}
