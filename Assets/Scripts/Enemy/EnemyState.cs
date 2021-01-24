using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyStates
{
    public enum State
    {
        Idle,
        Walk,
        Run,
        Jump,
        Firing,
        SeeEnemyFirstTime,
        SeeingEnemy,
        StopSeeingEnemy,
        DontSeeEnemy,
        CloseAttack,
    }
}
    
