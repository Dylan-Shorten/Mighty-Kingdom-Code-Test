using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Format/Clock Format List")]
public class ClockFormatList : ScriptableObject
{
    [SerializeField]
    ClockFormat[] formats = default;


    public ClockFormat GetFormat(int index)
    {
        if (index < 0 || index >= formats.Length)
        {
            return null;
        }

        return formats[index];
    }

    public int GetIndexOfFormat(ClockFormat format)
    {
        return Array.IndexOf(formats, format);
    }
}
