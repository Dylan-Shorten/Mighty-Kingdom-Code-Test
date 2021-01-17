using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Clock/Clock Display Format")]
public class ClockFormat : ScriptableObject
{
    public string Format => format;

    [SerializeField, TextArea]
    string format = default;


    public string GetDateTimeFormatted(DateTime dateTime)
    {
        return dateTime.ToString(format);
    }
}
