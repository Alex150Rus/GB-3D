using System.Collections.Generic;
using SpaceJailRunner.Player;
using UnityEngine;

namespace SpaceJailRunner.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _healthPoints = 100f;
        [SerializeField] private float _playerSpeed = 15f;
        [SerializeField] private float _rotateSpeed = 150f;
        [SerializeField] private float _runSpeed = 2.49f;
        [SerializeField] private float _jumpForce = 180f;
        [SerializeField] private float _jumpStateStartsPos = 0.3f;
        [SerializeField] private PlayerState _playerStartingState= PlayerState.Idle;

        public float Speed => _playerSpeed;
        public float RotationSpeed => _rotateSpeed;
        public float RunSpeed => _runSpeed;
        public float JumpForce => _jumpForce;
        public float JumpStateStartsPos => _jumpStateStartsPos;
        public PlayerState PlayerStartingState => _playerStartingState;

        public float HealthPoints => _healthPoints;
    }
}