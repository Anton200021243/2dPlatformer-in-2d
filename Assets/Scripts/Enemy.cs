using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour
{
    private EnemyPatrol _enemyPatrol;
    private EnemyPursuit _enemyPursuit;

    private float _viewDistance = 5f;

    private void Awake()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyPursuit = GetComponent<EnemyPursuit>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _enemyPursuit.Target.position) < _viewDistance)
        {
            _enemyPursuit.Pursue();
        }
        else
        {
            _enemyPatrol.Patrol();
        }
    }
}
