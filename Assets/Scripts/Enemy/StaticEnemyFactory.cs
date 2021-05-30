using SpaceJailRunner.Enemy.Interface;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    internal class StaticEnemyFactory : ICreateEnemy
    {
        public Enemy Create()
        {
            var enemy = Resources.Load<Enemy>("Prefabs/Chars/PolicemanTurret");
            var enemyInstance = GameObject.Instantiate(enemy);
            return enemyInstance;
        }
    }
}