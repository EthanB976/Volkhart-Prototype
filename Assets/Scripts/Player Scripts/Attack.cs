using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour
{
    public GameObject melee;
    public Animator meleeAttack;
    public bool isAttacking = false;
    public float attackDuration = 0.25f;
    public float resetDelay = 0.1f;
    public float attackDistance = 1.5f;
    public float attackSpeed = 10f;
    public Vector2 originalLocalPos;

    public InventoryManager inventory;

    [SerializeField] private SoundManager soundManager;

    private void Start()
    {
        melee.SetActive(false);
    }

    public IEnumerator OnAttack()
    {
        if (isAttacking)
            yield break;

        isAttacking = true;

        soundManager.SwordSwing();
        melee.SetActive(true);

        meleeAttack.SetTrigger("Attack");
        
        yield return new WaitForSeconds(attackDuration);

        melee.SetActive(false);

        yield return new WaitForSeconds(resetDelay);

        isAttacking = false;
    }


}
