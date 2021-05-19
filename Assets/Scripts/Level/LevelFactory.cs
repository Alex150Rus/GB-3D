using SpaceJailRunner.Prefabs;
using UnityEngine;

namespace SpaceJailRunner.Level
{
    internal class LevelFactory: ILevelFactory
    {
        public Transform CreateLevel(string levelName)
        {
            var prefab = Resources.Load<GameObject>($"{PrefabsRoutesManager.LEVELS}{levelName}");
            return Object.Instantiate(prefab, Vector3.zero, Quaternion.identity).transform;
        }
    }
}