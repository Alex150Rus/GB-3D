using System;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using SpaceJailRunner.Ammos;
using SpaceJailRunner.Enemy.Interface;
using SpaceJailRunner.Player.Interface;
using SpaceJailRunner.weapon;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    internal class Enemy: MonoBehaviour, ICanSeeEnemy
    {
        private Health.Health _health;
        private Weapon _weapon;
        private IHaveHealth _target;
        private bool _fireCourutineStarted;
        private Transform _targetTransform;
        public Health.Health Health => _health;
        
        public Weapon Weapon
        {
            get => _weapon;
            set => _weapon = value;
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