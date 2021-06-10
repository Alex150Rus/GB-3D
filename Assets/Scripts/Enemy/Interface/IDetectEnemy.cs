using UnityEngine;

namespace SpaceJailRunner.Enemy.Interface
{
    internal interface IDetectEnemy
    {
        public bool Detect(Transform source, Transform target);
    }
}