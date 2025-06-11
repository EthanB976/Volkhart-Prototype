using System.Collections;
using UnityEngine;

public class AlienBase : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator Alien;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Alien.SetTrigger("slimeDamaged");
        StartCoroutine(SlimeDamage());
        if (health <= 0)
        {
            StartCoroutine(SlimeDeath());
        }
    }

    IEnumerator SlimeDamage()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.15f);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator SlimeDeath()
    {
        Alien.SetTrigger("slimeDeath");
        rb.linearVelocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
