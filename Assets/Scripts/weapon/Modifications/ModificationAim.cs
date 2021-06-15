using SpaceJailRunner.Aim.Interface;

namespace SpaceJailRunner.weapon.Modifications
{
    internal class ModificationAim : WeaponModification
    {
        private IAim _aim;

        public IAim Aim => _aim;

        public ModificationAim(IAim aim)
        {
            _aim = aim;
        }
        protected override Weapon AddModification(Weapon weapon)
        {
            if (weapon is WeaponTurret weaponTurret)
                weaponTurret.Type = WeaponType.TurretWithAim;
            return weapon;
        }

        protected override Weapon RemoveModif(Weapon weapon)
        {
            if (weapon is WeaponTurret weaponTurret)
                weaponTurret.Type = WeaponType.Turret;
            return weapon;
        }
    }
}