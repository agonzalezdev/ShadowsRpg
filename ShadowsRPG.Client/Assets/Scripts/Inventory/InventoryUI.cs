using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header("Inventory panel description")]
    [SerializeField] private GameObject inventoryPanelDescription;
    [SerializeField] private Image inventoryPanelItemIcon;
    [SerializeField] private TextMeshProUGUI inventoryPanelItemName;
    [SerializeField] private TextMeshProUGUI inventoryPanelItemDescription;


    [SerializeField] private InventorySlot inventarySlotPrefab;
    [SerializeField] private Transform container;

    public int InitialIndexSlotToMove { get; private set; }

    public InventorySlot SelectedSlot { get; private set; }

    List<InventorySlot> availableSlots = new();

    // Start is called before the first frame update
    void Start()
    {
        InitInventory();
        InitialIndexSlotToMove = -1;
    }

    private void Update()
    {
        UpdateSelectedSlot();
        if (Input.GetKeyDown(KeyCode.M) && SelectedSlot != null)
        {
            InitialIndexSlotToMove = SelectedSlot.Index;
        }
    }

    private void InitInventory()
    {
        for (int i = 0; i < Inventory.Instance.SlotNumber; i++)
        {
            var slot = Instantiate(inventarySlotPrefab, container);
            slot.Index = i;
            availableSlots.Add(slot);
        }
    }

    private void UpdateSelectedSlot()
    {
        var gameObjectSelected = EventSystem.current.currentSelectedGameObject;
        if (gameObjectSelected == null) return;

        var slot = gameObjectSelected.GetComponent<InventorySlot>();
        if (slot == null) return;

        SelectedSlot = slot;
    }

    public void DrawItemInInventory(ItemBase item, int quantity, int itemIndex)
    {
        var slot = availableSlots[itemIndex];
        if (item != null)
        {
            slot.EnableSlotUI(true);
            slot.UpdateSlot(item, quantity);
        }
        else
        {
            slot.EnableSlotUI(false);
        }
    }

    private void UpdatePanelDescription(int index)
    {
        var inventoryItem = Inventory.Instance.InventoryItems[index];
        if (inventoryItem == null)
        {
            inventoryPanelDescription.SetActive(false);
            return;
        }

        inventoryPanelItemIcon.sprite = inventoryItem.Icon;
        inventoryPanelItemName.text = inventoryItem.Name;
        inventoryPanelItemDescription.text = inventoryItem.Description;
        inventoryPanelDescription.SetActive(true);
    }

    public void UseItem()
    {
        if (SelectedSlot == null) return;

        SelectedSlot.UseSlotItem();
        SelectedSlot.SelectSlot();
    }

    #region Events
    private void SlotInteractionResponse(InventoryItemAction inventoryItemAction, int index)
    {
        if (inventoryItemAction == InventoryItemAction.Click)
        {
            UpdatePanelDescription(index);
        }
    }


    private void OnEnable()
    {
        InventorySlot.EventSlotTrigger += SlotInteractionResponse;
    }


    private void OnDisable()
    {
        InventorySlot.EventSlotTrigger -= SlotInteractionResponse;
    }
    #endregion






}
