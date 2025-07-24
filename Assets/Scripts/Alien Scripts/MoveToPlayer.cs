using Unity.VisualScripting;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private float targetDetection = 5f;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private AlienBase alienBase;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

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
            MoveTowardsPlayer();
        }

    }

    private void DetectPlayer()
    {
        Collider2D hitColliders = Physics2D.OverlapCircle(transform.position, targetDetection, detectionLayer);

        if (hitColliders != null)
        {
            playerTransform = hitColliders.transform;
        }
        else
        {
            playerTransform = null;
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
