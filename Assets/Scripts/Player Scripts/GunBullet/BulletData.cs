using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletData : MonoBehaviour
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
        rb2d.linearVelocity = transform.up * bulletSpeed;
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
        Debug.Log("Bullet Hit");

        if (other.tag == "Enemy")
        {
            other.GetComponent<AlienBase>().TakeDamage(bulletDamage);
            Debug.Log("Enemy Hit");

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
