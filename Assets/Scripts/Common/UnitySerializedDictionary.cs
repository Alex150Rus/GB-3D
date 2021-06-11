using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceJailRunner.Common
{
    public abstract class UnitySerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField]
        protected List<TKey> _keys = new List<TKey>();
        [SerializeField]
        protected List<TValue> _values = new List<TValue>();
        
        protected Dictionary<TKey, TValue> _Dictionary = new Dictionary<TKey, TValue>();

        public void OnAfterDeserialize()
        {
            _Dictionary = new Dictionary<TKey, TValue>();

            for (int i = 0; i != Math.Min(_keys.Count, _values.Count); i++)
                _Dictionary.Add(_keys[i], _values[i]);
        }

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            foreach (var kvp in _Dictionary)
            {
                _keys.Add(kvp.Key);
                _values.Add(kvp.Value);
            }
        }
    }
}