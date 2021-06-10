using System.Collections.Generic;
using UnityEngine;

namespace SpaceJailRunner.Enemy.Interface
{
    internal interface IReturnStartPointsByEnemyType
    {
        public GameObject[] GetStartPoints(EnemyType enemyType);
    }
}