using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueTriggerBox;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private string dialogueText;
    public TypeWriteEffect typeWriteEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueUI.SetActive(true);
            typeWriteEffect.textBox.maxVisibleCharacters = 0;
            typeWriteEffect.textBox.text = dialogueText;
            dialogueTriggerBox.SetActive(false);
        }
    }
}
