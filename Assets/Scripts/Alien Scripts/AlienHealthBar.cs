using UnityEngine;
using UnityEngine.UIElements;

public class AlienHealthBar : MonoBehaviour
{
    [SerializeField] private Slider enemyHealthBar;

    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offSet;

    private void Awake()
    {
        camera = FindAnyObjectByType<Camera>();
    }

    private void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offSet;
    }
}
