using System;
using SpaceJailRunner.Patrol;
using UnityEngine;

namespace SpaceJailRunner.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData", order = 0)]
    internal sealed class EnemyData : ScriptableObject
    {
        [SerializeField] private float _healthPoints = 100f;
        [Header("PatrollingEnemy"), SerializeField] private float _enemyDistance = 23f;
        [SerializeField] private float _closeAttackDistance = 1f;
        [SerializeField] private float _chaseStopsAfterSeconds = 1f;
        [SerializeField] private float _chaseSpeed = 3f;
        [SerializeField] private ChaseState _chaseState = ChaseState.InPatrol;

        [Header("StaticEnemy"), SerializeField] private float _chaseSpeedStatic = 2.5f;
        [SerializeField] private ChaseState _chaseStateStatic = ChaseState.Idle;
        
        public float HealthPoints => _healthPoints;
    }
}