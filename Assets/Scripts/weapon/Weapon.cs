using System;
using SpaceJailRunner.weapon.Interface;
using UnityEngine;

namespace SpaceJailRunner.weapon
{
    [Serializable]
    internal abstract class Weapon : IDoDamage
    {
        protected float _damage;
        public abstract void DoDamage(Health.Health health, Transform target, Transform source);
    }
}