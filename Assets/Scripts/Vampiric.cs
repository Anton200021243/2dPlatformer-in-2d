using System.Collections;
using UnityEngine;

public class Vampiric : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyMask;

    private Health _playerHealth;

    private float _vampiricHealth = 0.2f;
    private float _vampiricRadius = 100f;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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

    private IEnumerator Vampire(Health enemyHealth)
    {
        yield return new WaitForSeconds(2);

        while (true)
        {
            enemyHealth.EnemyDamage(_vampiricHealth);
            _playerHealth.AddHealth(_vampiricHealth);
        }
    }
}
