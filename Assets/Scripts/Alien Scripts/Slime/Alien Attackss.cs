using UnityEngine;

public class AlienAttackss : MonoBehaviour
{
    [SerializeField] private float Damage = 5f;
    public Rigidbody2D Rigidbody2D;

    [SerializeField] AlienBases alienBase;

    private void Start()
    {
        alienBase = GetComponent<AlienBases>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Enemy Takes Damage
        if (other.tag == "Player")      
        {
            other.GetComponent<PlayerBase>().TakeDamage(Damage);

            Rigidbody2D enemyrigidbody = other.GetComponent<Rigidbody2D>();

            if (enemyrigidbody != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                float knockForce = 8f;
                enemyrigidbody.AddForce(knockbackDirection * knockForce, ForceMode2D.Impulse);

                StartCoroutine(alienBase.SlimeDamage(0.5f));
            }
        }

    }




}
