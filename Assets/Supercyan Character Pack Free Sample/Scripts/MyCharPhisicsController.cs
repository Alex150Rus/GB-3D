using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MyCharPhisicsController : MonoBehaviour
{
    [SerializeField] private float _moveSpeedMultyplier = 2f;
    [SerializeField, Range(0.0f, 1.0f)] private float _percentageOfSlowDown = 0.01f;

    public float percentageOfSlowDown => (1 - _percentageOfSlowDown);
    
    private Rigidbody _body;

    private Vector3 _moveDirection;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _moveDirection.Set(horizontal, 0f, vertical);

        //двигаем
        _body.AddForce(_moveDirection * _moveSpeedMultyplier);

        //смотрим по направлению движения
        transform.LookAt(_moveDirection + transform.position);
    }

    private void LateUpdate()
    {
        if(_moveDirection == Vector3.zero)
        {
            _body.velocity = new Vector3(_body.velocity.x * percentageOfSlowDown, _body.velocity.y, _body.velocity.z * percentageOfSlowDown);
        }
    }
}
