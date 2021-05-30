using UnityEngine;

namespace SpaceJailRunner.Data
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "Data/CameraData", order = 0)]
    public class CameraData : ScriptableObject
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Vector3 _rotation;

        public Vector3 Position => _offset;
    }
}