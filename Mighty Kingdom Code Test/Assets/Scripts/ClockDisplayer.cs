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
        if (Application.isPlaying)
            textDisplay.text = clockFormat.GetDateTimeFormatted(clockController.ClockTime);
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (!Application.isPlaying)
        {
            textDisplay.text = clockFormat.Format;
        }
    }
#endif
}
