using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HandleInput))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Animator _animator;
    private HandleInput _handleInput;

    private float _playerRotationFlip = 180;
    private float _horizontalInput;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _handleInput = GetComponent<HandleInput>();
    }

    private void Update()
    {
        _horizontalInput = _handleInput.InputHorizontal();
    }

    public void Move()
    {
        Vector3 direction = transform.right * _moveSpeed * _horizontalInput;

        FlipToDirection();

        transform.Translate(direction * Time.deltaTime);
        _animator.SetFloat(PlayerAnimatorData.Params.HorizontalMove, Mathf.Abs(_horizontalInput));
    }

    private void FlipToDirection()
    {
        if (_horizontalInput < 0)
            transform.rotation = Quaternion.Euler(0, _playerRotationFlip, 0);
        else
            transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
