using UnityEngine;

namespace SpaceJailRunner.Ammos.Interface
{
    internal interface ICreateAmmoByType
    {
        public Ammo CreateAmmo(Transform parent, AmmoType type);
    }
}