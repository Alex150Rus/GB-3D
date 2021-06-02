using System.Collections.Generic;
using SpaceJailRunner.Enemy.Interface;
using SpaceJailRunner.NameManager.Tags;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    internal struct StaticEnemyStartPoints : IReturnStartPoints
    {
        public GameObject[] GetStartPoints()
        {
            return GameObject.FindGameObjectsWithTag(TagNamesManager.ENEMY_STATIC_STARTING_POINT_TAG);
        }
    }
}