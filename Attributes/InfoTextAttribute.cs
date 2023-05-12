using UnityEngine;

namespace SaintStudio.Core.Attributes
{
    public class InfoTextAttribute : PropertyAttribute
    {
        public enum MessageType
        {
            None,
            Info,
            Warning,
            Error
        }

        public string DisplayText;
        public MessageType Type;

        public InfoTextAttribute(string displayText, MessageType messageType = MessageType.Info)
        {
            DisplayText = displayText;
            Type = messageType;
        }
    }
}