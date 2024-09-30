using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] protected float speed;
    
    protected Rigidbody2D Rigidbody;

    protected float Horizontal;
    protected float Vertical;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        Rigidbody.velocity = new Vector2(Horizontal * speed, Vertical * speed);
    }
}