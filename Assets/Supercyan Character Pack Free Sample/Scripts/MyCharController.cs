using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharController : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _turnSpeed = 20;
    private Vector3 _direction;
    
    private void Awake()
    {

    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        var speed = _direction * _speed * Time.deltaTime;
        transform.Translate(speed, Space.World);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _turnSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(desiredForward);

    }
}
