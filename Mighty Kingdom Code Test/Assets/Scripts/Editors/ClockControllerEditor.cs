using UnityEditor;


#if UNITY_EDITOR

[CustomEditor(typeof(ClockController), true)]
public class ClockControllerEditor : Editor
{
    ClockController targetClockController;
    SerializedProperty clockModeProperty;

    void OnEnable()
    {
        targetClockController = target as ClockController;
        clockModeProperty = serializedObject.FindProperty("clockMode");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();

        EditorGUILayout.PropertyField(clockModeProperty);

        serializedObject.ApplyModifiedProperties();

        if (EditorGUI.EndChangeCheck())
        {
            // Reset the clock controller if the clock mode was changed in editor.
            targetClockController.ResetClock();
        }
    }
}

#endif