using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] private Animator animator;

    [SerializeField] private Vector2 movement;

    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 1f;
    [SerializeField] private float dashCoolDown = 1f;
    [SerializeField] public bool isDashing = false;
    [SerializeField] private bool canDash = true;

    [SerializeField] LefttoRightMovement ltrMovement;

    [SerializeField] LayerMask playerLayerMask;
    [SerializeField] LayerMask enemyLayerMask;

    [SerializeField] private PlayerBase playerBase;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private float soundThreshold = 0.1f;


    private void Start()
    {
        ltrMovement = GetComponent<LefttoRightMovement>();
        playerBase = GetComponent<PlayerBase>();
    }

    private void Update()
    {
        if (!isDashing)
        {
            if (!playerBase.stunned)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");



                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);

            }
            
        }
      
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
             Dash();
        }

        if (!isDashing && !playerBase.stunned)
        {
            if (movement.sqrMagnitude > soundThreshold)
            {
                if (!soundManager.footSteps.isPlaying)
                {
                    soundManager.FootSteps();

                    Debug.Log("Walking sounds");
                }
                
            }
            else
            {
                if (soundManager.footSteps.isPlaying)
                {
                    soundManager.FootStepss();
                    Debug.Log("Stopped walking");
                }
                    
            }
        }

        

    }


    private void FixedUpdate()
    {
        if (!isDashing)
        {
            if (!playerBase.stunned)
            {
                rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
            }
           
        }

        

    }

    public void Dash()
    {
        canDash = false;
        isDashing = true;
        Physics2D.IgnoreLayerCollision(7, 8, true);
        Physics2D.IgnoreLayerCollision(7, 9, true);
        Vector2 direction = movement.normalized;
        rb2d.AddForce(direction * dashSpeed);
        StartCoroutine(DashDuration());
    }

    public IEnumerator DashDuration()
    {
        yield return new WaitForSeconds(dashDuration);
        Physics2D.IgnoreLayerCollision(7, 8, false);
        Physics2D.IgnoreLayerCollision(7, 9, false);
        isDashing = false;
        StartCoroutine(DashCoolDown());
    }

    public IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
        Debug.Log("Player Dashed");
    }
}
