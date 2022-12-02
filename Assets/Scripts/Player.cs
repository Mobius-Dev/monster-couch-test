using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _forcePerFrame;
    [SerializeField] private KeyCode _upKey = KeyCode.W;
    [SerializeField] private KeyCode _downKey = KeyCode.S;
    [SerializeField] private KeyCode _leftKey = KeyCode.A;
    [SerializeField] private KeyCode _rightKey = KeyCode.D;

    private Rigidbody2D _rb;

    private static string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(_upKey))
        {
            _rb.AddForce(Vector2.up * _forcePerFrame * Time.deltaTime);
        }

        if (Input.GetKey(_downKey))
        {
            _rb.AddForce(Vector2.down * _forcePerFrame * Time.deltaTime);
        }

        if (Input.GetKey(_leftKey))
        {
            _rb.AddForce(Vector2.left * _forcePerFrame * Time.deltaTime);
        }

        if (Input.GetKey(_rightKey))
        {
            _rb.AddForce(Vector2.right * _forcePerFrame * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ENEMY_TAG)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.DisableMovement();
        }
    }
}
