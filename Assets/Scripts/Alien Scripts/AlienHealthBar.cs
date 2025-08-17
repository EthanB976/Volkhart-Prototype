using UnityEngine;
using UnityEngine.UIElements;

public class AlienHealthBar : MonoBehaviour
{
    [SerializeField] private Slider enemyHealthBar;

    [SerializeField] private Camera cameras;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offSet;

    private void Awake()
    {
        cameras = FindAnyObjectByType<Camera>();
    }

    private void Update()
    {
        transform.rotation = cameras.transform.rotation;
        transform.position = target.position + offSet;
    }
}
