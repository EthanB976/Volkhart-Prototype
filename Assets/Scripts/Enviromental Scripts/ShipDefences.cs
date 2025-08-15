using UnityEngine;

public class ShipDefences : MonoBehaviour
{
    public KeyTasks keyTasks;
    private bool inArea;

    // Update is called once per frame
    void Update()
    {
        if (inArea == true)
        {
            TurnDefencesOff();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = false;
        }
    }

    private void TurnDefencesOff()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyTasks.TurnOffShipDefences();
        }
    }
}
