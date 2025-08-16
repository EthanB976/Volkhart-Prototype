using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private int correctWeight;
    [SerializeField] private GameObject wrongColour;
    [SerializeField] private GameObject rightColour;

    public bool IsCorrect { get; private set; } = false;

    private void Start()
    {
        wrongColour.SetActive(false);
        rightColour.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeightObject obj = collision.GetComponent<WeightObject>();

        if (obj != null)
        {
            CheckWeight(obj.weight);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        WeightObject obj = collision.GetComponent<WeightObject>();

        if (obj != null)
        {
            wrongColour.SetActive(false);
            rightColour.SetActive(false);

            IsCorrect = false;
        }
    }

    private void CheckWeight(int weight)
    {
        if (weight == correctWeight)
        {
            rightColour.SetActive(true);
            IsCorrect = true;
            Debug.Log("Success");
        }
        else
        {
            wrongColour.SetActive(true);
            IsCorrect = false;
            Debug.Log("Fail");
        }
    }
}
