using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/HP Potion")]
public class HPPotion : ItemBase
{
    [Header("Potion data")]
    public float HPRestoreAmount;

    public override bool UseItem()
    {
        if (Inventory.Instance.Character.CharacterHP.CanBeHealed)
        {
            Inventory.Instance.Character.CharacterHP.HealHP(HPRestoreAmount);
            return true;
        }

        return false;
    }
}
