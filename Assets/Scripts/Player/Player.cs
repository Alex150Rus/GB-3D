using System;
using SpaceJailRunner.Common;
using SpaceJailRunner.Player.Interface;
using SpaceJailRunner.State;
using UnityEngine;

namespace SpaceJailRunner.Player
{
    [Serializable]
    internal class Player: MonoBehaviour, IHaveHealth, IUnit
    {
        private Health.Health _health;
        
        private StateMachine _movementSm;
        private IdleState _idleState;
        private RunningState _runningState;
        private JumpingState _jumpingState;
        
        private Animator _playerAnimator;

        public Health.Health Health => _health;

        public StateMachine MovementSM => _movementSm;
        public IdleState IdleState => _idleState;
        public RunningState RunningState => _runningState;
        public JumpingState JumpingState => _jumpingState;

        public Animator PlayerAnimator => _playerAnimator;

        private void Awake()
        {
            _health = new Health.Health();
            _playerAnimator = GetComponent<Animator>();

            _movementSm = new StateMachine();
            _idleState = new IdleState(_movementSm, this);
            _runningState = new RunningState(_movementSm, this);
            _jumpingState = new JumpingState(_movementSm, this);
            _movementSm.Initialize(_idleState);
        }
    }
}