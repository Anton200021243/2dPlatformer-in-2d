using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _patrolPoint;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private float _speed;

    private Transform[] _patrolPoints;
    private int _indexOfPoint = 0;
    private float _distanceToPoint = 0.03f;

    private void Start()
    {
        _patrolPoints = new Transform[_patrolPoint.childCount];

        for (int i = 0; i < _patrolPoint.childCount; i++)
        {
            _patrolPoints[i] = _patrolPoint.GetChild(i);
        }

        _enemyAnimator = GetComponent<Animator>();
        _enemyAnimator.SetFloat("Run", 1);
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _patrolPoints[_indexOfPoint].position, _speed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, _patrolPoints[_indexOfPoint].position) < _distanceToPoint)
        {
            _indexOfPoint = (++_indexOfPoint) % _patrolPoints.Length;
        }
    }
}
