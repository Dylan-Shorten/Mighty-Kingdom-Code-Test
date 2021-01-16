using UnityEngine;
using TMPro;


[ExecuteAlways]
public class ClockDisplayer : MonoBehaviour
{
    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    TMP_Text textDisplay = default;

    [SerializeField]
    ClockFormat clockFormat = default;


    void Update()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        if (clockFormat == null || textDisplay == null)
        {
            return;
        }

        textDisplay.text = clockFormat.GetDateTimeFormatted(clockController.ClockTime);
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        if (clockFormat == null || textDisplay == null)
        {
            return;
        }

        textDisplay.text = clockFormat.Format;
    }
#endif
}
