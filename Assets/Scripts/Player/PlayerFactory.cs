using SpaceJailRunner.Player.Interface;
using SpaceJailRunner.Prefabs_my;
using SpaceJailRunner.Tags;
using UnityEngine;

namespace SpaceJailRunner.Player
{
    public class PlayerFactory : ICreatePlayer
    {
        public Transform CreatePlayer()
        {
            var prefab = Resources.Load<GameObject>($"{PrefabsRoutesManager.CHARS}Player");
            var playerStartingPont = GameObject.
                FindGameObjectWithTag(TagNamesManager.PLAYER_STARTING_POINT_TAG).transform.position;
            var instance = Object.Instantiate(prefab, playerStartingPont, Quaternion.identity);
            return instance.transform;
        }
    }
}