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
        [SerializeField] private float _moveSpeedMultiplyer = 9.0f;
        [SerializeField] private float _jumpForce = 180f;
        [SerializeField] private float _jumpStateStartsPos = 0.3f;
        [SerializeField] private PlayerState _playerStartingState= PlayerState.Idle;

        public float Speed => _playerSpeed;
        public float RotationSpeed => _rotateSpeed;
        public float MoveSpeedMultiplyer => _moveSpeedMultiplyer;
        public float JumpForce => _jumpForce;
        public float JumpStateStartsPos => _jumpStateStartsPos;
        public PlayerState PlayerStartingState => _playerStartingState;

        public float HealthPoints => _healthPoints;
    }
}