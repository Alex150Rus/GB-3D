using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.UserInput.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.Move
{
    internal class PhysicsMove: IMove
    {
        private Rigidbody _rigidbody;
        private float _speed;
        private float _verticalAxis;
        private float _horizontalAxis;
        private Vector3 _destination;
        
        public PhysicsMove(SpaceJailRunner.Player.Player player, PlayerData playerData, 
            (IUserInputProxy verticalInput, IUserInputProxy horizontalInput) input)
        {
            _rigidbody = player.GetComponent<Rigidbody>();
            _speed = playerData.Speed;
            input.verticalInput.OnAxisChange += SetHorizontalAxis;
           input.horizontalInput.OnAxisChange += SetVerticalAxis;

        }
        public void Move()
        {
            _destination.Set(_horizontalAxis, 0f, _verticalAxis);
            _destination.Normalize();
            _rigidbody.AddForce(_destination * _speed);
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