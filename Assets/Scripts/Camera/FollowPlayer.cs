using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float FollowSpeed = 2f;
    [SerializeField] private float yOffset = 1f;
    [SerializeField] private Transform target;

    // Update is called once per frame
    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -5f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
