using SpaceJailRunner.Controller.Player.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.Player;
using UnityEngine;

namespace SpaceJailRunner.Controller.Player
{
    internal sealed class PlayerInit: IGetPlayer
    {
        private Transform _player;
        
        public PlayerInit(PlayerFactory playerFactory)
        {
            _player = playerFactory.CreatePlayer();
        }

        public Transform GetPlayer()
        {
            return _player;
        }
    }
}