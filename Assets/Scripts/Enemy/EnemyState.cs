using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    public enum EnemyState
    {
        Idle = 0,
        Walk = 1,
        Run = 2,
        Jump = 3,
        Firing = 4,
        SeeEnemyFirstTime = 5,
        SeeingEnemy = 6,
        StopSeeingEnemy = 7,
        DontSeeEnemy = 8,
        CloseAttack = 9,
    }
}
    
