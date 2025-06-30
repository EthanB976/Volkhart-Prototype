using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] private Animator animator;

    private Vector2 movement;

    [SerializeField] private Transform Aim;
    [SerializeField] private Transform Weapon;
    [SerializeField] private Transform Gun;

    [SerializeField] private bool isStunned = false;

    private void Update()
    {
        if (!isStunned)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");


            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            RotateAim();
        }
        
    }

    private void RotateAim()
    {
        if (movement.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            Aim.rotation = Quaternion.Euler(0, 0, angle);
            Weapon.rotation = Quaternion.Euler(0, 0, angle);
            Gun.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void FixedUpdate()
    {
        if (!isStunned)
        {
            rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        
    }

    public void Stunned()
    {
        isStunned = true;
    }

    public void NotStunned()
    {
        isStunned = false;
    }
}
