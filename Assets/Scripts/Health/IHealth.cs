using System;
using SpaceJailRunner.Listeners.Interface;

namespace SpaceJailRunner.Health
{
    internal interface IHealth
    {
        public event Action<float> OnHealthChanged;
        public event Action OnDeath;

        public float HealthPoints
        {
            get;
            set;
        }
        public void TakeDamage(float damage);
    }
}