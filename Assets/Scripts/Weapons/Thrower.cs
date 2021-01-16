using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] Inventory _inventory;
    [SerializeField] int _throwForce = 200;


    void Start()
    {
        PlayerInput.OnInputFireBtn2 += ThrowBall;
    }

    private void ThrowBall(bool throwBall)
    {
        if(gameObject.activeSelf && throwBall && _inventory.BallsAmmoQty > 0)
        {
            GameObject ball = Instantiate(_prefab, transform.position, Quaternion.identity);       
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * _throwForce);
            _inventory.BallsAmmoQty--;
        }
    }
}
