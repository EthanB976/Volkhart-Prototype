using UnityEngine;
using System;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] AlienBase alienBase;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private float targetDetection = 10f;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float shootingRange = 8f;
    [SerializeField] private float retreatRange = 3f;

    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float speed = 5f;

    [SerializeField] private AlienGunData alienGunData;
    [SerializeField] private AlienAimGun alienAimGun;

    [SerializeField] public bool shootingPlayer = false;

    private void Start()
    {
        alienBase = GetComponent<AlienBase>();
        alienGunData = GetComponentInChildren<AlienGunData>();

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
            else if (distance <= shootingRange)
            {
                rb2D.linearVelocity = Vector2.zero;
                Shoot();
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
            shootingPlayer = true;
            alienAimGun.playerTransform = playerTransform;
        }
        else
        {
            playerTransform = null;
            alienAimGun.playerTransform = playerTransform;
            shootingPlayer = false;
        }
    }

    private void Shoot()
    {
        alienGunData.Shoot();
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
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }

}
