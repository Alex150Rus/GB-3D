using SpaceJailRunner.Controller.Jump.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.UserInput.Interface;
using UnityEngine;

namespace SpaceJailRunner.Controller.Jump
{
    internal class JumpPhysics: IJump
    {
        private Rigidbody _rigidbody;
        private float _jumpForce;
        private float _jumpStartPosition;
        private SpaceJailRunner.Player.Player _player;
        
        
        public JumpPhysics(SpaceJailRunner.Player.Player player, PlayerData playerData, IUserInputKeDownProxy jumpInput)
        {
            _rigidbody = player.GetComponent<Rigidbody>();
            _jumpForce = playerData.JumpForce;
            _jumpStartPosition = playerData.JumpStateStartsPos;
            _player = player;
            jumpInput.OnBtnDown += Jump;

        }

        public void Jump()
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(_rigidbody.transform.position, Vector3.down, out hitInfo, 2f))
            {
                if (hitInfo.distance < _jumpStartPosition)
                {
                    _rigidbody.AddForce(Vector3.up * _jumpForce);
                }
            }
        }

        private void Jump(bool jump)
        {
            if(jump)
                Jump();
        }
    }
}