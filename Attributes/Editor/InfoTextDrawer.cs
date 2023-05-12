using UnityEditor;
using UnityEngine;

namespace SaintStudio.Core.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(InfoTextAttribute))]
    public class InfoTextDrawer : PropertyDrawer
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
            if (attribute is InfoTextAttribute infoTextAttribute)
                EditorGUI.HelpBox(position, infoTextAttribute.DisplayText, (MessageType)infoTextAttribute.Type);
        }
    }
}