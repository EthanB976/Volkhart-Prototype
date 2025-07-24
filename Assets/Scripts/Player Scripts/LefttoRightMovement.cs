using UnityEngine;

public class LefttoRightMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private bool isStunned = false;
    [SerializeField] private bool isDashing = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = rb2d.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isStunned && !isDashing)
        {
            rb2d.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            spriteRenderer.flipX = rb2d.linearVelocity.x > 0f;
        }
       
    }

    public void Stunned()
    {
        isStunned = true;
    }

    public void Dashing()
    {
        isDashing = true;
    }
    public void NotStunned()
    {
        isStunned = false;
    }

    public void NotDashing()
    {
        isDashing = false;
    }
}
