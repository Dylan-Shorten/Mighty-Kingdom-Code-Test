using UnityEngine;


public class ClockModeInstancer : MonoBehaviour
{
    // In case clock mode is requested before Awake.
    public ClockMode InstancedClockMode
    {
        get
        {
            TryCreateClockMode();
            return instancedClockMode;
        }
    }

    [SerializeField]
    ClockMode baseClockMode = default;

    ClockMode instancedClockMode;

    private void Awake()
    {
        TryCreateClockMode();
    }

    void TryCreateClockMode()
    {
        if (instancedClockMode == null)
        {
            instancedClockMode = ScriptableObject.CreateInstance(baseClockMode.GetType()) as ClockMode;
            instancedClockMode.SetupClock(baseClockMode);
        }
    }
}