using UnityEngine;

namespace SpaceJailRunner.Enemy.Interface
{
    internal interface ICreateEnemy
    {
        public Enemy Create(Transform transform);
    }
}