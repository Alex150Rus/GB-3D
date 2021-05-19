using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Player.Interface;
using SpaceJailRunner.Player;
using UnityEngine;

namespace SpaceJailRunner.Controller.Player
{
    internal sealed class PlayerInit: IGetPlayer, IInit
    {
        private readonly Transform _player;
        
        public PlayerInit(PlayerFactory playerFactory)
        {
            _player = playerFactory.CreatePlayer();
        }
        public Transform GetPlayer()
        {
            return _player;
        }

        public void Init()
        {
            throw new System.NotImplementedException();
        }
    }
}