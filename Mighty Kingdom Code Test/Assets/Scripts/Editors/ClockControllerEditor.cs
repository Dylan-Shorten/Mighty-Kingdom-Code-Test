using UnityEditor;


#if UNITY_EDITOR

[CustomEditor(typeof(ClockController), true)]
public class ClockControllerEditor : Editor
{
    ClockController targetClockController;

    SerializedProperty clockModeProperty;

    SerializedProperty initiallyStartedProperty;

    SerializedProperty startEventProperty;

    SerializedProperty stopEventProperty;

    SerializedProperty resetEventProperty;


    void OnEnable()
    {
        targetClockController = target as ClockController;

        clockModeProperty = serializedObject.FindProperty("clockMode");
        initiallyStartedProperty = serializedObject.FindProperty("initiallyStarted");
        startEventProperty = serializedObject.FindProperty("onStart");
        stopEventProperty = serializedObject.FindProperty("onStop");
        resetEventProperty = serializedObject.FindProperty("onReset");
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

        EditorGUILayout.PropertyField(initiallyStartedProperty);
        EditorGUILayout.PropertyField(startEventProperty);
        EditorGUILayout.PropertyField(stopEventProperty);
        EditorGUILayout.PropertyField(resetEventProperty);

        serializedObject.ApplyModifiedProperties();
    }
}

#endif