using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Player;
using UnityEngine;

namespace SpaceJailRunner.Controller.Cameras
{
    internal sealed class PlayerFollowingCamera : ILateExecute
    {

        private readonly Camera _camera;
        private Transform _player;
        
        public PlayerFollowingCamera(Camera camera, Transform player)
        {
            _camera = camera;
            _player = player;
        }

        public void LateExecute(float deltaTime)
        {
            if (_player.gameObject.activeSelf)
                _camera.transform.position = _player.transform.position;
        }
    }
}