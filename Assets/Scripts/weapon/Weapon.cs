using System;
using UnityEngine;

namespace SpaceJailRunner.weapon
{
    [Serializable]
    internal abstract class Weapon
    {
        protected float _damage;
        public abstract void DoDamage(Health.Health health, Transform target, Transform source);
    }
}