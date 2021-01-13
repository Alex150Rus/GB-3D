using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MyCharPhisicsController : MonoBehaviour
{
    [SerializeField] private float _moveSpeedMultyplier = 15.0f;
    
    private Rigidbody _body;

    private Vector3 _moveDirection;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        PlayerInput.OnInput += Move;
        PlayerInput.OnInputSpaceBtn += Jump;
    }

    private void Update()
    {
        //поворачиваем перса;
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _moveDirection, 5f * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(desiredForward);
    }

    private void Move(Vector3 input)
    {
        _moveDirection.Set(input.x * _moveSpeedMultyplier, 0f, input.z * _moveSpeedMultyplier);
        //двигаем
        _body.AddForce(_moveDirection);
    }

    private void Jump(bool jump)
    {
        if (jump) _body.AddForce(Vector3.up * 250f);
    }
}
