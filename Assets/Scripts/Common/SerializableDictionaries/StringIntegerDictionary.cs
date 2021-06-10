using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceJailRunner.Common.SerializableDictionaries
{
    [Serializable]
    public class StringIntegerDictionary: UnitySerializedDictionary<string, int>
    {
        public StringIntegerDictionary(Dictionary<string, int> dictionary)
        {
            _Dictionary = dictionary;
        }
    }
}