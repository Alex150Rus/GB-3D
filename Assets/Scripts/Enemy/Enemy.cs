using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _enemy;
    [SerializeField] private int _enemyDistance = 23;
    [SerializeField] private UnityEvent onTargetIsVisible;
    [SerializeField] private UnityEvent onTargetIsInvisible;

    private enum State
    {
        SeeEnemyFirstTime,
        SeeingEnemy,
        StopSeeingEnemy,
        DontSeeEnemy
    }

    private void Start()
    {
        _state = State.DontSeeEnemy;
    }

    private State _state;

    private void Update()
    {
        FindEnemy();
    }

    private void FindEnemy()
    {
        RaycastHit hit;

        Vector3 direction = _enemy.transform.position - transform.position;
      
        if (Physics.Raycast(transform.position, direction, out hit, _enemyDistance) && hit.collider.CompareTag(_enemy.tag))
        {
            if (_state == State.DontSeeEnemy || _state == State.StopSeeingEnemy)
            {
                _state = State.SeeEnemyFirstTime;
                //таким образом отправим событие единожды
                onTargetIsVisible?.Invoke();
            }
            else if (_state == State.SeeEnemyFirstTime) _state = State.SeeingEnemy;

            transform.LookAt(_enemy.position);
                  
        } else
        {
            if (_state == State.SeeEnemyFirstTime || _state == State.SeeingEnemy)
            {
                _state = State.StopSeeingEnemy;
                //таким образом отправим событие единожды
                onTargetIsInvisible?.Invoke();
            }
            else if (_state == State.StopSeeingEnemy) _state = State.DontSeeEnemy;
        }

            
    }

}
