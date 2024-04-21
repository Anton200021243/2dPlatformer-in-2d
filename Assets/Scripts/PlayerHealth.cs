using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action OnPlayerDeath;

    private int _health = 2;

    public int Health => _health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Damage();
            Destroy(enemy.gameObject);
            Debug.Log(Health + " Health");
        }

        if (collision.gameObject.TryGetComponent<AidKit>(out AidKit aidKit))
        {
            AddHealth();
            Destroy(aidKit.gameObject);
            Debug.Log(Health + " Health");
        }
    }

    public void Damage()
    {
        if (_health > 1) 
            _health--;
        else
            OnPlayerDeath?.Invoke();
    }

    public void AddHealth()
    {
        _health++;
    }
}
