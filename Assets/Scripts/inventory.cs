using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Transform itemsParent;
    public GameObject inventoryUI;
    public Text itemNameText;
    public Text itemDescriptionText;
    public GameObject inventoryPanel;

    public Item selectedItem;

    public InventorySlot[] slots;

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }
   
    public void AddItem(ItemData itemData)
    {
        Item newItem = new Item(itemData);
        items.Add(newItem);

        UpdateUI();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        UpdateUI();
    }

    public void SelectItem(Item item)
    {
        selectedItem = item;
        itemNameText.text = selectedItem.itemData.name;
        itemDescriptionText.text = selectedItem.itemData.description;
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].AddItem(items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}

[System.Serializable]
public class Item
{
    public ItemData itemData;

    public Item(ItemData data)
    {
        itemData = data;
    }
}

[System.Serializable]
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.itemData.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}