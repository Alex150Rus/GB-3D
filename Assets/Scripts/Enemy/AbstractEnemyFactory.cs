using System;
using SpaceJailRunner.Enemy.Interface;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    internal sealed class AbstractEnemyFactory: ICreateEnemyByType
    {
        private readonly StaticEnemyFactory _staticEnemyFactory;
        private readonly PatrollingEnemyFactory _patrollingEnemyFactory;
        
        public AbstractEnemyFactory()
        {
            _staticEnemyFactory = new StaticEnemyFactory();
            _patrollingEnemyFactory = new PatrollingEnemyFactory();
        }
        
        public Enemy Create(EnemyType enemyType, Transform transform)
        {
            switch (enemyType)
            {
                case EnemyType.Patrolling:
                    return _patrollingEnemyFactory.Create(transform);
                case EnemyType.Static:
                    return _staticEnemyFactory.Create(transform);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}