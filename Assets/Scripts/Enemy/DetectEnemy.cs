using SpaceJailRunner.Enemy.Interface;
using UnityEngine;

namespace SpaceJailRunner.Enemy
{
    internal class DetectEnemy : IDetectEnemy
    {
        private float _angle = 90;

        public bool Detect(Transform source, Transform target)
        {
            Vector3 direction = target.position - source.position + Vector3.up;
            Ray ray = new Ray(source.position, direction);
            RaycastHit raycastHit;
            Debug.DrawRay(source.position, direction, Color.red, 0.01f);
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("Player") && Vector3.Angle(source.forward, direction) < _angle)
                {
                    return true;
                }
            }

            return false;
        }
    }
}