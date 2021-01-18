using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _throwForce= 50;
    [SerializeField] private float _distance = 23;
    [SerializeField] private float _fireIntervalInSeconds = 1f;
    [SerializeField] private float _ballStartHeight = 0.8f;

    private Vector3 _ballStartPosition;
    
    private enum State
    {
        TargetIsInvisible,
        TargetIsVisible,
    }

    private State _state;


    private void Start()
    {
        _state = State.TargetIsInvisible;
        _ballStartPosition.Set(transform.position.x, transform.position.y + _ballStartHeight, transform.position.z);

        StartCoroutine(Fire());
    }

    private void Update()
    {
        FindEnemy();
    }

    private void FindEnemy()
    {
        RaycastHit hit;

        Vector3 direction = (_enemy.transform.position-transform.position).normalized;
        if (Physics.Raycast(transform.position, direction, out hit, _distance) && hit.collider.CompareTag(_enemy.tag) )
        {
            transform.LookAt(_enemy.position);
            _state = State.TargetIsVisible;
        } else
        {
            _state = State.TargetIsInvisible;
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            while (_state == State.TargetIsVisible)
            {
                
                GameObject ball = Instantiate(_prefab, _ballStartPosition, Quaternion.identity);
                ball.GetComponent<Rigidbody>().AddForce((_enemy.transform.position - transform.position) * _throwForce);
                yield return new WaitForSeconds(_fireIntervalInSeconds);
            }
            yield return null;
        }

    } 

}
