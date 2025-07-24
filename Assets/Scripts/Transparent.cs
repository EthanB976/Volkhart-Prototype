using UnityEngine;

public class Transparent : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float transparency = 0.5f;

    [SerializeField] private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Color color = renderer.material.color;
            color.a = transparency;
            renderer.material.color = color;

        }
    }


}
