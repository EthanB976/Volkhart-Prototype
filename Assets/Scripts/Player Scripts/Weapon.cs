using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float Damage = 1;
    public GameObject melee;
    public Rigidbody2D Rigidbody2D;

    private void Start()
    {
        melee.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Enemy Takes Damage
        if (other.tag == "Enemy")
        {
            other.GetComponent<AlienBase>().TakeDamage(Damage);
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
