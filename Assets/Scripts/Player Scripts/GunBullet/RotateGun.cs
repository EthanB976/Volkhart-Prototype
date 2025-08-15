using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public float turretRotationSpeed = 150;
    public Camera mainCamera;
    public Attack attack;

    public void Update()
    {
        if (!attack.isAttacking)
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            HandleGun(mousePosition);
        }

        
    }

    public void HandleGun(Vector2 pointerPosition)
    {
        Aim(pointerPosition);
    }

    public void Aim(Vector2 inputPointerPosition)
    {
        var turretDirection = (Vector3)inputPointerPosition - transform.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
        var rotationStep = turretRotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle), rotationStep);
    }
}
