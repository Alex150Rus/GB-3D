using SpaceJailRunner.Player.Interface;
using SpaceJailRunner.Prefabs_my;
using SpaceJailRunner.Tags;
using UnityEngine;

namespace SpaceJailRunner.Player
{
    internal class PlayerFactory : ICreatePlayer
    {
        public Player CreatePlayer()
        {
            var prefab = Resources.Load<Player>($"{PrefabsRoutesManager.CHARS}Player");
            var playerStartingPont = GameObject.
                FindGameObjectWithTag(TagNamesManager.PLAYER_STARTING_POINT_TAG).transform.position;
            var instance = Object.Instantiate(prefab, playerStartingPont, Quaternion.identity);
            return instance;
        }
    }
}