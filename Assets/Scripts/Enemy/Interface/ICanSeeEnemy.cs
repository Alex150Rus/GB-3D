using SpaceJailRunner.Player.Interface;
using UnityEngine;

namespace SpaceJailRunner.Enemy.Interface
{
    internal interface ICanSeeEnemy
    {
        public bool EnemyIsInSight { get; set; }
        public void SetTarget(IHaveHealth target);
    }
}