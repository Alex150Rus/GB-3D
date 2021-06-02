using System;
using UnityEngine;

namespace SpaceJailRunner.weapon
{
    internal abstract class Weapon
    {
        protected float _damage;
        public abstract void DoDamage(Health.Health health);
    }
}