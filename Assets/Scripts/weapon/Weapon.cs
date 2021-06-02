using System;

namespace SpaceJailRunner.weapon
{
    internal abstract class Weapon
    {
        protected float damage;
        public abstract void DoDamage();
    }
}