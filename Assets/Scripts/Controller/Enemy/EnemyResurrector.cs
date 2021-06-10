using SpaceJailRunner.Common;
using SpaceJailRunner.Controller.Enemy.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.Enemy
{
    internal class EnemyResurrector: IResurrectEnemy
    {
        private readonly SpaceJailRunner.Enemy.Enemy _enemy;
        public EnemyResurrector(SpaceJailRunner.Enemy.Enemy enemy)
        {
            _enemy = enemy;
        }
        public void ResurrectEnemy(Vector3 position)
        {
            var enemy = _enemy.Clone();
            enemy.transform.position -= position;
            Debug.Log(enemy.transform.position);
        }
    }
}