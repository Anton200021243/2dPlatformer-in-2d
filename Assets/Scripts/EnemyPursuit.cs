using UnityEngine;

public class EnemyPursuit : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    public Transform Target => _target;

    public void Pursue()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);
    }
}
