using UnityEngine;

namespace SpaceJailRunner.Ammos
{
    internal class Ammo: MonoBehaviour
    {
        public float DamagePoints => damagePoints;
        protected float damagePoints = 5.0f;
    }
}