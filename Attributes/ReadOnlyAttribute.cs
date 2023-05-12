using UnityEngine;

namespace SaintStudio.Core.Attributes
{
    public class ReadOnlyAttribute : PropertyAttribute
    {
        public string Key;
        
        public ReadOnlyAttribute(string key = null)
        {
            Key = key;
        }
    }

    public interface IReadOnlyAttributeStateGetter
    {
        public bool GetAttributeState(string key);
    }
}