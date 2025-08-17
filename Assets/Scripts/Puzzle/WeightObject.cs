using UnityEngine;

public class WeightObject : MonoBehaviour
{
    public int weight = 0;

    [HideInInspector] public Vector3 startPosition;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private float soundThreshold = 0.1f;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soundManager.MovingObjects();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
              soundManager.MovingObjectss();
        }
    }
}
