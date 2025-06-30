using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour
{
    public GameObject melee;
    public Animator meleeAttack;
    public bool isAttacking = false;
    public float atkDuration = 0.3f;
    public float resetDelay = 0.1f;
    public float attackDistance = 1.5f;
    public float attackSpeed = 10f;
    public Vector2 originalLocalPos;

    public GunData gunData;


    private void Start()
    {
        originalLocalPos = melee.transform.localPosition; 
        gunData = GetComponentInChildren<GunData>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            StartCoroutine(OnAttack());
        }

        if (Input.GetMouseButtonDown(1))
        {
            gunData.Shoot();
        }
    }

    private IEnumerator OnAttack()
    {
        isAttacking = true;

        melee.SetActive(true);
        meleeAttack.SetTrigger("Attack");

        Vector2 attackDir = Vector2.down;
        Vector2 targetLocalPos = originalLocalPos + attackDir * attackDistance;


        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * attackSpeed;
            melee.transform.localPosition = Vector2.Lerp(originalLocalPos, targetLocalPos, t);
            yield return null;
        }

       

        yield return new WaitForSeconds(atkDuration);
        melee.transform.localPosition = originalLocalPos;
        melee.SetActive(false);

        isAttacking = false;
    }
}
