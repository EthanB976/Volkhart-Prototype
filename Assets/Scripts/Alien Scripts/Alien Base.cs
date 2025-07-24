using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using UnityEngine.UI;

public class AlienBase : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator Alien;

   

    [SerializeField] private float wanderRange = 10f;
    [SerializeField] private float wanderTimer = 10f;
    [SerializeField] private Vector2 wanderTarget;
    [SerializeField] private bool isWaiting = false;
    [SerializeField] private bool hasTarget = false;
    [SerializeField] private bool stop = false;
    public bool stunned = false;

    [SerializeField] private Slider enemyHealthBar;

    private void Start()
    {
        health = maxHealth;
        enemyHealthBar.maxValue = maxHealth;
        enemyHealthBar.value = health;
    }

    private void Update()
    {
        if (stunned)
        {
            return;
        }

        Wander();

    }


    

    public void Wander()
    {
        if (isWaiting || stop)
        {
            return;
        }

        if (!hasTarget)
        {
            Vector2 randomTarget = Random.insideUnitCircle * wanderRange;
            wanderTarget = (Vector2)transform.position + randomTarget;
            hasTarget = true;
        }

        Vector2 direction = (wanderTarget - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if (Vector2.Distance(transform.position, wanderTarget) < 0.5f && hasTarget)
        {
            hasTarget = false;
            stop = true;
            StartCoroutine(WanderStop());
        }


    }

    public IEnumerator WanderStop()
    {
        isWaiting = true;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(2);
        isWaiting = false;
        stop = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        enemyHealthBar.value = health;
        Alien.SetTrigger("slimeDamaged");
        StartCoroutine(SlimeDamage(0.5f));
        if (health <= 0)
        {
            StartCoroutine(SlimeDeath());
        }
    }

    public IEnumerator SlimeDamage(float duration)
    {
        stunned = true;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(0.25f);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        stunned = false;
    }

    public IEnumerator SlimeDeath()
    {
        Alien.SetTrigger("slimeDeath");
        rb.linearVelocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);

        enemyHealthBar.gameObject.SetActive(false);

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere (transform.position, wanderRange);
    }

}
