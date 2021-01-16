using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Display Format List")]
public class ClockDisplayFormatList : ScriptableObject
{
    [SerializeField]
    ClockDisplayFormat[] formats = default;


    public ClockDisplayFormat GetFormat(int index)
    {
        if (index < 0 || index >= formats.Length)
        {
            return null;
        }

        return formats[index];
    }

    public int GetIndexOfFormat(ClockDisplayFormat format)
    {
        return Array.IndexOf(formats, format);
    }
}
