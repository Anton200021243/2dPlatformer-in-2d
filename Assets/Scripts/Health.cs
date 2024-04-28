using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action PlayerDead;
    public event Action HealthChanged;

    [SerializeField] private float _maxHealth;

    private float _health;
    private float _healthChange = 1;

    public float HealthPoints => _health;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            PlayerDamage(_healthChange);
        }
        
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            EnemyDamage(_healthChange);
        }

        if (collision.gameObject.TryGetComponent<AidKit>(out AidKit aidKit))
        {
            AddHealth(_healthChange);
            Destroy(aidKit.gameObject);
        }
    }

    public void PlayerDamage(float damage)
    {
        if (_health > 1)
            _health -= damage;
        else
            PlayerDead?.Invoke();

        HealthChanged?.Invoke();
    }

    public void EnemyDamage(float damage)
    {
        if (_health > 1)
            _health -= damage;
        else
            Destroy(gameObject);

        HealthChanged?.Invoke();
    }

    public void AddHealth(float heal)
    {
        if (_health < _maxHealth)
            _health += heal;

        HealthChanged?.Invoke();
    }
}
