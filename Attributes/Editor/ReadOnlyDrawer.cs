using UnityEditor;
using UnityEngine;

namespace SaintStudio.Core.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property,
            GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position,
            SerializedProperty property,
            GUIContent label)
        {
            var readOnlyAttribute = (ReadOnlyAttribute)attribute;

            GUI.enabled = readOnlyAttribute.Key != null && ((IReadOnlyAttributeStateGetter)property.serializedObject.targetObject).GetAttributeState(readOnlyAttribute.Key);
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}