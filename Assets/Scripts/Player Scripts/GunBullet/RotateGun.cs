using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public float turretRotationSpeed = 150;
    public Camera mainCamera;
    public Transform player;
    public Transform gun;

    public void Update()
    {

        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        HandleGun(mousePosition);

    }

    public void HandleGun(Vector2 pointerPosition)
    {
        Aim(pointerPosition);
    }

    public void Aim(Vector2 inputPointerPosition)
    {
        var turretDirection = (Vector3)inputPointerPosition - player.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
        var rotationStep = turretRotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle), rotationStep);


        if (turretDirection.x < 0)
        {
            gun.localRotation = Quaternion.Euler(180f, 0, -45f);
        }
        else
        {
            gun.localRotation = Quaternion.Euler(0, 0, -45f); 
        }
    }
}
