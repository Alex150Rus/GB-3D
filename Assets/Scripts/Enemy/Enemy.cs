using System;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    public class Enemy: MonoBehaviour
    {
        private Health.Health _health;
        public Health.Health Health => _health;
        private void Awake()
        {
            _health = new Health.Health();
        }
    }
}