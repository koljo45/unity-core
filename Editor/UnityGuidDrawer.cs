using UnityEditor;
using UnityEngine;

namespace SaintStudio.Core.Editor
{
    [CustomPropertyDrawer(typeof(UnityGuid))]
    public class UnityGuidDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Draw label
            EditorGUI.LabelField(position, $"{property.displayName}: {property.FindPropertyRelative("_guidString").stringValue}");
        }
    }
}
