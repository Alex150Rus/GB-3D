using SpaceJailRunner.Enemy.Interface;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    internal class PatrollingEnemyFactory : ICreateEnemy
    {
        public Enemy Create()
        {
            var enemy = Resources.Load<Enemy>("Prefabs/Chars/Policeman");
            var enemyInstance = GameObject.Instantiate(enemy);
            return enemyInstance;
        }
    }
}