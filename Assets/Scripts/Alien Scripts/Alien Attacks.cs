using UnityEngine;

public class AlienAttacks : MonoBehaviour
{
    [SerializeField] private float Damage = 5f;
    public Rigidbody2D Rigidbody2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Enemy Takes Damage
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerBase>().TakeDamage(Damage);
            Debug.Log("Player Hit");

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
