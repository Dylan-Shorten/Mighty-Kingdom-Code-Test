using UnityEngine;

public class ClockController : MonoBehaviour
{
    public float ClockTime => clockTime;

    float clockTime = 0.0f;

    void Update()
    {
        clockTime += Time.deltaTime;
    }
}
