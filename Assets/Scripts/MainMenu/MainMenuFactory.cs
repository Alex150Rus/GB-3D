using SpaceJailRunner.MainMenu.Interface;
using UnityEngine;

namespace SpaceJailRunner.MainMenu
{
    internal class MainMenuFactory : IMainMenuFactory
    {
        public Transform Create()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/Levels/MainMenuBlocks");
            var instance = Object.Instantiate(prefab);
            return instance.transform;
        }
    }
}