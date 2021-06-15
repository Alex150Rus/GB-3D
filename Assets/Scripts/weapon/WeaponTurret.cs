using SpaceJailRunner.Ammos;
using UnityEngine;

namespace SpaceJailRunner.weapon
{
    internal sealed class WeaponTurret: WeaponWithAmmo
    {
        private WeaponType _type = WeaponType.Turret;

        public WeaponType Type
        {
            get => _type;
            set => _type = value;
        }
        
        public Ammo Ammo
        {
            get => _ammo;
            set => _ammo = value;
        }
        
        public WeaponTurret(Ammo ammo)
        {
            _ammo = ammo;
        }
        
        public override void DoDamage(Health.Health health, Transform target, Transform source)
        {
            var ammo = _ammo.AmmoPool.GetOneAmmo(AmmoType.TurretBall);
            ammo.transform.position = new Vector3(source.position.x ,source.position.y + 0.6f, source.position.z);
            ammo.gameObject.SetActive(true);
            ammo.transform.GetComponent<Rigidbody>().AddForce((target.position - source.position)*Time.deltaTime*50, ForceMode.Impulse);
            Debug.Log(ammo.transform.position);
        }
    }
}