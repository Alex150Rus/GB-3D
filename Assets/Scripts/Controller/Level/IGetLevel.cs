using UnityEngine;

namespace SpaceJailRunner.Controller.Level
{
    internal interface IGetLevel
    {
        public Transform GetLevel(string levelName);
    }
}