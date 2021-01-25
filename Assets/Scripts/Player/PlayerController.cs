using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeedMultiplyer = 135.0f;
    [SerializeField] private float _jumpForce = 18000f;
    [SerializeField] private float _jumpStateStartsPos = 0.3f;

    [SerializeField] private Inventory _inventory;

    private Rigidbody _body;
    private Animator _animator;
    private Vector3 _moveDirection;
    private State _state;

    private static readonly int _speed = Animator.StringToHash("speed");
    private static readonly int _fire = Animator.StringToHash("fire");

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _state = State.Idle;
    }

    private void Start()
    {   
        PlayerInput.OnInput += Move;
        PlayerInput.OnInputSpaceBtn += Jump;
        _state = State.Idle;
    }

    private void Update()
    {
        //поворачиваем перса;
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _moveDirection, 5f * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(desiredForward);
        Animate();
    }

    private void Move(Vector3 input)
    {
        
        if (input.magnitude > 0)
        {
            _state = State.Run;
            _moveDirection.Set(input.x * _moveSpeedMultiplyer, 0f, input.z * _moveSpeedMultiplyer);
            //двигаем
            _body.AddForce(_moveDirection);
        } else
        {
            _state = State.Idle;
        }
    }

    private void Jump(bool jump)
    {
        if (jump && transform.position.y < _jumpStateStartsPos) {
            _body.AddForce(Vector3.up * _jumpForce);
            //переключение состояний прыжка
            _state = State.Jump;
        } 
    }

    public void Fire()
    {
        _state = State.Firing;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.CompareTag(_inventory.BallAmmoTag))
        {
            Destroy(collisionObject);
            _inventory.BallsAmmoQty++;
            
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_inventory.FirstAidTag))
        {
            Destroy(other.gameObject);
            _inventory.FirstAidQty++;
        }
        else if (other.CompareTag(_inventory.KeyCardTag))
        {
            Destroy(other.gameObject);
            _inventory.KeyCardsQty++;
        }
    }

    private void Animate()
    {
        switch (_state)
        {
            case State.Jump:
            case State.Idle:
                _animator.SetFloat(_speed, 0f);
                break;
            case State.Run:
                _animator.SetFloat(_speed, _moveSpeedMultiplyer);
                break;
            case State.Firing:
                _animator.SetTrigger(_fire);
                break;
            default:
                break;
        }
    }

}
