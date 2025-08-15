using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Object = UnityEngine.Object;

public class TypeWriteEffect : MonoBehaviour
{
    public TMP_Text textBox;

    private int currentVisibleCharacterIndex;
    private Coroutine typewriterCoroutine;
    private bool readyForNewText = true;

    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _interpunctuationDelay;

    [SerializeField] private float charactersPerSecond = 20f;
    [SerializeField] private float interpunctuationDelay = 0.5f;

    public bool CurrentlySkipping { get; private set; }
    private WaitForSeconds skipDelay;

    [SerializeField] private bool quickSkip;
    [SerializeField][Min(1)] private int skipSpeedup = 5;

    private WaitForSeconds textBoxFullEventDelay;
    [SerializeField][Range(0.1f, 0.5f)] private float sendDoneDelay = 0.25f;

    public static event Action CompleteTextRevealed;
    public static event Action<char> CharacterRevealed;

    private bool textFinishedDisplaying;

    public GameObject dialogueUI;

    private void Awake()
    {
        textBox = GetComponent<TMP_Text>();

        _simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
        _interpunctuationDelay = new WaitForSeconds(interpunctuationDelay);

        skipDelay = new WaitForSeconds(1 / (charactersPerSecond * skipSpeedup));
        textBoxFullEventDelay = new WaitForSeconds(sendDoneDelay);
    }

   private void OnEnable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(PrepareForNewText);
    }

    private void OnDisable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(PrepareForNewText);
    } 

    private void Update()
    {
        if (dialogueUI.activeSelf == true)
        {
            if (textFinishedDisplaying == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    textFinishedDisplaying = false;
                    dialogueUI.SetActive(false);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (textBox.maxVisibleCharacters != textBox.maxVisibleCharacters - 1)
                {
                    Skip();
                }
            }
        }
    }

    public void PrepareForNewText(Object obj)
    {
        if (!readyForNewText)
        {
            return;
        }

        readyForNewText = false;

        if (typewriterCoroutine != null)
        {
            StopCoroutine(typewriterCoroutine);
        }


        textBox.maxVisibleCharacters = 0;
        currentVisibleCharacterIndex = 0;

        typewriterCoroutine = StartCoroutine(TypeWriter());
    }

    private IEnumerator TypeWriter()
    {
        TMP_TextInfo textInfo = textBox.textInfo;

        while (currentVisibleCharacterIndex < textInfo.characterCount + 1)
        {
            var lastCharacterIndex = textInfo.characterCount - 1;

            if (currentVisibleCharacterIndex == lastCharacterIndex)
            {
                textBox.maxVisibleCharacters++;
                yield return textBoxFullEventDelay;
                CompleteTextRevealed?.Invoke();
                readyForNewText = true;
                textFinishedDisplaying = true;
                yield break;
            }

            char character = textInfo.characterInfo[currentVisibleCharacterIndex].character;

            textBox.maxVisibleCharacters++;

            if (!CurrentlySkipping && (character == '?' || character == '.' || character == ',' || character == ':' || character == ';' || character == '!' || character == '-'))
            {
                yield return _interpunctuationDelay;
            }
            else
            {
                yield return CurrentlySkipping ? skipDelay : _simpleDelay;
            }

            CharacterRevealed?.Invoke(character);
            currentVisibleCharacterIndex++;

        }
    }

    void Skip()
    {
        if (CurrentlySkipping)
        { return; }

        CurrentlySkipping = true;

        if (!quickSkip)
        {
            StartCoroutine(SkipSpeedUpReset());
            return;
        }

        StopCoroutine(typewriterCoroutine);
        textBox.maxVisibleCharacters = textBox.textInfo.characterCount;
        readyForNewText = true;
        CompleteTextRevealed?.Invoke();
    }

    private IEnumerator SkipSpeedUpReset()
    {
        yield return new WaitUntil(() => textBox.maxVisibleCharacters == textBox.textInfo.characterCount - 1);
        CurrentlySkipping = false;
    }
}

