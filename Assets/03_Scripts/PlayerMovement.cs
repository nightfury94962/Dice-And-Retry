using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("HorizontalSpeed", movement.x);
        animator.SetFloat("VerticalSpeed", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
