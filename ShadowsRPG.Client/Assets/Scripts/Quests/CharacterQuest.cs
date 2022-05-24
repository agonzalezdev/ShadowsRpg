using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterQuest : QuestBase
{
    [SerializeField] private TextMeshProUGUI progress;
    [SerializeField] private TextMeshProUGUI goldReward;
    [SerializeField] private TextMeshProUGUI expReward;

    [Header("Item")]
    [SerializeField] private Image rewardItemIcon;
    [SerializeField] private TextMeshProUGUI itemRewardQuantity;


    public override void ConfigureQuestUI(Quest questToLoad)
    {
        base.ConfigureQuestUI(questToLoad);
        goldReward.text = questToLoad.GoldReward.ToString();
        expReward.text = questToLoad.ExpReward.ToString();
        progress.text = $"{questToLoad.ActualQuantity}/{questToLoad.MaxQuantity}";

        rewardItemIcon.sprite = questToLoad.ItemReward.Item.Icon;
        itemRewardQuantity.text = questToLoad.ItemReward.Quantity.ToString();
    }
}
