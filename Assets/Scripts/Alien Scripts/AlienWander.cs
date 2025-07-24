using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class AlienWander : MonoBehaviour
{
    [SerializeField] private float wanderRange = 10f;
    [SerializeField] private float wanderTimer = 10f;
    [SerializeField] private Vector2 wanderTarget;
    [SerializeField] private bool isWaiting = false;
    [SerializeField] private bool hasTarget = false;
    [SerializeField] private bool stop = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    [SerializeField] AlienBase alienBase;

    private void Start()
    {
        alienBase = GetComponent<AlienBase>();
    }
    private void Update()
    {
        if (alienBase.stunned)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, wanderRange);
    }

}
