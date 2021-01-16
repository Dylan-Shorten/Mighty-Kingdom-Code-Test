using UnityEngine;
using TMPro;


public class ClockFormatDropdown : MonoBehaviour
{
    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    ClockDisplayFormatList formatList = default;

    [SerializeField]
    TMP_Dropdown dropdown = default;


    void Start()
    {
        dropdown.onValueChanged.AddListener(SetClockDisplayFormat);
        SetClockDisplayFormat(0);
    }

    public void SetClockDisplayFormat(int clockFormatIndex)
    {
        ClockDisplayFormat foundFormat = formatList.GetFormat(clockFormatIndex);

        if (foundFormat != null)
        {
            clockController.ClockFormat = foundFormat;
        }
    }

    public void SyncClockDisplayFormat()
    {
        int foundIndex = formatList.GetIndexOfFormat(clockController.ClockFormat);

        if (foundIndex >= 0)
        {
            dropdown.value = foundIndex;
        }
    }
}