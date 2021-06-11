using System;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Data;
using SpaceJailRunner.UserInput.Interface;

namespace SpaceJailRunner.Controller.Move
{
    internal class MoveProxy: IProvideIMoveImplementation
    {
        private IMove _movePhysics;
        private IMove _moveTransform;
        
        public MoveProxy(SpaceJailRunner.Player.Player player, PlayerData playerData, 
            (IUserInputProxy verticalInput, IUserInputProxy horizontalInput) input)
        {
            _movePhysics = new PhysicsMove(player, playerData, input);
            _moveTransform = new TransformMove(player, playerData, input);
            new MoveUsingNavMeshAgent();
        }

        public IMove GetMoveImplementation(MoveType moveType)
        {
            switch (moveType)
            {
                case MoveType.Physics:
                    return _movePhysics;
                case MoveType.Transform:
                    return _moveTransform; 
                case MoveType.NaVMeshAgent:
                    return new MoveUsingNavMeshAgent();;
                case MoveType.None:
                    throw new NotImplementedException(); 
                default:
                    throw new ArgumentOutOfRangeException(); 
            }
        }
    }
}