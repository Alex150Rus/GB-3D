using SpaceJailRunner.Health;
using SpaceJailRunner.Listeners.Interface;
using UnityEngine;

namespace SpaceJailRunner.Listeners
{
    internal class DeadEnemiesListener: IHealthListener
    {

        private int _qtyOfDeadEnemies = 0;
        
        public void Add(IHealth health)
        {
            health.OnDeath += ShowQtyOfDeadEnemies;
        }

        public void Remove(IHealth health)
        {
            health.OnDeath += ShowQtyOfDeadEnemies;
        }

        private void ShowQtyOfDeadEnemies()
        {
            _qtyOfDeadEnemies++;
            Debug.Log(_qtyOfDeadEnemies);
        }
        
        
    }
}