using System;
using SpaceJailRunner.Ammos;
using UnityEditor.Timeline.Actions;

namespace SpaceJailRunner.weapon
{
    internal sealed class WeaponTurret: WeaponWithAmmo
    {
        public event Action<float> OnDoingDamage;
        
        public Ammo Ammo
        {
            get => _ammo;
            set => _ammo = value;
        }
        
        WeaponTurret(Ammo ammo)
        {
            _ammo = ammo;
        }
        
        public override void DoDamage()
        {
            OnDoingDamage?.Invoke(_ammo.DamagePoints);
        }
    }
}