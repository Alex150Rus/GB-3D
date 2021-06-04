using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using SpaceJailRunner.Ammos;
using SpaceJailRunner.Enemy.Interface;
using SpaceJailRunner.Player.Interface;
using SpaceJailRunner.weapon;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

namespace SpaceJailRunner.Enemy
{
    internal class Enemy: MonoBehaviour, ICanSeeEnemy
    {
        private Health.Health _health;
        private Weapon _weapon;
        private IHaveHealth _target;
        private bool _fireCourutineStarted;
        private Transform _targetTransform;
        private Animator _animator;
        private EnemyState _state;
        private NavMeshAgent _navMeshAgent;
        private EnemyType _enemyType;
        public Health.Health Health => _health;
        
        public Weapon Weapon
        {
            get => _weapon;
            set => _weapon = value;
        }

        public Animator Animator => _animator;

        public EnemyState State
        {
            get => _state;
            set => _state = value;
        }

        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        public EnemyType EnemyType
        {
            get => _enemyType;
            set => _enemyType = value;
        }

        public bool EnemyIsInSight { get; set; }
        
        public void SetTarget(IHaveHealth target)
        {
            _target = target;
            if (target is Player.Player player)
                _targetTransform = player.transform;
        }

        private void Awake()
        {
            _health = new Health.Health();
            EnemyIsInSight = false;
            _fireCourutineStarted = false;
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _state = EnemyState.Idle;
        }

        public void DoDamage()
        {
            if (!_fireCourutineStarted)
            {
                _fireCourutineStarted = true;
                StartCoroutine(Fire());
            }
            
        }

        private IEnumerator Fire()
        {
            while(EnemyIsInSight)
            {
                Weapon.DoDamage(_target.Health, _targetTransform, transform);
                yield return new WaitForSeconds(2);
                Weapon.DoDamage(_target.Health, _targetTransform, transform);
            }

            _fireCourutineStarted = false;
        }
    }
}