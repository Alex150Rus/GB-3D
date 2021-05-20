using SpaceJailRunner.Controller.Player.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.Player;
using UnityEngine;

namespace SpaceJailRunner.Controller.Player
{
    internal sealed class PlayerInit: IGetStartPlayer, IGetPlayer
    {
        private readonly PlayerFactory _playerFactory;
        private Transform _player;
        
        public PlayerInit(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        private void CreatePlayer()
        {
            _player = _playerFactory.CreatePlayer();
        }
        
        
        public Transform GetPlayer(PlayerData playerData, int sceneNumber)
        {   
            if(_player == null)
                CreatePlayer();
            
            SetPlayerPosition(playerData, sceneNumber);
            return _player;
        }

        private void SetPlayerPosition(PlayerData playerData, int sceneNumber)
        {
            _player.position = playerData.StartPositions[sceneNumber-1];
            _player.rotation = Quaternion.Euler(Vector3.up * playerData.StartRotations[sceneNumber-1]);
        }
        
        public Transform GetPlayer()
        {
            return _player;
        }
    }
}