using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _forcePerFrame;
    [SerializeField] private float _minDistanceToEscape;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private Color _disabledColor;

    private Rigidbody2D _rb;
    private bool _canMove = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_canMove) return;

        float distanceToPlayer = Vector2.Distance(transform.position, GameManager.Instance.Player.position);

        if (distanceToPlayer < _minDistanceToEscape && _rb.velocity.magnitude < _maxVelocity)
        {
            Vector2 moveVector = (transform.position - GameManager.Instance.Player.position).normalized;
            _rb.AddForce(moveVector * _forcePerFrame * Time.deltaTime);          
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    public void DisableMovement()
    {
        _canMove = false;
        _rb.velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = _disabledColor;
    }
}
