using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelBall : MonoBehaviour
{
    [SerializeField] private int _damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.GetComponent<Health>().TakeDamage(_damage);

        Debug.Log(collision.gameObject);
        Destroy(gameObject);
    }

}
