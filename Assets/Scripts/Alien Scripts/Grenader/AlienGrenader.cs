using UnityEngine;
using System;

public class AlienGrenader : MonoBehaviour
{
    [SerializeField] AlienBase alienBase;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private float targetDetection = 10f;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float throwingRange = 8f;
    [SerializeField] private float retreatRange = 3f;

    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float speed = 5f;

    [SerializeField] private GameObject grenadeObject;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private float coolDown = 2f;
    [SerializeField] private float throwTimer;

    [SerializeField] public bool attackingPlayer = false;

    [SerializeField] public bool isThrowing = false;

    private void Start()
    {
        alienBase = GetComponent<AlienBase>();
    }
    private void Update()
    {
        if (alienBase.stunned)
        {
            return;
        }

        DetectPlayer();

        if (playerTransform != null)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            if (distance < retreatRange)
            {
                Retreat();
            }
            else if (distance <= throwingRange)
            {
                rb2D.linearVelocity = Vector2.zero;
                ThrowGrenade();
            }
            else
            {
                MoveTowardsPlayer();
            }

        }

    }

    private void DetectPlayer()
    {
        Collider2D hitColliders = Physics2D.OverlapCircle(transform.position, targetDetection, detectionLayer);

        if (hitColliders != null)
        {
            playerTransform = hitColliders.transform;
            attackingPlayer = true;
        }
        else
        {
            playerTransform = null;
            attackingPlayer = false;
        }
    }

    private void ThrowGrenade()
    {
        if (Time.time < throwTimer)
        {
            return;
        }

        isThrowing = true;

        throwTimer = Time.time + coolDown;

        Vector2 direction = (playerTransform.position - transform.position).normalized;

        GameObject grenade = Instantiate(grenadeObject, throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();

        rb.AddForce(direction * throwForce, ForceMode2D.Impulse);

        isThrowing = false;
    }

    private void Retreat()
    {
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb2D.linearVelocity = direction * speed;
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb2D.linearVelocity = direction * speed;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetDetection);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, retreatRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, throwingRange);

    }

}
