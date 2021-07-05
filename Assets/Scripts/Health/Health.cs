using System;

namespace SpaceJailRunner.Health
{
    [Serializable]
    public class Health: IHealth
    {
        private float _healthPoints;
        public event Action<float> OnHealthChanged;
        public event Action OnDeath;

        public float HealthPoints
        {
            get => _healthPoints;
            set
            {
                _healthPoints = value;
                OnHealthChanged?.Invoke(_healthPoints - value);
                if(_healthPoints <= 0)
                    OnDeath?.Invoke();
            }
        }
        public void TakeDamage(float damage)
        {
            HealthPoints -= damage;
        }
    }
}