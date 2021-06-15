using UnityEngine;

namespace SpaceJailRunner.weapon.Modifications
{
    internal abstract class WeaponModification: Weapon
    {
        private Weapon _weapon;

        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon RemoveModif(Weapon weapon);

        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void RemoveModification(Weapon weapon)
        {
            _weapon = RemoveModif(weapon);
        }

        public override void DoDamage(Health.Health health, Transform target, Transform source)
        {
            _weapon.DoDamage(health, target, source);
        }
    }
}