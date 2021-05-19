using UnityEngine;

namespace SpaceJailRunner.Level
{
    internal interface ILevelFactory
    {
        public Transform CreateLevel(string levelName);
    }
}