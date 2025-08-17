using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private RawImage fadeImage;
    [SerializeField] private float timer;

    void Awake()
    {
        fadeImage = GetComponent<RawImage>();
        Color c = fadeImage.color;
        c.a = 1f; // start fully opaque
        fadeImage.color = c;
    }

    void Update()
    {
        if (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
        }
        else
        {
            // Disable after fade
            gameObject.SetActive(false);
        }
    }
}
