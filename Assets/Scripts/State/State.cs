using SpaceJailRunner.Common;
using SpaceJailRunner.Data;

namespace SpaceJailRunner.State
{
    internal abstract class State
    {
        protected StateMachine _stateMachine;
        protected IUnit _context;

        public State(StateMachine stateMachine, IUnit context)
        {
            _stateMachine = stateMachine;
            _context = context;
        }


        public virtual void Enter()
        {
            
        }

        public virtual void HandleInput()
        {
            
        }

        public virtual void LogicUpdate(PlayerData playerData)
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            
        }

        public virtual void Exit()
        {
            
        }
    }
}