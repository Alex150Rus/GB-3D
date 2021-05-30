using System.Collections.Generic;
using SpaceJailRunner.Enemy.Interface;
using SpaceJailRunner.Tags;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    internal struct PatrollingEnemyStartPoints : IReturnStartPoints
    {
        public GameObject[] GetStartPoints()
        {
            return GameObject.FindGameObjectsWithTag(TagNamesManager.ENEMY_PATROLLING_STARTING_POINT_TAG);
        }
    }
}