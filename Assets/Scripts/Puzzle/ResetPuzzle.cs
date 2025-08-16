using UnityEngine;

public class ResetPuzzle : MonoBehaviour
{
    [SerializeField] private WeightObject[] objectsToReset;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {

        foreach (WeightObject obj in objectsToReset)
        {
            if (!collision.CompareTag(playerTag)) return;

            if (obj != null)
                obj.ResetPosition();
        }
    }
}
