using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum InventoryItemAction
{
    Click,
    Use,
    Equip,
    Remove
}

public class InventorySlot : MonoBehaviour
{
    public static Action<InventoryItemAction, int> EventSlotTrigger;

    [SerializeField] private Image itemIcon;
    [SerializeField] private GameObject quantityBackground;
    [SerializeField] private TextMeshProUGUI quantityText;

    public int Index { get; set; }

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void UpdateSlot(ItemBase item, int quantity)
    {
        itemIcon.sprite = item.Icon;
        quantityText.text = quantity.ToString();
    }

    public void EnableSlotUI(bool status)
    {
        itemIcon.gameObject.SetActive(status);
        quantityBackground.SetActive(status);
    }

    public void SelectSlot()
    {
        _button.Select();
    }

    public void ClickSlot()
    {
        EventSlotTrigger?.Invoke(InventoryItemAction.Click, Index);

        if (InventoryUI.Instance.InitialIndexSlotToMove != -1 &&
            InventoryUI.Instance.InitialIndexSlotToMove != Index)
        {
            Inventory.Instance.MoveItem(InventoryUI.Instance.InitialIndexSlotToMove, Index);
        }
    }

    public void UseSlotItem()
    {
        if (Inventory.Instance.InventoryItems[Index] == null) return;

        EventSlotTrigger?.Invoke(InventoryItemAction.Use, Index);
    }
}
