using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Thrower : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private int _throwForce = 200;
    [SerializeField] private UnityEvent _firing;


    void Start()
    {
        PlayerInput.OnInputFireBtn2 += ThrowBall;
    }

    private void ThrowBall(bool throwBall)
    {
        if(gameObject.activeSelf && throwBall && _inventory.BallsAmmoQty > 0)
        {
            _firing?.Invoke();
            GameObject ball = Instantiate(_prefab, transform.position, Quaternion.identity);       
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * _throwForce);
            _inventory.BallsAmmoQty--;
        }
    }
}
