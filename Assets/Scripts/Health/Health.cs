using System;
using SpaceJailRunner.HUD;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceJailRunner.Health
{
    [Serializable]
    internal sealed class Health: IHealth
    {
        private float _healthPoints;
        
        public HealthBelongs HealthBelongs { get; set; }
        public event Action<float> OnHealthChanged;
        public float HealthPoints
        {
            get => _healthPoints;
            set
            {
                _healthPoints = value;
                OnHealthChanged?.Invoke(_healthPoints - value);
                if (_healthPoints <=0 && HealthBelongs == HealthBelongs.Enemy)
                    ExecuteEvents.Execute<PanelOne>(
                        GameObject.Find(NameManager.NameManager.PANEL_ONE), 
                        null, 
                        (x,y)=>x.Message1());
            }
        }
        public void TakeDamage(float damage)
        {
            HealthPoints -= damage;
        }
    }
}