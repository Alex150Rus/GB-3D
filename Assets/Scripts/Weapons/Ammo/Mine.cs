using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health enemy = other.GetComponent<Health>();
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10000, other.transform.position, 3);
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

}
