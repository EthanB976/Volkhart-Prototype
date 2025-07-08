using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] private Animator animator;

    [SerializeField] private Vector2 movement;

    [SerializeField] private Transform Aim;
    [SerializeField] private Transform Weapon;
    [SerializeField] private Transform Gun;

    [SerializeField] private bool isStunned = false;

    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 1f;
    [SerializeField] private float dashCoolDown = 1f;
    [SerializeField] private bool isDashing = false;
    [SerializeField] private bool canDash = true;

    [SerializeField] LefttoRightMovement ltrMovement;

    private void Start()
    {
        ltrMovement = GetComponent<LefttoRightMovement>();
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
      
         if (Input.GetKeyDown(KeyCode.F) && canDash)
         {
             Dash();
         }

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
        if (isDashing)
        {
            return;
        }

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

    public void Dash()
    {
        canDash = false;
        isDashing = true;
        ltrMovement.Dashing();
        Vector2 direction = movement.normalized;
        rb2d.AddForce(direction * dashSpeed);
        StartCoroutine(DashDuration());
    }

    public IEnumerator DashDuration()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        ltrMovement.NotDashing();
        StartCoroutine(DashCoolDown());
    }

    public IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
        Debug.Log("Player Dashed");
    }
}
