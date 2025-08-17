using UnityEngine;

public class FreezeAllRigidBody : MonoBehaviour
{
    public GameObject[] enemies;
    public LefttoRightMovement lefttoRightMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FreezeAll()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            enemy.GetComponent<Animator>().enabled = false;
        }

        GameObject player = GameObject.FindWithTag("Player");       
        
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        player.GetComponent<Animator>().enabled = false;
        lefttoRightMovement.enabled = false;

    }

    public void UnfreezeAll()
    {
        GameObject player = GameObject.FindWithTag("Player");

        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        player.GetComponent<Animator>().enabled = true;
        lefttoRightMovement.enabled = true;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            enemy.GetComponent<Animator>().enabled = true;
        }
    }
}
