using System;
using UnityEngine;


[Flags]
public enum EDateTimeSelection
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
public struct EditableDateTime : ISerializationCallbackReceiver
{
    public DateTime DateTime { get => dateTime; set => dateTime = value; }

    public EDateTimeSelection DateTimeSelection => dateTimeSelection;

    DateTime dateTime;

    [SerializeField]
    EDateTimeSelection dateTimeSelection;

    [SerializeField]
    int millisecond;

    [SerializeField]
    int second;

    [SerializeField]
    int minute;

    [SerializeField]
    int hour;

    [SerializeField]
    int day;
    
    [SerializeField]
    int month;

    [SerializeField]
    int year;


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
