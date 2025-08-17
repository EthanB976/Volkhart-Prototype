using Unity.VisualScripting;
using UnityEngine;

public class MoveToPlayers : MonoBehaviour
{
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private float targetDetection = 5f;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private AlienBases alienBase;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    [SerializeField] public bool movingToPlayer = false;

    private void Start()
    {
        alienBase = GetComponent<AlienBases>();
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
            MoveTowardsPlayer();
        }

    }

    private void DetectPlayer()
    {
        Collider2D hitColliders = Physics2D.OverlapCircle(transform.position, targetDetection, detectionLayer);

        if (hitColliders != null)
        {
            playerTransform = hitColliders.transform;
            movingToPlayer = true;
        }
        else
        {
            playerTransform = null;
            movingToPlayer = false;
        }
    }


    private void MoveTowardsPlayer()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetDetection);

    }
}
