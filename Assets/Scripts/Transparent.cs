using UnityEngine;

public class Transparent : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float transparency = 0.5f;

    [SerializeField] private Renderer renderers;

    private void Start()
    {
        renderers = GetComponent<Renderer>();

        if (renderers != null)
        {
            Color color = renderers.material.color;
            color.a = transparency;
            renderers.material.color = color;

        }
    }


}
