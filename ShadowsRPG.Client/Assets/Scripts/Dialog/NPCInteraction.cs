using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{

    [SerializeField] private GameObject npcInteractionButton;
    [SerializeField] private NPCDialog npcDialog;
    public NPCDialog NPCDialog => npcDialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            npcInteractionButton.SetActive(true);
            DialogManager.Instance.NPCAvailable = this;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogManager.Instance.NPCAvailable = null;
            npcInteractionButton.SetActive(false);
        }
    }
}
