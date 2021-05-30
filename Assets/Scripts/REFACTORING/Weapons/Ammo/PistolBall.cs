using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBall : MonoBehaviour
{
    [SerializeField] private int _damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
        Destroy(gameObject);
    }
}
