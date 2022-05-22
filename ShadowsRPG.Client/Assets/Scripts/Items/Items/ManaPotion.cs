using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Mana Potion")]
public class ManaPotion : ItemBase
{
    [Header("Potion data")]
    public float ManaRestoreAmount;

    public override bool UseItem()
    {
        if (Inventory.Instance.Character.CharacterMana.CanBeHealed)
        {
            Inventory.Instance.Character.CharacterMana.RestoreMana(ManaRestoreAmount);
            return true;
        }

        return false;
    }
}
