using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(AIController))]
public class QueueDisplay : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        float w1 = (EditorGUIUtility.currentViewWidth - position.x) * 0.5f;
        float w2 = (EditorGUIUtility.currentViewWidth - position.x) * 0.5f;
        var statRect = new Rect(position.x, position.y, w1, position.height);
        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(statRect, property.FindPropertyRelative(nameof(AIController.actionQueue)), GUIContent.none);
        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
