using System.Collections.Generic;
using SpaceJailRunner.Common.SerializableDictionaries;
using UnityEditor;
using UnityEngine;

namespace SpaceJailRunner.Data
{
    [CreateAssetMenu(fileName = "SceneNames", menuName = "Data/SceneNames", order = 0)]
    internal class SceneNames : ScriptableObject
    {
        [SerializeField] private List<string> _sceneNames;
        
        private static Dictionary<string, int> _dict = new Dictionary<string, int> {
            {"главное меню", 0},
            {"уровень 1", 1}
        };

        public StringIntegerDictionary _stringIntegerDictionary = new StringIntegerDictionary(_dict);

        public List<string> GameSceneNames => _sceneNames;
    }
}