using System.Collections.Generic;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Controller.Move;

namespace SpaceJailRunner.Controller.Enemy
{
    internal class PatrollingEnemyMoveController : IExecute
    {
        private List<IMove> _moveRealization;

        public PatrollingEnemyMoveController(List<SpaceJailRunner.Enemy.Enemy> enemies)
        {
            _moveRealization = new List<IMove>();
            foreach (var enemy in enemies)
            {
                _moveRealization.Add(new MoveUsingNavMeshAgent(enemy));
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