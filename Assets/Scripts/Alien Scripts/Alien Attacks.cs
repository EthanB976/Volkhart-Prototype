using UnityEngine;

public class AlienAttacks : MonoBehaviour
{
    [SerializeField] private float Damage = 5f;
    public Rigidbody2D Rigidbody2D;
    [SerializeField] private float knockBack = 8f;

    [SerializeField] AlienBase alienBase;

    private void Start()
    {
        alienBase = GetComponent<AlienBase>();
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
                enemyrigidbody.AddForce(knockbackDirection * knockBack, ForceMode2D.Impulse);

                StartCoroutine(alienBase.SlimeDamage(0.5f));
            }
        }

    }




}
