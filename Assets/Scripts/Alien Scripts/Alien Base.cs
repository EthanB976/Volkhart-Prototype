using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBase : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator Alien;

    public List<LayerMask> dectectionLayers;
    [SerializeField] private float targetDetection 5f;


    private void Update()
    {
        DetectPlayer();
    }


    private void DetectPlayer()
    {
        foreach (var layer in dectectionLayers)
        {
            Collider2D hitcolliders = Physics2D.OverlapCircle(transform.position, targetDetection, layer);

        }
    }


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
        
        yield return new WaitForSeconds(0.25f);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
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
