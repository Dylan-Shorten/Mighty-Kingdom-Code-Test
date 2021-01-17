using UnityEngine;
using TMPro;


public class ClockFormatDropdown : MonoBehaviour
{
    [SerializeField]
    ClockController clockController = default;

    [SerializeField]
    ClockFormatList formatList = default;

    [SerializeField]
    TMP_Dropdown dropdown = default;

    bool hasBlockedFirstInput = default;


    void Start()
    {
        dropdown.onValueChanged.AddListener(SetClockDisplayFormat);
        SetClockDisplayFormat(0);
    }

    public void SetClockDisplayFormat(int clockFormatIndex)
    {
        // The dropdown class automatically sets the value to the first value in the list.
        // We block this callback because we want the dropdown to sync to the current mode's format on start.
        if (!hasBlockedFirstInput)
        {
            hasBlockedFirstInput = true;
            return;
        }

        ClockFormat foundFormat = formatList.GetFormat(clockFormatIndex);

        if (foundFormat != null)
        {
            clockController.ClockFormat = foundFormat;
        }
    }

    public void SyncClockDisplayFormat()
    {
        int foundIndex = formatList.GetIndexOfFormat(clockController.ClockFormat);

        if (foundIndex != -1)
        {
            dropdown.value = foundIndex;
        }
    }
}