using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCQuest : QuestBase
{
    [SerializeField] private TextMeshProUGUI questReward;

    public override void ConfigureQuestUI(Quest quest)
    {
        base.ConfigureQuestUI(quest);
        LoadedQuest = quest;
        questReward.text = $"-{quest.GoldReward} gold" +
                            $"\n-{quest.ExpReward} exp" +
                            $"\n-{quest.ItemReward.Item.Quantity} x {quest.ItemReward.Item.Name}";
    }

    public void AcceptQuest()
    {
        if (LoadedQuest == null)
            return;

        QuestManager.Instance.AddQuest(LoadedQuest);
        gameObject.SetActive(false);
    }
}
