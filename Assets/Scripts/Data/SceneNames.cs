using System.Collections.Generic;
using UnityEngine;

namespace SpaceJailRunner.Data
{
    [CreateAssetMenu(fileName = "SceneNames", menuName = "Data/SceneNames", order = 0)]
    internal class SceneNames : ScriptableObject
    {
        [SerializeField] private List<string> _sceneNames;
        
        public List<string> GameSceneNames => _sceneNames;
    }
}