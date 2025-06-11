using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float Damage = 1;
    public GameObject melee;

    private void Start()
    {
        melee.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Enemy Takes Damage
        if (other.tag == "Enemy")
        {
            other.GetComponent<AlienBase>().TakeDamage(Damage);
            Debug.Log("Enemy Hit");
        }

    }
}
