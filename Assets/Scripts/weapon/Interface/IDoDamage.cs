using UnityEngine;

namespace SpaceJailRunner.weapon.Interface
{
    internal interface IDoDamage
    {
        public void DoDamage(Health.Health health, Transform target, Transform source);
    }
}