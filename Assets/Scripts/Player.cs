using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D _playerRigidbody;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private float _horizontalInput;
    private float _rayDistance = 0.7f;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _playerAnimator.SetBool("IsJumped", true);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(_playerRigidbody.position, Vector2.down, _rayDistance, _groundLayer);

        if (hit.collider != null)
            return true;
        else
            return false;
    }

    private void Move()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 direction = transform.right * _moveSpeed * _horizontalInput;

        FlipToDirection();

        transform.Translate(direction * Time.deltaTime);
        _playerAnimator.SetFloat("HorizontalMove", Mathf.Abs(_horizontalInput));
    }

    private void FlipToDirection()
    {
        if (_horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }
}
