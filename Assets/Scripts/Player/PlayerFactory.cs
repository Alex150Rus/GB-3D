using SpaceJailRunner.Player.Interface;
using SpaceJailRunner.Prefabs_my;
using UnityEngine;

namespace SpaceJailRunner.Player
{
    public class PlayerFactory : ICreatePlayer
    {
        public Transform CreatePlayer()
        {
            var prefab = Resources.Load<GameObject>($"{PrefabsRoutesManager.CHARS}Player");
            var instance = Object.Instantiate(prefab);
            return instance.transform;
        }
    }
}