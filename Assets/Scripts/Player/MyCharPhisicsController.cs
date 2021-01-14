using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MyCharPhisicsController : MonoBehaviour
{
    [SerializeField] private float _moveSpeedMultiplyer = 15.0f;
    [SerializeField] private float _jumpForce = 18000f;
    [SerializeField] private float _jumpStateStartsPos = 0.3f;
    
    private Rigidbody _body;
    private Vector3 _moveDirection;

    private enum State
    {
        Idle,
        Jump,
    }

    private State _state;

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

        if (transform.position.y > _jumpStateStartsPos) _state = State.Jump;
        else _state = State.Idle;
    }

    private void Move(Vector3 input)
    {
        _moveDirection.Set(input.x * _moveSpeedMultiplyer, 0f, input.z * _moveSpeedMultiplyer);
        //двигаем
        _body.AddForce(_moveDirection);
    }

    private void Jump(bool jump)
    {
        if (jump && _state == State.Idle) _body.AddForce(Vector3.up * _jumpForce);
    }
}
