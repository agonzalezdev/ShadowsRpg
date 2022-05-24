using System;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string Id;
    public int MaxQuantity;

    [Header("Description")]
    [TextArea] public string Description;

    [Header("Rewards")]
    public int GoldReward;
    public float ExpReward;
    public ItemReward ItemReward;

    [HideInInspector]
    public int ActualQuantity;
    [HideInInspector]
    public bool QuestCompleted;

        
}

[Serializable]
public class ItemReward
{
    public ItemBase Item;
    public int Quantity;
}
