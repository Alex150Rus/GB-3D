using SpaceJailRunner.Ammos.Interface;
using SpaceJailRunner.Common;
using UnityEngine;

namespace SpaceJailRunner.Ammos
{
    internal class TurretBallFactory: ICreateAmmo
    {
        public Ammo CreateAmmo()
        {
            // var ammo = Resources.Load<Ammo>("Prefabs/Ammo/TurrelBall");
            // var ammoInstance = GameObject.Instantiate(ammo);

            #region AmmoBuilder

            var ammoInstance = GameObject.CreatePrimitive(PrimitiveType.Sphere)
                .SetScale(0.215f, 0.215f, 0.215f)
                .SetName("turretBall")
                .AddRigidbody(0.1f, 0f, 0f, false)
                .SetPhysicsMaterial("Ball")
                .SetColor(Color.red)
                .SetTriggerMode(true)
                .AddComponent<Ammo>();
            
            #endregion
            
            return ammoInstance;
        }
    }
}