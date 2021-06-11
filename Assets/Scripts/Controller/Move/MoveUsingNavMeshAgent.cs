using System.Linq;
using SpaceJailRunner.Controller.Interface;
using SpaceJailRunner.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace SpaceJailRunner.Controller.Move
{
    internal sealed class MoveUsingNavMeshAgent: IMove 
    {
        private NavMeshAgent _navMeshAgent;
        private SpaceJailRunner.Enemy.Enemy _enemy;
        private Transform[] _waypoints;
        private int _currentWaypointIndex = 0;

        public void SetMovingUnit(SpaceJailRunner.Enemy.Enemy enemy)
        {
            _navMeshAgent = enemy.NavMeshAgent;
            _enemy = enemy;
            
            if (enemy.transform.parent.childCount > 1)
            {
                var waypoints = enemy.transform.parent.GetChild(0);
                var enemyId = waypoints.GetInstanceID();
                _waypoints = waypoints.GetComponentsInChildren<Transform>().
                    Where(transform => transform.GetInstanceID() != enemyId).ToArray();
            }
        }

        public void Move()
        {
            _enemy.State = EnemyState.Run;
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance && _waypoints != null)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
            } 
        }
    }
}