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
        TypeWriteEffect.CompleteTextRevealed -= HideNextButton;
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
