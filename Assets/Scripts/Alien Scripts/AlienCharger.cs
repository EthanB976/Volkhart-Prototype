using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class AlienCharger : MonoBehaviour
{

    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private float targetDetection = 10f;
    [SerializeField] private float chargeRange = 9f;
    [SerializeField] private float chargeTimer = 1f;
    [SerializeField] private float chargeDuration = 5f;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Vector2 chargeDirection;
    [SerializeField] public bool isCharging;
    [SerializeField] private float speed = 5f;
    [SerializeField] public bool isPreparingCharging = false;

    [SerializeField] private AlienBase alienBase;
    [SerializeField] private GameObject warning;

    [SerializeField] private SoundManager soundManager;

    private void Start()
    {
        alienBase = GetComponent<AlienBase>();
        warning.SetActive(false);
    }

    private void Update()
    {
        if (alienBase.stunned)
        {
            return;
        }

        DetectPlayer();

        if (playerTransform != null)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            if (distance < chargeRange)
            {
                Charge();
            }
            else
            {
                MoveTowardsPlayer();
            }

        }

    }

    private void DetectPlayer()
    {
        Collider2D hitColliders = Physics2D.OverlapCircle(transform.position, targetDetection, detectionLayer);

        if (hitColliders != null)
        {
            playerTransform = hitColliders.transform;
        }
        else
        {
            playerTransform = null;
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb2D.linearVelocity = direction * speed;
    }

    private void Charge()
    {
        if (isCharging || isPreparingCharging)
        {
            return;
        }

        StartCoroutine(ChargingTime());
    }

    IEnumerator ChargingTime()
    {
        isPreparingCharging = true;
        warning.SetActive(true);

        rb2D.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(chargeTimer);

        chargeDirection = (playerTransform.position - transform.position).normalized;

        isPreparingCharging = false;
        warning.SetActive(false);
        isCharging = true;

        rb2D.linearVelocity = chargeDirection * speed * 5f;
        soundManager.Woosh();

        yield return new WaitForSeconds(chargeDuration);

        rb2D.linearVelocity = Vector2.zero;
        isCharging = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, targetDetection);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, chargeRange);


    }

}
