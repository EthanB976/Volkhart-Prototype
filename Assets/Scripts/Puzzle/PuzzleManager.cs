using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PressurePlate[] plates;
    [SerializeField] private GameObject door;

    private void Update()
    {
        bool allCorrect = true;
        foreach (PressurePlate plate in plates)
        {
            if (!plate.IsCorrect)
            {
                allCorrect = false;
                break;
            }
        }

        door.SetActive(!allCorrect);
    }
}
