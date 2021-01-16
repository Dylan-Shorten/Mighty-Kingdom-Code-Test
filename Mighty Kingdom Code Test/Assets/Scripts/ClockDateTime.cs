using System;
using UnityEngine;


[Flags]
public enum EDateTimeFormat
{
    Millisecond = 1 << 1,
    Second = 1 << 2,
    Minute = 1 << 3,
    Hour = 1 << 4,
    Day = 1 << 5,
    Month = 1 << 6,
    Year = 1 << 7,
}


[Serializable]
public class ClockDateTime : ISerializationCallbackReceiver
{
    public DateTime DateTime { get => dateTime; set => dateTime = value; }

    public EDateTimeFormat DateTimeFormat => dateTimeFormat;

    DateTime dateTime = default;

    [SerializeField]
    EDateTimeFormat dateTimeFormat = 0;

    [SerializeField]
    int millisecond = default;

    [SerializeField]
    int second = default;

    [SerializeField]
    int minute = default;

    [SerializeField]
    int hour = default;

    [SerializeField]
    int day = default;
    
    [SerializeField]
    int month = default;

    [SerializeField]
    int year = default;


    public void OnBeforeSerialize()
    {
        millisecond = DateTime.Millisecond;
        second = DateTime.Second;
        minute = DateTime.Minute;
        hour = DateTime.Hour;
        day = DateTime.Day;
        month = DateTime.Month;
        year = DateTime.Year;
    }

    public void OnAfterDeserialize()
    {
        DateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
    }
}
