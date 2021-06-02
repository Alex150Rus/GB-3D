using System.Linq;
using SpaceJailRunner.Controller.Interface;
using UnityEngine;
using UnityEngine.AI;

namespace SpaceJailRunner.Controller.Move
{
    internal sealed class MoveUsingNavMeshAgent: IMove 
    {
        private NavMeshAgent _navMeshAgent;
        private Transform[] _waypoints;
        private int _currentWaypointIndex = 0;

        public MoveUsingNavMeshAgent(SpaceJailRunner.Enemy.Enemy enemy)
        {
            _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
            
            if (enemy.transform.parent.childCount > 1)
            {
                var waypoints = enemy.transform.parent.GetChild(0);
                var enemyId = waypoints.GetInstanceID();
                _waypoints = waypoints.GetComponentsInChildren<Transform>().
                    Where(transform => transform.GetInstanceID() != enemyId).ToArray();
                Debug.Log( _waypoints.Length);
                Debug.Log(_waypoints[0].name);    
            }
        }

        public void Move()
        {
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance && _waypoints != null)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
            } 
        }
    }
}