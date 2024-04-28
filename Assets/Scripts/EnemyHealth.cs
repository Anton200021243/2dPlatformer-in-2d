using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public event Action OnEnemyHealthChange;

    private float _maxHealth = 2;
    private float _health;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void Damage()
    {
        if (_health > 1)
            _health--;
        else
            Destroy(gameObject);

        OnEnemyHealthChange?.Invoke();
    }
}
