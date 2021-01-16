using UnityEngine;


public class ClockModeInstancer : MonoBehaviour
{
    public ClockMode InstancedClockMode => instancedClockMode;

    [SerializeField]
    ClockMode baseClockMode = default;

    [SerializeField]
    bool assignToControllerOnAwake = default;

    [SerializeField]
    ClockController clockController = default;

    ClockMode instancedClockMode;


    private void Awake()
    {
        instancedClockMode = ScriptableObject.CreateInstance(baseClockMode.GetType()) as ClockMode;
        instancedClockMode.SetupClock(baseClockMode);

        if (assignToControllerOnAwake)
        {
            AssignToClockController();
        }
    }

    public void AssignToClockController()
    {
        clockController.ClockMode = InstancedClockMode;
    }
}