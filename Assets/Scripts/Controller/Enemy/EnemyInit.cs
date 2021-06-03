using System;
using System.Collections.Generic;
using System.Linq;
using SpaceJailRunner.Ammos;
using SpaceJailRunner.Controller.Enemy.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.Enemy;
using SpaceJailRunner.weapon;
using UnityEngine;

namespace SpaceJailRunner.Controller.Enemy
{
    internal class EnemyInit : IReturnListOfEnemies, IReturnListOfPatrollingEnemies
    {
        private List<SpaceJailRunner.Enemy.Enemy> _patrollingEnemy;
        private List<SpaceJailRunner.Enemy.Enemy> _staticEnemy;
        private EnemyData _enemyData;
        private AmmoAbstractFactory _ammoAbstarctFactorty;
       
        public EnemyInit(AbstractEnemyFactory enemyFactory, EnemyStartPoints enemyStartPoints, EnemyData enemyData,
            AmmoAbstractFactory ammoAbstarctFactorty)
        {
            _patrollingEnemy = new List<SpaceJailRunner.Enemy.Enemy>();
            _staticEnemy = new List<SpaceJailRunner.Enemy.Enemy>();
            _enemyData = enemyData;
            _ammoAbstarctFactorty = ammoAbstarctFactorty;
            
            SetListOfEnemies(enemyFactory, enemyStartPoints, EnemyType.Patrolling);
            SetListOfEnemies(enemyFactory, enemyStartPoints, EnemyType.Static);
        }

        private void SetListOfEnemies(AbstractEnemyFactory enemyFactory, EnemyStartPoints enemyStartPoints,
            EnemyType enemyType)
        {
            var enemyStartPointsArray = enemyStartPoints.GetStartPoints(enemyType);
            
            for (int i = 0; i < enemyStartPointsArray.Length; i++)
            {
                var enemy = enemyFactory.Create(enemyType, enemyStartPointsArray[i].transform);
                enemy.Health.HealthPoints = _enemyData.HealthPoints;
                enemy.Weapon = new WeaponTurret(_ammoAbstarctFactorty.CreateAmmo(AmmoType.TurretBall));
                AddEnemyToTheList(enemyType, enemy);
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

        public List<SpaceJailRunner.Enemy.Enemy> GetListOfEnemies()
        {
            return _patrollingEnemy.Union(_staticEnemy).ToList();
        }

        public List<SpaceJailRunner.Enemy.Enemy> GetPatrollingEnemies()
        {
            return _patrollingEnemy;
        }
    }
}