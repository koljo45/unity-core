using System;
using UnityEngine;

namespace SaintStudio.Core
{
    [Serializable]
    public class UnityGuid : ISerializationCallbackReceiver
    {
        // Switch this to byte[] if string proves slow
        [SerializeField] private string _guidString;
        // First time the object is constructed as a part of a list element Unity automatically tries to deserialize it after the constructor is executed. This would result in _guidString being overwritten with string.Empty. Because of this a check is added to see if the object is initialized.
        [SerializeField, HideInInspector] private bool _initialized;

        private Guid _guid;

        public UnityGuid(Guid guid)
        {
            _initialized = true;
            _guid = guid;
            _guidString = _guid.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is UnityGuid guid &&
                    _guid.Equals(guid._guid);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_guidString);
        }

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            if (!_initialized)
            {
                _initialized = true;
                _guid = Guid.NewGuid();
                _guidString = _guid.ToString();
            }

            if (Guid.TryParse(_guidString, out Guid result))
            {
                _guid = result;
            }
            else
            {
                _guid = Guid.Empty;
                Debug.LogWarning($"Attempted to parse invalid GUID string '{_guidString}'. GUID will set to System.Guid.Empty");
            }
        }

        public override string ToString() => _guid.ToString();

        public static bool operator ==(UnityGuid a, UnityGuid b) => a._guid == b._guid;
        public static bool operator !=(UnityGuid a, UnityGuid b) => a._guid != b._guid;
        public static bool operator ==(UnityGuid a, Guid b) => a._guid == b;
        public static bool operator !=(UnityGuid a, Guid b) => a._guid != b;
        public static bool operator ==(Guid a, UnityGuid b) => a == b._guid;
        public static bool operator !=(Guid a, UnityGuid b) => a != b._guid;
        public static implicit operator UnityGuid(Guid guid) => new(guid);
        public static implicit operator Guid(UnityGuid serializable) => serializable._guid;
        public static implicit operator UnityGuid(string serializedGuid) => new(Guid.Parse(serializedGuid));
        public static implicit operator string(UnityGuid serializedGuid) => serializedGuid.ToString();
    }
}