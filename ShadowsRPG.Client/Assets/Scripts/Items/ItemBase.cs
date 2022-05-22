using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Potions,
    Scrolls,
    Ingredients,
    Treasures
}

public class ItemBase : ScriptableObject
{
    [Header("Params")]
    public string Id;
    public Sprite Icon;
    public string Name;
    [TextArea] public string Description;

    [Header("Info")]
    public ItemType ItemType;
    public bool IsConsumable;
    public bool IsStackable;
    public int MaxStack;

    [HideInInspector] public int Quantity;

    public ItemBase CopyItem() => Instantiate(this);

    public virtual bool UseItem() => true;
    public virtual bool EquipItem() => true;
    public virtual bool RemoveItem() => true;
}
