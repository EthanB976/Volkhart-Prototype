using System.Collections;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 5f;


    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(PlayerDamage(0.5f));
        if (health <= 0)
        {
            //StartCoroutine(PlayerDeath());
        }
    }


    private IEnumerator PlayerDamage(float duration)
    {
        yield return new WaitForSeconds(0.25f);
    }
}
