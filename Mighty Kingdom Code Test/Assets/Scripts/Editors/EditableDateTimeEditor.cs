using System;
using UnityEditor;
using UnityEngine;


#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(EditableDateTime))]
public class EditableDateTimeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        EditorGUILayout.LabelField(label);
        EditorGUI.indentLevel++;

        SerializedProperty selectionProperty = property.FindPropertyRelative("dateTimeSelection");
        SerializedProperty millisecondProperty = property.FindPropertyRelative("millisecond");
        SerializedProperty secondProperty = property.FindPropertyRelative("second");
        SerializedProperty minuteProperty = property.FindPropertyRelative("minute");
        SerializedProperty hourProperty = property.FindPropertyRelative("hour");
        SerializedProperty dayProperty = property.FindPropertyRelative("day");
        SerializedProperty monthProperty = property.FindPropertyRelative("month");
        SerializedProperty yearProperty = property.FindPropertyRelative("year");

        EditorGUILayout.PropertyField(selectionProperty);
        EDateTimeSelection selection = (EDateTimeSelection)selectionProperty.intValue;

        if (selection.HasFlag(EDateTimeSelection.Millisecond))
        {
            EditorGUILayout.IntSlider(millisecondProperty, 0, 999);
        }
        if (selection.HasFlag(EDateTimeSelection.Second))
        {
            EditorGUILayout.IntSlider(secondProperty, 0, 59);
        }
        if (selection.HasFlag(EDateTimeSelection.Minute))
        {
            EditorGUILayout.IntSlider(minuteProperty, 0, 59);
        }
        if (selection.HasFlag(EDateTimeSelection.Hour))
        {
            EditorGUILayout.IntSlider(hourProperty, 0, 23);
        }
        if (selection.HasFlag(EDateTimeSelection.Day))
        {
            EditorGUILayout.IntSlider(dayProperty, 1, DateTime.DaysInMonth(yearProperty.intValue, monthProperty.intValue));
        }
        if (selection.HasFlag(EDateTimeSelection.Month))
        {
            EditorGUILayout.IntSlider(monthProperty, 1, 12);
        }
        if (selection.HasFlag(EDateTimeSelection.Year))
        { 
            EditorGUILayout.IntSlider(yearProperty, 1, 9999);
        }

        EditorGUI.indentLevel--;

        EditorGUI.EndProperty();

        // Perform additional clamp of the day property in case the month changed and the day is out of range.
        dayProperty.intValue = Mathf.Clamp(dayProperty.intValue, 0, DateTime.DaysInMonth(yearProperty.intValue, monthProperty.intValue));
    }
}

#endif