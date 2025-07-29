using UnityEngine;
using System;

public class AlienAimGun : MonoBehaviour
{
    public Transform playerTransform;

    private void Update()
    {
        if (playerTransform == null)
        {
            return;
        }

        Vector2 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
