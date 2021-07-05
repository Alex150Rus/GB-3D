using SpaceJailRunner.Common;
using SpaceJailRunner.Data;
using UnityEngine;

namespace SpaceJailRunner.State
{
    internal class RunningState: State
    {
        private readonly int _speed = Animator.StringToHash(NameManager.NameManager.ANIMATOR_SPEED);
        
        public RunningState(StateMachine stateMachine, IUnit context) : base(stateMachine, context)
        {
        
        }

        public override void LogicUpdate(PlayerData playerData)
        {
            base.LogicUpdate(playerData);
            if (_context is Player.Player player)
                player.PlayerAnimator.SetFloat(_speed, playerData.RunSpeed);
        }
    }
}