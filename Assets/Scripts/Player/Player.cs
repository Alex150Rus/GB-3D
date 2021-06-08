using System;
using SpaceJailRunner.Player.Interface;
using UnityEngine;

namespace SpaceJailRunner.Player
{
    [Serializable]
    internal class Player: MonoBehaviour, IHaveHealth
    {
        private Health.Health _health;
        private PlayerState _state;
        private Animator _playerAnimator;

        public Health.Health Health => _health;

        public PlayerState State
        {
            get => _state;
            set => _state = value;
        }

        public Animator PlayerAnimator => _playerAnimator;

        private void Awake()
        {
            _health = new Health.Health();
            _playerAnimator = GetComponent<Animator>();
        }
    }
}