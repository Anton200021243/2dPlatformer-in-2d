using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour
{
    private EnemyPatrol _enemyPatrol;

    private void Awake()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
    }

    private void Update()
    {
        _enemyPatrol.Patrol();
    }
}
