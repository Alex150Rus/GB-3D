using SpaceJailRunner.Controller.Player.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.Player;
using UnityEngine;

namespace SpaceJailRunner.Controller.Player
{
    internal sealed class PlayerInit: IGetPlayer
    {
        private SpaceJailRunner.Player.Player _player;
        
        public PlayerInit(PlayerFactory playerFactory, PlayerData playerData)
        {
            _player = playerFactory.CreatePlayer();
            _player.Health.HealthPoints = playerData.HealthPoints;
        }

        public SpaceJailRunner.Player.Player GetPlayer()
        {
            return _player;
        }
    }
}