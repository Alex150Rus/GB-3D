using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage = 50;
    [SerializeField] private GameObject _particleSystem;

    private ParticleSystem[] _particleSystems;
    private PlaySound _playSound;

    private void Start()
    {
        _particleSystems = _particleSystem.GetComponentsInChildren<ParticleSystem>();
        _playSound = GetComponent<PlaySound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health enemy = other.GetComponent<Health>();
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10000, other.transform.position, 3);
            enemy.TakeDamage(_damage);
            _playSound.Play("Explosion");
            foreach (var ps in _particleSystems)
                ps.Play();
            Destroy(gameObject, 1.01f);
        }
    }

}
