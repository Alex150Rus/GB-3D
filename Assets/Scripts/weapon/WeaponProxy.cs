using UnityEngine;

namespace SpaceJailRunner.weapon
{
    internal class WeaponProxy: Weapon
    {
        private readonly Weapon _weapon;
        private readonly UnlockWeapon _unlockWeapon;

        public WeaponProxy(Weapon weapon, UnlockWeapon unlockWeapon)
        {
            _weapon = weapon;
            _unlockWeapon = unlockWeapon;
        }
        
        public override void DoDamage(Health.Health health, Transform target, Transform source)
        {
            Debug.Log(_unlockWeapon.IsUnlock);
            if (_unlockWeapon.IsUnlock)
                _weapon.DoDamage(health, target, source);
            else Debug.Log("Weapon is lock");
        }
    }
}