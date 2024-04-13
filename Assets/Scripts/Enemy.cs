using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.FilePathAttribute;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private Transform _patrolPoint;

    [SerializeField] private Animator _enemyAnimator;

    [SerializeField] private float _speed;

    private int _indexOfPoint = 0;

    private void Start()
    {
        _patrolPoints = new Transform[_patrolPoint.childCount];

        for (int i = 0; i < _patrolPoint.childCount; i++)
        {
            _patrolPoints[i] = _patrolPoint.GetChild(i);
        }

        _enemyAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Patrol();
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _patrolPoints[_indexOfPoint].position, _speed * Time.fixedDeltaTime);

        _enemyAnimator.SetFloat("Run", 1);

        if (Vector2.Distance(transform.position, _patrolPoints[_indexOfPoint].position) < 0.03f)
        {
            _indexOfPoint = (_indexOfPoint + 1) % _patrolPoints.Length;
        }
    }
}
