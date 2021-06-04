using System;
using System.Collections.Generic;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace SpaceJailRunner.Controller.Enemy
{
    internal sealed class EnemyAnimator : IExecute
    {
        private readonly List<SpaceJailRunner.Enemy.Enemy> _enemies;

        private readonly int _speed = Animator.StringToHash(NameManager.NameManager.ANIMATOR_SPEED);
        private readonly int _fire = Animator.StringToHash(NameManager.NameManager.ANIMATOR_FIRE);
        private static readonly int _idle = Animator.StringToHash(NameManager.NameManager.ANIMATOR_IDLE);
        private static readonly int _clAttack = Animator.StringToHash(NameManager.NameManager.ANIMATOR_ClOSE_ATTACK);

        public EnemyAnimator(List<SpaceJailRunner.Enemy.Enemy> enemies)
        {
            _enemies = enemies;
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                Debug.Log(_enemies[i].State);
                Debug.Log(_enemies[i].EnemyType);
                switch (_enemies[i].State)
                {
                    case EnemyState.Idle:
                        _enemies[i].Animator.SetTrigger(_idle);
                        break;
                    case EnemyState.Walk:
                        _enemies[i].Animator.SetFloat(_speed, _enemies[i].NavMeshAgent.speed);
                        break;
                    case EnemyState.Run:
                        _enemies[i].Animator.SetFloat(_speed, _enemies[i].NavMeshAgent.speed);

                        break;
                    case EnemyState.Firing:
                        _enemies[i].Animator.SetTrigger(_fire);
                        break;
                    case EnemyState.CloseAttack:
                        _enemies[i].Animator.SetTrigger(_clAttack);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}