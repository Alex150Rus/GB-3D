using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Player.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.Player;
using UnityEngine;

namespace SpaceJailRunner.Controller.Player
{
    internal sealed class PlayerInit: IGetPlayer, IExecute
    {
        private SpaceJailRunner.Player.Player _player;
        private PlayerData _playerData;
        
        public PlayerInit(PlayerFactory playerFactory, PlayerData playerData)
        {
            _player = playerFactory.CreatePlayer();
            _player.Health.HealthPoints = playerData.HealthPoints;
            _playerData = playerData;
        }

        public SpaceJailRunner.Player.Player GetPlayer()
        {
            return _player;
        }

        public void Execute(float deltaTime)
        {
            _player.MovementSM.CurrentState.LogicUpdate(_playerData);
        }
    }
}