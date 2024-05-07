using System;
using System.Collections;
using UnityEngine;

public class Vampiric : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyMask;

    private Health _playerHealth;

    public event Action UsedSpell;

    private float _vampiricHealth = 0.2f;
    private float _vampiricRadius = 6f;
    private float _vampiricTick = 1;
    private float _vampiricCouldown = 15f;

    public float VampiricCouldown => _vampiricCouldown;

    private bool isCouldown = false;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCouldown == false)
        {
            UseSpell();
        }
    }

    private void UseSpell()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _vampiricRadius, Vector2.zero, _vampiricRadius, _enemyMask);

        if (hit == true && hit.transform.TryGetComponent<Health>(out Health enemyHealth))
        {
            StartCoroutine(Vampire(enemyHealth));
        }
    }

    private IEnumerator VampireCouldown()
    {
        isCouldown = true;
        UsedSpell?.Invoke();
        yield return new WaitForSeconds(_vampiricCouldown);
        isCouldown = false;
    }

    private IEnumerator Vampire(Health enemyHealth)
    {
        int counterTicks = 0;
        int castTime = 6;

        StartCoroutine(VampireCouldown());

        while (counterTicks != castTime)
        {
            if (enemyHealth != null)
            {
                enemyHealth.EnemyDamage(_vampiricHealth);
                _playerHealth.AddHealth(_vampiricHealth);
            }

            counterTicks++;
            yield return new WaitForSeconds(_vampiricTick);
        }
    }
}
