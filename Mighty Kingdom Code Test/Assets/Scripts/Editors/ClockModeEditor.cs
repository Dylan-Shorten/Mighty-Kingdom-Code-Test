﻿using UnityEditor;


#if UNITY_EDITOR

// This editor is in place to circumvent an error that causes the clock mode editor to not draw when trying to display a EditableClockTime property.
[CustomEditor(typeof(ClockMode), true)]
public class ClockModeEditor : Editor
{

}

#endif