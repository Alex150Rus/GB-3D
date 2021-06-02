using UnityEngine;

namespace SpaceJailRunner.Player
{
    internal class Player: MonoBehaviour
    {
        private Health.Health _health;

        public Health.Health Health => _health;

        private void Awake()
        {
            _health = new Health.Health();
        }
    }
}