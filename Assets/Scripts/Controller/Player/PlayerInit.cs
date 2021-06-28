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

            #region ChainOfResponsibilities
            
            Debug.Log(_player.Health.HealthPoints);
            Debug.Log(_player.State);

            var root = new PlayerModifier(_player);
            root.Add(new StateModifier(_player, PlayerState.Run));
            root.Add(new HealthModifier(_player, 500));
            root.Handle();
            
            Debug.Log(_player.Health.HealthPoints);
            Debug.Log(_player.State);

            #endregion
        }

        public SpaceJailRunner.Player.Player GetPlayer()
        {
            return _player;
        }
    }
}