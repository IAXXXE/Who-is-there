using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    [Header("Text")]
    public GameObject dialogue;
    public TextMeshProUGUI dialogueText;
    public GameObject narration;
    public TextMeshProUGUI narrationText;
    public GameObject thinkL;
    public TextMeshProUGUI thinkLText;
    public GameObject closeUpL;
    public GameObject thinkR;
    public TextMeshProUGUI thinkRText;
    public GameObject closeUpR;

    public DialogueData_SO dialogueData;

    [Header("Image")]
    public GameObject character;
    public Image characterImage;
    public GameObject strange;
    public Image strangeImage;

    public int currDialogueIdx;

    private void Awake()
    {
        dialogue.SetActive(true);
        narration.SetActive(false);
        thinkL.SetActive(false);
        thinkR.SetActive(false);    
        closeUpL.SetActive(false);
        closeUpR.SetActive(false);
        strange.SetActive(false);
        

        EventHandler.ShowNextDialogueEvent += OnShowNextDialogue;
        EventHandler.ShowOptionEvent += OnShowOption;
        EventHandler.HideOptionEvent += OnHideOption;
        EventHandler.SelectOptionEvent += OnSelectOption;

        currDialogueIdx = 0;
        dialogueText.text = dialogueData.dialoguePieces[0].text;
    }

    private void OnDestroy()
    {
        EventHandler.ShowNextDialogueEvent -= OnShowNextDialogue;
        EventHandler.ShowOptionEvent -= OnShowOption;
        EventHandler.HideOptionEvent -= OnHideOption;
        EventHandler.SelectOptionEvent -= OnSelectOption;
    }

    private void OnShowNextDialogue()
    {

        if (dialogueData.dialoguePieces.Count > currDialogueIdx + 1)
        {
            narration.SetActive(false);
            currDialogueIdx++;
            Player.Instance.stat = PlayerStat.Listen;
        }
        else if(dialogueData.dialoguePieces[currDialogueIdx].hsaOption)
        {
            narrationText.text = "想";
            narration.SetActive(true);
            Player.Instance.stat = PlayerStat.Think;
        }
        else
        {
            UpdateDialogueData(dialogueData.dialoguePieces[currDialogueIdx].dialogueData);
        }

        dialogueText.text = dialogueData.dialoguePieces[currDialogueIdx].text;
    }

    private void OnShowOption(bool isLeft)
    {
        if(isLeft)
        {
            thinkL.SetActive(true);
            thinkLText.text = dialogueData.dialoguePieces[currDialogueIdx].opition[0].text;
        }
        else
        {
            thinkR.SetActive(true);
            thinkRText.text = dialogueData.dialoguePieces[currDialogueIdx].opition[1].text;
        }
    }

    private void OnHideOption(bool isLeft)
    {
        if(isLeft)
        {
            thinkL.SetActive(false);
        }
        else
        {
            thinkR.SetActive(false);
        }
    }

    private void OnSelectOption(bool isLeft)
    {
        Player.Instance.stat = PlayerStat.Choose;
        DialogueOption option;
        if(isLeft)
        {
            option = dialogueData.dialoguePieces[currDialogueIdx].opition[0];
        }
        else
        {
            option = dialogueData.dialoguePieces[currDialogueIdx].opition[1];
        }
        narrationText.text = option.narrationText;
        dialogueData = option.nextDialogue;
        ShowStrange(option);
        StartCoroutine(NextDialogue());
    }

    private IEnumerator NextDialogue()
    {
        // continue
        yield return new WaitForSeconds(3f);
        narration.SetActive(false);
        strange.SetActive(false);
        closeUpL.SetActive(false);
        closeUpR.SetActive(false);
        thinkL.SetActive(false);
        thinkR.SetActive(false);

        currDialogueIdx = 0;
        dialogueText.text = dialogueData.dialoguePieces[currDialogueIdx].text;

        // EventHandler.CallFadeInEvent(1f);
    }

    private void ShowStrange(DialogueOption option)
    {
        if(option.Image != null)
        {
            strangeImage.sprite = option.Image;
            strangeImage.SetNativeSize();
            strange.GetComponent<RectTransform>().anchoredPosition = option.ImagePos;
            strange.SetActive(true);
        }

        if(option.closeUp != null)
        {
            if(thinkL.activeSelf == true)
            {
                closeUpR.GetComponent<Image>().sprite = option.closeUp;
                closeUpR.SetActive(true);
            }
            else
            {
                closeUpL.GetComponent<Image>().sprite = option.closeUp;
                closeUpL.SetActive(true);
            }
        }
    }

    private void UpdateDialogueData(DialogueData_SO newDialogueData)
    {
        dialogueData = newDialogueData;
        currDialogueIdx = 0;
        dialogueText.text = dialogueData.dialoguePieces[currDialogueIdx].text;
    }

}
