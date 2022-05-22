using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : Singleton<DialogManager>
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Image dialogIcon;
    [SerializeField] private TextMeshProUGUI dialogName;
    [SerializeField] private TextMeshProUGUI dialogText;

    public NPCInteraction NPCAvailable { get; set; }

    private Queue<string> dialogsSequence;
    private bool animatedDialog;
    private bool shownLeave;

    private void Start()
    {
        dialogsSequence = new();
    }

    private void Update()
    {
        if (NPCAvailable == null)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ConfigureDialogPanel(NPCAvailable.NPCDialog);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shownLeave)
            {
                TriggerDialogPanel(false);
                shownLeave = false;
                return;
            }

            if (animatedDialog)
            {
                ContinueDialog();
            }
        }
    }

    public void TriggerDialogPanel(bool status)
    {
        dialogPanel.SetActive(status);
    }

    private void ConfigureDialogPanel(NPCDialog npcDialog)
    {
        TriggerDialogPanel(true);
        LoadDialogSequence(npcDialog);

        dialogIcon.sprite = npcDialog.Icon;
        dialogName.text = $"{npcDialog.Name}:";
        ShowAnimatedText(npcDialog.Salute);
        
    }

    private void LoadDialogSequence(NPCDialog npcDialog)
    {
        if (npcDialog.Conversation == null || npcDialog.Conversation.Length <= 0)
            return;

        for (int i = 0; i < npcDialog.Conversation.Length; i++)
        {
            dialogsSequence.Enqueue(npcDialog.Conversation[i].Phrase);
        }

    }

    private void ContinueDialog()
    {
        if(NPCAvailable == null)
            return;

        if (shownLeave)
            return;

        if(dialogsSequence.Count == 0)
        {
            string leave = NPCAvailable.NPCDialog.Leave;
            ShowAnimatedText(leave);
            shownLeave = true;
            return;
        }

        string nextDialog = dialogsSequence.Dequeue();
        ShowAnimatedText(nextDialog);
    }
    
    private IEnumerator AnimateDialog(string phrase)
    {
        animatedDialog = false;
        dialogText.text = "";
        var letters = phrase.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            dialogText.text += letters[i];
            yield return new WaitForSeconds(0.03f);
        }

        animatedDialog = true;
    }

    private void ShowAnimatedText(string phrase)
    {
        StartCoroutine(AnimateDialog(phrase));
    }
}
