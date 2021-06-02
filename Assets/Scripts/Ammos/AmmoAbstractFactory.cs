using System;
using SpaceJailRunner.Ammos.Interface;
using UnityEngine;

namespace SpaceJailRunner.Ammos
{
    internal sealed class AmmoAbstractFactory: ICreateAmmoByType
    {
        private TurretBallFactory _turretBallFactory;
        
        public AmmoAbstractFactory()
        {
            _turretBallFactory = new TurretBallFactory();
        }
        
        public Ammo CreateAmmo(Transform parent, AmmoType type)
        {
            switch (type)
            {
                case AmmoType.TurretBall:
                    return _turretBallFactory.CreateAmmo(parent);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}