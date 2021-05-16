using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stick : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private UnityEvent _CloseAttack;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(_damage);
            _CloseAttack?.Invoke();
        }
    }
}
