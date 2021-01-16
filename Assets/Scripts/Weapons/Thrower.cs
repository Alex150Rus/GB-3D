using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] int _throwForce = 200;
    [SerializeField] int _qtyOfAmmo = 10;


    void Start()
    {
        PlayerInput.OnInputFireBtn2 += ThrowBall;
    }

    private void ThrowBall(bool throwBall)
    {
        if(throwBall && _qtyOfAmmo > 0)
        {
            GameObject ball = Instantiate(_prefab, transform.position, Quaternion.identity);       
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * _throwForce);
            _qtyOfAmmo--;
        }
    }
}
