using SpaceJailRunner.Aim.Interface;
using UnityEngine;

namespace SpaceJailRunner.Aim
{
    internal class Aim : IShowAim
    {
        private AimType _aimType;
        
        public Aim(AimType aimType)
        {
            _aimType = aimType;
        }

        public void ShowAim()
        {
            Debug.LogFormat("this aim is of {0} type", _aimType);
        }
    }
}