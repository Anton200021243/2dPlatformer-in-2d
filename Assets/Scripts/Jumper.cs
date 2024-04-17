using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HandleInput))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpForce;

    private HandleInput _handleInput;
    private Rigidbody2D _playerRigidbody;

    private float _rayDistance = 0.7f;
    private bool _isSpaceClick = false;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _handleInput = GetComponent<HandleInput>();
    }

    private void Update()
    {
        if (_handleInput.SpaceInput())
            _isSpaceClick = true;
    }

    public void Jump()
    {
        if (_isSpaceClick && IsGrounded())
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isSpaceClick = false;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(_playerRigidbody.position, Vector2.down, _rayDistance, _groundLayer);

        return hit.collider != null;
    }
}
