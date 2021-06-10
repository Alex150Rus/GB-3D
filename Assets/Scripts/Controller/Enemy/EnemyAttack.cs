using System.Collections;
using System.Collections.Generic;
using SpaceJailRunner.Controller.Interface;

namespace SpaceJailRunner.Controller.Enemy
{
    internal class EnemyAttack: IExecute
    {
        private List<SpaceJailRunner.Enemy.Enemy> _enemies;
        public EnemyAttack(List<SpaceJailRunner.Enemy.Enemy> enemies)
        {
            _enemies = enemies;
        }
        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].EnemyIsInSight)
                {
                    _enemies[i].DoDamage();
                }
            }
        }
    }
}