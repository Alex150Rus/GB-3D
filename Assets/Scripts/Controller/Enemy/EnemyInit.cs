using System;
using System.Collections.Generic;
using SpaceJailRunner.Data;
using SpaceJailRunner.Enemy;
using UnityEngine;

namespace SpaceJailRunner.Controller.Enemy
{
    internal class EnemyInit
    {
        private List<SpaceJailRunner.Enemy.Enemy> _patrollingEnemy;
        private List<SpaceJailRunner.Enemy.Enemy> _staticEnemy;
       
        public EnemyInit(AbstractEnemyFactory enemyFactory, EnemyStartPoints enemyStartPoints)
        {
            _patrollingEnemy = new List<SpaceJailRunner.Enemy.Enemy>();
            _staticEnemy = new List<SpaceJailRunner.Enemy.Enemy>();
            
            SetListOfEnemies(enemyFactory, enemyStartPoints, EnemyType.Patrolling);
            SetListOfEnemies(enemyFactory, enemyStartPoints, EnemyType.Static);

            Debug.Log(_patrollingEnemy.Count);
        }

        private void SetListOfEnemies(AbstractEnemyFactory enemyFactory, EnemyStartPoints enemyStartPoints,
            EnemyType enemyType)
        {
            var enemyStartPointsArray = enemyStartPoints.GetStartPoints(enemyType);
            
            for (int i = 0; i < enemyStartPointsArray.Length; i++)
            {
                var enemy = enemyFactory.Create(enemyType);
                AddEnemyToTheList(enemyType, enemy);
                enemy.transform.SetPositionAndRotation(enemyStartPointsArray[i].transform.position, Quaternion.identity);
            }
        }

        private void AddEnemyToTheList(EnemyType enemyType, SpaceJailRunner.Enemy.Enemy enemy)
        {
            switch (enemyType)
            {
                case EnemyType.Patrolling:
                    _patrollingEnemy.Add(enemy);
                    break;
                case EnemyType.Static:
                    _staticEnemy.Add(enemy);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}