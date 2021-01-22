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
            transform.LookAt(_enemy.position);
            onTargetIsVisible?.Invoke();            
        } else onTargetIsInvisible?.Invoke();
    }

}
