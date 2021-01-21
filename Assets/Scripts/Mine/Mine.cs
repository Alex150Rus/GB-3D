using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage = 100;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health enemy = other.GetComponent<Health>();
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

}
