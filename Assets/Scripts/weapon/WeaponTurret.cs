using System;
using SpaceJailRunner.Ammos;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace SpaceJailRunner.weapon
{
    internal sealed class WeaponTurret: WeaponWithAmmo
    {
        public Ammo Ammo
        {
            get => _ammo;
            set => _ammo = value;
        }
        
        public WeaponTurret(Ammo ammo)
        {
            _ammo = ammo;
        }
        
        public override void DoDamage(Health.Health health)
        {
            health.TakeDamage(_ammo.DamagePoints);
            Debug.Log(health.HealthPoints);
        }
    }
}