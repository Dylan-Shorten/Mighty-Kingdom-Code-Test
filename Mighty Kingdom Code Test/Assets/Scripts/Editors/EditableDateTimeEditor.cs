using System;
using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(EditableDateTime))]
public class EditableDateTimeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        EditorGUILayout.LabelField(label);
        EditorGUI.indentLevel++;

        SerializedProperty formatProperty = property.FindPropertyRelative("dateTimeFormat");
        EditorGUILayout.PropertyField(formatProperty);

        SerializedProperty millisecondProperty = property.FindPropertyRelative("millisecond");
        SerializedProperty secondProperty = property.FindPropertyRelative("second");
        SerializedProperty minuteProperty = property.FindPropertyRelative("minute");
        SerializedProperty hourProperty = property.FindPropertyRelative("hour");
        SerializedProperty dayProperty = property.FindPropertyRelative("day");
        SerializedProperty monthProperty = property.FindPropertyRelative("month");
        SerializedProperty yearProperty = property.FindPropertyRelative("year");

        EDateTimeFormat formatEnum = (EDateTimeFormat)formatProperty.intValue;
        if (formatEnum.HasFlag(EDateTimeFormat.Millisecond))
        {
            EditorGUILayout.IntSlider(millisecondProperty, 0, 999);
        }
        if (formatEnum.HasFlag(EDateTimeFormat.Second))
        {
            EditorGUILayout.IntSlider(secondProperty, 0, 59);
        }
        if (formatEnum.HasFlag(EDateTimeFormat.Minute))
        {
            EditorGUILayout.IntSlider(minuteProperty, 0, 59);
        }
        if (formatEnum.HasFlag(EDateTimeFormat.Hour))
        {
            EditorGUILayout.IntSlider(hourProperty, 0, 23);
        }
        if (formatEnum.HasFlag(EDateTimeFormat.Day))
        {
            EditorGUILayout.IntSlider(dayProperty, 1, DateTime.DaysInMonth(yearProperty.intValue, monthProperty.intValue));
        }
        if (formatEnum.HasFlag(EDateTimeFormat.Month))
        {
            EditorGUILayout.IntSlider(monthProperty, 1, 12);
        }
        if (formatEnum.HasFlag(EDateTimeFormat.Year))
        {
            EditorGUILayout.PropertyField(yearProperty);
        }

        EditorGUI.indentLevel--;

        EditorGUI.EndProperty();

        // Perform additional clamp of the day property in case the month changed and the day is out of range.
        dayProperty.intValue = Mathf.Clamp(dayProperty.intValue, 0, DateTime.DaysInMonth(yearProperty.intValue, monthProperty.intValue));
    }
}