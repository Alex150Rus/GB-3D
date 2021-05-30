using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _health;
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHealth(int healthUnits)
    {

        if (_currentHealth == _health) return;

        _currentHealth += healthUnits;
        _currentHealth = Mathf.Clamp(_currentHealth, 1, _health);

    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
