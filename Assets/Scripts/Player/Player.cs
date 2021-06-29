using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SpaceJailRunner.Ability;
using SpaceJailRunner.Ability.Interface;
using SpaceJailRunner.Player.Interface;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceJailRunner.Player
{
    [Serializable]
    internal class Player: MonoBehaviour, IHaveHealth, IHaveAbilities
    {
        private Health.Health _health;
        private PlayerState _state;
        private Animator _playerAnimator;
        private List<IAbility> _abilities;

        public Health.Health Health => _health;

        public PlayerState State
        {
            get => _state;
            set => _state = value;
        }

        public Animator PlayerAnimator => _playerAnimator;

        public List<IAbility> Abilities
        {
            get => _abilities;
            set => _abilities = value;
        }

        public IAbility this[int index] => _abilities[index];

        public string this[AbilityType index] {
            get
            {
                var ability = _abilities.FirstOrDefault(a => a.Type == index);
                return ability == null ? "Not supported" : ability.ToString();
            }
        }

        public IEnumerable<IAbility> GetAbility()
        {
            while (true)
            {
                yield return _abilities[Random.Range(0, _abilities.Count)];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _abilities.Count; i++)
            {
                yield return _abilities[i];
            }
        }

        public IEnumerable<IAbility> GetAbility(AbilityType index)
        {
            foreach (var ability in _abilities)
            {
                if (ability.Type == index)
                    yield return ability;
            }
        }

        private void Awake()
        {
            _health = new Health.Health();
            _playerAnimator = GetComponent<Animator>();
        }
    }
}