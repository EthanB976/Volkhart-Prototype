using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float explosionTimer = 3f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private int damage = 50;
    [SerializeField] private LayerMask damageLayer;
    [SerializeField] private Rigidbody2D rb;

    [Header("Visuals")]
    [SerializeField] private GameObject radiusPrefab;
    private GameObject radiusInstance;

    private Vector3 targetPosition;
    private bool hasReachedTarget = false;

    private bool hasExploded = false;

    [SerializeField] private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();

        // Lock target position at throw time
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            targetPosition = playerObj.transform.position;

        // Visual indicator
        if (radiusPrefab != null)
        {
            radiusInstance = Instantiate(radiusPrefab, transform.position, Quaternion.identity);
            radiusInstance.transform.localScale = Vector3.one * (explosionRadius * 2f);

            SpriteRenderer sr = radiusInstance.GetComponent<SpriteRenderer>();

        }
    }

    private void Update()
    {
        // Move and stop at target
        if (!hasReachedTarget)
        {
            if (Vector2.Distance(transform.position, targetPosition) <= 0.1f)
            {
                rb.linearVelocity = Vector2.zero;
                hasReachedTarget = true;
                soundManager.GranadeSlam();
            }
        }

        if (radiusInstance != null)
            radiusInstance.transform.position = transform.position;

        // Countdown timer
        explosionTimer -= Time.deltaTime;
        if (explosionTimer <= 0f && !hasExploded)
        {
            hasExploded = true;  // prevent multiple calls
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("Grenade exploded!"); // confirm it's called
        soundManager.GrenadeExplosion();
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, damageLayer);

        foreach (Collider2D other in hits)
        {

            if (other.tag == "Player")
            {
                other.GetComponent<PlayerBase>().TakeDamage(damage);

                Rigidbody2D enemyrigidbody = other.GetComponent<Rigidbody2D>();

                if (enemyrigidbody != null)
                {
                    
                    Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                    float knockForce = 50f;

                    enemyrigidbody.AddForce(knockbackDirection * knockForce, ForceMode2D.Impulse);
                }
            }
        }



        if (radiusInstance != null) Destroy(radiusInstance);
        Destroy(gameObject);
    }
}
