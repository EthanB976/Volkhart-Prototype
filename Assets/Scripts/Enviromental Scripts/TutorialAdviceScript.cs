using TMPro;
using UnityEngine;

public class TutorialAdviceScript : MonoBehaviour
{
    public string text;
    public GameObject tutorialAdviceGameObject;
    public TextMeshProUGUI tutorialAdviceText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            tutorialAdviceGameObject.gameObject.SetActive(true);
            tutorialAdviceText.text = text;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            tutorialAdviceGameObject.gameObject.SetActive(false);
        }
    }
}
