using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour
{
    private EnemyPatrol _enemyPatrol;

    private void Start()
    {
        _enemyPatrol = GetComponent<EnemyPatrol>();
    }

    private void Update()
    {
        _enemyPatrol.Patrol();
    }
}
