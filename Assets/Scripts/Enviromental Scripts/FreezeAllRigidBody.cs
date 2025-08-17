using UnityEngine;

public class FreezeAllRigidBody : MonoBehaviour
{
    public GameObject[] enemies;
    public LefttoRightMovement lefttoRightMovement;
    public Rigidbody2D playerRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lefttoRightMovement = FindAnyObjectByType<LefttoRightMovement>();

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

        playerRB.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        playerRB.GetComponent<Animator>().enabled = false;
        lefttoRightMovement.enabled = false;

    }

    public void UnfreezeAll()
    {
        playerRB.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        playerRB.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        playerRB.GetComponent<Animator>().enabled = true;
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
