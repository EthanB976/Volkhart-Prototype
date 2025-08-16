using UnityEngine;

public class WeightObject : MonoBehaviour
{
    public int weight = 0;

    [HideInInspector] public Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position; // store starting location
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
