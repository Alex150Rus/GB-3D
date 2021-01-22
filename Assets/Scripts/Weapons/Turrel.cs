using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _throwForce= 50;
    [SerializeField] private float _fireIntervalInSeconds = 1f;

    private bool _isFiring = false;
    
    private void Start()
    {
       StartCoroutine(Fire());
    }

    public void StartFiring(bool isFiring)
    {
        _isFiring = isFiring;
    }


    private IEnumerator Fire()
    {
        while (true)
        {
            while (_isFiring)
            {
                
                GameObject ball = Instantiate(_prefab, transform.position, Quaternion.identity);
                ball.GetComponent<Rigidbody>().AddForce((_enemy.transform.position - transform.position + Vector3.up) * _throwForce);
                yield return new WaitForSeconds(_fireIntervalInSeconds);
            }
            yield return null;
        }

    } 

}
