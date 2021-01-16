using UnityEditor;


#if UNITY_EDITOR

[CustomEditor(typeof(ClockController), true)]
public class ClockControllerEditor : Editor
{
    ClockController targetClockController = default;

    SerializedProperty clockModeProperty = default;

    SerializedProperty startEventProperty = default;

    SerializedProperty tickEventProperty = default;

    SerializedProperty stopEventProperty = default;

    SerializedProperty resetEventProperty = default;

    SerializedProperty finishedEventProperty = default;

    SerializedProperty modeChangedEventProperty = default;


    void OnEnable()
    {
        targetClockController = target as ClockController;

        clockModeProperty = serializedObject.FindProperty("clockMode");
        startEventProperty = serializedObject.FindProperty("onStart");
        tickEventProperty = serializedObject.FindProperty("onTick");
        stopEventProperty = serializedObject.FindProperty("onStop");
        resetEventProperty = serializedObject.FindProperty("onReset");
        finishedEventProperty = serializedObject.FindProperty("onFinished");
        modeChangedEventProperty = serializedObject.FindProperty("onModeChanged");
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        serializedObject.Update();

        EditorGUILayout.PropertyField(clockModeProperty);

        serializedObject.ApplyModifiedProperties();

        if (EditorGUI.EndChangeCheck())
        {
            // Reset the clock controller if the clock mode was changed in editor.
            targetClockController.ResetClock();
        }


        serializedObject.Update();

        EditorGUILayout.PropertyField(startEventProperty);
        EditorGUILayout.PropertyField(tickEventProperty);
        EditorGUILayout.PropertyField(stopEventProperty);
        EditorGUILayout.PropertyField(resetEventProperty);
        EditorGUILayout.PropertyField(finishedEventProperty);
        EditorGUILayout.PropertyField(modeChangedEventProperty);

        serializedObject.ApplyModifiedProperties();
    }
}

#endif