using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AlienBase : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator alien;
    
    public bool stunned = false;

    [SerializeField] private Slider enemyHealthBar;

    [SerializeField] private SoundManager soundManager;

    [SerializeField] private GameObject healthBar;

    private Vector2 movement;

    private float originalXScale;

    private void Start()
    {
        health = maxHealth;
        enemyHealthBar.maxValue = maxHealth;
        enemyHealthBar.value = health;
        healthBar.SetActive(false);
        originalXScale = transform.localScale.x;
    }

    private void Update()
    {
        if (stunned)
        {
            return;
        }
        Vector2 movement = rb.linearVelocity;

        // Scale speed for animator
        float speed = movement.magnitude;
        speed = Mathf.Clamp01(speed / 5f); // adjust 5f based on how fast alien moves

        alien.SetFloat("Speed", speed);

        if (movement.x > 0.01f)        // moving right
            transform.localScale = new Vector3(Mathf.Abs(originalXScale), transform.localScale.y, transform.localScale.z);
        else if (movement.x < -0.01f)  // moving left
            transform.localScale = new Vector3(-Mathf.Abs(originalXScale), transform.localScale.y, transform.localScale.z);
    }

    public void TakeDamage(float damage)
    {
        healthBar.SetActive(true);
        health -= damage;
        enemyHealthBar.value = health;
        soundManager.DamageAlien();
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
        rb.linearVelocity = Vector3.zero;
        enemyHealthBar.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    

}
