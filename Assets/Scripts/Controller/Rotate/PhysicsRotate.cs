using SpaceJailRunner.Controller.Rotate.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.Rotate
{
    internal sealed class PhysicsRotate: IRotate
    {
        private Rigidbody _rigidbody;
        private float _speed;
        private float _verticalAxis;
        private float _horizontalAxis;
        private Vector3 _destination;
        public PhysicsRotate(SpaceJailRunner.Player.Player player, PlayerData playerData, 
            (IUserInputProxy verticalInput, IUserInputProxy horizontalInput) input)
        {
            _rigidbody = player.GetComponent<Rigidbody>();
            _speed = playerData.RotationSpeed;
            input.verticalInput.OnAxisChange += SetHorizontalAxis;
            input.horizontalInput.OnAxisChange += SetVerticalAxis;

        }
        public void Rotate()
        {
            _destination.Set(_horizontalAxis, 0f, _verticalAxis);
            
            Vector3 desiredForward = 
                Vector3.RotateTowards(_rigidbody.transform.forward, _destination,_speed, 0f);
            _rigidbody.transform.rotation = Quaternion.LookRotation(desiredForward);
        }
        
        private void SetHorizontalAxis(float axis)
        {
            _horizontalAxis = axis;
        }

        private void SetVerticalAxis(float axis)
        {
            _verticalAxis = axis;
        }
    }
}