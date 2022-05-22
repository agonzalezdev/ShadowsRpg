using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [Header("Items")]
    [SerializeField] private ItemBase[] inventoryItems;
    [SerializeField] private Character character;
    [SerializeField] private int slotNumber;

    public Character Character => character;
    public int SlotNumber => slotNumber;
    public ItemBase[] InventoryItems => inventoryItems;


    private void Start()
    {
        inventoryItems = new ItemBase[slotNumber];
    }

    public void AddItemToInventory(ItemBase itemToAdd, int quantity)
    {
        if (itemToAdd == null || quantity == 0)
            return;

        var indexes = CheckItemsIninventory(itemToAdd.Id);

        if (itemToAdd.IsStackable && indexes.Count > 0)
        {
            for (int i = 0; i < indexes.Count; i++)
            {
                var itemReference = inventoryItems[indexes[i]];

                if (itemReference == null) continue;


                if (itemReference.Quantity < itemToAdd.MaxStack)
                {
                    itemReference.Quantity += quantity;
                    if (itemReference.Quantity > itemToAdd.MaxStack)
                    {
                        int difference = itemReference.Quantity - itemToAdd.MaxStack;
                        itemReference.Quantity = itemToAdd.MaxStack;
                        AddItemToInventory(itemToAdd, difference);

                        InventoryUI.Instance.DrawItemInInventory(
                            itemToAdd,
                            itemReference.Quantity,
                            indexes[i]
                        );
                        return;
                    }

                }
            }
        }

        if (quantity > itemToAdd.MaxStack)
        {
            AddItemInAvailableSlot(itemToAdd, itemToAdd.MaxStack);
            quantity -= itemToAdd.MaxStack;
            AddItemToInventory(itemToAdd, quantity);
        }
        else
        {
            AddItemInAvailableSlot(itemToAdd, quantity);
        }
    }

    private void AddItemInAvailableSlot(ItemBase item, int quantity)
    {
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == null)
            {
                inventoryItems[i] = item.CopyItem();
                inventoryItems[i].Quantity = quantity;
                InventoryUI.Instance.DrawItemInInventory(item, quantity, i);
                return;
            }
        }
    }

    private List<int> CheckItemsIninventory(string itemID)
    {
        List<int> itemIndexes = new List<int>();
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] != null && inventoryItems[i].Id == itemID)
            {
                itemIndexes.Add(i);
            }
        }

        return itemIndexes;
    }

    private void RemoveItem(int index)
    {
        InventoryItems[index].Quantity--;
        if (InventoryItems[index].Quantity <= 0)
        {
            InventoryItems[index].Quantity = 0;
            InventoryItems[index] = null;
            InventoryUI.Instance.DrawItemInInventory(null, 0, index);
        }
        else
        {
            InventoryUI.Instance.DrawItemInInventory(
                InventoryItems[index],
                InventoryItems[index].Quantity,
                index
            );
        }
    }

    public void MoveItem(int initialIndex, int endIndex)
    {
        if (InventoryItems[initialIndex] == null || InventoryItems[endIndex] != null)        
            return;
        

        ItemBase itemToMove = InventoryItems[initialIndex].CopyItem();
        InventoryItems[endIndex] = itemToMove;
        InventoryUI.Instance.DrawItemInInventory(itemToMove, itemToMove.Quantity, endIndex);

        InventoryItems[initialIndex] = null;
        InventoryUI.Instance.DrawItemInInventory(null, 0, initialIndex);
    }

    private void UseItem(int index)
    {
        if (InventoryItems[index] == null) return;

        if (InventoryItems[index].UseItem())    
            RemoveItem(index);        
    }

    #region Events
    private void OnEnable()
    {
        InventorySlot.EventSlotTrigger += SlotTriggerResponse;
    }

    private void OnDisable()
    {
        InventorySlot.EventSlotTrigger -= SlotTriggerResponse;
    }

    private void SlotTriggerResponse(InventoryItemAction inventoryItemAction, int index)
    {
        switch (inventoryItemAction)
        {
            case InventoryItemAction.Use:
                UseItem(index);
                break;
            case InventoryItemAction.Equip:
                break;
            case InventoryItemAction.Remove:
                break;
        }
    }



    #endregion
}
