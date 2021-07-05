using System;
using System.Diagnostics;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.Player;
using UnityEngine;

namespace SpaceJailRunner.Controller.Player
{
    internal sealed class PlayerAnimator : IExecute
    {
        private readonly Animator _animator;
        private readonly SpaceJailRunner.Player.Player _player;
        private readonly float _runSpeed;

        private readonly int _speed = Animator.StringToHash(NameManager.NameManager.ANIMATOR_SPEED);
        private readonly int _fire = Animator.StringToHash(NameManager.NameManager.ANIMATOR_FIRE);
        
        public PlayerAnimator(SpaceJailRunner.Player.Player player, PlayerData playerData)
        {
            _animator = player.PlayerAnimator;
            _player = player;
            _runSpeed = playerData.RunSpeed;
        }

        public void Execute(float deltaTime)
        {
            // switch (_player.State)
            // {
            //     case PlayerState.Idle:
            //     case PlayerState.Jump:
            //         _animator.SetFloat(_speed, 0f);
            //         break;
            //     case PlayerState.Run:
            //         _animator.SetFloat(_speed, _runSpeed);
            //         break;
            //     case PlayerState.Firing:
            //         _animator.SetTrigger(_fire);
            //         break;
            //     default:
            //         throw new ArgumentOutOfRangeException();
            // }
        }
    }
}