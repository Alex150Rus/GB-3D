using System;
using System.Collections.Generic;
using System.Linq;
using SpaceJailRunner.Ammos;
using SpaceJailRunner.Common;
using SpaceJailRunner.Controller.Enemy.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.Enemy;
using SpaceJailRunner.Health;
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
        private AmmoPool _ammoPool;
       
        public EnemyInit(AbstractEnemyFactory enemyFactory, EnemyStartPoints enemyStartPoints, EnemyData enemyData,
            AmmoAbstractFactory ammoAbstarctFactorty)
        {
            _patrollingEnemy = new List<SpaceJailRunner.Enemy.Enemy>();
            _staticEnemy = new List<SpaceJailRunner.Enemy.Enemy>();
            _enemyData = enemyData;
            _ammoAbstarctFactorty = ammoAbstarctFactorty;
            _ammoPool = new AmmoPool(5, ammoAbstarctFactorty);

            #region serviceLocator 

            ServiceLocator.SetService(_ammoPool);

            #endregion
            
            
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
                
                enemy.Health.HealthBelongs = HealthBelongs.Enemy;
                enemy.Health.HealthPoints = 0;
                
                enemy.Weapon = new WeaponTurret(_ammoAbstarctFactorty.CreateAmmo(AmmoType.TurretBall));
                if (enemy.Weapon is WeaponTurret weaponTurret)
                {
                    
                    //weaponTurret.Ammo.AmmoPool = _ammoPool;

                    #region gettingAmmoPoolViaServiceLocator

                    weaponTurret.Ammo.AmmoPool = ServiceLocator.Resolve<AmmoPool>();

                    #endregion
                }
                
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