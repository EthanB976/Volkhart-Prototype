using System.Collections;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private bool stunned = false;

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] LefttoRightMovement lefttoRightMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        lefttoRightMovement = GetComponent<LefttoRightMovement>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        StartCoroutine(PlayerDamage(2f));
        if (health <= 0)
        {
            
            //StartCoroutine(PlayerDeath());
        }

    }


    private IEnumerator PlayerDamage(float duration)
    {
        stunned = true;
        playerMovement.Stunned();
        lefttoRightMovement.Stunned();
        yield return new WaitForSeconds(0.25f);
        playerMovement.NotStunned();
        lefttoRightMovement.NotStunned();
        stunned = false;

    }
}
