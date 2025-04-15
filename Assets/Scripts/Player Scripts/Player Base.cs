using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 5f;


    public void TakeDamage()
    {
        //take damage
    }
}
