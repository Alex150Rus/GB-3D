using SpaceJailRunner.MainMenu.Interface;
using SpaceJailRunner.Prefabs_my;
using UnityEngine;

namespace SpaceJailRunner.MainMenu
{
    internal sealed class MainMenuFactory : IMainMenuFactory
    {
        public Transform Create()
        {
            var prefab = Resources.Load<GameObject>($"{PrefabsRoutesManager.LEVELS}MainMenuBlocks");
            var instance = Object.Instantiate(prefab);
            return instance.transform;
        }
    }
}