using System.Collections.Generic;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Move;

namespace SpaceJailRunner.Controller.Enemy
{
    internal class PatrollingEnemyMoveController : IExecute
    {
        private List<IMove> _moveRealization;

        public PatrollingEnemyMoveController(List<SpaceJailRunner.Enemy.Enemy> enemies, 
            IProvideIMoveImplementation moveProxy)
        {
            _moveRealization = new List<IMove>();
            foreach (var enemy in enemies)
            {
                var item = moveProxy.GetMoveImplementation(MoveType.NaVMeshAgent);
                _moveRealization.Add(item);
                if (item is MoveUsingNavMeshAgent moveNavMeshAgent)
                    moveNavMeshAgent.SetMovingUnit(enemy);
                
            }
        }
        
        public void Execute(float deltaTime)
        {
            foreach (var moveRealization in _moveRealization)
            {
                moveRealization.Move();
            }
        }
    }
}