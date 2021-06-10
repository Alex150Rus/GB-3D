using System;
using SpaceJailRunner.Enemy.Interface;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    internal sealed class EnemyStartPoints : IReturnStartPointsByEnemyType
    {
        private StaticEnemyStartPoints _staticEnemyStartPoints;
        private PatrollingEnemyStartPoints _patrollingEnemyStartPoints;
        
        public EnemyStartPoints()
        {
            _staticEnemyStartPoints = new StaticEnemyStartPoints();
            _patrollingEnemyStartPoints = new PatrollingEnemyStartPoints();
        }
        
        public GameObject[] GetStartPoints(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Patrolling:
                    return _patrollingEnemyStartPoints.GetStartPoints();
                case EnemyType.Static:
                    return _staticEnemyStartPoints.GetStartPoints();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}