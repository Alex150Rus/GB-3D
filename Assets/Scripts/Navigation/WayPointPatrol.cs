using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent.SetDestination(_waypoints[0].position);
        StartCoroutine(Patrol());
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
        _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
        StartCoroutine(Patrol());
    }

    public void StopPatrol()
    {
        StopCoroutine(Patrol());
    }
}
