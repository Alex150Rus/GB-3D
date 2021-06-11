using SpaceJailRunner.JSON.Interface;
using UnityEngine;

namespace SpaceJailRunner.JSON
{
    public class Unit: MonoBehaviour, IUnit
    {
        private string _type;
        private float _health;

        public void SetType(string type)
        {
            _type = type;
        }

        public void SetHealth(float health)
        {
            _health = health;
        }
    }
}