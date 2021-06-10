using System;

namespace SpaceJailRunner.Health
{
    [Serializable]
    public sealed class Health: IHealth
    {
        private float _healthPoints;
        public event Action<float> OnHealthChanged;
        public float HealthPoints
        {
            get => _healthPoints;
            set
            {
                _healthPoints = value;
                OnHealthChanged?.Invoke(_healthPoints - value);
            }
        }
        public void TakeDamage(float damage)
        {
            HealthPoints -= damage;
        }
    }
}