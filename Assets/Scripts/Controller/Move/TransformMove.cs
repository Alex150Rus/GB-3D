using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.UserInput.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.Player;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.Move
{
    internal class TransformMove: IMove
    {
        private float _speed;
        private float _verticalAxis;
        private float _horizontalAxis;
        private Vector3 _destination;
        private SpaceJailRunner.Player.Player _player;
        
        public TransformMove(SpaceJailRunner.Player.Player player, PlayerData playerData, 
            (IUserInputProxy verticalInput, IUserInputProxy horizontalInput) input)
        {
            _speed = playerData.Speed;
            _player = player;
            input.verticalInput.OnAxisChange += SetHorizontalAxis;
           input.horizontalInput.OnAxisChange += SetVerticalAxis;

        }
        public void Move()
        {
            _destination.Set(_horizontalAxis, 0f, _verticalAxis);
            if (_destination.magnitude > 0)
                _player.State = PlayerState.Run;
            else
            {
                _player.State = PlayerState.Idle;
            }
               
            
            _destination.Normalize();
            _player.transform.Translate(_destination * Time.deltaTime * _speed, Space.World);
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