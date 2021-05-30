using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Player;
using SpaceJailRunner.Data;
using UnityEngine;

namespace SpaceJailRunner.Controller.Cameras
{
    internal sealed class PlayerFollowingCamera : ILateExecute
    {

        private readonly Camera _camera;
        private readonly Transform _player;
        private readonly Vector3 _offsetPosition;
        
        public PlayerFollowingCamera(Camera camera, Transform player, CameraData cameraData)
        {
            _camera = camera;
            _player = player;
            _offsetPosition = cameraData.Position;
        }

        public void LateExecute(float deltaTime)
        {
            _camera.transform.position = _player.transform.position + _offsetPosition;
        }
    }
}