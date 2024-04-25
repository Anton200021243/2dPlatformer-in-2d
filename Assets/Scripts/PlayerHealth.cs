using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action OnPlayerDeath;
    public event Action OnHealthChange;

    private float _maxHealth = 3;
    private float _health;
    private float _healthChange = 1;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public float HealthChange => _healthChange;

    private void Start()
    {
        _health = _maxHealth;
        OnHealthChange?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Damage();
            Destroy(enemy.gameObject);
        }

        if (collision.gameObject.TryGetComponent<AidKit>(out AidKit aidKit))
        {
            AddHealth();
            Destroy(aidKit.gameObject);
        }
    }

    public void Damage()
    {
        if (_health > 1)
            _health -= HealthChange;
        else
            OnPlayerDeath?.Invoke();

        OnHealthChange?.Invoke();
    }

    public void AddHealth()
    {
        if (_health < _maxHealth)
            _health += HealthChange;

        OnHealthChange?.Invoke();
    }
}
