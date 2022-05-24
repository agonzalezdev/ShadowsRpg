using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestBase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questDescription;

    public Quest LoadedQuest { get; set; }

    public virtual void ConfigureQuestUI(Quest quest)
    {
        questName.text = quest.Name;
        questDescription.text = quest.Description;
    }


}
