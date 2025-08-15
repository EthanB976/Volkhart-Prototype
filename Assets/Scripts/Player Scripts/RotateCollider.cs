using UnityEngine;

public class RotateCollider : MonoBehaviour
{
    public Rigidbody2D playerrb;
    public Transform targetTransform;


    private void Update()
    {
        Vector2 movedir = playerrb.linearVelocity;

        if (movedir.sqrMagnitude > 0.1f)
        {
            float angle = Mathf.Atan2(movedir.y, movedir.x) * Mathf.Rad2Deg;
            targetTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
