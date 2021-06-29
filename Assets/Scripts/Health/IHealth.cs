using System;

namespace SpaceJailRunner.Health
{
    internal interface IHealth
    {
        public HealthBelongs HealthBelongs
        {
            get;
            set;
        }
        
        public event Action<float> OnHealthChanged;

        public float HealthPoints
        {
            get;
            set;
        }
        public void TakeDamage(float damage);
    }
}