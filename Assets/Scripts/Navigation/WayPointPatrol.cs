using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class WayPointPatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private UnityEvent _patrol;

    private int _currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartPatrol();
    }

    private IEnumerator Patrol()
    {
        while (true) {
            
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
            } 
            yield return null;
        }
    }

    public void StartPatrol()
    {
        _patrol?.Invoke();
        _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
        StartCoroutine(nameof(Patrol));
    }

    public void StopPatrol()
    {
        StopCoroutine(nameof(Patrol));
    }
}
