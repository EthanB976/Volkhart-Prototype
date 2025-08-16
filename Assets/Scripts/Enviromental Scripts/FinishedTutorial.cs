using UnityEngine;

public class FinishedTutorial : MonoBehaviour
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
            playerTasks.FinishedTutorial();
            trigger.SetActive(false);
        }
    }
}
