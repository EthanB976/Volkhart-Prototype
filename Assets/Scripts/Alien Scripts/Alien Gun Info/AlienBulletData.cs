using UnityEngine;

public class AlienBulletData : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletDamage = 10f;
    [SerializeField] private float maxDistance = 10f;

    [SerializeField] private Vector2 startPosition;
    [SerializeField] private float distanceTravelled = 0;
    [SerializeField] private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rb2d.linearVelocity = transform.right * bulletSpeed;
    }

    private void Update()
    {
        distanceTravelled = Vector2.Distance(transform.position, startPosition);

        if (distanceTravelled > maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb2d.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerBase>().TakeDamage(bulletDamage);

            Rigidbody2D enemyrigidbody = other.GetComponent<Rigidbody2D>();

            if (enemyrigidbody != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                float knockForce = 5f;

                enemyrigidbody.AddForce(knockbackDirection * knockForce, ForceMode2D.Impulse);
            }
        }
    }
}
