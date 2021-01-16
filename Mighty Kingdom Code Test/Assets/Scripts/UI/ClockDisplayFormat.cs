using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Display Format")]
public class ClockDisplayFormat : ScriptableObject
{
    public string Format => format;

    [SerializeField, TextArea]
    string format = default;


    public string GetDateTimeFormatted(DateTime dateTime)
    {
        if (dateTime == null)
        {
            return string.Empty;
        }

        return dateTime.ToString(format);
    }
}
