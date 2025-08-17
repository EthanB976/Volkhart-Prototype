using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AlienBases : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator Alien;
    
    public bool stunned = false;

    [SerializeField] private Slider enemyHealthBar;

    [SerializeField] private SoundManager soundManager;

    [SerializeField] private GameObject healthBar;

    private void Start()
    {
        health = maxHealth;
        enemyHealthBar.maxValue = maxHealth;
        enemyHealthBar.value = health;
        healthBar.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        healthBar.SetActive(true);
        health -= damage;
        enemyHealthBar.value = health;
        soundManager.DamageAlien();
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

    

}
