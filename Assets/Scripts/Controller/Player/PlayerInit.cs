using System.Collections.Generic;
using System.Linq;
using SpaceJailRunner.Ability;
using SpaceJailRunner.Ability.Interface;
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

            #region Iterator

            _player.Abilities = new List<IAbility>()
            {
                new Ability.Ability("Athlete", AbilityType.Athlete, 10),
                new Ability.Ability("Survivor", AbilityType.Survivor, 50),
                new Ability.Ability("Jumper", AbilityType.Jumper, 30)
            };
            
            Debug.Log(_player[0]);
            Debug.Log(_player[AbilityType.Jumper]);

            foreach (var ability in _player)
            {
                Debug.Log(ability);
            }
            
            foreach (var ability in _player.GetAbility().Take(2))
            {
                Debug.Log(ability);
            }
            
            foreach (var ability in _player.GetAbility(AbilityType.Survivor))
            {
                Debug.Log(ability);
            }


            #endregion
        }

        public SpaceJailRunner.Player.Player GetPlayer()
        {
            return _player;
        }
    }
}