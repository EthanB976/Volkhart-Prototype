using UnityEngine;

public class DisplayNextButton : MonoBehaviour
{
    [SerializeField] private GameObject nextButton;

    private void OnEnable()
    {
        TypeWriteEffect.CompleteTextRevealed += ShowNextButton;
    }

    private void OnDisable()
    {
        TypeWriteEffect.CompleteTextRevealed -= ShowNextButton;
    }

    private void ShowNextButton()
    {
        nextButton.SetActive(true);
    }

    public void HideNextButton()
    {
        nextButton.SetActive(false);
    }
}
