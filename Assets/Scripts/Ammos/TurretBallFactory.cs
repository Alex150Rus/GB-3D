using SpaceJailRunner.Ammos.Interface;
using UnityEngine;

namespace SpaceJailRunner.Ammos
{
    internal class TurretBallFactory: ICreateAmmo
    {
        public Ammo CreateAmmo()
        {
            var ammo = Resources.Load<Ammo>("Prefabs/Ammo/TurrelBall");
            var ammoInstance = GameObject.Instantiate(ammo);
            return ammoInstance;
        }
    }
}