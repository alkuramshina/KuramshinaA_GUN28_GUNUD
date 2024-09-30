using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] protected float speed;
    
    private Rigidbody2D _rigidbody;

    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_horizontal * speed, _vertical * speed);
    }
}