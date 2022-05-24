using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Quests")]
    [SerializeField] private Quest[] availableQuests;

    [Header("NPC Quests")]
    [SerializeField] private NPCQuest npcQuestPrefab;
    [SerializeField] private Transform npcQuestContainer;

    [Header("Character Quests")]
    [SerializeField] private CharacterQuest characterQuestPrefab;
    [SerializeField] private Transform characterQuestContainer;



    void Start()
    {
        LoadNPCQuestsInUI();
    }

    private void LoadNPCQuestsInUI()
    {
        for (int i = 0; i < availableQuests.Length; i++)
        {
            var newQuest = Instantiate(npcQuestPrefab, npcQuestContainer);
            newQuest.ConfigureQuestUI(availableQuests[i]);
        }
    }

    private void LoadCharacterQuestsInUI(Quest quest)
    {
        var newQuest = Instantiate(characterQuestPrefab, characterQuestContainer);
        newQuest.ConfigureQuestUI(quest);
    }

    public void AddQuest(Quest questToComplete)
    {
        LoadCharacterQuestsInUI(questToComplete);
    }
}
