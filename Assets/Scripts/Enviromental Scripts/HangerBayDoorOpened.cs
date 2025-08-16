using UnityEngine;

public class HangerBayDoorOpened : MonoBehaviour
{
    [SerializeField] private PlayerTasks playerTasks;
    [SerializeField] private GameObject trigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerTasks.FixedFinalDoor();
            trigger.SetActive(false);
        }
    }
}
