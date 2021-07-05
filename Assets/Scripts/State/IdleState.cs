using SpaceJailRunner.Common;
using SpaceJailRunner.Data;
using UnityEngine;

namespace SpaceJailRunner.State
{
    internal class IdleState: State
    {
        private readonly int _speed = Animator.StringToHash(NameManager.NameManager.ANIMATOR_SPEED);

        public IdleState(StateMachine stateMachine, IUnit context) : base(stateMachine, context)
        {

        }

        public override void LogicUpdate(PlayerData playerData)
        {
            base.LogicUpdate(playerData);
            if (_context is Player.Player player)
                player.PlayerAnimator.SetFloat(_speed, 0f);
        }
    }
}