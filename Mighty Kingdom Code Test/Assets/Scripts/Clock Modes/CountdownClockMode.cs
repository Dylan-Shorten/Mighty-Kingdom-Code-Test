using UnityEngine;


[CreateAssetMenu]
public class CountdownClockMode : ClockMode
{
    public ClockDateTime StartTime => startTime;

    [SerializeField]
    ClockDateTime startTime = default;


    public override void UpdateClockTime(ref ClockDateTime clockTime)
    {
        clockTime.DateTime = clockTime.DateTime.AddSeconds(-Time.deltaTime);
    }

    public override void ResetClockTime(ref ClockDateTime clockTime)
    {
        clockTime = startTime;
    }
}
