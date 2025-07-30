using UnityEngine;

public class AlienAttacks : MonoBehaviour
{
    [SerializeField] private float Damage = 5f;
    public Rigidbody2D Rigidbody2D;

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
            Debug.Log("Attack player");
            other.GetComponent<PlayerBase>().TakeDamage(Damage);
            Debug.Log("Player Hit");

            Rigidbody2D enemyrigidbody = other.GetComponent<Rigidbody2D>();

            if (enemyrigidbody != null)
            {
                //Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                //float knockForce = 5f;
                //Debug.Log("apply force");
                //enemyrigidbody.AddForce(knockbackDirection * knockForce, ForceMode2D.Impulse);

                StartCoroutine(alienBase.SlimeDamage(0.5f));
            }
        }

    }




}
