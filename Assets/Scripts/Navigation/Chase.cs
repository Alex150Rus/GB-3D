using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Chase : MonoBehaviour
{
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _chaseStopsAfterSeconds = 1.0f;
    [SerializeField] private float _chaseSpeed = 2.5f;
    [SerializeField] private State _state;
    [SerializeField] private UnityEvent _StartChase, _StopChase, _ChaseCompleted;
   

    private float _currentBlindChaseTimeSeconds = 0.0f;
    private NavMeshAgent _selfNavMeshAgent;
    private Vector3 _startingPoint;
    private State _startingState;
    private WayPointPatrol _patrolScript;
    private float _navMeshAgentStartingSpeed;

    private enum State
    {
        Idle,
        inPatrol,
    }

    private void Awake()
    {
        _selfNavMeshAgent = GetComponent<NavMeshAgent>();
        _patrolScript = GetComponent<WayPointPatrol>();
        if (_state == State.Idle) _startingPoint = transform.position;
        _startingState = _state;
        _navMeshAgentStartingSpeed = _selfNavMeshAgent.speed;
    }

    public void ChaseEnemy()
    {
        _selfNavMeshAgent.speed = _chaseSpeed;
        _currentBlindChaseTimeSeconds = 0;
        StopCoroutine(nameof(ReturnToPosition));
        _StartChase?.Invoke();

        StartCoroutine(nameof(ChaseEnemyCorutine)); 
    }

    public void StopChase()
    {
        StopCoroutine(nameof(ChaseEnemyCorutine));
        _selfNavMeshAgent.speed = _navMeshAgentStartingSpeed;

        if (_patrolScript) _StopChase.Invoke();
        else StartCoroutine(nameof(ReturnToPosition));
    }

    private IEnumerator ReturnToPosition()
    {
        while (true)
        {

            if (transform.position.x != _startingPoint.x && transform.position.z != _startingPoint.z)
                _selfNavMeshAgent.SetDestination(_startingPoint);
            else
            {
                _currentBlindChaseTimeSeconds = 0;
                _ChaseCompleted?.Invoke();
            };

            yield return null;
        }
    }

    private IEnumerator ChaseEnemyCorutine()
    {
        while (true)
        {
            _selfNavMeshAgent.SetDestination(_enemy.position);
            yield return null;
        }
    }
}
